using System;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples
{
	///<summary>
	/// Servers as a base type for all <see cref="RadGridView"/> examples.
	///</summary>
	public class GridViewExample : UserControl
	{
		private ResourceDictionary filterStyleDictionary;
		public GridViewExample()
		{
			this.DataContext = new ExamplesDataContext();

			this.Loaded += this.OnLoaded;
			this.Unloaded += this.OnUnloaded;
#if WPF
			ApplicationThemeManager.GetInstance().ThemeChanged += GridViewExample_ThemeChanged;
#endif
#if !WPF
			string source = "/GridView;component/GridViewStylesSL.xaml";
#else
			string source = "/GridView;component/GridViewStyles.xaml";
#endif
			this.filterStyleDictionary = new ResourceDictionary() { Source = new Uri(source, UriKind.Relative) };
		}

		void GridViewExample_ThemeChanged(object sender, EventArgs e)
		{
			if (ApplicationThemeManager.GetInstance().CurrentTheme == ApplicationThemeManager.DefaultThemeNameTouch)
			{
				this.Resources.MergedDictionaries.Add(this.filterStyleDictionary);
			}
			else if(this.Resources.MergedDictionaries.Contains(this.filterStyleDictionary))
			{
				this.Resources.MergedDictionaries.Remove(this.filterStyleDictionary);
			}
		}

		protected virtual void OnLoaded(object sender, RoutedEventArgs e)
		{
			if (ConfigurationPanel != null)
			{
				ConfigurationPanel.DataContext = this.ChildrenOfType<RadGridView>().FirstOrDefault();
			}
#if !WPF
			string source = "/GridView;component/GridViewStylesSL.xaml";
#else
			string source = "/GridView;component/GridViewStyles.xaml";
#endif
			if (ApplicationThemeManager.GetInstance().CurrentTheme == ApplicationThemeManager.DefaultThemeNameTouch)
			{
				this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(source, UriKind.Relative) });
			}
		}

		/// <summary>
		/// Used to clear any set data context and avoid memory leaks.
		/// </summary>
		protected virtual void OnUnloaded(object sender, RoutedEventArgs e)
		{
#if WPF
			ApplicationThemeManager.GetInstance().ThemeChanged -= GridViewExample_ThemeChanged;
#endif
		}

		protected Panel ConfigurationPanel
		{
			get
			{
				return Telerik.Windows.Controls.QuickStart.QuickStart.GetConfigurationPanel(this);
			}
		}
	}
}