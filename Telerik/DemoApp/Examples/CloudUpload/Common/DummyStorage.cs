using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.CloudUpload.Common
{
	public static class DummyStorage
	{
		public static ObservableCollection<StorageFile> StorageFiles { get; private set; }

		static DummyStorage()
		{
			StorageFiles = new ObservableCollection<StorageFile>();
		}
	}
}
