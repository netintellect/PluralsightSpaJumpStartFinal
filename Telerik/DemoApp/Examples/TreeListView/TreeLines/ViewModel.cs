using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.TreeListView.TreeLines
{
	public class ViewModel : ViewModelBase
	{
		IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> _visibilities;

		public IEnumerable<Telerik.Windows.Data.EnumMemberViewModel> Visibilities
		{
			get
			{
				if (_visibilities == null)
				{
					_visibilities = Telerik.Windows.Data.EnumDataSource.FromType<Telerik.Windows.Controls.TreeListView.TreeLinesVisibility>();
				}

				return _visibilities;
			}
		}
	}
}