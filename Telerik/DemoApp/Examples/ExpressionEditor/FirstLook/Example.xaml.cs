using System.Linq.Expressions;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ExpressionEditor.FirstLook
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example
	{
		private string lastExpressionText;

		public Example()
		{
			this.InitializeComponent();

			this.SetInitialExpressionColumnExpression();
		}

		private void SetInitialExpressionColumnExpression()
		{
			// We need to construct the expression tree manually, as VB.NET 9 lacks proper lambda support.
			ParameterExpression parameterExpression = Expression.Parameter(typeof(MyBusinessObject), "dataItem");
			Expression memberAccess = Expression.Property(parameterExpression, "Discontinued");
			Expression lambda = Expression.Lambda(memberAccess, parameterExpression);

			GridViewExpressionColumn column = (GridViewExpressionColumn)this.GridView.Columns["ExpressionColumn"];
			column.Expression = lambda;

			this.lastExpressionText = "Discontinued";
		}

		private void OnExpressionButtonClick(object sender, System.Windows.RoutedEventArgs e)
		{
			ExpressionEditorWindow window = new ExpressionEditorWindow();
			window.ExpressionEditor.Item = this.GridView.CurrentItem;
			window.ExpressionEditor.ExpressionText = this.lastExpressionText;

			window.Closed += this.OnExpressionWindowClosed;

			window.ShowDialog();
		}

		private void OnExpressionWindowClosed(object sender, WindowClosedEventArgs e)
		{
			ExpressionEditorWindow window = (ExpressionEditorWindow)sender;

			if (window.DialogResult == true)
			{
				GridViewExpressionColumn column = (GridViewExpressionColumn)this.GridView.Columns["ExpressionColumn"];

				if (column.Expression != window.ExpressionEditor.Expression)
				{
					column.ClearFilters();
					column.Expression = window.ExpressionEditor.Expression;
				}

				this.lastExpressionText = window.ExpressionEditor.ExpressionText;
			}
		}
	}
}
