using System;
using System.Globalization;
using System.Linq;
#if SILVERLIGHT
using System.Net;
#endif
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;
using Telerik.Windows.Controls.GridView;
using Telerik.Charting;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;


namespace Telerik.Windows.Examples.Map.SalesDashboard
{
    public partial class Example : UserControl
    {
        private const int DefaultZoomLevel = 10;
        private string VEKey;

        private Store lastHighlightedStore;
        private Area lastHighlightedArea;
        private FrameworkElement clickedElement;
        private ExampleViewModel context;

        public Example()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Map;component/SalesDashboard/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Map;component/SalesDashboard/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
            this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Map;component/SalesDashboard/GridViewStyles.xaml", UriKind.RelativeOrAbsolute) });

            InitializeComponent();

            context = this.DataContext as ExampleViewModel;

#if SILVERLIGHT
            this.GetVEServiceKey();
#else
            SetProvider();
#endif
        }

        // Initialize Virtual Earth map provider.
        private void SetProvider()
        {
#if SILVERLIGHT
            BingMapProvider provider = new BingMapProvider(MapMode.Road, true, this.VEKey);
#else 
            BingMapProvider provider = new BingMapProvider(MapMode.Road, true, BingMapHelper.VEKey);
            provider.IsTileCachingEnabled = true;
#endif
            this.radMap.Provider = provider;
        }

#if SILVERLIGHT
        private void GetVEServiceKey()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            Uri keyURI = new Uri(URIHelper.CurrentApplicationURL, "VEKey.txt");
            wc.DownloadStringAsync(keyURI);
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.VEKey = e.Result;
            this.SetProvider();
        }
#endif

        private void SetDefaultZoomAndCenter()
        {
            // set center
            this.radMap.Center = new Telerik.Windows.Controls.Map.Location(33.7861647934865, -84.371616833534);

            // set zoom
            this.radMap.ZoomLevel = DefaultZoomLevel;
        }

        private void ChartSelectionBehavior_SelectionChanged(object sender, ChartSelectionChangedEventArgs e)
        {
            if (e.AddedPoints.Count > 0)
            {
                this.SelectItem(e.AddedPoints[0].DataItem);
            }
        }

        private void gridView_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                this.SelectItem(e.AddedItems[0]);
            }
        }

        private void SelectItem(object item)
        {
            Area area = item as Area;
            if (area != null)
            {
                this.radMap.Center = area.Center;
                this.SetAreaHighlightStyle(area);
            }
            else
            {
                Store store = item as Store;
                if (store != null)
                {
                    this.radMap.Center = store.Center;
                    this.SetStoreHighlightStyle(store);
                }
            }
        }

        private void SetStoreDefaultStyle(Store element)
        {
            this.lastHighlightedStore = null;
            this.gridView.SelectedItem = null;
        }

        private void SetStoreHighlightStyle(Store element)
        {
            if (element.Equals(this.lastHighlightedStore))
            {
                return;
            }

            if (this.lastHighlightedStore != null)
            {
                this.SetStoreDefaultStyle(lastHighlightedStore);
            }

            this.lastHighlightedStore = element;
        }

        private void elementMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (element != null)
            {
                this.clickedElement = element;
            }
        }

        private object GetSenderDataPoint()
        {
            if (this.clickedElement != null)
            {
                FrameworkElement element = this.clickedElement;
                this.clickedElement = null;

                return element.DataContext;
            }
            return null;
        }

        private void radMap_MapMouseClick(object sender, MapMouseRoutedEventArgs eventArgs)
        {
            object senderDataPoint = GetSenderDataPoint();
            if (senderDataPoint != null)
            {
                Area area = this.GetDataPointArea(senderDataPoint);
                if (senderDataPoint is Store)
                {
                    Store store = (Store)senderDataPoint;

                    if (!store.Equals(this.lastHighlightedStore))
                    {
                        this.SelectArea(store.Area);
                        this.SetStoreHighlightStyle(store);
                    }
                    else
                    {
                        this.SetStoreDefaultStyle(store);
                    }
                }
                else
                {
                    this.SelectArea(area);
                }
            }
        }

        private Area GetDataPointArea(object senderDataPoint)
        {
            if (senderDataPoint is Store)
            {
                return ((Store)senderDataPoint).Area;
            }
            else
            {
                return (Area)senderDataPoint;
            }
        }

        private void SetAreaDefaultStyle(Area element)
        {
            element.StrokeThickness = 0;
            this.lastHighlightedArea = null;
        }

        private void SetAreaHighlightStyle(Area element)
        {
            if (element == this.lastHighlightedArea)
            {
                return;
            }

            if (this.lastHighlightedArea != null)
            {
                this.SetAreaDefaultStyle(lastHighlightedArea);
            }

            this.lastHighlightedArea = element;
            element.StrokeThickness = 3;
            element.Stroke = new SolidColorBrush(Color.FromArgb(0xFF, 0x76, 0x76, 0x76));
        }

        private void SelectArea(Area area)
        {
            if (area == lastHighlightedArea)
            {
                this.context.Selection.SelectedArea = null;
                this.ExpandRow("");
                this.SetAreaDefaultStyle(area);
                this.viewAllButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.context.Selection.SelectedArea = area;
                this.ExpandRow(area.Name);
                this.SetAreaHighlightStyle(area);
                this.viewAllButton.Visibility = Visibility.Visible;
            }
        }

        private void ExpandRow(string name)
        {
            var gridRows = gridView.ChildrenOfType<GridViewGroupRow>();
            foreach (GridViewGroupRow row in gridRows)
            {
                row.IsExpanded = false;
                if (row.Group.Key.ToString() == name)
                {
                    row.IsExpanded = true;
                    row.Focus();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.context.Selection.SelectedArea = null;
            this.viewAllButton.Visibility = Visibility.Collapsed;
            SelectArea(lastHighlightedArea);
        }

        private void gridView_DataLoaded(object sender, EventArgs e)
        {
            var grid = (RadGridView)sender;
            if (grid.Items.Groups.Count > 0)
            {
                var firstGroup = grid.Items.Groups[0] as Telerik.Windows.Data.IGroup;
                if (firstGroup != null)
                {
                    grid.ExpandGroup(firstGroup);
                }
            }
        }
    }
}
