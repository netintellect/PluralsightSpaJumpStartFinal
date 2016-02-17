using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Infrastructure;
using Telerik.Windows.QuickStart.ViewModel;

namespace Telerik.Windows.QuickStart
{
    public class ViewBase : UserControl, INotifyUser, IView
    {
        public virtual void Notify(object param)
        {
            MessageBox.Show(param.ToString());
        }

        public virtual void OnNavigatedFrom(object parameter)
        {
        }

        public virtual void OnNavigatedTo(object parameter)
        {
        }
    }
}
