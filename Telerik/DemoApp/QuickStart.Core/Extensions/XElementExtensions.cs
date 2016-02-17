using System.Collections.Generic;
using System.Xml.Linq;

namespace Telerik.Windows.QuickStart
{
	public static class XElementExtensions
	{
		public static string GetAttribute(this XElement element, string name, string defaultValue)
		{
			var attribute = element.Attribute(name);
			return attribute == null ? defaultValue : attribute.Value;
		}

		public static bool GetAttribute(this XElement element, string name, bool defaultValue)
		{
			var attribute = element.Attribute(name);
			if (attribute != null)
			{
				bool result;
				if (bool.TryParse(attribute.Value, out result))
				{
					return result;
				}
			}
			return defaultValue;
		}
	}
}