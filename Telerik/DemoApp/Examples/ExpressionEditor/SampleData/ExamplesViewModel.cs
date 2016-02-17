using System.Collections.Generic;
using System.Linq;

namespace Telerik.Windows.Examples.ExpressionEditor
{
	/// <summary>
	/// View model for all examples.
	/// </summary>
	public class ExamplesViewModel
	{
		private IEnumerable<MyBusinessObject> products;

		/// <summary>
		/// Gets the random products.
		/// </summary>
		/// <value>The random products.</value>
		public IEnumerable<MyBusinessObject> Products
		{
			get
			{
				if (this.products == null)
				{
					this.products = new MyBusinessObjects().GetData(100).ToList();
				}

				return this.products;
			}
		}
	}
}
