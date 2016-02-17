using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.CoverFlow.DataInfo
{
    public partial class DetailsPopup : UserControl
    {
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(DetailsPopup), new PropertyMetadata(OnIsSelectedChanged));

        private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if ((bool)args.NewValue)
            {
                (d as DetailsPopup).ShowInfoPanel();
            }
            else
            {
                (d as DetailsPopup).HideInfoPanel();
            }
        }

        public DetailsPopup()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(DetailsPopupLoaded);
            this.HideInfoPanel();
        }

        private void DetailsPopupLoaded(object sender, RoutedEventArgs e)
        {
            RadCoverFlowItem item = this.ParentOfType<RadCoverFlowItem>();

            this.SetBinding(IsSelectedProperty, new System.Windows.Data.Binding("IsSelected") { Source = item });
        }

        public void ShowInfoPanel()
        {
            (this.Resources["ShowAnimation"] as Storyboard).Begin();
        }

        public void HideInfoPanel()
        {
            (this.Resources["HideAnimation"] as Storyboard).Begin();
        }

        private void OnContentClicked(object sender, RoutedEventArgs e)
        {
			InfoWindowContent infoWindowContent = new InfoWindowContent();
			infoWindowContent.DataContext = this.DataContext;
			RadWindow window = new RadWindow();
			window.Content = infoWindowContent;
			window.Header = "Image details..." ;
			window.ResizeMode = ResizeMode.NoResize;
			window.WindowStartupLocation=Controls.WindowStartupLocation.CenterScreen;
			window.ShowDialog();
        }


    }
}
