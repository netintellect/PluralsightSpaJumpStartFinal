using System;
using Telerik.Pivot.Core.Aggregates;

namespace Telerik.Windows.Examples.PivotGrid.CustomAggregateDescription
{
    public class SqrtSumAggregateFunction : Telerik.Pivot.Core.Aggregates.AggregateFunction
    {
        public override string DisplayName
        {
            get { return "Sqrt Of Sum"; }
        }

        protected override AggregateValue CreateAggregate(Type dataType)
        {
            return new SqrtSumAggregate();
        }

        public override string GetStringFormat(Type dataType, string format)
        {
            if (format == null)
            {
                return "G";
            }

            return format;
        }

        public override string ToString()
        {
            return "Sqrt Of Sum";
        }

        public override bool Equals(object obj)
        {
            return obj is SqrtSumAggregateFunction;
        }

        protected override void CloneCore(Telerik.Pivot.Core.Cloneable source)
        {
        }

        protected override Telerik.Pivot.Core.Cloneable CreateInstanceCore()
        {
            return new SqrtSumAggregateFunction();
        }

        protected override AggregateValue CreateAggregate(IAggregateContext context)
        {
            return this.CreateAggregate(context.DataType);
        }
    }
}
