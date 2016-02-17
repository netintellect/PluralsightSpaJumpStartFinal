using System;
using System.Collections;
using System.IO;
using System.Reflection;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples
{
    public abstract class DataSourceViewModelBase : ViewModelBase
    {
        protected const string silverlightPath = "DataSources/{0}";
        protected const string wpfPath = "/Map;component/DataSources/{0}";

        protected virtual void GetData(string fileName)
        {
#if WPF
            Uri uri = new Uri(string.Format(DataSourceViewModelBase.wpfPath, fileName), UriKind.RelativeOrAbsolute);
            System.Windows.Resources.StreamResourceInfo streamInfo = System.Windows.Application.GetResourceStream(uri);
            using (StreamReader fileReader = new StreamReader(streamInfo.Stream))
            {
                GetDataCompleted(this.ParseData(fileReader));
            }
#else
            Uri dataURI = new Uri(Telerik.Windows.Examples.Map.URIHelper.CurrentApplicationURL, string.Format(DataSourceViewModelBase.silverlightPath, fileName));
            System.Net.WebClient dataRetriever = new System.Net.WebClient();
            dataRetriever.DownloadStringCompleted += DownloadStringCompleted;
            dataRetriever.DownloadStringAsync(dataURI);
#endif
        }

        protected abstract void GetDataCompleted(IEnumerable data);

        protected abstract IEnumerable ParseData(TextReader dataReader);

        private void DownloadStringCompleted(object sender, System.Net.DownloadStringCompletedEventArgs e)
        {
            StringReader dataReader = new StringReader(e.Result);
            GetDataCompleted(this.ParseData(dataReader));
        }
    }
}
