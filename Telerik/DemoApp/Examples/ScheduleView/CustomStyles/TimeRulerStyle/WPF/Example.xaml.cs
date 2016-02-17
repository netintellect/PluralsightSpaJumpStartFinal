using System.Windows;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.ScheduleView.CustomStyles.TimeRulerStyle
{
    public partial class Example : UserControl
    {
        public Example()
        {
            this.InitializeComponent();

            this.Unloaded += this.OnExampleUnloaded;

            this.AddExpression_DarkResourcesToApplicationResources();
        }

        private void OnExampleUnloaded(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= this.OnExampleUnloaded;

            this.RemoveExpression_DarkResourcesFromApplicationResources();
        }
  
        private void AddExpression_DarkResourcesToApplicationResources()
        {
            foreach (var resourceDictionary in this.Resources.MergedDictionaries)
            {
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }
        }
        
        private void RemoveExpression_DarkResourcesFromApplicationResources()
        {
            foreach (var resourceDictionary in this.Resources.MergedDictionaries)
            {
                Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary);
            }
        }
    }
}