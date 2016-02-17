using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;
using Telerik.Windows.Controls;

namespace Telerik.Examples.Gauge
{
	/// <summary>
	/// Interaction logic for DynamicBasePage.xaml
	/// </summary>
    public partial class DynamicBasePage : UserControl
	{
		/// <summary>
		/// Timer interval
		/// </summary>
		protected TimeSpan interval = TimeSpan.FromSeconds(1);

		/// <summary>
		/// Timer to change indicator's value
		/// </summary>
		protected DispatcherTimer timer;

		/// <summary>
		/// Randomizer
		/// </summary>
		protected Random rnd = new Random();

		public DynamicBasePage()
		{
			this.Loaded += new RoutedEventHandler(DynamicBasePage_Loaded);
			this.Unloaded += new RoutedEventHandler(DynamicBasePage_Unloaded);
		}

		/// <summary>
		/// Gets or sets timer interval
		/// </summary>
		protected TimeSpan TimerInterval
		{
			get
			{
				return interval;
			}

			set
			{
				timer.Stop();

				interval = value;
				timer.Interval = interval;

				timer.Start();
			}
		}

		private void DynamicBasePage_Loaded(object sender, RoutedEventArgs e)
		{
			timer = new DispatcherTimer();
			timer.Interval = interval;
			timer.Tick += new EventHandler(Timer_Tick);
			timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
            if (timer != null)
            {
                timer.Stop();

                NewValue();

                timer.Start();
            }
		}

		protected virtual void NewValue()
		{
		}

		private void DynamicBasePage_Unloaded(object sender, RoutedEventArgs e)
		{
            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }
		}

        /// <summary>
        /// Setup binding between GUI element (like TextBox or ComboBox)
        /// and gauge element
        /// </summary>
        /// <param name="guiElement"></param>
        /// <param name="valueProperty"></param>
        /// <param name="gaugeElement"></param>
        /// <param name="gaugeProperty"></param>
        protected void SetupBinding(FrameworkElement guiElement,
            DependencyProperty valueProperty,
            FrameworkElement gaugeElement,
            DependencyProperty gaugeProperty,
            IValueConverter converter)
        {
            SetupBinding(guiElement, valueProperty, gaugeElement, gaugeProperty, converter, null);
        }

        /// <summary>
        /// Setup binding between GUI element (like TextBox or ComboBox)
        /// and gauge element
        /// </summary>
        /// <param name="guiElement"></param>
        /// <param name="valueProperty"></param>
        /// <param name="gaugeElement"></param>
        /// <param name="gaugeProperty"></param>
        protected void SetupBinding(FrameworkElement guiElement,
            DependencyProperty valueProperty,
            FrameworkElement gaugeElement,
            DependencyProperty gaugeProperty,
            IValueConverter converter,
            object converterParameter)
        {
            BindingHelper helper = new BindingHelper();
            Binding binding = new Binding();
            binding.Source = helper;
            binding.Path = new PropertyPath("Value");
            binding.Mode = BindingMode.TwoWay;
            binding.Converter = converter;
            binding.ConverterParameter = converterParameter;
            guiElement.SetBinding(valueProperty, binding);

            binding = new Binding();
            binding.Source = helper;
            binding.Path = new PropertyPath("Value");
            gaugeElement.SetBinding(gaugeProperty, binding);
        }

        /// <summary>
        /// This class facilitates databinding by providing a property with change notification.
        /// </summary>
        [Description("This class facilitates databinding by providing a property with change notification.")]
        public class BindingHelper : INotifyPropertyChanged
        {
            private object _value;

            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>The value.</value>
            [Description("Gets or sets the value.")]
            public object Value
            {
                get
                {
                    return _value;
                }

                set
                {
                    _value = value;
                    OnPropertyChanged("Value");
                }
            }

            /// <summary>
            /// Occurs when a property value changes.
            /// </summary>
            [Description("Occurs when a property value changes.")]
            public event PropertyChangedEventHandler PropertyChanged;

            /// <summary>
            /// Fires the property changed event.
            /// </summary>
            /// <param name="propertyName">The name of the property, that is changed.</param>
            [Description("Fires the property changed event.")]
            protected virtual void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
	}
}
