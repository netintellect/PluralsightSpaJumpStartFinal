using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using Telerik.Windows.Persistence.Services;
using System;

namespace Telerik.Windows.Examples.PersistenceFramework.DockingCustomSerialization
{
    public class DockingCustomPropertyProvider : ICustomPropertyProvider
    {
        public CustomPropertyInfo[] GetCustomProperties()
        {
            // Create two custom properties to serialize the Layout of the RadDocking and the Content of the RadPanes
            return new CustomPropertyInfo[] 
            {
                new CustomPropertyInfo("Layout", typeof(string)),
                new CustomPropertyInfo("Content", typeof(List<PaneProxy>)) { AllowCreateInstance =false, TreatAsUI = false},
            };
        }

        public void InitializeObject(object context)
        {
        }

        public object InitializeValue(CustomPropertyInfo customPropertyInfo, object context)
        {
            if (customPropertyInfo.Name == "Content")
            {
                // See remarks in ProvideValue method:
                // provide the values on which the saved properties will be restored upon
                RadDocking docking = context as RadDocking;
                List<PaneProxy> proxies = new List<PaneProxy>();
                foreach (RadPane pane in this.GetOrderedPanes(docking).ToArray())
                {
                    proxies.Add(new PaneProxy() { Content = pane.Content });
                }
                return proxies;
            }
            return null;
        }

        public object ProvideValue(CustomPropertyInfo customPropertyInfo, object context)
        {
            RadDocking docking = context as RadDocking;
            if (customPropertyInfo.Name == "Layout")
            {
                // let the RadDocking save the layout of the Panes:
                return this.SaveLayoutAsString(docking);
            }
            else if (customPropertyInfo.Name == "Content")
            {
                // create proxies for all of the Panes and save their content
                IEnumerable<RadPane> panes = this.GetOrderedPanes(docking);
                List<PaneProxy> proxies = new List<PaneProxy>();
                foreach (RadPane pane in panes)
                {
                    proxies.Add(new PaneProxy() { Content = pane.Content });
                }
                return proxies;
            }
            return null;
        }

        public void RestoreValue(CustomPropertyInfo customPropertyInfo, object context, object value)
        {
            if (customPropertyInfo.Name == "Layout")
            {
                // let the RadDocking load the layout of the RadPanes
                this.LoadLayoutFromString(value.ToString(), context as RadDocking);
            }
            else if (customPropertyInfo.Name == "Content")
            {
                // the PersistenceManager does not re-create UI elements - in this case the Content of the RadPane.
                // So, instead of providing a value on which the saved properties will be applied, 
                // we will use the InitializeValue method.
            }
        }

        private string SaveLayoutAsString(RadDocking instance)
        {
            MemoryStream stream = new MemoryStream();
            instance.SaveLayout(stream);

            stream.Seek(0, SeekOrigin.Begin);

            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        private void LoadLayoutFromString(string xml, RadDocking instance)
        {
            using (Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                stream.Seek(0, SeekOrigin.Begin);
                instance.LoadLayout(stream);
            }
        }

        private IEnumerable<RadPane> GetOrderedPanes(RadDocking docking)
        {
            // get the RadPanes always in the same order:
            RadPane[] array = docking.Panes.ToArray();
            Array.Sort(array,new RadPaneComparer());
            return array;
        }
    }

    public class RadPaneComparer : IComparer<RadPane>
    {
        int IComparer<RadPane>.Compare(RadPane x, RadPane y)
        {
            // compare RadPanes by their serialization tag:
            string xSerializationTag = RadDocking.GetSerializationTag(x);
            string ySerializationTag = RadDocking.GetSerializationTag(y);

            return xSerializationTag.CompareTo(ySerializationTag);
        }
    }

}
