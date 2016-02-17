using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GridView.Selection
{
	public class MyViewModel : ViewModelBase
	{
		IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> _modes;
		public IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> Modes
		{
			get
			{
				if (_modes == null)
				{
					_modes = Telerik.Windows.Data.EnumDataSource.FromType<System.Windows.Controls.SelectionMode>();
				}

				return _modes;
			}
		}

		IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> _units;
		public IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> Units
		{
			get
			{
				if (_units == null)
				{
					_units = Telerik.Windows.Data.EnumDataSource.FromType<Telerik.Windows.Controls.GridView.GridViewSelectionUnit>();
				}

				return _units;
			}
		}
	}
}
