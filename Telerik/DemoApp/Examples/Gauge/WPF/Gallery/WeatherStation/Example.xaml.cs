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
using System.Windows.Threading; 
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Gauges;
using System.Windows.Media.Animation;
using Telerik.Examples.Gauge;

namespace Telerik.Windows.Examples.Gauge.Gallery.WeatherStation
{
	/// <summary>
	/// Interaction logic for Weather Station Application
	/// </summary>
	public partial class Example : DynamicBasePage
	{
		private int ticksCounter = 0;
		private Storyboard storyboard;
		private List<WeatherStationCity> indicatorCities = new List<WeatherStationCity>();
		private List<ControlTemplate> weatherTemplates = new List<ControlTemplate>();
		private int weatherTemplatesLoaded = 0;

		public Example()
		{
			InitializeComponent();

			this.interval = TimeSpan.FromSeconds(8);
			this.Loaded += new RoutedEventHandler(Example_Loaded);
		}

		void RegisterElementNames(Control control)
		{
			string[] names = {
				"ellipse", "ellipse1", "ellipse2", "ellipse3", "ellipse4",
				"ellipse5", "ellipse6", "ellipse9", "ellipse10", "ellipse11",
				"ellipse12", "ellipse13", "ellipse9_Copy", "ellipse9_Copy1",
				"ellipse10_Copy", "ellipse10_Copy1", "ellipse11_Copy", "ellipse11_Copy1",
				"ellipse12_Copy", "ellipse12_Copy1", "ellipse13_Copy", "ellipse13_Copy1",
				"ellipse13_Copy3", "ellipse13_Copy4",
				"path", "path1", "path2", "path3", "path4", "path5",
				"path6", "path7", "path8", "path9", "path10", "path11"
			};

			foreach (string name in names)
			{
				object namedObject = control.Template.FindName(name, control);
				if (namedObject != null)
					this.RegisterName(name, namedObject);
			}
		}

		void RegisterControlElements()
		{
			NameScope.SetNameScope(this, new NameScope());

			this.RegisterElementNames(sofiaWeather);
			this.RegisterElementNames(parisWeather);
			this.RegisterElementNames(londonWeather);
			this.RegisterElementNames(newYorkWeather);
		}

		void Example_Loaded(object sender, RoutedEventArgs e)
		{
			weatherTemplates.Add(this.Resources["SunnyWeather"] as ControlTemplate);
			weatherTemplates.Add(this.Resources["PartlyCloudyWeather"] as ControlTemplate);
			weatherTemplates.Add(this.Resources["RainyWeather"] as ControlTemplate);
			weatherTemplates.Add(this.Resources["ThunderstormWeather"] as ControlTemplate);

			indicatorCities.Add(new WeatherStationCity(
				new RealDataEmulator(15, 30, 26, 12, 12),
				sofiaCurrent,
				sofiaWeather,
				sofiaNext241,
				sofiaNext242,
				sofiaNext481,
				sofiaNext482
			));
			indicatorCities.Add(new WeatherStationCity(
				new RealDataEmulator(5, 30, 18, 12, 12),
				parisCurrent,
				parisWeather,
				parisNext241,
				parisNext242,
				parisNext481,
				parisNext482
			));
			indicatorCities.Add(new WeatherStationCity(
				new RealDataEmulator(0, 24, 18, 12, 12),
				londonCurrent,
				londonWeather,
				londonNext241,
				londonNext242,
				londonNext481,
				londonNext482
			));
			indicatorCities.Add(new WeatherStationCity(
				new RealDataEmulator(5, 30, 10, 12, 12),
				newYorkCurrent,
				newYorkWeather,
				newYorkNext241,
				newYorkNext242,
				newYorkNext481,
				newYorkNext482
			));

			this.NewValue();
		}

		private void StartAnimation()
		{
			this.RegisterControlElements();
			this.storyboard = this.Resources["Anim"] as Storyboard;
			storyboard.Begin();
		}

		private void Weather_Loaded(object sender, RoutedEventArgs e)
		{
			weatherTemplatesLoaded ++;
			if (this.IsLoaded && weatherTemplatesLoaded == 4)
				this.StartAnimation();
		}

		private static int CompareRandom(ControlTemplate templateA, ControlTemplate templateB)
		{
			if (templateA == templateB)
				return 0;

			Random rnd = new Random();

			int random = rnd.Next(-1, 1);
			if (random == 0)
				return 1;

			return -1;
		}

		protected override void NewValue()
		{
			foreach (WeatherStationCity indicatorCity in indicatorCities)
			{
				indicatorCity.SetNextValue();
			}

			this.ticksCounter++;
			if (this.ticksCounter == 5)
			{
				this.ticksCounter = 0;
				this.weatherTemplatesLoaded = 0;
				this.weatherTemplates.Sort(CompareRandom);

				for (int i = 0; i < this.indicatorCities.Count; i++)
				{
					WeatherStationCity indicator = this.indicatorCities[i];
					if (indicator.WeatherContentControl.Template != this.weatherTemplates[i])
					{
						indicator.WeatherContentControl.Template = this.weatherTemplates[i];
					}
					else
						this.weatherTemplatesLoaded++;
				}
			}

			if (this.weatherTemplatesLoaded == 4)
				this.StartAnimation();
		}

		private class WeatherStationCity
		{
			private int ticksCounter = 0;
			private RealDataEmulator dataEmulator;
			private RealDataEmulator currentDataEmulator;
			private NumericIndicator indicator;
			private NumericIndicator indicator24Max;
			private NumericIndicator indicator24Min;
			private NumericIndicator indicator48Max;
			private NumericIndicator indicator48Min;
			private ContentControl weatherContentControl;

			private static int startCounter = 0;

			public WeatherStationCity(RealDataEmulator dataEmulator,
				NumericIndicator indicator,
				ContentControl weatherContentControl,
				NumericIndicator indicator24Max,
				NumericIndicator indicator24Min,
				NumericIndicator indicator48Max,
				NumericIndicator indicator48Min)
			{
				startCounter++;
				this.dataEmulator = dataEmulator;
				for (int i = 0; i < startCounter; i++ )
					this.dataEmulator.GetNextValue();

				this.indicator = indicator;
				this.weatherContentControl = weatherContentControl;

				this.indicator24Max = indicator24Max;
				this.indicator24Min = indicator24Min;

				double min = this.dataEmulator.GetNextValue();
				double max = this.dataEmulator.GetNextValue();

				this.indicator24Max.Value = min < max ? max : min;
				this.indicator24Min.Value = min < max ? min : max;

				this.indicator48Max = indicator48Max;
				this.indicator48Min = indicator48Min;

				this.SetCurrentGenerator();
			}

			private void SetCurrentGenerator()
			{
				double min = this.dataEmulator.GetNextValue();
				double max = this.dataEmulator.GetNextValue();

				this.indicator48Max.Value = min < max ? max : min;
				this.indicator48Min.Value = min < max ? min : max;

				this.currentDataEmulator = new RealDataEmulator(this.indicator24Min.Value, this.indicator24Max.Value);
			}

			public void SetNextValue()
			{
				this.ticksCounter++;

				if (this.ticksCounter == 8)
				{
					this.ticksCounter = 0;

					this.indicator24Max.Value = this.indicator48Max.Value;
					this.indicator24Min.Value = this.indicator48Min.Value;

					this.SetCurrentGenerator();
				}

				this.indicator.Value = this.currentDataEmulator.GetNextValue();
			}

			public ContentControl WeatherContentControl
			{
				get { return weatherContentControl; }
			}
		}
	}
}
