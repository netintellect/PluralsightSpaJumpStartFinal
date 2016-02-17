using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Globalization;

namespace Telerik.Windows.Examples.ChartView.FirstLook
{
    public class SalesDataByProductTypeViewModel : DataSourceViewModelBase
    {
        List<ProductSales> _productSales;

        public List<ProductSales> ProductSales
        {
            get
            {
                return _productSales;
            }
            set
            {
                if (this._productSales != value)
                {
                    this._productSales = value;
                    this.OnPropertyChanged("ProductSales");
                }
            }
        }

        public SalesDataByProductTypeViewModel()
        {
            this.GetData("SalesDashboardDataByProductType.csv");
        }

        protected override void GetDataCompleted(System.Collections.IEnumerable data)
        {
            this.ProductSales = data as List<ProductSales>;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;

            List<ProductSales> chartData = new List<ProductSales>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                ProductSales dataItem = new ProductSales();
                dataItem.Food = double.Parse(data[0], CultureInfo.InvariantCulture);
                dataItem.Clothing = double.Parse(data[1], CultureInfo.InvariantCulture);
                dataItem.Electronic = double.Parse(data[2], CultureInfo.InvariantCulture);
                dataItem.Homeware = double.Parse(data[3], CultureInfo.InvariantCulture);
                dataItem.Month = DateTime.Parse(data[4], CultureInfo.InvariantCulture).ToString("MMM");
                
                chartData.Add(dataItem);
            }

            return chartData;
        }
    }

    public class ProductSales
    {
        private double _food;
        public double Food
        {
            get
            {
                return this._food;
            }
            set
            {
                this._food = value;
            }
        }

        private double _clothing;
        public double Clothing
        {
            get
            {
                return this._clothing;
            }
            set
            {
                this._clothing = value;
            }
        }

        private double _electronic;
        public double Electronic
        {
            get
            {
                return this._electronic;
            }
            set
            {
                this._electronic = value;
            }
        }

        private double _homeware;
        public double Homeware
        {
            get
            {
                return this._homeware;
            }
            set
            {
                this._homeware = value;
            }
        }

        private string _month;
        public string Month
        {
            get
            {
                return this._month;
            }
            set
            {
                this._month = value;
            }
        }
    }
}
