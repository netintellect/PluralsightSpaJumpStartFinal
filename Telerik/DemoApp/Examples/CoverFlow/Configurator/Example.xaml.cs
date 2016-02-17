using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Media.Animation;
using Telerik.Windows.Controls;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.CoverFlow.Configurator
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            Dictionary<string, IEasingFunction> easings = new Dictionary<string, IEasingFunction>();
            CircleEase circleEase = new CircleEase();
            circleEase.EasingMode = EasingMode.EaseOut;
            easings.Add("Circle", circleEase);

            BackEase backEase = new BackEase();
            backEase.EasingMode = EasingMode.EaseOut;
            backEase.Amplitude = 2;
            easings.Add("Back", backEase);

            ExponentialEase exponentialEase = new ExponentialEase();
            exponentialEase.EasingMode = EasingMode.EaseOut;
            exponentialEase.Exponent = 5;
            easings.Add("Exponential", exponentialEase);

            PowerEase powerEase = new PowerEase();
            powerEase.EasingMode = EasingMode.EaseOut;
            powerEase.Power = 10;
            easings.Add("Power", powerEase);

            QuadraticEase quadraticEase = new System.Windows.Media.Animation.QuadraticEase();
            quadraticEase.EasingMode = EasingMode.EaseOut;
            easings.Add("Quadratic", quadraticEase);

            CubicEase cubicEase = new CubicEase();
            cubicEase.EasingMode = EasingMode.EaseOut;
            easings.Add("Cubic", cubicEase);

            QuarticEase quarticEase = new System.Windows.Media.Animation.QuarticEase();
            quarticEase.EasingMode = EasingMode.EaseOut;
            easings.Add("Quartic", quarticEase);

            QuinticEase quanticEase = new QuinticEase();
            quanticEase.EasingMode = EasingMode.EaseOut;
            easings.Add("Quintic", quanticEase);

            ElasticEase elasticEase = new ElasticEase();
            elasticEase.EasingMode = EasingMode.EaseOut;
            elasticEase.Oscillations = 2;
            elasticEase.Springiness = 3;
            easings.Add("Elastic", elasticEase);

            BounceEase bounceEase = new BounceEase();
            bounceEase.EasingMode = EasingMode.EaseOut;
            bounceEase.Bounces = 2;
            bounceEase.Bounciness = 2;
            easings.Add("Bounce", bounceEase);

            SineEase sineEase = new SineEase();
            sineEase.EasingMode = EasingMode.EaseOut;
            easings.Add("Sine", sineEase);

            this.EasingFunction.ItemsSource = easings;
            this.EasingFunction.SelectedIndex = 0;

            this.CameraViewpoint.ItemsSource = this.GetNames<CameraViewpoint>();
            this.CameraViewpoint.SelectedIndex = 2;

            this.Orientation.ItemsSource = this.GetNames<Orientation>();
            this.Orientation.SelectedIndex = 1;
        }

        private void ItemChangeDelay_Changed(object sender, RadRangeBaseValueChangedEventArgs e)
        {
            if (cover != null && e.NewValue != null)
            {
                this.cover.ItemChangeDelay = TimeSpan.FromMilliseconds((double)e.NewValue);
            }
        }

        private IEnumerable<T> GetNames<T>()
        {
            Type type = typeof(T);

            return type
                .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                .Select((FieldInfo x) => (T)Enum.Parse(type, x.Name, true));
        }

        private void Orientation_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((Orientation)Orientation.SelectedValue == System.Windows.Controls.Orientation.Vertical)
            {
                CameraViewpoint.SelectedValue = Telerik.Windows.Controls.CameraViewpoint.Center;
                OffsetY.Value = 0;
            }
            else
            {
                CameraViewpoint.SelectedValue = Telerik.Windows.Controls.CameraViewpoint.Center;
                OffsetY.Value = 100;
            }
        }
    }
}