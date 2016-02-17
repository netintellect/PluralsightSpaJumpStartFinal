using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Telerik.Windows.QuickStart
{
    public class DeployManager
    {
        private readonly bool isWebDeployed;

        private readonly static List<string> downloadedFileGroups = new List<string>();

        public const string ThemesDownloadGroupName = "Themes";

        public DeployManager()
        {
            this.isWebDeployed = ApplicationDeployment.IsNetworkDeployed;
        }

        public void LoadModule(string moduleName, Action readyCallback, Action<int> progressCallback)
        {
            if (!this.isWebDeployed)
            {
                readyCallback();
                return;
            }
            
            Task.Factory.StartNew(() =>
            {
                this.EnsureFileGroupAndDependenciesAreDownloaded(moduleName, progressCallback);
                Application.Current.Dispatcher.BeginInvoke(readyCallback);
            }, TaskCreationOptions.LongRunning);
        }

        private void EnsureFileGroupAndDependenciesAreDownloaded(string groupName, Action<int> progressCallback)
        {
            lock (((System.Collections.ICollection)downloadedFileGroups).SyncRoot)
            {
                if (!downloadedFileGroups.Contains(groupName))
                {
                    downloadedFileGroups.Add(groupName);
                    this.DownloadFileGroupBlocking(groupName, progressCallback);

                    if (groupName != ThemesDownloadGroupName && !AssemblyHelper.IsStringTelerikAssemblyName(groupName))
                    {
                        this.EnsureModuleDependenciesAreDownloaded(groupName, progressCallback);
                    }
                }
            }
        }

        private void EnsureModuleDependenciesAreDownloaded(string moduleName, Action<int> progressCallback)
        {
            IEnumerable<string> assemblyReferencesToDownload = GetTelerikReferencesFromAssembly(moduleName);
            int filesCount = assemblyReferencesToDownload.Count();
            int filesToDownload = filesCount;

            Action<int> calculatedProgressCallback = (originalPercentage) =>
            {
                int calculatedPercentage = (originalPercentage + (filesCount - filesToDownload) * 100) / filesCount;
                progressCallback(calculatedPercentage);
            };

            foreach (var assemblyReference in assemblyReferencesToDownload)
            {
                var groupName = assemblyReference;

                this.EnsureFileGroupAndDependenciesAreDownloaded(groupName, calculatedProgressCallback);
                filesToDownload--;
            }
        }

        private static IEnumerable<string> GetTelerikReferencesFromAssembly(string assemblyName)
        {
            int maxRetries = 3;
            int retry = 0;
            int msecBetweenRetries = 100;
            string modulePath = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName + "\\" + assemblyName + ".exe";
            FileInfo fileInfo = new FileInfo(modulePath);
            while (retry < maxRetries)
            {
                if (fileInfo.Exists)
                {
                    var loadedModule = Assembly.LoadFrom(modulePath);
                    using (var referencesFileStream = AssemblyHelper.GetResourceStreamFromAssembly(loadedModule, "ReferencesList.txt"))
                    {
                        string content = AssemblyHelper.GetStringFromStream(referencesFileStream);
                        IEnumerable<string> references = AssemblyHelper.ParseTelerikReferencesFromContent(content);
                        return references;
                    }
                }
                else
                {
                    Thread.Sleep(msecBetweenRetries);
                    retry++;
                    fileInfo.Refresh();
                }
            }
            throw new Exception(string.Format("Could not load Telerik references for {0}.", assemblyName));
        }

        private void DownloadFileGroupBlocking(string fileGroup, Action<int> progressCallback)
        {
            AutoResetEvent are = new AutoResetEvent(false);

            DownloadFileGroupCompletedEventHandler completedHandler = null;
            DeploymentProgressChangedEventHandler progressChangedHandler = null;
            completedHandler = (s, e) =>
            {
                ApplicationDeployment.CurrentDeployment.DownloadFileGroupCompleted -= completedHandler;
                ApplicationDeployment.CurrentDeployment.DownloadFileGroupProgressChanged -= progressChangedHandler;

                are.Set();
                are.Dispose();
            };

            progressChangedHandler = (object s, DeploymentProgressChangedEventArgs e) =>
            {
                progressCallback(e.ProgressPercentage);
            };
            ApplicationDeployment.CurrentDeployment.DownloadFileGroupCompleted += completedHandler;
            ApplicationDeployment.CurrentDeployment.DownloadFileGroupProgressChanged += progressChangedHandler;
            ApplicationDeployment.CurrentDeployment.DownloadFileGroupAsync(fileGroup);
         
            are.WaitOne();
        }
    }
}