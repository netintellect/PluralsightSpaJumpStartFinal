using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ListBox.Configurator
{
	public class ViewModel : AgencyViewModel
	{
		private string[] selectionModeItems;

		public string[] SelectionModeItems
		{
			get
			{
				return this.selectionModeItems = this.GetSelectionModes();
			}
		}

		public string[] GetSelectionModes()
		{
#if WPF
			return Enum.GetNames(typeof(System.Windows.Controls.SelectionMode));
#else 
			return Enum.GetNames(typeof(Telerik.Windows.Controls.SelectionMode));
#endif
		}
	}
}
