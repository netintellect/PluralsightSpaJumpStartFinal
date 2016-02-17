using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Telerik.Windows.Examples.MaskedInput
{
    public static class HelperClass
    {
        public static IEnumerable GetCultures()
        {
            List<CultureInfo> cultures = new List<CultureInfo>();

            cultures.Add(new CultureInfo("en-US"));
            cultures.Add(new CultureInfo("de-DE"));
            cultures.Add(new CultureInfo("fr-FR"));
            cultures.Add(new CultureInfo("bg-BG"));
            cultures.Add(new CultureInfo("es-ES"));
            cultures.Add(new CultureInfo("ja-JP"));
            cultures.Add(new CultureInfo("ru-RU"));
            cultures.Add(new CultureInfo("zh-HK"));

            return cultures;
        }


        public static IEnumerable GetEnumNames(Type type)
        {
            return type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).Select((FieldInfo x) => Enum.Parse(type, x.Name, true));
        }
    }
}
