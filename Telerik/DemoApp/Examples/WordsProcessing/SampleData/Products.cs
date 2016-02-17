using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.WordsProcessing.SampleData
{
    public class Products
    {
        static string[] names = new string[] { "Côte de Blaye", "Boston Crab Meat", 
            "Singaporean Hokkien Fried Mee", "Gula Malacca", "Rogede sild", 
            "Spegesild", "Zaanse koeken", "Chocolade", "Maxilaku", "Valkoinen suklaa" };

        static double[] prizes = new double[] { 23.2500, 9.0000, 45.6000, 32.0000, 
            14.0000, 19.0000, 263.5000, 18.4000, 3.0000, 14.0000 };

        static DateTime[] dates = new DateTime[] { new DateTime(2007, 5, 10), new DateTime(2008, 9, 13), 
            new DateTime(2008, 2, 22), new DateTime(2009, 1, 2), new DateTime(2007, 4, 13), 
            new DateTime(2008, 5, 12), new DateTime(2008, 1, 19), new DateTime(2008, 8, 26), 
            new DateTime(2008, 7, 31), new DateTime(2007, 7, 16) };

        static bool[] bools = new bool[] { true, false, true, false, true, false, true, false, true, false };

        public IEnumerable<Product> GetData(int maxItems)
        {
            Random rnd = new Random();

            return from i in Enumerable.Range(1, maxItems)
                   select new Product(i, names[rnd.Next(9)], prizes[rnd.Next(9)],
                       dates[rnd.Next(9)], bools[rnd.Next(9)]);
        }

        public static Product GenerateRandomBusinessObject(Random random)
        {
            return new Product(random.Next(0, 100)
                , names[random.Next(9)]
                , prizes[random.Next(9)]
                , dates[random.Next(9)]
                , bools[random.Next(9)]);
        }

        public static void SetRandomPropertyValues(Product obj, Random random)
        {
            obj.Name = names[random.Next(9)];
            obj.UnitPrice = prizes[random.Next(9)];
            obj.Date = dates[random.Next(9)];
            obj.Discontinued = bools[random.Next(9)];
        }
    }

    public class Product : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private double unitPrice;
        private DateTime date;
        private bool discontinued;

        public Product()
        {
            //
        }

        public Product(Random random)
        {
            Products.SetRandomPropertyValues(this, random);
        }

        public Product(int ID, string Name, double UnitPrice, DateTime Date,
            bool Discontinued)
        {
            this.ID = ID;
            this.Name = Name;
            this.UnitPrice = UnitPrice;
            this.Date = Date;
            this.Discontinued = Discontinued;
        }

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public double UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                unitPrice = value;
                OnPropertyChanged("UnitPrice");
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public bool Discontinued
        {
            get
            {
                return discontinued;
            }
            set
            {
                discontinued = value;
                OnPropertyChanged("Discontinued");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
