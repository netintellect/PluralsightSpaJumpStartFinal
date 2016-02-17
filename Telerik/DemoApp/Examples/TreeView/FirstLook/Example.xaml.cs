using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Telerik.Windows.Examples.TreeView.FirstLook
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			this.MergeResourceDictionaries();
			InitializeComponent();

			ObservableCollection<Employee> employees = ExamplesDB.GetEmployeesCollection();

			List<Office> offices = new List<Office>();

			offices.Add(new Office("BLAUS USA", employees.Take(5),
					"Seatle", "USA", "blaus@blaus.com", "(206)555 -5759", "507 - 20th Ave., E., Apt 24A"));
			offices.Add(new Office("DUMON CORPORATION", employees.Skip(5).Take(2),
					"New York", "USA", "dumon@dumon.com", "(451)555 -1234", "123 - 26th Ave., E., Apt 6"));
			offices.Add(new Office("FISS GROUP", employees.Skip(7).Take(2),
					"Boston", "USA", "fissgroup@fissgroup.com", "(123)555 -5678", "Lexington str, 25, Apt 23"));

			offices[0].IsExpanded = true;
			offices[0].IsSelected = true;

			this.xTreeView.ItemsSource = offices;
		}

		private void MergeResourceDictionaries()
		{
			try
			{
				ResourceDictionary dict1 = new ResourceDictionary();
				ResourceDictionary dict2 = new ResourceDictionary();
#if WPF
				dict1.Source = new Uri("TreeView;component/FirstLook/DetailsTemplates.xaml", UriKind.RelativeOrAbsolute);
				dict2.Source = new Uri("TreeView;component/FirstLook/TreeViewTemplates_WPF.xaml", UriKind.RelativeOrAbsolute);
#else
				Application.LoadComponent(dict1, new Uri("TreeView;component/FirstLook/DetailsTemplates.xaml", UriKind.RelativeOrAbsolute));
				Application.LoadComponent(dict2, new Uri("TreeView;component/FirstLook/TreeViewTemplates_SL.xaml", UriKind.RelativeOrAbsolute));
#endif
				this.Resources.MergedDictionaries.Add(dict1);
				this.Resources.MergedDictionaries.Add(dict2);
			}
			catch
			{
			}
		}
	}

	public class Office
	{
		public string Name { get; set; }
		public IEnumerable<Employee> Employees { get; private set; }
		public string City { get; set; }
		public string Country { get; set; }
		public string Email { get; set; }
		public string WorkPhone { get; set; }
		public string Address { get; set; }
		public bool IsExpanded { get; set; }
		public bool IsSelected { get; set; }
		public bool IsEditable { get; set; }

		public Office(string name, IEnumerable<Employee> employees, string city, string country, string email, string workphone, string address)
		{
			this.Name = name;
			this.Employees = employees;
			this.City = city;
			this.Country = country;
			this.Email = email;
			this.WorkPhone = workphone;
			this.Address = address;
		}
	}
}