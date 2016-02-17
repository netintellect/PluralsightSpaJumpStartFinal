using System;
using System.Collections;
using System.IO;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ChartView
{
    public abstract class DataSourceViewModelBase : ViewModelBase
    {
        protected virtual string SilverlightPath
        {
            get
            {
                return "DataSources/{0}";
            }
        }

        protected virtual string WpfPath
        {
            get
            {
                return "/ChartView;component/DataSources/{0}";
            }
        }

        protected virtual void GetData(string fileName)
        {
#if WPF
            Uri uri = new Uri(string.Format(this.WpfPath, fileName), UriKind.RelativeOrAbsolute);
            System.Windows.Resources.StreamResourceInfo streamInfo = System.Windows.Application.GetResourceStream(uri);
            using (StreamReader fileReader = new StreamReader(streamInfo.Stream))
            {
                this.GetDataCompleted(this.ParseData(fileReader));
            }
#else
            Uri dataURI = new Uri(Telerik.Windows.Examples.ChartView.URIHelper.CurrentApplicationURL, string.Format(this.SilverlightPath, fileName));
            System.Net.WebClient dataRetriever = new System.Net.WebClient();
            dataRetriever.DownloadStringCompleted += this.DownloadStringCompleted;
            dataRetriever.DownloadStringAsync(dataURI);
#endif
        }

        protected abstract void GetDataCompleted(IEnumerable data);

        protected abstract IEnumerable ParseData(TextReader dataReader);

#if SILVERLIGHT
        private void DownloadStringCompleted(object sender, System.Net.DownloadStringCompletedEventArgs e)
        {
            System.Net.WebClient dataRetriever = sender as System.Net.WebClient;
            dataRetriever.DownloadStringCompleted -= this.DownloadStringCompleted;

            using (StringReader dataReader = new StringReader(e.Result))
            {
                this.GetDataCompleted(this.ParseData(dataReader));
            }
        }
#endif
    }
}

