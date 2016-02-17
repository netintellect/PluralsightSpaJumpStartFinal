using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.QuickStart
{
    public static class ModelExtensions
    {
        public static bool IsTouchExample(this IExampleInfo exampleInfo)
        {
            return exampleInfo.Mode == Enums.Mode.Touch || exampleInfo.Mode == Enums.Mode.Both;
        }

        public static bool IsDesktopExample(this IExampleInfo exampleInfo)
        {
            return exampleInfo.Mode == Enums.Mode.Desktop || exampleInfo.Mode == Enums.Mode.Both;
        }

        public static bool IsTouchAndDesktopExample(this IExampleInfo exampleInfo)
        {
            return exampleInfo.IsDesktopExample() && exampleInfo.IsTouchExample();
        }

        public static IEnumerable<IExampleInfo> FilterTouchExamples(this IEnumerable<IExampleInfo> exampleInfos)
        {
            return exampleInfos.Where(IsTouchExample);
        }

        public static IEnumerable<IExampleInfo> FilterNonTouchExamples(this IEnumerable<IExampleInfo> exampleInfos)
        {
            return exampleInfos.Where(IsDesktopExample);
        }
    }
}
