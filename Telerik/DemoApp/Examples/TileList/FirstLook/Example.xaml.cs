using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Threading;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.TileList.FirstLook
{
    public partial class Example : UserControl
    {
        private NASDAQViewModel viewModel;

        public Example()
        {
            InitializeComponent();

            this.viewModel = this.LayoutRoot.Resources["NASDAQViewModel"] as NASDAQViewModel;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        void OnTimerTick(object sender, EventArgs e)
        {
            viewModel.UpdateDisplayValue();
        }
    }
}