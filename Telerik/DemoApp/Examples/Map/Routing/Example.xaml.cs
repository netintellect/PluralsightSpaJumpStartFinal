using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;
#if SILVERLIGHT
using System.Windows.Browser;
using ItemsControl = Telerik.Windows.Controls.ItemsControl;
using SelectionChangedEventArgs = Telerik.Windows.Controls.SelectionChangedEventArgs;
using Telerik.Windows.Examples.Map;
#endif

namespace Telerik.Windows.Examples.Map.Routing
{
	public partial class Example : UserControl
	{
#if SILVERLIGHT
		private string VEKey;
#endif
		private BingRouteProvider routeProvider;
		private LocationCollection routePoints = new LocationCollection();
        private ObservableCollection<AnimatedMapItem> animatedItems = new ObservableCollection<AnimatedMapItem>();
        private IEnumerator<Action<Action>> animationActions;
        private Storyboard storyboard = null;
        private bool animationStopped = false;
        private PolylineData routeLine;

		public Example()
		{
			InitializeComponent();

            Binding binding = new Binding();
            binding.Source = this.routePoints;
            this.wayPointsLayer.SetBinding(VisualizationLayer.ItemsSourceProperty, binding);
			this.listBox.SetBinding(ItemsControl.ItemsSourceProperty, binding);
            this.animationLayer.ItemsSource = this.animatedItems;

#if SILVERLIGHT
			this.GetVEServiceKey();
#else
            this.SetProvider();
#endif
        }

		private void ExampleLoaded(object sender, RoutedEventArgs e)
		{
			lineColorCombo.SelectedItem = "Red";
		}

		// Initialize Virtual Earth map provider.
		private void SetProvider()
		{
#if SILVERLIGHT
			BingMapProvider provider = new BingMapProvider(MapMode.Aerial, true, this.VEKey);
#else
            BingMapProvider provider = new BingMapProvider(MapMode.Aerial, true, BingMapHelper.VEKey);
			provider.IsTileCachingEnabled = true;
#endif
            this.RadMap1.Provider = provider;

			// Init route provider.
            routeProvider = new BingRouteProvider();
#if SILVERLIGHT
            routeProvider.ApplicationId = this.VEKey;
#else
            routeProvider.ApplicationId = BingMapHelper.VEKey;
#endif
            routeProvider.MapControl = this.RadMap1;
			routeProvider.RoutingCompleted += new EventHandler<RoutingCompletedEventArgs>(Provider_RoutingCompleted);
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

		private void MapMouseClick(object sender, MapMouseRoutedEventArgs eventArgs)
		{
			this.routePoints.Add(eventArgs.Location);
		}

        private void FindRouteClicked(object sender, RoutedEventArgs e)
		{
            this.routeLayer.Items.Clear();
            this.ErrorSummary.Visibility = Visibility.Collapsed;

            RouteRequest routeRequest = new RouteRequest();
            routeRequest.Culture = new System.Globalization.CultureInfo("en-US");
			routeRequest.Options.RoutePathType = RoutePathType.Points;

			if (this.routePoints.Count > 1)
			{
				this.findRouteButton.IsEnabled = false;

				foreach (Location location in this.routePoints)
				{
					routeRequest.Waypoints.Add(location);
				}
				this.routeProvider.CalculateRouteAsync(routeRequest);
			}
		}

		private void Provider_RoutingCompleted(object sender, RoutingCompletedEventArgs e)
		{
			this.findRouteButton.IsEnabled = true;

            RouteResponse routeResponse = e.Response as RouteResponse;
            if (routeResponse != null && routeResponse.Error == null &&
                routeResponse.Result != null && routeResponse.Result.RoutePath != null)
            {
                this.routeLine = new PolylineData()
                {
                    Points = routeResponse.Result.RoutePath.Points,
                    ShapeFill = new MapShapeFill()
                    {
                        Stroke = this.GetBrushFromCombo(),
                        StrokeThickness = 2
                    }
                };

                this.routeLayer.Items.Add(this.routeLine);
            }
            else
            {
                this.ErrorSummary.Visibility = Visibility.Visible;
            }
		}

		private void ClearRouteClicked(object sender, RoutedEventArgs e)
		{
			this.findRouteButton.IsEnabled = true;

			this.routePoints.Clear();
            this.routeLayer.Items.Clear();
            this.ErrorSummary.Visibility = Visibility.Collapsed;

            this.animatedItems.Clear();
		}

		private SolidColorBrush GetBrushFromCombo()
		{
			ColorStringConverter converter = new ColorStringConverter();
			SolidColorBrush brush = converter.ConvertBack(this.lineColorCombo.SelectedItem,
				typeof(SolidColorBrush),
				null,
				System.Globalization.CultureInfo.CurrentUICulture) as SolidColorBrush;

			return brush;
		}

		private void LineColorChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.routeLine != null)
			{
                this.routeLine.ShapeFill.Stroke = this.GetBrushFromCombo();
			}
		}

        private void AnimateRouteButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.routeLayer.Items.Count > 0)
            {
                PolylineData routeLine = this.routeLayer.Items[0] as PolylineData;
                if (routeLine != null && routeLine.Points.Count > 1)
                {
                    this.SetIsEnabled(false);
                    this.animatedItems.RemoveAll();

                    AnimatedMapItem item = new AnimatedMapItem()
                    {
                        Caption = DateTime.Now.ToString(),
                        Location = routeLine.Points[0]
                    };
                    this.animatedItems.Add(item);

                    this.animationActions = this.AnimationSequence().GetEnumerator();
                    this.RunNextAction();
                }
            }
        }


        IEnumerable<Action<Action>> AnimationSequence()
        {
            if (this.routeLayer.Items.Count > 0)
            {
                PolylineData routeLine = this.routeLayer.Items[0] as PolylineData;
                if (routeLine != null && routeLine.Points.Count > 1)
                {
                    for (int i = 0; i < routeLine.Points.Count - 1; i++)
                    {
                        yield return this.AnimateItem(this.animatedItems[0], (Point)routeLine.Points[i], (Point)routeLine.Points[i + 1]);
                    }
                }
            }
        }

        private Action<Action> AnimateItem(AnimatedMapItem item, Point from, Point to)
        {
            return completed =>
            {
                PointAnimation pointAnimation = new PointAnimation()
                {
                    Duration = TimeSpan.FromMilliseconds(300),
                    From = from,
                    To = to,
                };

                Storyboard.SetTarget(pointAnimation, item);
                Storyboard.SetTargetProperty(pointAnimation, new PropertyPath("Point"));

                this.storyboard = new Storyboard()
                {
                    AutoReverse = false,
                };

                storyboard.Completed += this.Storyboard_Completed;
                storyboard.Children.Add(pointAnimation);
                storyboard.Begin();
            };
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            if (!this.animationStopped)
            {
                this.RunNextAction();
            }
        }

        private void RunNextAction()
        {
            if (animationActions.MoveNext())
            {
                animationActions.Current(RunNextAction);
            }
            else
            {
                this.SetIsEnabled(true);
            }
        }

        private void SetIsEnabled(bool enabled)
        {
            this.findRouteButton.IsEnabled = enabled;
            this.clearButton.IsEnabled = enabled;
            this.animateRouteButton.IsEnabled = enabled;
            this.cancelAnimationButton.IsEnabled = !enabled;
        }

        private void CancelAnimationButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.storyboard != null)
            {
                this.storyboard.Stop();
                this.SetIsEnabled(true);
            }
        }
	}
}
