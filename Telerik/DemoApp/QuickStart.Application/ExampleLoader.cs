using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;
using Telerik.Windows.QuickStart.ViewModel;

namespace Telerik.Windows.QuickStart
{
    public class ExampleLoader : INotifyPropertyChanged
    {
        private static ExampleLoader instance;

        private DeployManager deployManager;
        private IQuickStartData data;
        private IExampleInfo currentExample;
        private IExampleInfo exampleToNavigate;
        private XmlDocument currentControlFilesListDocument;
        private int exampleProgress;
        private bool isInitialized;
        private string currentTheme;

        private ExampleLoader()
        {
            // intentionally empty
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<ExampleInstantiatedEventArgs> ExampleInstantiated;

        public static ExampleLoader Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new ExampleLoader();
                }

                return instance;
            }
        }

        public IExampleInfo CurrentExample
        {
            get
            {
                return this.currentExample;
            }
            set
            {
                if (this.currentExample != value)
                {
                    this.currentExample = value;
                    this.OnPropertyChanged("CurrentExample");
                }
            }
        }

        public int ExampleProgress
        {
            get
            {
                return this.exampleProgress;
            }

            set
            {
                if (this.exampleProgress != value)
                {
                    this.exampleProgress = value;
                    this.OnPropertyChanged("ExampleProgress");
                }
            }
        }

        public string CurrentTheme
        {
            get
            {
                return this.currentTheme;
            }
            set
            {
                this.currentTheme = value;
                this.OnPropertyChanged("CurrentTheme");
            }
        }

        public void Initialize(IQuickStartData data, DeployManager deployManager)
        {
            if (this.isInitialized)
            {
                return;
            }
            this.data = data;
            this.deployManager = deployManager;
            this.isInitialized = true;
        }

        public void LoadExample(IExampleInfo exampleInfo, string themeName)
        {
            var newExample = exampleInfo;
            this.exampleToNavigate = newExample;
            this.CurrentExample = this.exampleToNavigate;
            var moduleName = string.IsNullOrEmpty(this.exampleToNavigate.PackageName)
                             ? this.exampleToNavigate.ExampleGroup.Control.Name
                             : this.exampleToNavigate.PackageName;

            this.ExampleProgress = 0;

            if (newExample.Type == Enums.ExampleType.Theming)
            {
                this.deployManager.LoadModule(DeployManager.ThemesDownloadGroupName, () =>
                {
                    this.LoadNormalExample(moduleName, themeName);
                }, p =>
                {
                    this.ExampleProgress = p;
                });
            }
            else
            {
                this.LoadNormalExample(moduleName, themeName);
            }
        }

        private static Assembly GetAssemblyByName(string moduleName)
        {
            return AppDomain.CurrentDomain
                            .GetAssemblies()
                            .Where(a => a.GetName().Name == moduleName)
                            .FirstOrDefault();
        }

        private void LoadNormalExample(string assemblyName, string theme)
        {
            int initialExampleProgressPercentage = 0;
            this.deployManager.LoadModule(assemblyName, () =>
            {
                this.CurrentTheme = theme;

                //if this callback is for the currently requested control
                if (assemblyName == this.exampleToNavigate.ExampleGroup.Control.Name || assemblyName == this.exampleToNavigate.PackageName)
                {
                    this.ExampleProgress = 100;
                    FileInfo fi = new FileInfo(Assembly.GetExecutingAssembly().Location);
                    var assembly = Assembly.LoadFile(fi.DirectoryName + "\\" + assemblyName + ".exe");
                    using (var resourceFileStream = AssemblyHelper.GetResourceStreamFromAssembly(assembly, "FilesList.xml"))
                    {
                        this.PopulateFilesListDocument(resourceFileStream);
                    }

                    this.UpdateExampleResources(this.exampleToNavigate, assembly);
                    this.UpdateExampleDescription(this.exampleToNavigate);
                    this.InstantiateExampleContent(this.exampleToNavigate);
                }
            },
                p => this.ExampleProgress = initialExampleProgressPercentage + (100 - initialExampleProgressPercentage) * p / 100);
        }

        private void PopulateFilesListDocument(Stream resourceFileStream)
        {
            this.currentControlFilesListDocument = new XmlDocument();
            if (resourceFileStream != null)
            {
                using (StreamReader streamReader = new StreamReader(resourceFileStream))
                {
                    this.currentControlFilesListDocument.LoadXml(streamReader.ReadToEnd());
                }
            }
        }

        private void InstantiateExampleContent(IExampleInfo example)
        {
            var assemblyName = string.IsNullOrEmpty(this.exampleToNavigate.PackageName)
                               ? this.exampleToNavigate.ExampleGroup.Control.Name
                               : this.exampleToNavigate.PackageName;

            var assembly = GetAssemblyByName(assemblyName);
            object exampleInstance = assembly.CreateInstance(example.Name);
            this.RaiseExampleInstantiatedEvent(exampleInstance);
            this.CurrentExample = example;
        }

        private void UpdateExampleResources(IExampleInfo currentExample, Assembly assembly)
        {
            if (currentExample.Resources.Count == 0)
            {
                foreach (XmlNode item in this.currentControlFilesListDocument.GetElementsByTagName("RelativePath"))
                {
                    var containsFolderOrFile = currentExample.CommonFolders.Contains(item.Attributes["Key"].InnerText) ||
                                               currentExample.CommonFolders.Contains(item.InnerText);
                    if (containsFolderOrFile && !item.InnerText.EndsWith(".txt"))
                    {
                        var control =
                                     string.IsNullOrEmpty(currentExample.PackageName) ? currentExample.ExampleGroup.Control :
                                      this.data.Controls.Where(c => c.Name == currentExample.PackageName).First();

                        var exampleFile = new ExampleFile(control, item.InnerText);

                        // add resource only if it exists, i.e. it can be retrieved from assembly resources
                        if (ResourceToStreamHelper.ResourceExists(assembly, exampleFile.AssemblyResourcePath)
                            || (exampleFile.AssemblyResourcePath.IsXaml()
                                && ResourceToStreamHelper.ResourceExists(assembly, exampleFile.AssemblyResourcePath.Replace(".xaml", ".baml")))
                            )
                        {
                            currentExample.Resources.Add(exampleFile);
                        }
                    }
                }
            }
        }

        private void UpdateExampleDescription(IExampleInfo example)
        {
            foreach (var commonFolder in example.CommonFolders.Where(f => f.Trim() != string.Empty))
            {
                var controlName = string.IsNullOrEmpty(example.PackageName) ? example.ExampleGroup.Control.Name : this.exampleToNavigate.PackageName;
                var resourcePath = string.Format("{0}/Description.txt", commonFolder.Substring(controlName.Length + 1)).ToLower();
                var assemblyName = string.IsNullOrEmpty(this.exampleToNavigate.PackageName)
                                   ? this.exampleToNavigate.ExampleGroup.Control.Name
                                   : this.exampleToNavigate.PackageName;

                if (ResourceToStreamHelper.ResourceExists(GetAssemblyByName(assemblyName), resourcePath))
                {
                    var uriSource = new Uri(
                        string.Format("pack://application:,,,/{0};component/{1}",
                            controlName,
                            resourcePath,
                            UriKind.RelativeOrAbsolute));
                    example.Description = ResourceToStreamHelper.ExtractSourceCodeFromSource(uriSource);
                }
            }
        }

        private void RaiseExampleInstantiatedEvent(object exampleInstance)
        {
            if (this.ExampleInstantiated != null)
            {
                this.ExampleInstantiated(this, new ExampleInstantiatedEventArgs(exampleInstance));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler onPropertyChanged = this.PropertyChanged;
            if (onPropertyChanged != null)
            {
                onPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}