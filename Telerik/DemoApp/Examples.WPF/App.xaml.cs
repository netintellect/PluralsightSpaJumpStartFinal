using System;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Telerik.Windows.Controls.QuickStart;
using Telerik.Windows.Controls.QuickStart.Analytics;

namespace Telerik.Windows.QuickStart
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private const string LogFilename = "wpfqsf.log";

        public static string DefaultCodeViewerLanguageString { get; private set; }

        static App()
        {
            App.DefaultCodeViewerLanguageString = "c#";
        }

        public App()
        {
            this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
            this.InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
			EqatecMonitor.Instance.IsTrackingEnabled = SettingsManager.Instance.IsAnalyticsTrackingEnabled;
            // EQATEC: Start timing of application start-up and uptime
            EqatecMonitor.Instance.TrackFeatureStart(EqatecConstants.ApplicationStartupTime);
            EqatecMonitor.Instance.TrackFeatureStart(EqatecConstants.ApplicationUptime);

            System.IO.File.AppendAllText(LogFilename, string.Format("Starting WPF QSF at {0}.{1}{2}", DateTime.Now, DateTime.Now.Millisecond, Environment.NewLine));

            if (e.Args.Count() > 0)
            {
                string argument = e.Args.FirstOrDefault(a => a.Contains("language"));
                if (argument != null)
                {
                    string option = argument.Substring(1); // will return "language:c#"
                    string optionValue = string.Empty;

                    int optoinSeparatorIndex = option.IndexOf(':');
                    if (optoinSeparatorIndex > 0)
                    {
                        optionValue = option.Substring(optoinSeparatorIndex + 1);

                        App.DefaultCodeViewerLanguageString = optionValue.ToLower();
                    }
                }
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // EQATEC: stop application uptime counter
            EqatecMonitor.Instance.TrackFeatureStop(EqatecConstants.ApplicationUptime);
            EqatecMonitor.Instance.Stop();
            base.OnExit(e);
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            /* More detailed error message display */
            string exception = string.Empty;
            Exception ex = e.Exception;
            while (ex != null)
            {
                exception += String.Format("----------------\n{0}\n", ex.Message);
                exception += String.Format("{0}\n", ex.StackTrace);
                ex = ex.InnerException;
            }

            string logExceptionHeader = string.Format("Exception at {0}.{1} :", DateTime.Now, DateTime.Now.Millisecond);
            string logExceptionFooter = "End of exception.";
            string logText = string.Join(Environment.NewLine, logExceptionHeader, exception, logExceptionFooter, Environment.NewLine);
            System.IO.File.AppendAllText(LogFilename, logText);

            // EQATEC: cancel application startup timing if ongoing, report app crash and exception
            EqatecMonitor.Instance.TrackFeatureCancel(EqatecConstants.ApplicationStartupTime);
            EqatecMonitor.Instance.TrackFeatureCancel(EqatecConstants.ApplicationUptime);
            EqatecMonitor.Instance.TrackFeature(EqatecConstants.ApplicationCrash);
            EqatecMonitor.Instance.TrackException(e.Exception, logText);

            MessageBox.Show(e.Exception.Message, "Error");
            e.Handled = true;
        }
    }
}