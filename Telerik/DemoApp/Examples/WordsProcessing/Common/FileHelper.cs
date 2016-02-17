using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Microsoft.Win32;
using Telerik.Windows.Documents.Common.FormatProviders;
using Telerik.Windows.Documents.Flow.FormatProviders.Docx;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.FormatProviders.Rtf;
using Telerik.Windows.Documents.Flow.FormatProviders.Txt;
using Telerik.Windows.Documents.Flow.Model;
using Telerik.Windows.Documents.Flow.FormatProviders.Pdf;

namespace Telerik.Windows.Examples.WordsProcessing.Common
{
    public static class FileHelper
    {
        private static readonly string SampleDataFolder = "SampleData/";

        public static bool SaveDocument(RadFlowDocument document, string selectedFormat)
        {
            IFormatProvider<RadFlowDocument> formatProvider = null;
            switch (selectedFormat)
            {
                case "Docx":
                    formatProvider = new DocxFormatProvider();
                    break;
                case "Rtf":
                    formatProvider = new RtfFormatProvider();
                    break;
                case "Html":
                    formatProvider = new HtmlFormatProvider();
                    break;
                case "Txt":
                    formatProvider = new TxtFormatProvider();
                    break;
                case "Pdf":
                    formatProvider = new PdfFormatProvider();
                    break;
            }

            if (formatProvider == null)
            {
                return false;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = String.Format("{0} files|*{1}|All files (*.*)|*.*",
                selectedFormat,
                formatProvider.SupportedExtensions.First());
            dialog.FilterIndex = 1;

            if (dialog.ShowDialog() == true)
            {
                using (var stream = dialog.OpenFile())
                {
                    formatProvider.Export(document, stream);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public static Stream GetSampleResourceStream(string resource)
        {
            var streamInfo = Application.GetResourceStream(GetResourceUri(SampleDataFolder + resource));
            if (streamInfo != null)
            {
                return streamInfo.Stream;
            }

            return null;
        }

        private static Uri GetResourceUri(string resource)
        {
            AssemblyName assemblyName = new AssemblyName(typeof(FileHelper).Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);

            return resourceUri;
        }
    }
}