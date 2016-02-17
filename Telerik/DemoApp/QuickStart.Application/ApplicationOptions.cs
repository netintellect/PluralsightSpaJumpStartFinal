using System;
using System.Linq;

namespace Telerik.Windows.QuickStart
{
    public static class ApplicationOptions
    {
        static ApplicationOptions()
        {
            DefaultCodeViewerLanguage = CodeViewerLanguages.CSharp;
        }

        public static CodeViewerLanguages DefaultCodeViewerLanguage { get; set; }
    }

    public enum CodeViewerLanguages
    {
    	CSharp,
        VB 
    };
}
