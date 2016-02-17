using System;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Map.Cluster
{
	public class MyMapItem
	{
        private Location _location;
        private string _title;
        private string _description;

		public Location Location
		{
            get
            {
                return this._location;
            }
            set
            {
                this._location = value;
            }
		}

		public string Title
		{
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
		}

		public string Description
		{
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
		}
	}
}
