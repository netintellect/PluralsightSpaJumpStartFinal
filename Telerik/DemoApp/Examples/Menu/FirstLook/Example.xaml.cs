using Telerik.Windows.Controls;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Menu.FirstLook
{
	public partial class Example
	{
		
		public Example()
		{
            InitializeComponent();
		}

	}

    public class ViewModel : ViewModelBase
    {
        private SolidColorBrush menuColor = new SolidColorBrush(Colors.White);
        private double menuOpacity = 1;
        public SolidColorBrush MenuColor
        {
            get { return this.menuColor; }
            set
            {
                this.menuColor = value;
                this.OnPropertyChanged("MenuColor");
            }
        }
        public double MenuOpacity
        {
            get { return this.menuOpacity; }
            set
            {
                this.menuOpacity = value;
                this.OnPropertyChanged("MenuOpacity");
            }
        }
    }
}