using System.Collections.Generic;
using System.Globalization;
#if WPF
using System.Windows.Controls;
#else
using Telerik.Windows.Controls;
#endif

namespace Telerik.Windows.Examples.ScheduleView.Localization
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			this.InitializeComponent();

			this.InitializeSupportedCultures();
		}

		private void Example_Unloaded(object sender, System.Windows.RoutedEventArgs e)
		{
			Telerik.Windows.Controls.LocalizationManager.DefaultCulture = CultureInfo.InvariantCulture;
		}

		private void InitializeSupportedCultures()
		{
			List<CultureInfo> supportedCultures = new List<CultureInfo>();
			supportedCultures.Add(CultureInfo.InvariantCulture);
			supportedCultures.Add(new CultureInfo("es"));
			supportedCultures.Add(new CultureInfo("de"));
			supportedCultures.Add(new CultureInfo("tr"));
			supportedCultures.Add(new CultureInfo("it"));
			supportedCultures.Add(new CultureInfo("nl"));
			supportedCultures.Add(new CultureInfo("fr"));

			this.Cultures.ItemsSource = supportedCultures;
		}

		private void ResetTemplate()
		{
			System.Windows.Controls.ControlTemplate template = this.ScheduleView.Template;
			this.ScheduleView.Template = null;
			this.ScheduleView.Template = template;
		}

		private void Cultures_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Telerik.Windows.Controls.LocalizationManager.DefaultCulture = (CultureInfo)(sender as Telerik.Windows.Controls.RadComboBox).SelectedItem;

			if (e.RemovedItems.Count != 0)
			{
				this.ResetTemplate();
			}
		}
	}
}