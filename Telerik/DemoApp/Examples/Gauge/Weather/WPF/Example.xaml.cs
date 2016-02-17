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
using Telerik.Examples.Gauge;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Gauge;
using System.Globalization;
using System.Threading;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.Gauge.Weather
{
	/// <summary>
	/// Interaction logic for Weather Station Application
	/// </summary>
    public partial class Example : DynamicBasePage
    {
        private DateTime timeVar;
        private int ticksCounter = 0;
        private int i = 1;
        private string[] weatherIcons = new string[] { "SunnyWeather", "SnowyWeather", "PartlyCloudyWeather", "RainyWeather", "ThunderstormWeather" };
        private int[] allTimesMargin = new int[] { 8, 11, 3, 5, 30 };
        private ExampleViewModel context;

        public Example()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Weather/WPF/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Weather/WPF/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
            this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Weather/SunnyWeatherTemplate.xaml", UriKind.RelativeOrAbsolute) });
            this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Weather/SnowyWeatherTemplate.xaml", UriKind.RelativeOrAbsolute) });
            this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Weather/PartlyCloudyWeatherTemplate.xaml", UriKind.RelativeOrAbsolute) });
            this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Weather/ThunderstormWeatherTemplate.xaml", UriKind.RelativeOrAbsolute) });
            this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Weather/RainyWeatherTemplate.xaml", UriKind.RelativeOrAbsolute) });

            InitializeComponent();

#if WPF
            this.linearGaugeRange1.Background = new SolidColorBrush(Color.FromArgb(0x99, 0x79, 0x25, 0x6B));
            this.linearGaugeRange2.Background = new SolidColorBrush(Color.FromArgb(0xCC, 0x79, 0x25, 0x6B));
#else
            this.linearGaugeRange1.Background = new SolidColorBrush(Color.FromArgb(0x99, 0x25, 0xA0, 0xDA));
            this.linearGaugeRange2.Background = new SolidColorBrush(Color.FromArgb(0xCC, 0x25, 0xA0, 0xDA));
#endif

            context = this.DataContext as ExampleViewModel;
            context.NextData();

            InitialSetUp();
        }

        private void InitialSetUp()
        {
            WeatherContentControl icon = new WeatherContentControl();
            icon.Template = this.Resources[weatherIcons[0]] as ControlTemplate;
            this.weather.Content = icon;

            timeVar = DateTime.UtcNow.AddHours(allTimesMargin[0]);
        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            context.NextData();

            if (i < 5)
            {
                WeatherContentControl icon = new WeatherContentControl();
                icon.Template = this.Resources[weatherIcons[i]] as ControlTemplate;
                this.weather.Content = icon;

                timeVar = DateTime.UtcNow.AddHours(allTimesMargin[i]);

                i++; 
            }
            else
            {
                i = 1;
                InitialSetUp();
            }
        }

        public void SetNextValue()
        {
            this.ticksCounter++;

            if (this.ticksCounter == 1)
            {
                this.ticksCounter = 0;
                 
                timeVar = timeVar.AddSeconds(1);

                this.SecondsNeedle.Value = timeVar.Second;
                this.MinutesNeedle.Value = timeVar.Minute;
                this.HoursNeedle.Value = Math.Abs(12-timeVar.Hour);
                this.timeText.Text = timeVar.ToString("HH:mm:ss");
            }
        }

        protected override void NewValue()
        {
            SetNextValue();
        }
    }

	/// <summary>
	/// Weather content control class overrides OnApplyTemplate method
	/// to start animation when template is loaded
	/// </summary>
	public class WeatherContentControl : ContentControl
	{
		private Example example;

		/// <summary>
		/// Example object
		/// </summary>
		public Example Example
		{
			set { example = value; }
		}

		/// <summary>
		/// Calls Weather_Loaded method of example to notify that template is loaded
		/// </summary>
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

		}
	}
}
