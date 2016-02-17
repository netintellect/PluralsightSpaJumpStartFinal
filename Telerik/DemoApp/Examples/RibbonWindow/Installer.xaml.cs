using System;
using System.Windows;
using System.Windows.Controls;

namespace RibbonWindowExample
{
    public partial class Installer : UserControl
    {
        public Installer()
        {
            InitializeComponent();

            Loaded += Installer_Loaded;
            App.Current.InstallStateChanged += Current_InstallStateChanged;
        }

        private void Current_InstallStateChanged(object sender, EventArgs e)
        {
            this.UpdateStates();
        }

        private void Installer_Loaded(object sender, RoutedEventArgs e)
        {
            this.UpdateStates();
        }

        private void UpdateStates()
        {
            if (App.Current.InstallState == InstallState.Installed)
            {
                VisualStateManager.GoToState(this, "Installed", false);
            }
            else
            {
                VisualStateManager.GoToState(this, "NotInstalled", false);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Install();
        }
    }
}
