
namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	using System;
	using System.Collections.Generic;

	public static class StochasticEngine 
	{
		private readonly static Dictionary<string, DataAgent> dataAgents=new Dictionary<string, DataAgent>();
		/// <summary>
		/// Gets or sets the update interval in milliseconds.
		/// </summary>
		/// <value>
		/// The update interval.
		/// </value>
		public static int UpdateInterval { get; set; }

		 static StochasticEngine()
		 {
		 	 
		 }

		/// <summary>
		/// Gets the data agent for the specified source.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="dataPoints">The data points.</param>
		/// <param name="updateInterval">The update interval in milliseconds. </param>
		/// <returns></returns>
		public static DataAgent GetDataAgent(string name, int dataPoints = 30, int updateInterval = 1000)
		{
			if (dataAgents.ContainsKey(name)) return dataAgents[name];
			var agent = new EquityDataAgent(name,dataPoints) { UpdateInterval = TimeSpan.FromMilliseconds(updateInterval) };
			dataAgents.Add(name, agent);
			return agent;
		}
	}
}