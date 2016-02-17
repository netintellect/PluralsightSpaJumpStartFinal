using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.Chart.FirstLook
{
    public class OrderDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<OrderData> orderData = (value as IEnumerable<OrderData>).ToList();

            QueryableCollectionView groupedView = new QueryableCollectionView(orderData);

            groupedView.FilterDescriptors.Add(new FilterDescriptor("Date", FilterOperator.IsGreaterThanOrEqualTo, new DateTime(2009, 1, 1)));
            groupedView.FilterDescriptors.Add(new FilterDescriptor("Date", FilterOperator.IsLessThanOrEqualTo, new DateTime(2009, 12, 31)));

            return GroupAndAggregateDataByDate(groupedView);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static object GroupAndAggregateDataByDate(QueryableCollectionView groupedView)
        {
            GroupDescriptor groupDescriptor = new GroupDescriptor();
            groupDescriptor.Member = "Date";
            SumFunction sumFunction = new SumFunction();
            sumFunction.SourceField = "Amount";
            groupDescriptor.AggregateFunctions.Add(sumFunction);
            groupedView.GroupDescriptors.Add(groupDescriptor);

            List<OrderData> result = new List<OrderData>();
            foreach (QueryableCollectionViewGroup group in groupedView.Groups)
            {
                OrderData groupedData = new OrderData();
                groupedData.Amount = (int)group.AggregateResults[0].Value;
                groupedData.Date = (DateTime)group.Key;
                result.Add(groupedData);
            }
            return result;
        }
    }
}
