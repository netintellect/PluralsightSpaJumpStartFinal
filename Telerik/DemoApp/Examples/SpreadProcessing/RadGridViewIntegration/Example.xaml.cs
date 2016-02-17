using System;
using System.Linq;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.SpreadProcessing.RadGridViewIntegration
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            ExampleViewModel viewModel = new ExampleViewModel();
            viewModel.GridView = this.RadGridView;

            this.DataContext = viewModel;
            this.configurationPanel.DataContext = viewModel;
        }
    }
}