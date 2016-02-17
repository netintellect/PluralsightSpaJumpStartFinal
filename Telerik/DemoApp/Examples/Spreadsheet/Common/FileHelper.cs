using System;
using System.Linq;
using System.Reflection;

namespace Telerik.Windows.Examples.Spreadsheet.Common
{
    public static class FileHelper
    {
        public static Uri GetResourceUri(string resource, Type example)
        {
            AssemblyName assemblyName = new AssemblyName(example.Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);

            return resourceUri;
        }
    }
}