using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Telerik.Examples.Gauge
{
	/// <summary>
	/// Real Data Emulator allows generation of the values sequence relative to the scale
	/// The probability and a shift of current value to generating next value could be specifies within ranges
	/// </summary>
	class RealDataEmulator
	{
		/// <summary>
		/// minimum of scale value
		/// </summary>
		private double min;
		/// <summary>
		/// maximum of scale value
		/// </summary>
		private double max;
		/// <summary>
		/// generated value
		/// </summary>
		private double value;

		public double Value
		{
			get { return this.value; }
			set { this.value = value; }
		}
		/// <summary>
		/// max shift for value incrementing
		/// </summary>
		private double maxIncrement;
		/// <summary>
		/// max shift for value decrementing
		/// </summary>
		private double maxDecrement;
		/// <summary>
		/// direction of a shift
		/// </summary>
		private double direction;

		/// <summary>
		/// Randomizer for value generation
		/// </summary>
		private Random rnd = new Random();
		/// <summary>
		/// Randomizer for a shift direction
		/// </summary>
		private Random rndDirection = new Random();
		/// <summary>
		/// Ranges collection
		/// </summary>
		private RangeList _rangeList = new RangeList();

		/// <summary>
		/// Initializes properties of the class
		/// </summary>
		/// <param name="minValue">Minimal generated value.</param>
		/// <param name="maxValue">Maximal generated value.</param>
		/// <param name="currentValue">Initial value.</param>
		/// <param name="maxIncrement">Maximum value for increment.
		/// This parameter is multiplied by Random double for next value generation.</param>
		/// <param name="maxDecrement">Maximum value for decrement.
		/// This parameter is multiplied by Random double for next value generation.</param>
		private void Initialzation(double minValue, double maxValue,
			double currentValue,
			double maxIncrement, double maxDecrement)
		{
			min = minValue;
			max = maxValue;

			value = currentValue;
			this.maxIncrement = maxIncrement;
			this.maxDecrement = maxDecrement;

			direction = 1d;
		}

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param name="minValue">Minimal generated value.</param>
		/// <param name="maxValue">Maximal generated value.</param>
		/// <param name="currentValue">Initial value.</param>
		/// <param name="maxIncrement">Maximum value for increment.
		/// This parameter is multiplied by Random double for next value generation.</param>
		/// <param name="maxDecrement">Maximum value for decrement.
		/// This parameter is multiplied by Random double for next value generation.</param>
		public RealDataEmulator(double minValue, double maxValue,
			double currentValue,
			double maxIncrement, double maxDecrement)
		{
			Initialzation(minValue, maxValue,
				currentValue,
				maxIncrement, maxDecrement);
		}

		/// <summary>
		/// Class constructor
		/// Automatically creates max increment and decrement property as scale length / 10
		/// </summary>
		/// <param name="minValue">Minimal generated value.</param>
		/// <param name="maxValue">Maximal generated value.</param>
		/// <param name="currentValue">Initial value.</param>
		public RealDataEmulator(double minValue, double maxValue, double currentValue)
		{
			double increment = (maxValue - minValue) / 10d;
			Initialzation(minValue, maxValue, currentValue, increment, increment);
		}

		/// <summary>
		/// Class constructor
		/// Automatically creates max increment and decrement property as scale length / 10
		/// Also it setup initial value to scale minimum value
		/// </summary>
		/// <param name="minValue">Minimal generated value.</param>
		/// <param name="maxValue">Maximal generated value.</param>
		public RealDataEmulator(double minValue, double maxValue)
		{
			Initialzation(minValue, maxValue, minValue,
				(maxValue - minValue) / 10d,
				(maxValue - minValue) / 10d);
		}

		/// <summary>
		/// Class constructor
		/// Automatically creates a scale from 0 to 100
		/// </summary>
		public RealDataEmulator()
		{
			Initialzation(0d, 100d, 0d, 10d, 10d);
		}

		/// <summary>
		/// Specifies current direction (+ or -) for next value generation
		/// </summary>
		private void SetDirection()
		{
			double range = _rangeList.GetDirectionPriorityValue(value);
			double directionValue = rndDirection.NextDouble();
			direction = 1d;

			if (directionValue > 0.5 - range / 2
				&& directionValue < 0.5 + range / 2)
				direction = -direction;
		}

		/// <summary>
		/// Returns next generated value according to direction and/or range specific
		/// </summary>
		/// <returns></returns>
		private double GetNormalizedValue()
		{
			double nextValue = rnd.NextDouble();
			if (direction > 0)
			{
				nextValue *= _rangeList.maxIncrement < 0 ? maxIncrement : _rangeList.maxIncrement;
			}
			else
			{
				nextValue *= _rangeList.maxDecrement < 0 ? maxDecrement : _rangeList.maxDecrement;
			}

			return direction * nextValue;
		}

		/// <summary>
		/// Returns next generated value
		/// </summary>
		/// <returns></returns>
		public double GetNextValue()
		{
			SetDirection();
			double stepValue = GetNormalizedValue();

			double nextValue = value + stepValue;

			if (nextValue > max)
				nextValue = max - Math.Abs(stepValue);

			if (nextValue < min)
				nextValue = min + Math.Abs(stepValue);

			value = nextValue;

			if (value > max)
				value = max;

			if (value < min)
				value = min;

			return value;
		}

		/// <summary>
		/// Adds new range to a scale
		/// </summary>
		/// <param name="min">Min range value.</param>
		/// <param name="max">Max range value.</param>
		/// <param name="directionPriority">
		/// Probability of negative direction for next value generation.
		/// Shoul be between 0 to 1.
		///		0 - positive direction only
		///		1 - negative direction only</param>
		/// <param name="maxIncrement">Maximum value incrementing for the range.</param>
		/// <param name="maxDecrement">Maximum value decrementing for the range</param>
		public void AddRange(double min, double max, double directionPriority,
			double maxIncrement, double maxDecrement)
		{
			_rangeList.AddRange(min, max, directionPriority, maxIncrement, maxDecrement);
		}

		/// <summary>
		/// Adds new range to a scale
		/// Uses max increment and decrement for next value generation from base class data
		/// </summary>
		/// <param name="min">Min range value.</param>
		/// <param name="max">Max range value.</param>
		/// <param name="directionPriority">
		/// Probability of negative direction for next value generation.
		/// Shoul be between 0 to 1.
		///		0 - positive direction only
		///		1 - negative direction only</param>
		public void AddRange(double min, double max, double directionPriority)
		{
			AddRange(min, max, directionPriority, -1, -1);
		}

		/// <summary>
		/// The range list
		/// </summary>
		class RangeList
		{
			/// <summary>
			/// Ranges collection
			/// </summary>
			private List<Range> _rangeList = new List<Range>();
			public double maxIncrement;
			public double maxDecrement;

			public RangeList()
			{
			}

			/// <summary>
			/// Returns probability of negative direction according to current value and ranges
			/// </summary>
			/// <param name="value"></param>
			/// <returns></returns>
			public double GetDirectionPriorityValue(double value)
			{
				double directionPriority = 0.5;
				maxIncrement = -1;
				maxDecrement = -1;

				foreach (Range range in _rangeList)
				{
					double newPriority = range.GetDirectionPriorityValue(value);
					if (newPriority != 0)
					{
						maxIncrement = range.maxIncrement;
						maxDecrement = range.maxDecrement;
						return newPriority;
					}
				}

				return directionPriority;
			}

			/// <summary>
			/// Adds new range to collection
			/// </summary>
			/// <param name="min"></param>
			/// <param name="max"></param>
			/// <param name="directionPriority"></param>
			/// <param name="maxIncrement"></param>
			/// <param name="maxDecrement"></param>
			public void AddRange(double min, double max, double directionPriority,
				double maxIncrement, double maxDecrement)
			{
				_rangeList.Add(new Range(min, max, directionPriority, maxIncrement, maxDecrement));
			}

			/// <summary>
			/// Specifies direction priority within the range
			/// </summary>
			class Range
			{
				private double min;
				private double max;
				private double directionPriority;
				public double maxIncrement;
				public double maxDecrement;

				/// <summary>
				/// Creates new range
				/// </summary>
				/// <param name="min"></param>
				/// <param name="max"></param>
				/// <param name="directionPriority"></param>
				/// <param name="maxIncrement"></param>
				/// <param name="maxDecrement"></param>
				public Range(double min, double max, double directionPriority,
					double maxIncrement, double maxDecrement)
				{
					this.min = min;
					this.max = max;
					this.directionPriority = directionPriority;

					this.maxIncrement = maxIncrement;
					this.maxDecrement = maxDecrement;
				}

				/// <summary>
				/// Returns negative direction probability
				/// </summary>
				/// <param name="value"></param>
				/// <returns></returns>
				public double GetDirectionPriorityValue(double value)
				{
					if (!IsInRange(value))
						return 0d;

					return directionPriority;
				}

				/// <summary>
				/// Determines that a value within the range
				/// </summary>
				/// <param name="value"></param>
				/// <returns></returns>
				public bool IsInRange(double value)
				{
					return value >= min && value <= max;
				}
			}
		}
	}
}
