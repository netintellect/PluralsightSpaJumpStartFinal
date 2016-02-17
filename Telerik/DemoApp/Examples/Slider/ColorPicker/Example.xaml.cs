using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Slider.ColorPicker
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		private double dragDeltaX, dragDeltaY;

		public Example()
		{
			InitializeComponent();

			saturationSlider.ValueChanged += this.SaturationSlider_ValueChanged;
			luminanceSlider.ValueChanged += this.LuminanceSlider_ValueChanged;
			hueSlider.ValueChanged += this.HueSlider_ValueChanged;

			colorPickerThumb.DragStarted += this.ColorPickerThumb_DragStarted;
			colorPickerThumb.DragDelta += this.ColorPickerThumb_DragDelta;

			Pad.MouseLeftButtonDown += this.Pad_MouseLeftButtonDown;

			Color backColor = ColorConverter.HSLtoRGB(1 - hueSlider.Value, 1, 1);
			PaleteRectangle.Fill = new SolidColorBrush(backColor);
			this.UpdatePad();
		}

		private void Pad_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			double offsetX = 0;
			double offsetY = 0;

			offsetX = e.GetPosition(Pad).X;
			offsetY = e.GetPosition(Pad).Y;

			saturationSlider.Value = offsetX / Pad.ActualWidth;
			luminanceSlider.Value = 1 - offsetY / Pad.ActualHeight;
		}

		// HSL Sliders Value changed
		private void HueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			Color backColor = ColorConverter.HSLtoRGB(1 - hueSlider.Value, 1, 1);
			PaleteRectangle.Fill = new SolidColorBrush(backColor);
			this.UpdatePad();
		}
		private void LuminanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.UpdatePad();
			resizeRectangle.Height = DistanceConverter.ValueToPixels((double)e.NewValue, (Pad.ActualHeight - colorPickerThumb.ActualHeight), (luminanceSlider.Maximum - luminanceSlider.Minimum));
		}
		private void SaturationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.UpdatePad();
			resizeRectangle.Width = DistanceConverter.ValueToPixels((double)e.NewValue, (Pad.ActualWidth - colorPickerThumb.ActualWidth), (saturationSlider.Maximum - saturationSlider.Minimum));
		}

		// ColorPicker Thumb Drag events
		private void ColorPickerThumb_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
		{
			this.dragDeltaX = saturationSlider.Value;
			this.dragDeltaY = luminanceSlider.Value;
		}
		private void ColorPickerThumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
		{
			double offsetX = 0;
			double offsetY = 0;

			offsetX = DistanceConverter.PixelsToValue(e.HorizontalChange, (Pad.ActualWidth - colorPickerThumb.ActualWidth), (saturationSlider.Maximum - saturationSlider.Minimum));
			offsetY = DistanceConverter.PixelsToValue(e.VerticalChange, (Pad.ActualHeight - colorPickerThumb.ActualHeight), (luminanceSlider.Maximum - luminanceSlider.Minimum));

			this.dragDeltaX += offsetX;
			this.dragDeltaY += -offsetY;

			saturationSlider.Value = this.dragDeltaX;
			luminanceSlider.Value = this.dragDeltaY;
		}

		// Private methods
		private void UpdatePad()
		{
			Color backColor = ColorConverter.HSLtoRGB(1 - hueSlider.Value, saturationSlider.Value, luminanceSlider.Value);
			CurrentColorRectangle.Fill = new SolidColorBrush(backColor);
		}
	}

	public class DistanceConverter
	{
		public static double PixelsToValue(double distanceInPixels, double containerLength, double valueRange)
		{
			return (valueRange * distanceInPixels) / containerLength;
		}
		public static double ValueToPixels(double value, double containerLength, double valueRange)
		{
			return (value * containerLength) / valueRange;
		}
	}

	public class ColorConverter
	{
		public static Color HSLtoRGB(double hue, double saturation, double luminance)
		{
			int Max, Mid, Min;
			double q;

			Max = Round(luminance * 255);
			Min = Round((1.0 - saturation) * (luminance / 1.0) * 255);
			q = (double)(Max - Min) / 255;

			if (hue >= 0 && hue <= (double)1 / 6)
			{
				Mid = Round(((hue - 0) * q) * 1530 + Min);
				return Color.FromArgb(255, (byte)Max, (byte)Mid, (byte)Min);
			}
			else if (hue <= (double)1 / 3)
			{
				Mid = Round(-((hue - (double)1 / 6) * q) * 1530 + Max);
				return Color.FromArgb(255, (byte)Mid, (byte)Max, (byte)Min);
			}
			else if (hue <= 0.5)
			{
				Mid = Round(((hue - (double)1 / 3) * q) * 1530 + Min);
				return Color.FromArgb(255, (byte)Min, (byte)Max, (byte)Mid);
			}
			else if (hue <= (double)2 / 3)
			{
				Mid = Round(-((hue - 0.5) * q) * 1530 + Max);
				return Color.FromArgb(255, (byte)Min, (byte)Mid, (byte)Max);
			}
			else if (hue <= (double)5 / 6)
			{
				Mid = Round(((hue - (double)2 / 3) * q) * 1530 + Min);
				return Color.FromArgb(255, (byte)Mid, (byte)Min, (byte)Max);
			}
			else if (hue <= 1.0)
			{
				Mid = Round(-((hue - (double)5 / 6) * q) * 1530 + Max);
				return Color.FromArgb(255, (byte)Max, (byte)Min, (byte)Mid);
			}
			else
			{
				return Color.FromArgb(255, (byte)0, (byte)0, (byte)0);
			}
		}
		private static int Round(double val)
		{
			int ret_val = (int)val;

			int temp = (int)(val * 100);

			if ((temp % 100) >= 50)
			{
				ret_val += 1;
			}

			return ret_val;
		}
	}
}

