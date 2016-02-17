using Telerik.Windows.Persistence;
using Telerik.Windows.Persistence.Storage;
namespace Telerik.Windows.Examples.PersistenceFramework.FirstLook
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		System.IO.Stream stream;
		public Example()
		{
			InitializeComponent();
			this.EnsureLoadState();
		}

		private void OnSave(object sender, System.Windows.RoutedEventArgs e)
		{
			if (this.useIsolatedStorage.IsChecked == true)
			{
				IsolatedStorageProvider isoStorageProvider = new IsolatedStorageProvider();
				isoStorageProvider.SaveToStorage();
			}
			else
			{
				PersistenceManager manager = new PersistenceManager();
				this.stream = manager.Save(this.Content);
				this.EnsureLoadState();
			}
		}

		private void OnLoad(object sender, System.Windows.RoutedEventArgs e)
		{
			if (this.useIsolatedStorage.IsChecked == true)
			{
				IsolatedStorageProvider isoStorageProvider = new IsolatedStorageProvider();
				isoStorageProvider.LoadFromStorage();
			}
			else
			{
				this.stream.Position = 0L;
				PersistenceManager manager = new PersistenceManager();
				manager.Load(this.Content, this.stream);
				this.EnsureLoadState();
			}
		}

		private void OnUseStreamChecked(object sender, System.Windows.RoutedEventArgs e)
		{
			this.EnsureLoadState();
		}

		private void OnUseIsolatedStorageChecked(object sender, System.Windows.RoutedEventArgs e)
		{
			if (this.buttonLoad != null)
				this.buttonLoad.IsEnabled = true;
		}

		private bool CanLoad()
		{
			return this.stream != null && this.stream.Length > 0;
		}

		private void EnsureLoadState()
		{
			if (this.buttonLoad != null)
				this.buttonLoad.IsEnabled = this.CanLoad();
		}
	}
}
