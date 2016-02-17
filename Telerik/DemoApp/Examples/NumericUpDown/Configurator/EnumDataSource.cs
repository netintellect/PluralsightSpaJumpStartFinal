using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Telerik.Windows.Examples.NumericUpDown.Configurator
{
	public class EnumDataSource : IEnumerable<string>
	{
		private IEnumerable<string> names;

		private Type enumType;

		public Type EnumType
		{
			get
			{
				return this.enumType;
			}
			set
			{
				this.enumType = value;
				this.InitNames(this.enumType);
			}
		}

		public IEnumerator<string> GetEnumerator()
		{
			return this.names.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.names.GetEnumerator();
		}

		private void InitNames(Type type)
		{
			this.names = type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).Select((FieldInfo x) => x.Name);
		}
	}
}