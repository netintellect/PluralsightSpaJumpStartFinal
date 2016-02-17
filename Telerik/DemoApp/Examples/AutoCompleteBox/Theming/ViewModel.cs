using System;
using System.Collections.ObjectModel;
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

namespace Telerik.Windows.Examples.AutoCompleteBox.Theming
{
	public class ViewModel : ViewModelBase
	{
		private Data source = new Data();
		private ObservableCollection<Contact> _ContactsList;

		public ViewModel()
		{
			this.LoadContacts();
		}

		private void LoadContacts()
		{
			this._ContactsList = new ObservableCollection<Contact>();
			foreach (var contact in source.GetContacts())
			{
				this._ContactsList.Add(contact);
			}
		}
		public ObservableCollection<Contact> ContactsList
		{
			get
			{
				return this._ContactsList;
			}
		}
	}
}
