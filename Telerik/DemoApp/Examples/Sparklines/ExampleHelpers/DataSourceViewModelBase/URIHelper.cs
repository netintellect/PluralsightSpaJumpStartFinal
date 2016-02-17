using System;

namespace Telerik.Windows.Examples.Sparklines
{
    public static class URIHelper
    {
        public static Uri CurrentApplicationURL
        {
            get
            {
                return System.Windows.Browser.HtmlPage.Document.DocumentUri;
            }
        }
    }
}
