using System;
using System.Linq;
using Telerik.Windows.Documents.FormatProviders.Html.Parsing;
using Telerik.Windows.Controls.QuickStart;

namespace Telerik.Windows.QuickStart
{
    /// <summary>
    /// This class prevents the compiler from optimizing some of the references and thus exceptions like 
    /// "could not find some assembly" are avoided
    /// </summary>
    public class CompilerOptimizationFixer
    {
        // used for the Telerik.Windows.Documents.FormatProviders.Html reference
        private static readonly HtmlParser dummyParser = new HtmlParser();

        // used for the QuickStart.Common.WPF reference
        private static readonly HeaderedContentControl dummyControl = new HeaderedContentControl();
    }
}
