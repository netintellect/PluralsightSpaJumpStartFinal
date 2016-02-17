using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.SpellChecker.SampleData;

namespace Telerik.Windows.Examples.SpellChecker.RadGridView
{
    public partial class Example : UserControl
    {
        public Example()
        {
            // This method is used only to work around limitations for using MEF in Examples.
            ExamplesSpellCheckersManager.RegisterSpellCheckers();
            RadSpellChecker.WindowSettings.Theme = StyleManager.ApplicationTheme;

            InitializeComponent();

            this.DataContext = new ExamplesDataContext().Employees;
        }

        private void spellcheckRRTBButton_Click(object sender, RoutedEventArgs e)
        {
            RadGridViewSpellCheckHelper.CheckChildControl(this.radGridView, "radRichTextBox2");
        }
    }
}
