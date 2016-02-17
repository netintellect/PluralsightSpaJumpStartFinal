using System;
using System.Globalization;
using Telerik.Pivot.Core;
using Telerik.Pivot.Core.Aggregates;


namespace Telerik.Windows.Examples.PivotGrid.CustomAggregateDescription
{
    public sealed class SqrtSumAggregate : AggregateValue, IConvertibleAggregateValue<double>
    {
        private double sum;

        private bool hasError = false;

        /// <inheritdoc />
        protected override object GetValueOverride()
        {
            return Math.Round(Math.Sqrt(this.sum), 2);
        }

        /// <inheritdoc />
        protected override void AccumulateOverride(object value)
        {
            this.sum += Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        protected override void MergeOverride(AggregateValue childAggregate)
        {
            var sumAggregate = childAggregate as SqrtSumAggregate;
            if (sumAggregate != null)
            {
                this.sum += sumAggregate.sum;
            }
            else
            {
                double doubleValue;
                if (AggregateValueExtensions.TryConvertValue<double>(childAggregate, out doubleValue))
                {
                    this.sum += doubleValue;
                }
                else
                {
                    this.sum = 0;
                    this.hasError = true;
                }
            }
        }

        bool IConvertibleAggregateValue<double>.TryConvertValue(out double value)
        {
            if (this.hasError)
            {
                value = 0;
                return false;
            }

            value = (double)this.sum;
            return true;
        }
    }
}
