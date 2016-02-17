using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.TimeBar.SpecialSlots
{
    public class Airport
    {
        public string City { get; set; }
        public Location Location { get; set; }

        public Airport(string city, Location loc)
        {
            this.City = city;
            this.Location = loc;
        }
    }
}