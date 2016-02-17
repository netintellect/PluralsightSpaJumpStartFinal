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
using Telerik.Windows.Controls.Data.DataForm;

namespace Telerik.Windows.Examples.DataForm.CustomCommandsProvider
{
	public class CustomCommandProvider : DataFormCommandProvider
	{
		public CustomCommandProvider() : base(null)
		{
		}

		protected override void MoveCurrentToNext()
		{
			if (this.DataForm != null)
			{
				this.DataForm.MoveCurrentToNext();
				this.DataForm.BeginEdit();
			}
		}

		protected override void MoveCurrentToPrevious()
		{
			if (this.DataForm != null)
			{
				this.DataForm.MoveCurrentToPrevious();
				this.DataForm.BeginEdit();
			}
		}

		protected override void CommitEdit()
		{
			MessageBoxResult result = MessageBox.Show("Commit changes for the current edit item?", "CommitEdit confirmation", MessageBoxButton.OKCancel);
			if (result == MessageBoxResult.OK)
			{
				if (this.DataForm != null && this.DataForm.ValidateItem())
				{
					this.DataForm.CommitEdit();
				}
			}			
		}

		protected override void CancelEdit()
		{
			MessageBoxResult result = MessageBox.Show("Cancel changes for the current edit item?", "CancelEdit confirmation", MessageBoxButton.OKCancel);
			if (result == MessageBoxResult.OK)
			{
				if (this.DataForm != null)
				{
					this.DataForm.CancelEdit();
				}
			}	
		}
	}
}
