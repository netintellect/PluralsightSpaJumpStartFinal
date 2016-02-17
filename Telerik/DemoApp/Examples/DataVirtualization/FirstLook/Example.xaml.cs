namespace Telerik.Windows.Examples.DataVirtualization.FirstLook
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example
    {
        public Example()
        {
			this.InitializeComponent();

            DataContext = new ExamplesDataContext();
		}
    }
}
