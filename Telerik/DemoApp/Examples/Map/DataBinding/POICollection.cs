using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Resources;
using System.Xml.Linq;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Map.DataBinding
{
    public class POICollection : ObservableCollection<PointOfInterest>
    {
        public POICollection()
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
                new Uri("/Map;component/DataBinding/PointsOfInterest.xml", UriKind.RelativeOrAbsolute));
            StreamReader reader = new StreamReader(streamInfo.Stream);
            XDocument document = XDocument.Load(reader);
            XElement root = document.FirstNode as XElement;
            if (root != null)
            {
                foreach (XNode child in root.Nodes())
                {
                    XElement element = child as XElement;
                    PointOfInterest poi = new PointOfInterest();
                    poi.Location = this.GetLocation(element, "Location");
                    poi.Title = this.GetString(element, "Title");
                    poi.Description = this.GetString(element, "Description");
                    poi.ImageUri = this.GetString(element, "ImageUri");
                    this.Add(poi);
                }
            }
            reader.Close();
        }

        private XElement GetChildByName(XElement element, string nodeName)
        {
            for (element = element.FirstNode as XElement;
                element != null;
                element = element.NextNode as XElement)
            {
                if (element.Name.LocalName == nodeName)
                {
                    return element;
                }
            }

            return null;
        }

        private Location GetLocation(XElement element, string elementName)
        {
            Location location = Location.Empty;
            XElement child = this.GetChildByName(element, elementName);
            if (child != null)
            {
                location = Location.Parse(child.Value);
            }

            return location;
        }

        private string GetString(XElement element, string elementName)
        {
            string value = string.Empty;
            XElement child = this.GetChildByName(element, elementName);
            if (child != null)
            {
                value = child.Value;
            }

            return value;
        }
    }
}
