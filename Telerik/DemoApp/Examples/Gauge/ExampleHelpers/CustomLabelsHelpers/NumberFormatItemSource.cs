using System;
using System.Collections;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Telerik.Examples.Gauge
{
	/// <summary>
	/// Items source that represents numeric formats
	/// </summary>
	public class NumberFormatItemSource : IEnumerable
	{
		private static string[] numberFormatList = new string[]
			{
				"{0:F0}",
				"{0:F1}",
				"{0:F2}",
				"{0:N}"
			};

		/// <summary>
		/// Static class constructor
		/// </summary>
		static NumberFormatItemSource()
		{
		}

		/// <summary>
		/// Creates instance of the class
		/// </summary>
		public NumberFormatItemSource()
		{
		}

		#region IEnumerable Members

		/// <summary>
		/// Gets enumerator
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetEnumerator()
		{
			return numberFormatList.GetEnumerator();
		}

		#endregion
	}
}
