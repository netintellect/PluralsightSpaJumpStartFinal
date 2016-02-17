using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.PropertyGrid.GroupStyleSelector
{
	public class Employee
	{
		[Display(Name = "First Name", GroupName = "Name")]
		public string FirstName { get; set; }

		[Display(Description = "Employee's last name.", GroupName = "Name", Name = "Last Name")]
		public string LastName { get; set; }

		[Display(Name = "Occupation", GroupName = "Job Description")]
		public string Occupation { get; set; }

		[Display(Name = "Department", Order = 8, GroupName = "Job Description")]
		[ReadOnly(true)]
		public int DepartmentId { get; set; }

		[Display(Name = "Hire Date", GroupName = "Job Description")]
		public DateTime StartingDate { get; set; }
		
		[Display(Name = "Salary", GroupName = "Job Description")]
		public int Salary { get; set; }

		[Display(Name = "Phone Number", Order = 3, GroupName = "Work Contact")]
		public string WorkPhoneNum { get; set; }

		[Display(Name = "Email", GroupName = "Work Contact")]
		public string WorkEmail { get; set; }

		[Display(Name = "Phone Number", GroupName = "Personal Contact")]
		public string PhoneNum { get; set; }

		[Display(Name = "Email", GroupName = "Personal Contact")]
		public string Email { get; set; }

		[Display(Name = "Facebook", GroupName = "Personal Contact")]
		public string Facebook { get; set; }

		[Display(Name = "Age", GroupName = "Personal")]
		public int Age { get; set; }

		[Display(Name = "Gender", GroupName = "Personal")]
		public string Gender { get; set; }
	}
}
