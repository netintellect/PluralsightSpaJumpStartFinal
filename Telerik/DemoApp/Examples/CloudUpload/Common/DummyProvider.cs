using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telerik.Windows.Cloud;

namespace Telerik.Windows.Examples.CloudUpload.Common
{
	public class DummyProvider : ICloudUploadProvider
	{
		Random random = new Random();
		long uploadFilesCount = 0;

		public Task<object> UploadFileAsync(string fileName, Stream fileStream, CloudUploadFileProgressChanged uploadProgressChanged, CancellationToken cancellationToken)
		{
			return System.Threading.Tasks.Task.Factory.StartNew<object>(() => UploadFile(fileName, fileStream, uploadProgressChanged, cancellationToken), cancellationToken);
		}

		private object UploadFile(string fileName, Stream fileStream, CloudUploadFileProgressChanged uploadProgressChanged, CancellationToken cancellationToken)
		{
			this.uploadFilesCount++;
			if (uploadFilesCount % 10 == 0)
			{
				throw new Exception("Simulate upload failure.");
			}

			var fileLenght = fileStream.Length;
			var chunkSize = (int)Math.Min(100000, fileLenght);

			for (int i = 0; i < fileLenght; )
			{
				cancellationToken.ThrowIfCancellationRequested();
				uploadProgressChanged(i + chunkSize);
				Thread.Sleep(this.random.Next(200, 900));
				i += chunkSize;
			}
            lock (DummyStorage.StorageFiles)
            {
                DummyStorage.StorageFiles.Add(new StorageFile(fileName, fileLenght));
            }
			return fileName;
		}
	}
}
