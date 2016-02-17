using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.AutoCompleteBox.Boxes
{
    public class ViewModel
    {
        Data source = new Data();

        private ObservableCollection<Contact> contactsList = new ObservableCollection<Contact>();

        public ViewModel()
        {
            LoadContacts();
        }

        private void LoadContacts()
        {
            foreach (var contact in source.GetContacts())
            {
                contactsList.Add(contact);
            }
        }

        public ObservableCollection<Contact> ContactsList
        {
            get
            {
                return this.contactsList;
            }
        }
    }
}
