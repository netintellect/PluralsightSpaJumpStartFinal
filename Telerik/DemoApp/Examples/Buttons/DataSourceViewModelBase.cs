using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Buttons
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
                return "/Buttons;component/FirstLook/Data/{0}";
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
            Uri dataURI = new Uri(System.Windows.Browser.HtmlPage.Document.DocumentUri, string.Format(this.SilverlightPath, fileName));
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
            //System.Net.WebClient dataRetriever = sender as System.Net.WebClient;
            //dataRetriever.DownloadStringCompleted -= this.DownloadStringCompleted;

            //using (StringReader dataReader = new StringReader(e.Result))
            //{
            //    this.GetDataCompleted(this.ParseData(dataReader));
            //}

            StringReader dataReader = new StringReader(e.Result);
            GetDataCompleted(this.ParseData(dataReader));
        }
#endif
    }
}