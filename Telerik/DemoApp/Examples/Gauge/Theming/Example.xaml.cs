using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls.Gauge;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.Gauge.Theming
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            this.ApplyThemeSpecificSettings();
        }

        public string CurrentTheme
        {
            get
            {
                return ApplicationThemeManager.GetInstance().CurrentTheme;
            }
        }

        private void ApplyThemeSpecificSettings()
        {
            switch (this.CurrentTheme)
            {
                case "Office_Black":
                case "Office_Blue":
                case "Office_Silver":
                    {
                        this.horizontalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x60, 0x60, 0x60));
                        this.verticalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x60, 0x60, 0x60));
#if WPF
                        // WPF example not reloaded on theme change so we reset here.
                        this.Container.ClearValue(BackgroundProperty);
                        this.radialBar.ClearValue(OpacityProperty);
                        this.range1.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x8D, 0x00));
                        this.range2.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                        this.range3.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xE5, 0x00, 0x00));
                        this.horizontalScaleBorder.BorderThickness = new Thickness(1, 1, 0, 1);
                        this.verticalScaleBorder.BorderThickness = new Thickness(1, 0, 1, 1);

                        ResetTouchAndGreenAndOffice2013ThemeSpecificProperties();
#endif
                        break;
                    }
                case "Windows7":
                    {
                        this.range1.Background = new SolidColorBrush(Colors.Transparent);
                        this.range2.Background = new SolidColorBrush(Colors.Transparent);
                        this.range3.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xE5, 0x00, 0x00));

                        this.horizontalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x23, 0x66, 0xB0));
                        this.verticalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x23, 0x66, 0xB0));
#if WPF
                        // WPF example not reloaded on theme change so we reset here.
                        this.Container.ClearValue(BackgroundProperty);
                        this.radialBar.ClearValue(OpacityProperty);
                        this.horizontalScaleBorder.BorderThickness = new Thickness(1, 1, 0, 1);
                        this.verticalScaleBorder.BorderThickness = new Thickness(1, 0, 1, 1);

                        ResetTouchAndGreenAndOffice2013ThemeSpecificProperties();
#endif
                        break;
                    }
                case "Vista":
                    {
                        this.range1.Background = new SolidColorBrush(Colors.Transparent);
                        this.range2.Background = new SolidColorBrush(Colors.Transparent);
                        this.range3.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xE5, 0x00, 0x00));

                        this.horizontalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x16, 0xA5, 0xBB));
                        this.verticalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x16, 0xA5, 0xBB));
#if WPF
                        // WPF example not reloaded on theme change so we reset here.
                        this.Container.ClearValue(BackgroundProperty);
                        this.radialBar.ClearValue(OpacityProperty);
                        this.horizontalScaleBorder.BorderThickness = new Thickness(1, 1, 0, 1);
                        this.verticalScaleBorder.BorderThickness = new Thickness(1, 0, 1, 1);

                        ResetTouchAndGreenAndOffice2013ThemeSpecificProperties();
#endif
                        break;
                    }
                case "Summer":
                    {
                        this.range1.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x8D, 0x00));
                        this.range2.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                        this.range3.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xE5, 0x00, 0x00));

                        this.horizontalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x59, 0xBE, 0xE2));
                        this.verticalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x59, 0xBE, 0xE2));
#if WPF
                        // WPF example not reloaded on theme change so we reset here.
                        this.Container.ClearValue(BackgroundProperty);
                        this.radialBar.ClearValue(OpacityProperty);
                        this.horizontalScaleBorder.BorderThickness = new Thickness(1, 1, 0, 1);
                        this.verticalScaleBorder.BorderThickness = new Thickness(1, 0, 1, 1);

                        ResetTouchAndGreenAndOffice2013ThemeSpecificProperties();
#endif
                        break;
                    }
                case "Expression_Dark":
                    {
                        this.Container.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x33, 0x33, 0x33));
                        this.range2.Background = new SolidColorBrush(Colors.White);

                        this.horizontalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xA3, 0xA3, 0xA3));
                        this.verticalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xA3, 0xA3, 0xA3));
                        this.horizontalScaleBorder.BorderThickness = new Thickness(0, 1, 0, 1);
                        this.verticalScaleBorder.BorderThickness = new Thickness(1, 0, 1, 0);
#if WPF
                        // WPF example not reloaded on theme change so we reset here.
                        this.radialBar.ClearValue(OpacityProperty);
                        this.range1.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x8D, 0x00));
                        this.range3.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xE5, 0x00, 0x00));

                        ResetTouchAndGreenAndOffice2013ThemeSpecificProperties();
#endif
                        break;
                    }

                case "Windows8Touch":
                    {
                        SetTouchAndOffice2013ThemeSpecificProperties(new SolidColorBrush(Color.FromArgb(0xFF, 0xCC, 0xCC, 0xCC)));

                        this.horizontalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x60, 0x60, 0x60));
                        this.verticalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x60, 0x60, 0x60));
                        this.horizontalScaleBorder.BorderThickness = new Thickness(0, 1, 0, 1);
                        this.verticalScaleBorder.BorderThickness = new Thickness(1, 0, 1, 0);

#if WPF
                        // WPF example not reloaded on theme change so we reset here.
                        this.Container.ClearValue(BackgroundProperty);
                        this.range1.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x8D, 0x00));
                        this.range2.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                        this.range3.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xE5, 0x00, 0x00));
#endif
                        break;
                    }
                case "Office2013":
                case "Office2013_LightGray":
                case "Office2013_DarkGray":
                    {
                        SetTouchAndOffice2013ThemeSpecificProperties(new SolidColorBrush(Color.FromArgb(0xFF, 0xD4, 0xD4, 0xD4)));

                        this.horizontalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x60, 0x60, 0x60));
                        this.verticalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x60, 0x60, 0x60));
                        this.horizontalScaleBorder.BorderThickness = new Thickness(0, 1, 0, 1);
                        this.verticalScaleBorder.BorderThickness = new Thickness(1, 0, 1, 0);
#if WPF
                        // WPF example not reloaded on theme change so we reset here.
                        this.Container.ClearValue(BackgroundProperty);
                        this.range1.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x8D, 0x00));
                        this.range2.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                        this.range3.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xE5, 0x00, 0x00));
#endif
                        break;
                    }

                case "VisualStudio2013_Dark":
                    {
                        this.range1.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x33, 0x99, 0xFF));
                        this.range2.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x33, 0x99, 0xFF));
                        this.range3.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x99, 0x99, 0x99));

                        this.horizontalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x99, 0x99, 0x99));
                        this.verticalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x99, 0x99, 0x99));
                        this.horizontalScaleBorder.BorderThickness = new Thickness(0, 1, 0, 1);
                        this.verticalScaleBorder.BorderThickness = new Thickness(1, 0, 1, 0);
#if WPF
                        // WPF example not reloaded on theme change so we reset here.
                        this.Container.ClearValue(BackgroundProperty);
                        ResetTouchAndGreenAndOffice2013ThemeSpecificProperties();
#endif
                        break;
                    }
                case "Green_Dark":
                    {
                        SetGreenThemeSpecificProperties();
                        this.radialBar.ClearValue(OpacityProperty);
                        this.range1.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x86, 0xB9, 0x0E));
                        this.range2.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x86, 0xB9, 0x0E));
                        this.range3.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x47, 0x47, 0x47));
                        this.horizontalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x47, 0x47, 0x47));
                        this.verticalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x47, 0x47, 0x47));
                        this.horizontalScaleBorder.BorderThickness = new Thickness(0, 1, 0, 1);
                        this.verticalScaleBorder.BorderThickness = new Thickness(1, 0, 1, 0);
#if WPF
                        // WPF example not reloaded on theme change so we reset here.
                        this.Container.ClearValue(BackgroundProperty);
#endif
                        break;
                    }
                case "Green_Light":
                    {
                        SetGreenThemeSpecificProperties();
                        this.radialBar.ClearValue(OpacityProperty);
                        this.range1.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x84, 0x06));
                        this.range2.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x84, 0x06));
                        this.range3.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x99, 0x99, 0x99));
                        this.horizontalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x99, 0x99, 0x99));
                        this.verticalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x99, 0x99, 0x99));
                        this.horizontalScaleBorder.BorderThickness = new Thickness(0, 1, 0, 1);
                        this.verticalScaleBorder.BorderThickness = new Thickness(1, 0, 1, 0);
#if WPF
                        // WPF example not reloaded on theme change so we reset here.
                        this.Container.ClearValue(BackgroundProperty);
#endif
                        break;
                    }
                default:
                    {
                        this.radialBar.Opacity = 0.6;
                        this.horizontalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x60, 0x60, 0x60));
                        this.verticalScaleBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x60, 0x60, 0x60));
                        this.horizontalScaleBorder.BorderThickness = new Thickness(0, 1, 0, 1);
                        this.verticalScaleBorder.BorderThickness = new Thickness(1, 0, 1, 0);
#if WPF
                        // WPF example not reloaded on theme change so we reset here.
                        this.Container.ClearValue(BackgroundProperty);
                        this.range1.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x1E, 0x8D, 0x00));
                        this.range2.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
                        this.range3.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xE5, 0x00, 0x00));

                        ResetTouchAndGreenAndOffice2013ThemeSpecificProperties();
#endif
                        break;
                    }
            }
        }

        private void SetGreenThemeSpecificProperties()
        {
            this.scale.MiddleTicks = 2;
            this.scale.MinorTicks = 1;
            this.scale.MajorTickRelativeWidth = new GaugeMeasure(2);
            this.scale.MajorTickRelativeHeight = new GaugeMeasure(10);
            this.scale.MiddleTickRelativeWidth = new GaugeMeasure(2);
            this.scale.MiddleTickRelativeHeight = new GaugeMeasure(10);
            this.scale.MajorTickOffset = new GaugeMeasure(-2, GridUnitType.Pixel);
            this.scale.MiddleTickOffset = new GaugeMeasure(-2, GridUnitType.Pixel);
            this.scale.ClearValue(RadialScale.LabelOffsetProperty);

            //this.scale.LabelOffset = new GaugeMeasure(0.05, GridUnitType.Star);

            ScaleObject.SetOffset(this.radialBar, new GaugeMeasure(0.30, GridUnitType.Star));

            this.radialBar.StartWidth = 0.13;
            this.radialBar.EndWidth = 0.13;

            //range settings
            this.range1.StartWidth = this.range2.StartWidth = this.range3.StartWidth = 0.02;
            this.range1.EndWidth = this.range2.EndWidth = this.range3.EndWidth = 0.02;

            //linear scale markers
            ScaleObject.SetLocation(this.horizontalLinearScaleMarker, ScaleObjectLocation.Inside);
            ScaleObject.SetOffset(this.horizontalLinearScaleMarker, new GaugeMeasure(0));
            ScaleObject.SetRelativeWidth(this.horizontalLinearScaleMarker, new GaugeMeasure(14));
            ScaleObject.SetRelativeHeight(this.horizontalLinearScaleMarker, new GaugeMeasure(7));
            ScaleObject.SetLocation(this.verticalLinearScaleMarker, ScaleObjectLocation.Inside);
            ScaleObject.SetOffset(this.verticalLinearScaleMarker, new GaugeMeasure(0));
            ScaleObject.SetRelativeWidth(this.verticalLinearScaleMarker, new GaugeMeasure(14));
            ScaleObject.SetRelativeHeight(this.verticalLinearScaleMarker, new GaugeMeasure(7));

            //linear scale ticks and labels
            //this.horizontalLinearScale1.ClearValue(LinearScale.LabelOffsetProperty);
            this.horizontalLinearScale2.LabelOffset = new GaugeMeasure(0.09, GridUnitType.Star);
            this.verticalLinearScale1.LabelOffset = new GaugeMeasure(0.13, GridUnitType.Star);
            this.horizontalLinearScale1.MajorTickRelativeHeight = new GaugeMeasure(10);
            this.horizontalLinearScale1.MiddleTickRelativeHeight = new GaugeMeasure(5);
            this.horizontalLinearScale1.MinorTickRelativeHeight = new GaugeMeasure(5);
            this.verticalLinearScale1.MajorTickRelativeWidth = new GaugeMeasure(10);
            this.verticalLinearScale1.MiddleTickRelativeWidth = new GaugeMeasure(5);
            this.verticalLinearScale1.MinorTickRelativeWidth = new GaugeMeasure(5);

            //linear scale custom elements
            ScaleObject.SetRelativeHeight(this.horizontalScaleBorder, new GaugeMeasure(0.18, GridUnitType.Star));
            ScaleObject.SetRelativeWidth(this.verticalScaleBorder, new GaugeMeasure(0.18, GridUnitType.Star));

            //linear scale bar indicators
            this.horizontalBarIndicator.StartWidth = 0.09;
            this.verticalBarIndicator.StartWidth = 0.09;

            this.horizontalBarIndicator.ClearValue(BarIndicator.EmptyFillProperty);
            this.verticalBarIndicator.ClearValue(BarIndicator.EmptyFillProperty);
        }

        private void SetTouchAndOffice2013ThemeSpecificProperties(SolidColorBrush barIndicatorEmptyFill)
        {
            //radial scale
            this.scale.Radius = 0.9;
            this.scale.ClearValue(RadialScale.MajorTicksProperty);
            this.scale.ClearValue(RadialScale.MiddleTicksProperty);
            this.scale.ClearValue(RadialScale.MinorTicksProperty);
            this.scale.ClearValue(RadialScale.MajorTickRelativeWidthProperty);
            this.scale.ClearValue(RadialScale.MajorTickRelativeHeightProperty);
            this.scale.ClearValue(RadialScale.MajorTickRelativeWidthProperty);
            this.scale.ClearValue(RadialScale.MiddleTickRelativeHeightProperty);
            this.scale.ClearValue(RadialScale.MiddleTickRelativeWidthProperty);
            this.scale.MajorTickOffset = new GaugeMeasure(0);
            this.scale.MiddleTickOffset = new GaugeMeasure(0);
            this.scale.MinorTickOffset = new GaugeMeasure(0);
            this.scale.ClearValue(RadialScale.LabelOffsetProperty);

            //this.scale.LabelOffset = new GaugeMeasure(0.05, GridUnitType.Star);

            ScaleObject.SetOffset(this.radialBar, new GaugeMeasure(0.01, GridUnitType.Star));
            this.radialBar.StartWidth = 0.15;
            this.radialBar.EndWidth = 0.15;

            //range settings
            this.range1.StartWidth = this.range2.StartWidth = this.range3.StartWidth = 0.01;
            this.range1.EndWidth = this.range2.EndWidth = this.range3.EndWidth = 0.01;

            //linear scale markers
            ScaleObject.SetOffset(this.horizontalLinearScaleMarker, new GaugeMeasure(0));
            ScaleObject.SetRelativeWidth(this.horizontalLinearScaleMarker, new GaugeMeasure(20));
            ScaleObject.SetRelativeHeight(this.horizontalLinearScaleMarker, new GaugeMeasure(20));
            ScaleObject.SetLocation(this.horizontalLinearScaleMarker, ScaleObjectLocation.Outside);
            ScaleObject.SetOffset(this.verticalLinearScaleMarker, new GaugeMeasure(0));
            ScaleObject.SetRelativeWidth(this.verticalLinearScaleMarker, new GaugeMeasure(20));
            ScaleObject.SetRelativeHeight(this.verticalLinearScaleMarker, new GaugeMeasure(20));

            //linear scale custom elements
            ScaleObject.SetRelativeHeight(this.horizontalScaleBorder, new GaugeMeasure(0.14, GridUnitType.Star));
            ScaleObject.SetRelativeWidth(this.verticalScaleBorder, new GaugeMeasure(0.14, GridUnitType.Star));

            //linear scale ticks
            this.horizontalLinearScale1.ClearValue(LinearScale.MajorTickRelativeHeightProperty);
            this.horizontalLinearScale1.ClearValue(LinearScale.MiddleTickRelativeHeightProperty);
            this.horizontalLinearScale1.ClearValue(LinearScale.MinorTickRelativeHeightProperty);

            this.verticalLinearScale1.ClearValue(LinearScale.MajorTickRelativeWidthProperty);
            this.verticalLinearScale1.ClearValue(LinearScale.MiddleTickRelativeWidthProperty);
            this.verticalLinearScale1.ClearValue(LinearScale.MinorTickRelativeWidthProperty);

            //linear scale bar indicators
            this.horizontalBarIndicator.StartWidth = 0.1;
            this.verticalBarIndicator.StartWidth = 0.1;

            this.verticalBarIndicator.EmptyFill = barIndicatorEmptyFill;
            this.horizontalBarIndicator.EmptyFill = barIndicatorEmptyFill;
        }

#if WPF
        private void ResetTouchAndGreenAndOffice2013ThemeSpecificProperties()
        {
            //radial scale
            this.scale.ClearValue(RadialScale.MajorTickStepProperty);
            this.scale.ClearValue(RadialScale.RadiusProperty);
            this.scale.ClearValue(RadialScale.MajorTickRelativeHeightProperty);
            this.scale.ClearValue(RadialScale.MajorTickRelativeWidthProperty);
            this.scale.ClearValue(RadialScale.MiddleTickRelativeHeightProperty);
            this.scale.ClearValue(RadialScale.MiddleTickRelativeWidthProperty);
            this.scale.MajorTickOffset = new GaugeMeasure(-0.015, GridUnitType.Star);
            this.scale.MiddleTickOffset = new GaugeMeasure(-0.015, GridUnitType.Star);
            this.scale.MinorTickOffset = new GaugeMeasure(-0.015, GridUnitType.Star);
            this.scale.ClearValue(RadialScale.LabelOffsetProperty);

            ScaleObject.SetOffset(this.radialBar, new GaugeMeasure(0.25, GridUnitType.Star));
            this.radialBar.StartWidth = 0.1;
            this.radialBar.EndWidth = 0.1;

            //range settings
            this.range1.StartWidth = this.range2.StartWidth = this.range3.StartWidth = 0.01;
            this.range1.EndWidth = this.range2.EndWidth = this.range3.EndWidth = 0.01;

            //linear scale markers
            ScaleObject.SetOffset(this.horizontalLinearScaleMarker, new GaugeMeasure(-0.04, GridUnitType.Star));
            ScaleObject.SetRelativeWidth(this.horizontalLinearScaleMarker, new GaugeMeasure(0.03, GridUnitType.Star));
            ScaleObject.SetRelativeHeight(this.horizontalLinearScaleMarker, new GaugeMeasure(0.08, GridUnitType.Star));
            ScaleObject.SetLocation(this.horizontalLinearScaleMarker, ScaleObjectLocation.Inside);
            ScaleObject.SetOffset(this.verticalLinearScaleMarker, new GaugeMeasure(-0.04, GridUnitType.Star));
            ScaleObject.SetRelativeWidth(this.verticalLinearScaleMarker, new GaugeMeasure(0.08, GridUnitType.Star));
            ScaleObject.SetRelativeHeight(this.verticalLinearScaleMarker, new GaugeMeasure(0.03, GridUnitType.Star));

            //linear scale custom elements
            ScaleObject.SetRelativeHeight(this.horizontalScaleBorder, new GaugeMeasure(0.14, GridUnitType.Star));
            ScaleObject.SetRelativeWidth(this.verticalScaleBorder, new GaugeMeasure(0.14, GridUnitType.Star));

            //linear scale ticks
            this.horizontalLinearScale1.ClearValue(LinearScale.MajorTickRelativeHeightProperty);
            this.horizontalLinearScale1.ClearValue(LinearScale.MiddleTickRelativeHeightProperty);
            this.horizontalLinearScale1.ClearValue(LinearScale.MinorTickRelativeHeightProperty);

            this.verticalLinearScale1.ClearValue(LinearScale.MajorTickRelativeWidthProperty);
            this.verticalLinearScale1.ClearValue(LinearScale.MiddleTickRelativeWidthProperty);
            this.verticalLinearScale1.ClearValue(LinearScale.MinorTickRelativeWidthProperty);

            //linear scale bar indicators
            this.horizontalBarIndicator.StartWidth = 0.06;
            this.verticalBarIndicator.StartWidth = 0.06;

            this.horizontalBarIndicator.ClearValue(BarIndicator.EmptyFillProperty);
            this.verticalBarIndicator.ClearValue(BarIndicator.EmptyFillProperty);
        }
#endif

        private void Example_ThemeChanged(object sender, System.EventArgs e)
        {
            this.ApplyThemeSpecificSettings();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged += this.Example_ThemeChanged;
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationThemeManager.GetInstance().ThemeChanged -= this.Example_ThemeChanged;
        }
    }
}
