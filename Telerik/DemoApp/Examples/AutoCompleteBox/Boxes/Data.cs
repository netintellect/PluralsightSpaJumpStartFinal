using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.AutoCompleteBox.Boxes
{
    public class Data
    {
        ObservableCollection<Contact> contactsList = new ObservableCollection<Contact>();

        protected void EntryContactData()
        {
            contactsList.Add(new Contact()
            {
                FirstName = "Alejandra",
                LastName = "Camino"
            });
            contactsList.Add(new Contact()
            {
                FirstName = "Aria",
                LastName = "Cruz"
            });
            contactsList.Add(new Contact()
            {
                FirstName = "Alexander",
                LastName = "Feuer"
            });
            contactsList.Add(new Contact()
            {
                FirstName = "Elizabeth",
                LastName = "Lincoln"
            });
            contactsList.Add(new Contact()
            {
                FirstName = "Eddie",
                LastName = "Cochran"
            });
            contactsList.Add(new Contact()
            {
                FirstName = "Hanna",
                LastName = "Moos"
            });
            contactsList.Add(new Contact()
            {
                FirstName = "Ben",
                LastName = "Johnson"
            });
            contactsList.Add(new Contact()
            {
                FirstName = "Charlie",
                LastName = "Sheen"
            });
			contactsList.Add(new Contact()
			{
				FirstName = "Quin",
				LastName = "Sheen"
			});
			contactsList.Add(new Contact()
			{
				FirstName = "Wade",
				LastName = "Green"
			});
			contactsList.Add(new Contact()
			{
				FirstName = "Zack",
				LastName = "Johnson"
			});
			contactsList.Add(new Contact()
			{
				FirstName = "Vladimir",
				LastName = "Griffin"
			});
			contactsList.Add(new Contact()
			{
				FirstName = "Stanley",
				LastName = "Feemster"
			});
			contactsList.Add(new Contact()
			{
				FirstName = "Georgie",
				LastName = "Kinzer"
			});
			contactsList.Add(new Contact()
			{
				FirstName = "Arnetta",
				LastName = "Ratchford"
			});
			contactsList.Add(new Contact()
			{
				FirstName = "Paul",
				LastName = "Thorpe"
			});
			contactsList.Add(new Contact()
			{
				FirstName = "Cesar",
				LastName = "Carlock"
			});
			contactsList.Add(new Contact()
			{
				FirstName = "Shana",
				LastName = "Etsitty"
			});
			contactsList.Add(new Contact()
			{
				FirstName = "Alease",
				LastName = "Vanhoy"
			});
			contactsList.Add(new Contact()
			{
				FirstName = "Vennie",
				LastName = "Prigge"
			});
        }

        public ObservableCollection<Contact> GetContacts()
        {
            contactsList.Clear();
            EntryContactData();
            return this.contactsList;
        }
    }
}
