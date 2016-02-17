using System;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public sealed class EquityDataAgent : DataAgent
	{
		private static readonly Random Rand = new Random(Environment.TickCount);

		public int DataPoints { get; set; }


		public EquityDataAgent(string source, int dataPoints)
			: base(source)
		{
			this.DataPoints = dataPoints;
			// one time init
			// stock prices tend to increase, hence the generation of the logarithm
			var initial = DataGenerator.RandomInteger(156, 256);
			var acc = initial;
			for (var i = 0; i < dataPoints; i++)
			{
				acc += Increment();
				//if(Math.Abs(initial-acc)>100) acc = initial + DataGenerator.RandomInteger(16, 20);
				this.Data.Add(acc);
			}
		}



		protected override void UpdateData()
		{
			this.Data.RemoveAt(0);
			var last = this.Data[this.Data.Count - 1];
			this.Data.Add(last + Increment());
			base.UpdateData();
		}

		private static int Increment()
		{
			return 5+ Math.Max(Math.Min((int)Math.Floor(DataGenerator.LevyRandom()*4), 50), -30);
		}
	}
}