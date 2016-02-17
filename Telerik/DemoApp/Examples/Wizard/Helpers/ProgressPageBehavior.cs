using System;
using System.Net;
using System.Windows;
using System.Linq;
using System.Windows.Threading;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Wizard
{
	public class ProgressPageBehavior
	{
		private readonly WizardPage page = null;
		private DispatcherTimer timer;
		private RadProgressBar progressBar;

		public ProgressPageBehavior(WizardPage page)
		{
			this.page = page;
		}

		public static readonly DependencyProperty IsEnabledProperty
			= DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(ProgressPageBehavior),
				new PropertyMetadata(new PropertyChangedCallback(OnIsEnabledPropertyChanged)));

		public static void SetIsEnabled(DependencyObject dependencyObject, bool enabled)
		{
			dependencyObject.SetValue(IsEnabledProperty, enabled);
		}

		public static bool GetIsEnabled(DependencyObject dependencyObject)
		{
			return (bool)dependencyObject.GetValue(IsEnabledProperty);
		}

		private static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			var page = dependencyObject as WizardPage;
			if (page != null)
			{
				if ((bool)e.NewValue)
				{
					var behavior = new ProgressPageBehavior(page);
					behavior.Attach();
				}
			}
		}

		private void Attach()
		{
			this.timer = new DispatcherTimer();
			this.timer.Interval = TimeSpan.FromMilliseconds(10.0);
			this.timer.Tick += new EventHandler(this.Timer_Tick);

			if (page != null)
			{
				page.Loaded += page_Loaded;
			}
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			this.progressBar.Value += 1;
		}

		void page_Loaded(object sender, RoutedEventArgs e)
		{
			var page = sender as WizardPage;
			if (page.Name == "progressPage")
			{
				SetAllowProperties(page, false);
				this.progressBar = page.ChildrenOfType<RadProgressBar>().FirstOrDefault();
				if (this.progressBar != null)
				{
					this.progressBar.ValueChanged += progressBar_ValueChanged;
					this.progressBar.Value = 0;
					this.timer.Start();
				}		
			}
		}		

		void progressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			var wizard = this.progressBar.ParentOfType<RadWizard>();
			if (this.progressBar.Value == this.progressBar.Maximum && wizard != null)
			{
				SetAllowProperties(wizard.SelectedPage, true);
				this.timer.Stop();
			}
		}

		private void SetAllowProperties(WizardPage page, bool value)
		{
			page.AllowNext = value;
			page.AllowPrevious = value;
			page.AllowCancel = value;
		}
	}
}
