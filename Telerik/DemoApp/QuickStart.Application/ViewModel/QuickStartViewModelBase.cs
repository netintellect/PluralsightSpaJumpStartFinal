using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;
using Telerik.Windows.Controls.QuickStart.Analytics;
using Telerik.Windows.Controls.QuickStart.Infrastructure;

namespace Telerik.Windows.QuickStart.ViewModel
{
    public class QuickStartViewModelBase : ViewModelBase
    {
        public QuickStartViewModelBase(INotifyUser ownerView) 
            : this()
        {
            this.OwnerView = ownerView;
        }

        public QuickStartViewModelBase()
        {
            this.NavigateCommand = new DelegateCommand(this.OnNavigateCommandExecuted);
            this.ToggleApplicationTouchModeCommand = new DelegateCommand(this.OnToggleApplicationTouchModeCommandExecuted);
            
            this.HighlightedControlsTitle = this.GetPropertyForElement("HighlightedControls", "title");
            this.NewControlsTitle = this.GetPropertyForElement("NewControls", "title");
            this.AllControlsTitle = this.GetPropertyForElement("AllControls", "title");
            this.SampleAppsTitle = this.GetPropertyForElement("SampleApps", "title");
        }

        public static bool IsQsfInTouchMode { get; protected set; }

        public DelegateCommand ToggleApplicationTouchModeCommand { get; protected set; }

        public string HighlightedControlsTitle { get; private set; }
        public string NewControlsTitle { get; private set; }
        public string AllControlsTitle { get; private set; }
        public string SampleAppsTitle { get; private set; }

        public IQuickStartData Data
        {
            get
            {
                return QuickStartData.Instance;
            }
        }

        public bool IsAnalyticsTrackingEnabled
        {
            get
            {
                return EqatecMonitor.Instance.IsTrackingEnabled;
            }
            set
            {
                EqatecMonitor.Instance.IsTrackingEnabled = value;
				SettingsManager.Instance.IsAnalyticsTrackingEnabled = value;
                this.OnPropertyChanged("IsAnalyticsTrackingEnabled");
            }
        }

        public DelegateCommand NavigateCommand { get; protected set; }

        protected NavigationService NavigationService
        {
            get
            {
                return NavigationService.Instance;
            }
        }

        protected INotifyUser OwnerView { get; set; }

        public void ToggleApplicationTouchMode(bool goToTouchMode)
        {
            QuickStartViewModelBase.IsQsfInTouchMode = goToTouchMode;
        }

        protected void OnNavigateCommandExecuted(object parameter)
        {
            string analyticsFeatureSuffix = IsQsfInTouchMode ? ".Touch" : string.Empty;
            if (parameter is IExampleInfo)
            {
                // EQATEC: report navigation to example
                string analyticsString = EqatecConstants.Navigate + "." + ((IExampleInfo)parameter).Name.Replace("Telerik.Windows.Examples.", "") + analyticsFeatureSuffix;
                EqatecMonitor.Instance.TrackFeature(analyticsString);

                NavigationService.Instance.Navigate(this.GetSingleExampleView(parameter as IExampleInfo), parameter);
            }
            else if (parameter is IControlInfo)
            {
                var control = parameter as IControlInfo;

                // EQATEC: report navigation to control
                string analyticsString = EqatecConstants.Navigate + "." + ((IControlInfo)parameter).Name + analyticsFeatureSuffix;
                EqatecMonitor.Instance.TrackFeature(analyticsString);

                if (control.Name == "DataServiceDataSource" && ApplicationDeployment.IsNetworkDeployed)
                {
                    this.OwnerView.Notify("This example requires ADO.NET Data Services Update for .NET Framework 3.5 SP1. Please make sure you have it and run the examples locally");
                    return;
                }

                List<IExampleInfo> controlExamples = IsQsfInTouchMode ? control.TouchExamples : control.NonTouchExamples;
                if (controlExamples == null || controlExamples.Count == 0)
                {
                    throw new InvalidOperationException("There are no control examples set in Examples.xml.");
                }

                IExampleInfo defaultExample = controlExamples.FirstOrDefault(e => e.IsDefault) ?? controlExamples.FirstOrDefault();

                if (IsQsfInTouchMode)
                {
                    if (controlExamples.Count == 1)
                    {
                        this.NavigationService.Navigate(this.GetSingleExampleView(defaultExample), defaultExample);
                    }
                    else
                    {
                        this.NavigationService.Navigate(ApplicationView.SingleControlExamplesTouch, control);
                    }
                }
                else
                {
                    this.NavigationService.Navigate(this.GetSingleExampleView(defaultExample), defaultExample);
                }
            }
            else if (Uri.IsWellFormedUriString((string)parameter, UriKind.Absolute))
            {
                // EQATEC: report navigation to URL
                string analyticsString = EqatecConstants.Navigate + "." + parameter.ToString();
                EqatecMonitor.Instance.TrackFeature(analyticsString);

                string navigateUri = (string)parameter;
                Process.Start(new ProcessStartInfo(navigateUri));
            }
            else if (parameter is string)
            {
                // EQATEC: report navigation to URL
                string analyticsString = EqatecConstants.Navigate + "." + parameter.ToString();
                EqatecMonitor.Instance.TrackFeature(analyticsString);

                ApplicationView view = this.GetApplicationView(parameter.ToString());
                NavigationService.Instance.Navigate(view, parameter);
            }
        }

        private void OnToggleApplicationTouchModeCommandExecuted(object parameter)
        {
            this.ToggleApplicationTouchMode(!IsQsfInTouchMode);

            string nextMode = IsQsfInTouchMode ? "Touch" : "Desktop";
            // if parameter is null go to all controls
            parameter = parameter ?? "AllControls" + (IsQsfInTouchMode ? "Touch" : string.Empty);
            string analyticsString = string.Format("{0}.{1}.{2}", EqatecConstants.SwitchMode, nextMode, parameter.ToString().Replace("Telerik.Windows.Examples.", ""));
            EqatecMonitor.Instance.TrackFeature(analyticsString);

            this.NavigateCommand.Execute(parameter);
        }

        private ApplicationView GetSingleExampleView(IExampleInfo example)
        {
            if (example == null || ModelExtensions.IsTouchAndDesktopExample(example))
            {
                return IsQsfInTouchMode ? ApplicationView.SingleExampleTouch : ApplicationView.SingleExample;
            }

            if (ModelExtensions.IsDesktopExample(example))
            {
                return ApplicationView.SingleExample;
            }
            else
            {
                return ApplicationView.SingleExampleTouch;
            }
        }

        private ApplicationView GetApplicationView(string parameter)
        {
            if (IsQsfInTouchMode)
            {
                ApplicationView view;
                if (Enum.TryParse<ApplicationView>(parameter + "Touch", out view))
                {
                    return view;
                }
            }

            return (ApplicationView)Enum.Parse(typeof(ApplicationView), parameter);
        }

        private string GetPropertyForElement(string elementName, string propertyName)
        {
            var element = QuickStartData.Instance.Element.Element(elementName);
            return element.GetAttribute(propertyName, string.Empty);
        }
    }
}