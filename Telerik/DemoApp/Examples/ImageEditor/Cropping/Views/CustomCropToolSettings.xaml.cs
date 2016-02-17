using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Imaging.Tools;
using Telerik.Windows.Media.Imaging.Tools;

namespace Telerik.Windows.Examples.ImageEditor.Cropping.Views
{
    public partial class CustomCropToolSettings : UserControl, IToolSettingsContainer
    {
        public CustomCropToolSettings()
        {
            InitializeComponent();
        }

        public void Hide()
        {
        }

        public void Show(ITool tool, Action applyCallback, Action cancelCallback)
        {
        }

        private void SetInitialSize(Size size)
        {
            ExampleViewModel viewModel = this.DataContext as ExampleViewModel;
            if (viewModel == null)
            {
                return;
            }

            viewModel.InitialSize = size;
        }

        private void SmallButton_Click(object sender, RoutedEventArgs e)
        {
            this.SetInitialSize(new Size(100, 100));
        }

        private void MediumButton_Click(object sender, RoutedEventArgs e)
        {
            this.SetInitialSize(new Size(150, 150));
        }

        private void LargeButton_Click(object sender, RoutedEventArgs e)
        {
            this.SetInitialSize(new Size(200, 200));
        }
    }
}