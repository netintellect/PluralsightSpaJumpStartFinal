using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace RibbonWindowExample
{
    public partial class Installer : UserControl
    {
        public Installer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.InstallState == InstallState.Installed)
            {
                MessageBox.Show("Example is already installed.\nRemove it in order to install it again.");
            }
            else
            {
                Application.Current.Install();
            }
        }
    }
}
