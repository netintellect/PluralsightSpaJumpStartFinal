using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Telerik.Windows.QuickStart
{
	public class DropDownButtonCommands
	{
		// TODO: create on get:
		private static RoutedCommand dorpDownItemClick = new RoutedCommand("DropDownItemClick", typeof(DropDownButtonCommands));
		public static RoutedCommand DropDownItemClick
		{
			get
			{
				return dorpDownItemClick;
			}
		}
	}
}
