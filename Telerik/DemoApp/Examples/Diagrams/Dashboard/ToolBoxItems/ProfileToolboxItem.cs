using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public class ProfileToolboxItem : GeometryToolboxItem
	{
		public override RadDiagramShape CreateShape()
		{
			var shape = new TextShape
			{
				Text = DataProvider.FetchProfile(DataGenerator.RandomString(4, CharType.UpperCaseLetters))
			};

			return shape;
		}
	}
}