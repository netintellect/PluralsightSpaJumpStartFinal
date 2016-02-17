using Telerik.Windows.Automation.Peers;
using Telerik.Windows.Controls.QuickStart.Analytics;
using Telerik.Windows.Controls.QuickStart.Infrastructure;

namespace Telerik.Windows.QuickStart
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : System.Windows.Window
    {
        public Shell()
        {
            var viewModel = new ShellViewModel();
            viewModel.ViewModelInitialized += this.OnViewModelInitialized;
            viewModel.Initialize();
            this.DataContext = viewModel;
        }

        private void OnViewModelInitialized(object sender, System.EventArgs e)
        {
            (sender as ShellViewModel).ViewModelInitialized -= this.OnViewModelInitialized;

            // EQATEC: Stop timing of application start-up
            EqatecMonitor.Instance.TrackFeatureStop(EqatecConstants.ApplicationStartupTime);

            AutomationManager.AutomationMode = AutomationMode.Basic;
            InitializeComponent();

            var appModule = new ApplicationModule();
            appModule.Initialize();

            NavigationService.Instance.Frame = this.ApplicationContentPlaceholder;
            NavigationService.Instance.Navigate(ApplicationView.Home);
        }
    }
}
