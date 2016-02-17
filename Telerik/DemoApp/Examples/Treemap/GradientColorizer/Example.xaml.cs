using System.Globalization;
using System.Threading;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.Treemap.GradientColorizer
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        public Example()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            InitializeComponent();
        }
    }
}
