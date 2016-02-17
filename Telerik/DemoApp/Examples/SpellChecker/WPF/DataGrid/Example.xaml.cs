using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.SpellChecker.SampleData;

namespace Telerik.Windows.Examples.SpellChecker.DataGrid
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

        private void spellcheckRTBButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridSpellCheckHelper.CheckChildControl(this.dataGrid, "radRichTextBox2");
        }
    }
}
