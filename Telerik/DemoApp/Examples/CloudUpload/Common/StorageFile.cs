namespace Telerik.Windows.Examples.CloudUpload.Common
{
	public class StorageFile
	{
		public string Name { get; set; }
		public long Size { get; set; }

		public StorageFile(string name, long size)
		{
			this.Name = name;
			this.Size = size;
		}
	}
}
