using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Examples.ChartView.RadarAnnotations.ViewModels;
using Telerik.Windows.Examples.ChartView.RadarAnnotations.Models;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.ChartView.RadarAnnotations
{
    public partial class Example : UserControl
    {
        RadialAxisGridLineAnnotation radialAxisGridlineAnnotation = new RadialAxisGridLineAnnotation();
        RadialAxisPlotBandAnnotation radialAxisPlotBandAnnotation = new RadialAxisPlotBandAnnotation();
        PolarCustomAnnotation customAnnotation = new PolarCustomAnnotation();
        RadarAnnotationsViewModel vm = new RadarAnnotationsViewModel();

        public Example()
        {
            InitializeComponent();
        }

        private void SolsticesandEquinoxesToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            RadToggleButton toggleButton = sender as RadToggleButton;
            this.UpdateAnnotations(toggleButton.Tag, true, vm.SolsticesAndEquinoxesData, radialAxisGridlineAnnotation);
        }

        private void SolsticesandEquinoxesToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RadToggleButton toggleButton = sender as RadToggleButton;
            this.UpdateAnnotations(toggleButton.Tag, false, vm.SolsticesAndEquinoxesData, radialAxisGridlineAnnotation);
        }

        private void SeasonsToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            RadToggleButton toggleButton = sender as RadToggleButton;
            this.UpdateAnnotations(toggleButton.Tag, true, vm.SeasonsData, radialAxisPlotBandAnnotation);
        }

        private void SeasonsToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RadToggleButton toggleButton = sender as RadToggleButton;
            this.UpdateAnnotations(toggleButton.Tag, false, vm.SeasonsData, radialAxisPlotBandAnnotation);
        }

        private void UpdateAnnotations(object tag, bool shouldBeAdded, ObservableCollection<AnnotationsData> data, PolarChartAnnotation annotation)
        {
            if (shouldBeAdded)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    var dataItem = data[i];
                    if (annotation is RadialAxisGridLineAnnotation)
                    {
                        string Month = (dataItem as SolsticesAndEquinoxesData).Month;
                        if (object.Equals(tag, Month))
                        {
                            annotation = new RadialAxisGridLineAnnotation()
                            {
                                Value = Month,
                                Stroke = new SolidColorBrush(Colors.Gray),
                                StrokeThickness = 2,
                                DashArray = new DoubleCollection() { 5, 2 }
                            };
                            customAnnotation = new PolarCustomAnnotation()
                            {
                                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                                VerticalOffset = 9,
                                ClipToPlotArea = false,
                                RadialValue = Month,
                                PolarValue = 24,
                                Content = (dataItem as SolsticesAndEquinoxesData).Event,
                                ContentTemplate = this.Resources["customAnnotationContentTemplate"] as DataTemplate
                            };
                            this.polarChart.Annotations.Add(annotation);
                            this.polarChart.Annotations.Add(customAnnotation);
                            break;
                        }
                    }
                    else if (object.Equals(tag, (dataItem as SeasonsData).Event))
                    {
                        annotation = new RadialAxisPlotBandAnnotation()
                        {
                            From = (dataItem as SeasonsData).StartMonth,
                            To = (dataItem as SeasonsData).EndMonth,
                            Fill = new SolidColorBrush((Color)Telerik.Windows.Controls.ColorEditor.ColorConverter.ColorFromString("#50D6D4D4"))
                        };
                        this.polarChart.Annotations.Add(annotation);
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < data.Count; i++)
                {
                    var dataItem = data[i];
                    if (annotation is RadialAxisGridLineAnnotation)
                    {
                        string Month = (dataItem as SolsticesAndEquinoxesData).Month;
                        if (object.Equals(tag, Month))
                        {
                            polarChart.Annotations.Remove(polarChart.Annotations.Select(a => a).Where(a => a is RadialAxisGridLineAnnotation).Where(a => (a as RadialAxisGridLineAnnotation).Value.Equals(Month)).ToList()[0]);
                            polarChart.Annotations.Remove(polarChart.Annotations.Select(a => a).Where(a => a is PolarCustomAnnotation).Where(a => (a as PolarCustomAnnotation).RadialValue.Equals(Month)).ToList()[0]);
                            break;
                        }
                    }
                    else if (object.Equals(tag, (dataItem as SeasonsData).Event))
                    {
                        string StartMonth = (dataItem as SeasonsData).StartMonth;
                        polarChart.Annotations.Remove(polarChart.Annotations.Select(a => a).Where(a => a is RadialAxisPlotBandAnnotation).Where(a => (a as RadialAxisPlotBandAnnotation).From.Equals(StartMonth)).ToList()[0]);
                        break;
                    }
                }
            }
        }
    }
}
