using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.OrgChart.ViewModel
{
    public class DropDialogViewModel
    {
        public string Header { get; set; }
        public string DropMessage { get; set; }
        public DelegateCommand OkCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
    }
}
