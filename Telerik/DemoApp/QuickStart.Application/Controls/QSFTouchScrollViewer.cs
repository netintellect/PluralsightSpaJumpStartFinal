using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Telerik.Windows.QuickStart
{
    public class QSFTouchScrollViewer : ScrollViewer
    {
        private BlurEffect innerBorderEffect;
        private Border innerBorder;
        private Border outerBorder;
        private FrameworkElement scrollContentPresenterContainer;

        public double FadeThickness { get; set; }
        public double FadeSpeed { get; set; }
        public double FadeOpacity { get; set; }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.ScrollChanged -= this.OnScrollChanged;
            this.SizeChanged -= this.OnSizeChanged;

            this.ScrollChanged += this.OnScrollChanged;
            this.SizeChanged += this.OnSizeChanged;

            this.innerBorderEffect = new BlurEffect() { RenderingBias = RenderingBias.Performance };
            this.innerBorder = new Border()
            {
                Background = Brushes.Black,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
                VerticalAlignment = System.Windows.VerticalAlignment.Stretch,
                Effect = this.innerBorderEffect,
            };

            this.outerBorder = new Border()
            {
                Background = new SolidColorBrush(Color.FromArgb((byte)(this.FadeOpacity * 255), 0, 0, 0)),
                ClipToBounds = true,
                Child = this.innerBorder,
            };

            this.scrollContentPresenterContainer = this.GetTemplateChild("PART_ScrollContentPresenterContainer") as FrameworkElement;

            if (this.scrollContentPresenterContainer != null)
            {
                this.scrollContentPresenterContainer.OpacityMask = new VisualBrush() { Visual = this.outerBorder };
            }
        }

        private double CalculateMarginFromOffset(double offset)
        {
            var innerBorderMargin = this.FadeThickness / 2.0;
            var calculatedMargin = (innerBorderMargin) - (1.5 * (this.FadeThickness - (offset / this.FadeSpeed)));

            return Math.Min(innerBorderMargin, calculatedMargin);
        }

        private void OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var topMargin = this.CalculateMarginFromOffset(this.VerticalOffset);
            var bottomMargin = this.CalculateMarginFromOffset(this.ScrollableHeight - this.VerticalOffset);
            var leftMargin = this.CalculateMarginFromOffset(this.HorizontalOffset);
            var rightMargin = this.CalculateMarginFromOffset(this.ScrollableWidth - this.HorizontalOffset);

            if (this.innerBorder != null)
            {
                this.innerBorder.Margin = new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);
            }
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.outerBorder == null || this.innerBorder == null || this.innerBorderEffect == null)
            {
                return;
            }

            this.outerBorder.Width = e.NewSize.Width;
            this.outerBorder.Height = e.NewSize.Height;
            this.innerBorder.Margin = new Thickness(this.FadeThickness / 2.0);
            this.innerBorderEffect.Radius = this.FadeThickness;
        }
    }
}
