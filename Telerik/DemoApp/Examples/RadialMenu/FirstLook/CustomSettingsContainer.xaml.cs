using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Imaging.Tools;
using Telerik.Windows.Media.Imaging.Tools;

namespace Telerik.Windows.Examples.RadialMenu.FirstLook
{
    /// <summary>
    /// Interaction logic for CustomSettingsContainer.xaml
    /// </summary>
    public partial class CustomSettingsContainer : IToolSettingsContainer
    {
        public CustomSettingsContainer()
        {
            InitializeComponent();
            this.IsTopmost = true;
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            if (newContent == null)
            {
                this.Close();
            }
        }

        public void Show(ITool tool, Action applyCallback, Action cancelCallback)
        {
            this.Content = tool.GetSettingsUI();
            this.Header = tool.ToString().Split('.').Last();

            if (!this.IsOpen && this.Content != null)
            {
              this.Show();
            }
        }

        public void Hide()
        {
        }
    }
}
