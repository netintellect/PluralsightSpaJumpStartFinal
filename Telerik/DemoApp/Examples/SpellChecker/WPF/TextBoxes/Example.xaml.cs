using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.SpellChecker.TextBoxes
{
    public partial class Example : UserControl
    {
        public Example()
        {
            // This method is used only to work around limitations for using MEF in Examples.
            ExamplesSpellCheckersManager.RegisterSpellCheckers();
            RadSpellChecker.WindowSettings.Theme = StyleManager.ApplicationTheme;

            InitializeComponent();
        }

        private void buttonCheckTextBox_Click(object sender, RoutedEventArgs e)
        {
            RadSpellChecker.Check(this.textBox, SpellCheckingMode.WordByWord);
        }

        private void buttonCheckAllTextBox_Click(object sender, RoutedEventArgs e)
        {
            RadSpellChecker.Check(this.textBox, SpellCheckingMode.AllAtOnce);
        }

        private void buttonCheckRichTextBox_Click(object sender, RoutedEventArgs e)
        {
            RadSpellChecker.Check(this.richTextBox, SpellCheckingMode.WordByWord);
        }

        private void buttonCheckAllRichTextBox_Click(object sender, RoutedEventArgs e)
        {
            RadSpellChecker.Check(this.richTextBox, SpellCheckingMode.AllAtOnce);
        }

        private void buttonCheckRadRichTextBox_Click(object sender, RoutedEventArgs e)
        {
            RadSpellChecker.Check(this.radRichTextBox, SpellCheckingMode.WordByWord);
        }

        private void buttonCheckAllRadRichTextBox_Click(object sender, RoutedEventArgs e)
        {
            RadSpellChecker.Check(this.radRichTextBox, SpellCheckingMode.AllAtOnce);
        }
    }
}
