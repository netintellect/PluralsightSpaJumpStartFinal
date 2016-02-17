namespace Telerik.Windows.QuickStart
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public static class AssemblyHelper
    {
        public static Stream GetResourceStreamFromAssembly(Assembly assembly, string filename)
        {
            string uri = string.Format("/{0};component/{1}", assembly.GetName().Name, filename);
            return System.Windows.Application.GetResourceStream(
                new Uri(uri, UriKind.Relative)).Stream;
        }

        public static string GetStringFromStream(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static IEnumerable<string> ParseReferencesFromContent(string content)
        {
            IEnumerable<string> result = ParseContent(content);
            return result;
        }
        

        public static IEnumerable<string> ParseTelerikReferencesFromContent(string content)
        {
            string[] result = ParseContent(content);
            var telerikAssemblies = result.Where(IsStringTelerikAssemblyName).ToArray();

            for(int i = 0 ; i < telerikAssemblies.Length; i++)
            {
                if (telerikAssemblies[i].Contains(","))
                {
                    //assembly is fully named
                    telerikAssemblies[i] = telerikAssemblies[i].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                }
            }
            return telerikAssemblies;
        }

        public static bool IsStringTelerikAssemblyName(string content)
        {
            return content.StartsWith("Telerik");
        }

        private static string[] ParseContent(string content)
        {
            string[] splitContent = content.Split("\n\r\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < splitContent.Length; i++)
            {
                splitContent[i] = splitContent[i].Trim();
            }
            return splitContent;
        }

    }
}
