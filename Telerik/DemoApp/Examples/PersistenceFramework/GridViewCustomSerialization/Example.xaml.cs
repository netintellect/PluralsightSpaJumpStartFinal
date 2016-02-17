using Telerik.Windows.Persistence;
using Telerik.Windows.Persistence.Services;
using Telerik.Windows.Controls;
namespace Telerik.Windows.Examples.PersistenceFramework.GridViewCustomSerialization
{
	public partial class Example : System.Windows.Controls.UserControl
	{
        System.IO.Stream stream;
		public Example()
		{
			InitializeComponent();

            // register the custom property provider for the RadGridView:
            ServiceProvider.RegisterPersistenceProvider<ICustomPropertyProvider>(typeof(RadGridView), new GridViewCustomPropertyProvider());
            this.DataContext = ExamplesDB.GetCustomers();
			this.EnsureLoadState();
		}

        private void OnSave(object sender, System.Windows.RoutedEventArgs e)
        {
            PersistenceManager manager = new PersistenceManager();
            this.stream = manager.Save(this.gridView);
			this.EnsureLoadState();
        }

        private void OnLoad(object sender, System.Windows.RoutedEventArgs e)
        {
            this.stream.Position = 0L;
            PersistenceManager manager = new PersistenceManager();
            manager.Load(this.gridView, this.stream);
			this.EnsureLoadState();
        }
		private bool CanLoad()
		{
			return this.stream != null && this.stream.Length > 0;
		}

		private void EnsureLoadState()
		{
			this.buttonLoad.IsEnabled = this.CanLoad();
		}
	}
}
