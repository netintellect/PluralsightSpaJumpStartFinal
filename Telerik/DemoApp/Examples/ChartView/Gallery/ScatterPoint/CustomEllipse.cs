using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;


namespace Telerik.Windows.Examples.ChartView.Gallery.ScatterPoint
{
    [TemplateVisualState(Name = "Normal", GroupName = "GroupCommon")]
    [TemplateVisualState(Name = "MouseOver", GroupName = "GroupCommon")]
    public class CustomEllipse : Control
    {
        public double Thickness
        {
            get { return (double)GetValue(ThicknessProperty); }
            set { SetValue(ThicknessProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Thickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ThicknessProperty =
            DependencyProperty.Register("Thickness", typeof(double), typeof(CustomEllipse), new PropertyMetadata(1d));

        public CustomEllipse()
        {
            this.DefaultStyleKey = typeof(CustomEllipse);
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            var result = VisualStateManager.GoToState(this, "MouseOver", true);
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            var result = VisualStateManager.GoToState(this, "Normal", true);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            VisualStateManager.GoToState(this, "Normal", false);
        }
    }
}
