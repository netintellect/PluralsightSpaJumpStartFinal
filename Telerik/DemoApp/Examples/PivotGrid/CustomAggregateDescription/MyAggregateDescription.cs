using System.Collections.Generic;
using System.Linq;
using Telerik.Pivot.Core;
using Telerik.Pivot.Core.Aggregates;

namespace Telerik.Windows.Examples.PivotGrid.CustomAggregateDescription
{
    public class MyAggregateDescription : PropertyAggregateDescriptionBase
    {
        protected override void CloneOverride(Cloneable source)
        {

        }

        protected override Cloneable CreateInstanceCore()
        {
            return new MyAggregateDescription();
        }

        protected override IEnumerable<object> SupportedAggregateFunctions
        {
            get
            {
                var c = new PropertyAggregateDescription();
                var dp = this.GetService(typeof(IDataProvider)) as IDataProvider;
                if (dp != null)
                {
                    var hasCalculatedItem =
                                Enumerable.Any(
                                    Enumerable.Concat(
                                        Enumerable.OfType<PropertyGroupDescriptionBase>(dp.Settings.RowGroupDescriptions),
                                        Enumerable.OfType<PropertyGroupDescriptionBase>(dp.Settings.ColumnGroupDescriptions)),
                                    d => d.CalculatedItems != null && d.CalculatedItems.Count > 0);
                    if (hasCalculatedItem)
                    {
                        if (this.DataType == typeof(decimal) || this.DataType == typeof(double) || this.DataType == typeof(int))
                        {
                            var baseSuppFunct = base.SupportedAggregateFunctions;
                            var withoutMin = baseSuppFunct.Where(f => f.GetType() != AggregateFunctions.Min.GetType());
                            var result = withoutMin.Concat(new List<object>() { new SqrtSumAggregateFunction() });

                            return result;
                        }
                    }
                    else
                    {
                        if (this.DataType == typeof(decimal) || this.DataType == typeof(double) || this.DataType == typeof(int))
                        {
                            var baseSuppFunct = base.SupportedAggregateFunctions;
                            var withoutAvg = baseSuppFunct.Where(f => f.GetType() != AggregateFunctions.Average.GetType());
                            var withoutMin = withoutAvg.Where(f => f.GetType() != AggregateFunctions.Min.GetType());
                            var result = withoutMin.Concat(new List<object>() { new SqrtSumAggregateFunction() });

                            return result;
                        }
                    }
                }

                return base.SupportedAggregateFunctions;
            }
        }
    }
}
