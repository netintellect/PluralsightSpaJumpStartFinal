using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using Telerik.Windows.Controls;
using Examples.Web;

namespace Telerik.Windows.Examples.DataForm.DataFormRIA
{
    public partial class Example : UserControl
    {
        string[] displayedProperties = new string[] { "FirstName", "LastName", "Title", "HomePhone", "ReportsTo", "HireDate" };

        public Example()
        {
            InitializeComponent();

            MyRadDomainDataSource.SubmittedChanges += new EventHandler<Telerik.Windows.Controls.DomainServices.DomainServiceSubmittedChangesEventArgs>(MyRadDomainDataSource_SubmittedChanges);
        }

        void MyRadDomainDataSource_SubmittedChanges(object sender, Telerik.Windows.Controls.DomainServices.DomainServiceSubmittedChangesEventArgs e)
        {
            if (e.HasError)
            {
                //Avoids displaying errors, when deletion is prevented by DataBase constraints
                e.MarkErrorAsHandled();
            }
        }

        private void MyRadDataForm_AutoGeneratingField(object sender, Telerik.Windows.Controls.Data.DataForm.AutoGeneratingFieldEventArgs e)
        {
            if (!displayedProperties.Contains(e.PropertyName))
            {
                e.Cancel = true;
            }
            if (e.PropertyName == "ReportsTo")
            {
                DataFormComboBoxField dataField = new DataFormComboBoxField();

                dataField.Label = "ReportsTo";
                dataField.ItemsSource = new List<EmployeeID>() 
                { 
                    new EmployeeID("Nancy Davolio", 1),
                    new EmployeeID("Andrew Fuller", 2),
                    new EmployeeID("Janet Leverling", 3),
                    new EmployeeID("Margaret Peacock", 4),
                    new EmployeeID("Steven Buchanan", 5),
                    new EmployeeID("Michael Suyama", 6),
                    new EmployeeID("Robert King", 7),
                    new EmployeeID("Laura Callahan", 8),
                    new EmployeeID("Anne Dodsworth", 9)
                };

                dataField.DisplayMemberPath = "Name";
                dataField.SelectedValuePath = "ID";
                dataField.DataMemberBinding = new Binding("ReportsTo");
                e.DataField = dataField;
            }
        }

        private void MyRadDataForm_EditEnding(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndingEventArgs e)
        {
            if (e.EditAction == Telerik.Windows.Controls.Data.DataForm.EditAction.Commit)
            {
                if (((sender as RadDataForm).CurrentItem as Employee_).FirstName == null
                    || ((sender as RadDataForm).CurrentItem as Employee_).LastName == null)
                {
                    e.Cancel = true;
                }

                if (MyRadDataForm.ValidateItem())
                {
                    MyRadDomainDataSource.SubmitChanges();
                }
            }
        }

        private void MyRadDataForm_DeletedItem(object sender, Telerik.Windows.Controls.Data.DataForm.ItemDeletedEventArgs e)
        {
            MyRadDomainDataSource.SubmitChanges();
        }

        public class EmployeeID
        {
            public string Name { get; set; }
            public int ID { get; set; }

            public EmployeeID(string name, int id)
            {
                Name = name;
                ID = id;
            }
        }

		private void MyRadDomainDataSource_LoadedData(object sender, Controls.DomainServices.LoadedDataEventArgs e)
		{
			if (e.HasError)
			{
				e.MarkErrorAsHandled();
				return;
			}
		}
    }
}
