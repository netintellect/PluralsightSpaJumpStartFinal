using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls.Charting;
using Telerik.Windows.Controls;
using System.Windows.Threading;
using System.Collections.Generic;
#if WPF
using SelectionChangedEventArgs = System.Windows.Controls.SelectionChangedEventArgs;
#elif SILVERLIGHT
using SelectionChangedEventArgs = Telerik.Windows.Controls.SelectionChangedEventArgs;
#endif
namespace Telerik.Windows.Examples.Chart.CustomPalette
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        private BrushCollection _palette;
        private List<Color> _customColors;
        private readonly Color _noColor = Color.FromArgb(255, 0, 0, 0);

        public BrushCollection Palette 
        {
            get
            {
                return this._palette;
            }
            set
            {
                this._palette = value;
            }
        }

        public List<Color> CustomColors 
        {
            get
            {
                return this._customColors;
            }
            set
            {
                this._customColors = value;
            }
        }

        private double[] data = new double[] { 2, 3, 4, 5, 6, 7, 8, 9 };

        public Example()
        {
            InitializeComponent();

            BrushCollection paletteColors = new BrushCollection();
            paletteColors.Add(new SolidColorBrush(ColorPaletteBase.HexStringToColor("#FF214093")));
            paletteColors.Add(new SolidColorBrush(ColorPaletteBase.HexStringToColor("#FF2294D2")));
            paletteColors.Add(new SolidColorBrush(ColorPaletteBase.HexStringToColor("#FF309C8C")));
            paletteColors.Add(new SolidColorBrush(ColorPaletteBase.HexStringToColor("#FF2FA64A")));
            paletteColors.Add(new SolidColorBrush(ColorPaletteBase.HexStringToColor("#FFFBD00F")));
            paletteColors.Add(new SolidColorBrush(ColorPaletteBase.HexStringToColor("#FFF16B24")));
            paletteColors.Add(new SolidColorBrush(ColorPaletteBase.HexStringToColor("#FFAE1F25")));
            paletteColors.Add(new SolidColorBrush(ColorPaletteBase.HexStringToColor("#FF952168")));
            
            this.Palette = paletteColors;
            this.CustomColors = this.GetCustomColors();
        }

        private void Example_Loaded(object sender, RoutedEventArgs e)
        {
            PaletteListBox.DataContext = this;

            PaletteListBox.MinHeight = 20;

            foreach (Brush item in this.Palette)
            {
                RadChart1.PaletteBrushes.Add(item);
            }

            this.RadChart1.PaletteBrushesUseSolidColors = true; 
            
            this.RadChart1.DefaultSeriesDefinition.LegendDisplayMode = LegendDisplayMode.DataPointLabel;

            this.RadChart1.ItemsSource = data;
            this.PaletteListBox.ItemsSource = this.Palette;
            this.CustomColorSelector.MainPaletteItemsSource = this.CustomColors;
        }

        private void RadColorSelector_SelectedColorChanged(object sender, EventArgs e)
        {
            Color selectedColor = ((RadColorSelector)sender).SelectedColor;

            if (selectedColor == _noColor)
                return;

            SolidColorBrush selectedBrush = new SolidColorBrush(selectedColor);
            
            this.Palette.Insert(0, selectedBrush);
            RadChart1.PaletteBrushes.Insert(0, selectedBrush);

            if (this.Palette.Count > 8)
            {
                this.Palette.RemoveAt(8);
                RadChart1.PaletteBrushes.RemoveAt(8);
            };

            this.PaletteListBox.ItemsSource = null;
            this.PaletteListBox.ItemsSource = this.Palette;
            
            RadChart1.Rebind();
        }

        private void PaletteListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(250);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            ((DispatcherTimer)sender).Stop();
            SolidColorBrush selectedColorBrush = PaletteListBox.SelectedItem as SolidColorBrush;
            this.Palette.Remove(selectedColorBrush);

            this.PaletteListBox.ItemsSource = null;
            this.PaletteListBox.ItemsSource = this.Palette;

            RadChart1.PaletteBrushes.Remove(selectedColorBrush);
            RadChart1.Rebind();
        }

        private void ChartSeriesDefinitionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.RadChart1 == null)
                return;

            RadChart1.DefaultSeriesDefinition = (ISeriesDefinition)ChartSeriesDefinitionComboBox.SelectedItem;
            RadChart1.Rebind();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Palette.Clear();
            this.PaletteListBox.ItemsSource = null;
            this.RadChart1.PaletteBrushes.Clear();
            this.RadChart1.Rebind();
        }

        private void RepeatBrushesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (this.RadChart1 != null)
            {
                this.RadChart1.PaletteBrushesRepeat = (bool)(e.OriginalSource as CheckBox).IsChecked;
                this.RadChart1.Rebind();
            }
        }

        private List<Color> GetCustomColors()
        {
            List<Color> colors = new List<Color>();

            colors.Add(ColorPaletteBase.HexStringToColor("#FF050608"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF333333"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF676767"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF999999"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFCDCBCC"));

            colors.Add(ColorPaletteBase.HexStringToColor("#FF392E8C"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF493F98"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF514DA1"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF5B54A4"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF6B5AA8"));

            colors.Add(ColorPaletteBase.HexStringToColor("#FF26357A"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF233D94"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF2D4BA1"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF3857A7"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF3E5FAC"));

            colors.Add(ColorPaletteBase.HexStringToColor("#FF1E82B6"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF2393D2"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF34A3DB"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF50AEE1"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF6FBCE8"));

            colors.Add(ColorPaletteBase.HexStringToColor("#FF298175"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF309B8B"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF32AF9D"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF45C0AE"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF64C6B9"));

            colors.Add(ColorPaletteBase.HexStringToColor("#FF298D44"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF31A449"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF3CB54B"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF55B947"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF67BC45"));

            colors.Add(ColorPaletteBase.HexStringToColor("#FFE9BB1F"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFFECF0F"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFFDD528"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFFBDB4A"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFFCE46A"));

            colors.Add(ColorPaletteBase.HexStringToColor("#FFDB6327"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFF06C22"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFF37521"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFF58229"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFF68C40"));

            colors.Add(ColorPaletteBase.HexStringToColor("#FF991B1E"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFAD1E22"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFC52026"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFDA1F26"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFED1B24"));

            colors.Add(ColorPaletteBase.HexStringToColor("#FF801C5A"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FF942067"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFA92176"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFBE1B84"));
            colors.Add(ColorPaletteBase.HexStringToColor("#FFD3118C"));

            return colors;
        }
    }
}
