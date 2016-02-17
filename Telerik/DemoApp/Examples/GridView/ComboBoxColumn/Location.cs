using System;

namespace Telerik.Windows.Examples.GridView.ComboBoxColumn
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Location
    {
        public int ID { get; set; }

        public int CountryID { get; set; }
    }
}
