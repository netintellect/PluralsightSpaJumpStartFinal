using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace Telerik.Windows.Examples.PropertyGrid.DataAnnotationsSupport
{
	public class Employee 
	{
		private string firstName;
		private string lastName;
		private string occupation;
		private int salary;
		private string phoneNum;
		private int departmentId;
		private DateTime startingDate;
		private int age;
	
		[Description("Employee's first name.")]
		[Display(Name = "First Name", GroupName = "Personal Information")]		
		public string FirstName
		{
			get
			{
				return this.firstName;
			}
			set
			{
				if (this.firstName != value)
				{
					this.firstName = value;
				}
			}
		}
		
		[Display(Description = "Employee's last name.", GroupName = "Personal Information", Name = "Last Name")]
		public string LastName
		{
			get
			{
				return this.lastName;
			}
			set
			{
				if (this.lastName != value)
				{
					this.lastName = value;
				}
			}
		}
	
		[Description("Job title of the employee.")]
		[Display(Name = "Occupation", Order = 1, GroupName = "Job Description")]
		public string Occupation
		{
			get
			{
				return this.occupation;
			}
			set
			{
				if (this.occupation != value)
				{
					this.occupation = value;
				}
			}
		}
	
		[Description("Salary of the employee.")]
		[Display(Name = "Salary", Order = 4, GroupName = "Job Description")]
		public int Salary
		{
			get
			{
				return this.salary;
			}
			set
			{
				if (this.salary != value)
				{
					this.salary = value;
				}
			}
		}
		
		[Description("The phone number of the employee in his office.")]
		[Display(Name = "Phone Number", Order = 3, GroupName = "Personal Information")]
		[ReadOnly(true)]
		public string PhoneNum
		{
			get
			{
				return this.phoneNum;
			}
			set
			{
				if (this.phoneNum != value)
				{
					this.phoneNum = value;
				}
			}
		}
		
		[Browsable(true)]
		[Description("The department the employee is associated with.")]
		[Display(Name = "Department", Order = 2, GroupName = "Job Description")]
		[ReadOnly(true)]
		public int DepartmentId
		{
			get
			{
				return this.departmentId;
			}
			set
			{
				if (this.departmentId != value)
				{
					this.departmentId = value;
				}
			}
		}
	
		[Description("The date the employee was hired.")]
		[Display(Name = "Starting Date", Order = 5, GroupName = "Job Description")]
		public DateTime StartingDate
		{
			get
			{
				return this.startingDate;
			}
			set
			{
				if (this.startingDate != value)
				{
					this.startingDate = value;
				}
			}
		}

		[Display(AutoGenerateField = false)]
		public int Age
		{
			get
			{
				return this.age;
			}
			set
			{
				if (this.age != value)
				{
					this.age = value;
				}
			}
		}
	}
}
