using System.Linq;
using Telerik.Pivot.Core;
using Telerik.Pivot.Core.Aggregates;

namespace Telerik.Windows.Examples.PivotGrid.CustomAggregateDescription
{
    public class ProductCalculatedItem : CalculatedItem
    {
        protected override Telerik.Pivot.Core.Aggregates.AggregateValue GetValue(IAggregateSummaryValues aggregateSummaryValues)
        {
            AggregateValue[] aggregateValues = 
            {
                aggregateSummaryValues.GetAggregateValue("Printer stand"),
                aggregateSummaryValues.GetAggregateValue("Mouse pad"),
            };


            foreach (AggregateValue val in aggregateValues)
            {
                if (val.IsError())
                {
                    return new DoubleAggregateValue(0);
                }
            }

            if (aggregateValues.ContainsError())
            {
                return AggregateValue.ErrorAggregateValue;
            }

            double value = aggregateValues.Average(av => av.ConvertOrDefault<double>());

            return new DoubleAggregateValue(value);
        }
    }
}
