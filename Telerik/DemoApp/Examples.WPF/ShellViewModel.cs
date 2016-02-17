using System;
using System.ComponentModel;
using System.Deployment.Application;
using System.Linq;
using System.Windows;

namespace Telerik.Windows.QuickStart
{
    public class ShellViewModel : INotifyPropertyChanged
    {
        private int applicationProgress;

        public event EventHandler ViewModelInitialized;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ApplicationProgress
        {
            get
            {
                return this.applicationProgress;
            }

            set
            {
                if (this.applicationProgress != value)
                {
                    this.applicationProgress = value;
                    this.OnPropertyChanged("ApplicationProgress");
                }
            }
        }

        public void Initialize()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment.CurrentDeployment.DownloadFileGroupCompleted += new DownloadFileGroupCompletedEventHandler(CurrentDeployment_DownloadFileGroupCompleted);
                ApplicationDeployment.CurrentDeployment.DownloadFileGroupProgressChanged += new DeploymentProgressChangedEventHandler(CurrentDeployment_DownloadFileGroupProgressChanged);
                ApplicationDeployment.CurrentDeployment.DownloadFileGroupAsync("Application");
            }
            else
            {
                this.OnApplicationModuleDownloaded();
            }
        }

        private void CurrentDeployment_DownloadFileGroupProgressChanged(object sender, DeploymentProgressChangedEventArgs e)
        {
            this.ApplicationProgress = e.ProgressPercentage;
        }

        private void CurrentDeployment_DownloadFileGroupCompleted(object sender, DownloadFileGroupCompletedEventArgs e)
        {
            this.OnApplicationModuleDownloaded();
            ApplicationDeployment.CurrentDeployment.DownloadFileGroupCompleted -= CurrentDeployment_DownloadFileGroupCompleted;
            ApplicationDeployment.CurrentDeployment.DownloadFileGroupProgressChanged -= CurrentDeployment_DownloadFileGroupProgressChanged;
        }

        private void OnApplicationModuleDownloaded()
        {
            this.ApplicationProgress = 100;

            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                ApplicationOptions.DefaultCodeViewerLanguage = App.DefaultCodeViewerLanguageString.Equals("c#") ? CodeViewerLanguages.CSharp : CodeViewerLanguages.VB;
            }));

            this.ViewModelInitialized(this, new EventArgs());
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}