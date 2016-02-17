using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using System.IO;
using System.Collections;

namespace Telerik.Windows.Examples.HeatMap
{
    public abstract class DataSourceViewModelBase : ViewModelBase
    {
        protected const string silverlightPath = "DataSources/{0}";
        protected const string wpfPath = "/HeatMap;component/DataSources/{0}";

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
            Uri dataURI = new Uri(Telerik.Windows.Examples.HeatMap.URIHelper.CurrentApplicationURL, string.Format(DataSourceViewModelBase.silverlightPath, fileName));
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
