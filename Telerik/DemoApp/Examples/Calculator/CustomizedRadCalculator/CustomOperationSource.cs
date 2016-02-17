using System;
using Telerik.Windows.Controls.Calculator;

namespace Telerik.Windows.Examples.Calculator.CustomizedRadCalculator
{
    public class CustomOperationsSource : OperationsSource
    {
		public Operation Power
		{
			get
			{
				Func<decimal, decimal, decimal> operation =
					(d1, d2) =>
					{
						return (decimal)Math.Pow((double)d1, (double)d2);
					};

				return new Operation()
				{
					DisplayTrace = "^",
					OperationBody = operation,
					Type = OperationType.Binary
				};
			}
		}

		public Operation Sinus
		{
			get
			{
				Func<decimal, decimal> operation = null;
				operation =
					(d1) =>
					{
						return (decimal)Math.Sin(Decimal.ToDouble(d1));
					};

				return new Operation()
				{
					DisplayTrace = "sin",
					OperationBody = operation,
					Type = OperationType.Unary
				};
			}
		}

		public Operation Cosine
		{
			get
			{
				Func<decimal, decimal> operation = null;
				operation =
					(d1) =>
					{
						return (decimal)Math.Cos(Decimal.ToDouble(d1));
					};

				return new Operation()
				{
					DisplayTrace = "cos",
					OperationBody = operation,
					Type = OperationType.Unary
				};
			}
		}

		public Operation Tangent
		{
			get
			{
				Func<decimal, decimal> operation = null;
				operation =
					(d1) =>
					{
						return (decimal)Math.Tan(Decimal.ToDouble(d1));
					};

				return new Operation()
				{
					DisplayTrace = "tan",
					OperationBody = operation,
					Type = OperationType.Unary
				};
			}
		}
	}
}
