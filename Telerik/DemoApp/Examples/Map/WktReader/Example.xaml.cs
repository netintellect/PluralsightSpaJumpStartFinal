using System;
using System.Net;
using System.Windows.Controls;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Map.WktReader
{
    public partial class Example : UserControl
    {
#if SILVERLIGHT
        public Example()
        {
            InitializeComponent();

            this.GetVEServiceKey();
        }

        private void GetVEServiceKey()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            Uri keyURI = new Uri(URIHelper.CurrentApplicationURL, "VEKey.txt");

            wc.DownloadStringAsync(keyURI);
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.InitializeBingMapProvider(e.Result);
        }
#else
        public Example()
        {
            InitializeComponent();

            this.InitializeBingMapProvider(BingMapHelper.VEKey);
        }
#endif

        private void InitializeBingMapProvider(string VEKey)
        {
            if (string.IsNullOrEmpty(VEKey))
                return;

            this.RadMap1.Provider = new BingMapProvider(MapMode.Aerial, true, VEKey);
        }
    }
}
