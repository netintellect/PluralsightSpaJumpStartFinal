using System;
using System.Windows.Markup;

namespace Telerik.Windows.Examples.Diagrams.TableShape
{
	/// <summary>
	/// DataType MarkupExtension.
	/// </summary>
	public class DataTypeExtension : MarkupExtension
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DataTypeExtension"/> class.
		/// </summary>
		public DataTypeExtension()
		{
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return Enum.GetValues(typeof(DataType));
		}
	}
}
