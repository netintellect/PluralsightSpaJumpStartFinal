using System.Collections.Generic;

namespace Telerik.Windows.Examples.Chart.FirstLook
{
    public abstract class OrderView
    {
        private long _amount;
        private IEnumerable<OrderData> _data;
        private string _name;


        public OrderView(string name, IEnumerable<OrderData> data)
        {
            this._name = name;
            this._data = data;

            foreach (OrderData order in data)
            {
                this._amount += order.Amount;
            }
        }

        public long Amount
        {
            get
            {
                return this._amount;
            }
        }

        public IEnumerable<OrderData> Data
        {
            get
            {
                return this._data;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }
    }
}
