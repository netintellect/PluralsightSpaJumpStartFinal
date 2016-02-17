using Telerik.Windows.Controls;
using Telerik.Windows.Persistence;
using Telerik.Windows.Persistence.Services;
namespace Telerik.Windows.Examples.PersistenceFramework.DockingCustomSerialization
{
	public partial class Example : System.Windows.Controls.UserControl
	{
        System.IO.Stream stream;
		public Example()
		{
			InitializeComponent();

            // register the custom property provider for the RadDocking:
            ServiceProvider.RegisterPersistenceProvider<ICustomPropertyProvider>(typeof(RadDocking), new DockingCustomPropertyProvider());
			this.EnsureLoadState();
		}

        private void OnSave(object sender, System.Windows.RoutedEventArgs e)
        {
            PersistenceManager manager = new PersistenceManager();
            this.stream = manager.Save(this.Docking);
			this.EnsureLoadState();
		}

        private void OnLoad(object sender, System.Windows.RoutedEventArgs e)
        {
            this.stream.Position = 0L;
            PersistenceManager manager = new PersistenceManager();
            manager.Load(this.Docking, this.stream);
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
