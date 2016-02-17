using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Telerik.Windows.QuickStart
{
    public class ResourceBox : ListBox
    {
		protected override void OnItemsSourceChanged(System.Collections.IEnumerable oldValue, System.Collections.IEnumerable newValue)
		{
            this.SelectFirstItemIfPossible();
		}

        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.SelectFirstItemIfPossible();
        }
  
        private void SelectFirstItemIfPossible()
        {
            if (this.Items.Count > 0)
            {
                this.SelectedItem = this.Items[0];
            }
        }
    }
}
