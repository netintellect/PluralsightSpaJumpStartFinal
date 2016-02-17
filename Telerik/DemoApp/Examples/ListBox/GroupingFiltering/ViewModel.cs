using System;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ListBox.GroupingFiltering
{
	public class ViewModel : ViewModelBase
	{
		public ViewModel()
		{
			var list = this.GetEmployees();
			this.filteredEmploees = new CollectionViewSource();
			this.filteredEmploees.Source = list;
			this.filteredEmploees.Filter += this.EmployeeFilter;

			var groupFields = new ObservableCollection<string> { "Group to team", "Group to office", "Group to position" };
			this.groupingFields = new ObservableCollection<string>(groupFields);
		}

		private ObservableCollection<string> groupingFields;
		public ObservableCollection<string> GroupingFields
		{
			get
			{
				return this.groupingFields;
			}
		}

		private CollectionViewSource filteredEmploees;
		public CollectionViewSource FilteredEmploees
		{
			get { return filteredEmploees; }
			set { filteredEmploees = value; }
		}

		private string selectedGrouping;
		public string SelectedGrouping
		{
			get { return selectedGrouping; }
			set
			{
				selectedGrouping = value;
				this.GroupData(value);
			}
		}

		private string filterText = string.Empty;
		public string FilterText
		{
			get { return filterText; }
			set
			{
				filterText = value;
				OnPropertyChanged(() => this.FilterText);
				this.FilteredEmploees.View.Refresh();
			}
		}

		private void GroupData(string value)
		{
			switch (value)
			{
				case "Group to team":
					this.filteredEmploees.GroupDescriptions.Clear();
					this.filteredEmploees.GroupDescriptions.Add(new PropertyGroupDescription("Team"));
					break;
				case "Group to office":
					this.filteredEmploees.GroupDescriptions.Clear();
					this.filteredEmploees.GroupDescriptions.Add(new PropertyGroupDescription("Office"));
					break;
				case "Group to position":
					this.filteredEmploees.GroupDescriptions.Clear();
					this.filteredEmploees.GroupDescriptions.Add(new PropertyGroupDescription("Position"));
					break;
				default: this.filteredEmploees.GroupDescriptions.Clear();
					break;
			}
		}

		private void EmployeeFilter(object sender, FilterEventArgs e)
		{
			e.Accepted = this.EmployeeFilter(e.Item);
		}

		private bool EmployeeFilter(object item)
		{
			var employee = item as Employee;
			return employee != null && employee.Name.ToLower().Contains(this.FilterText.ToLower());
		}

		private ObservableCollection<Employee> GetEmployees()
		{
			var list = new ObservableCollection<Employee>();

			list.Add(new Employee { Name = "Huon Laprice", Position = "Events Assistant", Team = "Marketing", Office = "USA Office : Boston, MA", Address = "321 Jones Rd , Waltham, MA 04462", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image51.png", UriKind.RelativeOrAbsolute) });
			list.Add(new Employee { Name = "Keiran Hughes", Position = "Trainee", Team = "Marketing", Office = "Canada Office: Toronto", Address = "110-556 Portage Ave. Winnipeg, R3B 5A7", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image52.png", UriKind.RelativeOrAbsolute) });
			list.Add(new Employee { Name = "Swen Trommler", Position = "Brand Manager", Team = "Marketing", Office = "United Kingdom Office: London", Address = "15 Bedford Square London WC81C 15JA", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image53.png", UriKind.RelativeOrAbsolute) });
			list.Add(new Employee { Name = "Valentino Lorenco", Position = "Brand Manager", Team = "Marketing", Office = "Canada Office: Toronto", Address = "110-556 Portage Ave. Winnipeg, R3B 5A7", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image55.png", UriKind.RelativeOrAbsolute) });
			list.Add(new Employee { Name = "Linda Rodriges", Position = "Customer Advocate", Team = "Marketing", Office = "USA Office : San Diego, CA", Address = "12887 Scripps Summit Ct.", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image54.png", UriKind.RelativeOrAbsolute) });


			list.Add(new Employee { Name = "Elizabeth Brow", Position = "Events Assistant", Team = "Sales", Office = "USA Office : Austin, TX", Address = "Brazos Street, Suite 400", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image56.png", UriKind.RelativeOrAbsolute) });
			list.Add(new Employee { Name = "Deena Greece", Position = "Trainee", Team = "Sales", Office = "USA Office : Austin, TX", Address = "Brazos Street, Suite 400", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image57.png", UriKind.RelativeOrAbsolute) });
			list.Add(new Employee { Name = "Janine Labrune", Position = "Events Assistant", Team = "Sales", Office = "Canada Office: Toronto", Address = "Toronto 110-556 Portage Ave. Winnipeg", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image58.png", UriKind.RelativeOrAbsolute) });
			list.Add(new Employee { Name = "John Steel", Position = "Events Assistant", Team = "Sales", Office = "Canada Office: Toronto", Address = "Toronto 110-556 Portage Ave. Winnipeg", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image59.png", UriKind.RelativeOrAbsolute) });
			list.Add(new Employee { Name = "Jaime Yorres", Position = "Trainee", Team = "Sales", Office = "USA Office : Austin, TX", Address = "510 Brazos Street, Suite 400", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image60.png", UriKind.RelativeOrAbsolute) });
			list.Add(new Employee { Name = "Aria Cruz", Position = "Trainee", Team = "Sales", Office = "San Diego, CA", Address = "12887 Scripps Summit Ct.", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image61.png", UriKind.RelativeOrAbsolute) });



			list.Add(new Employee { Name = "Peter Franken", Position = "Trainee", Team = "Finance", Office = "USA Office : San Diego, CA", Address = "12887 Scripps Summit Ct.", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image62.png", UriKind.RelativeOrAbsolute) });
			list.Add(new Employee { Name = "Simon Crowther", Position = "Trainee", Team = "Finance", Office = "United Kingdom Office: London", Address = "15 Bedford Square London WC81C 15JA", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image63.png", UriKind.RelativeOrAbsolute) });
			list.Add(new Employee { Name = "John Terry", Position = "Brand Manager", Team = "Finance", Office = "United Kingdom Office: London", Address = "15 Bedford Square London WC81C 15JA", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image64.png", UriKind.RelativeOrAbsolute) });
			list.Add(new Employee { Name = "Michael Holz", Position = "Brand Manager", Team = "Finance", Office = "United Kingdom Office: London", Address = "110-556 Portage Ave. Winnipeg, R3B 5A7", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image65.png", UriKind.RelativeOrAbsolute) });
			list.Add(new Employee { Name = "Georg Pipps", Position = "Brand Manager", Team = "Finance", Office = "Canada Office: Toronto", Address = "15 Bedford Square London WC81C 15JA", PhotoPath = new Uri("../../Images/ListBox/GroupingFiltering/Image66.png", UriKind.RelativeOrAbsolute) });
			
			return list;
		}
	}
}