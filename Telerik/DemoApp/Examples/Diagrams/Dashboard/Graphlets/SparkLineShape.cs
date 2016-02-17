
namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public sealed class SparkLineShape : FinancialShape
	{
		protected override void UpdateData()
		{
			this.Content = StochasticEngine.GetDataAgent(this.Symbol);
		}
	}
}