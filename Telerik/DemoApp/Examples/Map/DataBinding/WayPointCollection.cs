using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Resources;
using System.Xml.Linq;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Map.DataBinding
{
    /// <summary>
    /// Represents collection of the way points.
    /// </summary>
    public class WayPointCollection : LocationCollection 
    {
        public WayPointCollection()
        {
        }

        public bool IsDataSource
        {
            get
            {
                return true;
            }
            set
            {
                if (value)
                {
                    this.Load();
                }
            }
        }

        /// <summary>
        /// Load way points from the resource.
        /// </summary>
        public void Load()
        {
            StreamResourceInfo streamInfo = Application.GetResourceStream(
                new Uri("/Map;component/DataBinding/WayPoints.xml", UriKind.RelativeOrAbsolute));
            StreamReader reader = new StreamReader(streamInfo.Stream);
            XDocument document = XDocument.Load(reader);
            XElement root = document.FirstNode as XElement;
            if (root != null)
            {
                foreach (XNode child in root.Nodes())
                {
                    XElement element = child as XElement;
                    Location location = new Location(
                        this.GetDoubleAttribute(element, "Latitude", double.PositiveInfinity),
                        this.GetDoubleAttribute(element, "Longitude", double.PositiveInfinity));
                    this.Add(location);
                }
            }
            reader.Close();
        }

        private double GetDoubleAttribute(XElement element, string attributeName, double defaultValue)
        {
            XAttribute attribute = element.Attribute(attributeName);
            if (attribute != null)
            {
                defaultValue = double.Parse(attribute.Value, CultureInfo.InvariantCulture);
            }

            return defaultValue;
        }

    }
}
