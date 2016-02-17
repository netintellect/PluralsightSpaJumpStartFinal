using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections;
using Telerik.Windows.Controls;
using System.Windows.Media.Animation;
using Examples.OutlookBar.CS;

namespace Telerik.Windows.Examples.OutlookBar.MinimizedMode
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();

			ContactsListBox.ItemsSource = new Contacts();
            MessagesTreeView.ItemsSource = new MailMessages();
		}

        private void RadNumericUpDown_ValueChanged(object sender, RadRangeBaseValueChangedEventArgs e)
        {
            if (outlookBar != null)
            {
                outlookBar.MinimizedWidth = (double)e.NewValue;
            }
        }

        private void RadNumericUpDown_ValueChanged_1(object sender, RadRangeBaseValueChangedEventArgs e)
        {
            if (outlookBar != null)
            {
                outlookBar.MinimizedWidthThreshold = (double)e.NewValue;
            }
        }
	}
}