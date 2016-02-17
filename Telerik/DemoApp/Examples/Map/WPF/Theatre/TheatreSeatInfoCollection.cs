using System.Collections.ObjectModel;
using System.Linq;

namespace Telerik.Windows.Examples.Map.Theatre
{
    public class TheatreSeatInfoCollection : ObservableCollection<TheatreSeatInfo>
    {
        public double TotalPrice
        {
            get
            {
                return this.Items.Sum(seatInfo => seatInfo.Price);
            }
        }
    }
}
