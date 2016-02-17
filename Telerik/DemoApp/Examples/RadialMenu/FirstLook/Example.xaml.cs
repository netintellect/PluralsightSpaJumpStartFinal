using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.RadialMenu.FirstLook
{
    public partial class Example : UserControl
    {
        CustomSettingsContainer settingsContainer;
        public Example()
        {
            InitializeComponent();
            this.settingsContainer = new CustomSettingsContainer() { Owner = this, Top = 540, Left = 123 };
            this.Loaded += OnExampleLoaded;
            this.Unloaded += OnExampleUnloaded;
        }

        void OnExampleLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window != null)
            {
                window.Deactivated += this.OnMainWindowDeactivated;
            }
            RadRadialMenu.EnableQuickMode = true;
            ImageExampleHelper.LoadSampleImage(this.editor1, "Image1.png");
            this.editor1.ToolSettingsContainer = this.settingsContainer;
            ImageExampleHelper.LoadSampleImage(this.editor2, "Image2.png");
            this.editor2.ToolSettingsContainer = this.settingsContainer;
            ImageExampleHelper.LoadSampleImage(this.editor3, "Image3.png");
            this.editor3.ToolSettingsContainer = this.settingsContainer;
            ImageExampleHelper.LoadSampleImage(this.editor4, "Image4.png");
            this.editor4.ToolSettingsContainer = this.settingsContainer;
            ImageExampleHelper.LoadSampleImage(this.editor5, "Image5.png");
            this.editor5.ToolSettingsContainer = this.settingsContainer;
            CommandManager.InvalidateRequerySuggested();
        }

        private void OnMainWindowDeactivated(object sender, EventArgs e)
        {
            RadialMenuCommands.Hide.Execute(null, this.editor1);
            RadialMenuCommands.Hide.Execute(null, this.editor2);
            RadialMenuCommands.Hide.Execute(null, this.editor3);
            RadialMenuCommands.Hide.Execute(null, this.editor4);
        }

        private void OnExampleUnloaded(object sender, RoutedEventArgs e)
        {
            RadRadialMenu.EnableQuickMode = false;
            var window = Window.GetWindow(this);
            if (window != null)
            {
                window.Deactivated -= this.OnMainWindowDeactivated;
            }
            RadWindowManager.Current.CloseAllWindows();
        }
    }
}