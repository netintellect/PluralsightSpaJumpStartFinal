using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace Telerik.Windows.Examples.ImageEditor.Cropping.Views
{
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            BindingExpression binding = textBox.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }
    }
}