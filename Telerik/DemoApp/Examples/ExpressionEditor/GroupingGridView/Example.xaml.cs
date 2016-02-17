using System;
using System.Linq.Expressions;
using System.Reflection;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.ExpressionEditor.GroupingGridView
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example
	{
		public Example()
		{
			this.InitializeComponent();

			this.SetInitialGroupDescriptorExpression();
		}

		private void SetInitialGroupDescriptorExpression()
		{
			// We need to construct the expression tree manually, as VB.NET 9 lacks proper lambda support.
			ParameterExpression parameterExpression = Expression.Parameter(typeof(MyBusinessObject), "dataItem");
			Expression memberAccess = Expression.Property(parameterExpression, "Discontinued");
			Expression lambda = Expression.Lambda(memberAccess, parameterExpression);

			GroupDescriptorBase descriptor = CreateGenericGroupDescriptor(lambda);
			SetExpressionText(descriptor, "Discontinued");

			this.GridView.GroupDescriptors.Add(descriptor);
		}

		private void OnExpressionButtonLoaded(object sender, System.Windows.RoutedEventArgs e)
		{
			RadButton button = (RadButton)sender;

			button.Content = GetExpressionText((GroupDescriptorBase)button.DataContext);
		}

		private void OnGridViewGrouping(object sender, GridViewGroupingEventArgs e)
		{
			// prevent the user from performing grouping operations
			e.Cancel = true;
		}

		private void OnExpressionButtonClick(object sender, System.Windows.RoutedEventArgs e)
		{
			RadButton expressionButton = (RadButton)sender;
			GroupDescriptorBase descriptor = (GroupDescriptorBase)expressionButton.DataContext;

			ExpressionEditorWindow window = new ExpressionEditorWindow();
			window.ExpressionEditor.Item = this.GridView.CurrentItem;
			window.ExpressionEditor.ExpressionText = GetExpressionText(descriptor);
			window.Closed += this.OnExpressionWindowClosed;
			window.ShowDialog();
		}

		private void OnExpressionWindowClosed(object sender, WindowClosedEventArgs e)
		{
			ExpressionEditorWindow window = (ExpressionEditorWindow)sender;

			if (window.DialogResult == true)
			{
				this.GridView.GroupDescriptors.Clear();

				GroupDescriptorBase descriptor = CreateGenericGroupDescriptor(window.ExpressionEditor.Expression);
				this.GridView.GroupDescriptors.Add(descriptor);

				SetExpressionText(descriptor, window.ExpressionEditor.ExpressionText);
			}
		}

		private static GroupDescriptorBase CreateGenericGroupDescriptor(Expression groupingExpression)
		{
			LambdaExpression expression = TransformExpression(groupingExpression);
			Type descriptorType = typeof(GroupDescriptor<,,>).MakeGenericType(typeof(MyBusinessObject), expression.Body.Type, expression.Body.Type);
			GroupDescriptorBase descriptor = (GroupDescriptorBase)Activator.CreateInstance(descriptorType);
			PropertyInfo groupingExpressionProperty = descriptorType.GetProperty("GroupingExpression");
			groupingExpressionProperty.SetValue(descriptor, expression, null);

			return descriptor;
		}

		private static LambdaExpression TransformExpression(Expression expression)
		{
			LambdaExpression lambda = expression as LambdaExpression;
			if (lambda == null)
			{
				lambda = Expression.Lambda(expression, Expression.Parameter(typeof(MyBusinessObject), "dataItem"));
			}
			else if (lambda.Parameters.Count == 0)
			{
				lambda = Expression.Lambda(lambda.Body, Expression.Parameter(typeof(MyBusinessObject), "dataItem"));
			}

			return lambda;
		}

		public static string GetExpressionText(System.Windows.DependencyObject obj)
		{
			return (string)obj.GetValue(ExpressionTextProperty);
		}

		public static void SetExpressionText(System.Windows.DependencyObject obj, string value)
		{
			obj.SetValue(ExpressionTextProperty, value);
		}

		public static readonly System.Windows.DependencyProperty ExpressionTextProperty =
			System.Windows.DependencyProperty.RegisterAttached("ExpressionText", typeof(string), typeof(GroupDescriptorBase), new System.Windows.PropertyMetadata(null));
	}
}
