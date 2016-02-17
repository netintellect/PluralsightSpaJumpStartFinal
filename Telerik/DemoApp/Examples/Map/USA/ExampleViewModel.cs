using System;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Map.USA
{
    public class ExampleViewModel : ViewModelBase
    {
#if SILVERLIGHT
        protected const string ShapeRelativeUriFormat = "DataSources/Geospatial/{0}.xml";
#else
        protected const string ShapeRelativeUriFormat = "/Map;component/Resources/{0}.xml";
#endif
        private Uri _mapSource;

        public ExampleViewModel()
        {
            this._mapSource = new Uri(string.Format(ShapeRelativeUriFormat, "UsaSimplified"), UriKind.Relative);
        }

        public Uri MapSource
        {
            get
            {
                return _mapSource;
            }
        }
    }
}
