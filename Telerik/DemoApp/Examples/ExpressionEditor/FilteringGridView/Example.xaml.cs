using System;
using System.Linq.Expressions;
using System.Windows;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.ExpressionEditor.FilteringGridView
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example
	{
		private FilterDescriptor<MyBusinessObject> genericFilterDescriptor = new FilterDescriptor<MyBusinessObject>();

		public Example()
		{
			this.InitializeComponent();
		}

		private void ExpressionEditor_ExpressionChanged(object sender, RadRoutedEventArgs e)
		{
			if (this.ExpressionEditor.Expression != null && this.ExpressionEditor.Expression.GetType() == typeof(Expression<Func<MyBusinessObject, bool>>))
			{
				this.genericFilterDescriptor.FilteringExpression = (Expression<Func<MyBusinessObject, bool>>)this.ExpressionEditor.Expression;

				if (!this.GridView.FilterDescriptors.Contains(this.genericFilterDescriptor))
				{
					this.GridView.FilterDescriptors.Add(this.genericFilterDescriptor);
				}

				this.errorMessageBlock.Visibility = Visibility.Collapsed;
			}
			else if (this.ExpressionEditor.Expression == null)
			{
				if (this.GridView.FilterDescriptors.Contains(this.genericFilterDescriptor))
				{
					this.GridView.FilterDescriptors.Remove(this.genericFilterDescriptor);
				}

				this.errorMessageBlock.Visibility = Visibility.Collapsed;
			}
			else
			{
				this.errorMessageBlock.Visibility = Visibility.Visible;
			}
		}
	}
}
