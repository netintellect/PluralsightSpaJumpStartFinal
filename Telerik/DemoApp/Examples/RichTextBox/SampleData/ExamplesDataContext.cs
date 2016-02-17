using System.Collections.Generic;
using Telerik.Windows.Documents.Model;

namespace Telerik.Windows.Examples.RichTextBox.SampleData
{
    public class ExamplesDataContext
    {
        private List<Employee> employees;

        public List<Employee> Employees
        {
            get
            {
                if (this.employees == null)
                {
                    this.employees = new List<Employee>()
                    {
                        new Employee()
                        {
                            FirstName = "Andrew",
                            LastName = "Fuller", 
                            JobTitle = "Director - Finance",
                        }, 
                        new Employee()
                        {
                            FirstName = "Nancy",
                            LastName = "Davolio", 
                            JobTitle = "Director - Human Resources",
                        },
                        new Employee()
                        {
                            FirstName = "Robert",
                            LastName = "King", 
                            JobTitle = "Engineering Design Manager",
                        },
                        new Employee()
                        {
                            FirstName = "Margaret",
                            LastName = "Peacock", 
                            JobTitle = "Finance & Investments Officer",
                        }
                    };
                }

                return employees;
            }
        }

        private PermissionInfoCollection users;

        public PermissionInfoCollection Users
        {
            get
            {
                if (this.users == null)
                {
                    this.users = new PermissionInfoCollection() 
                    {
                        PermissionInfo.CreateEveryonePermissionInfo(),
                        new PermissionInfo("jmiller", PermissionType.Individual, "James Miller"),
                        new PermissionInfo("jsmith", PermissionType.Individual, "John Smith"),
                        new PermissionInfo("rbrown", PermissionType.Individual, "Robert Brown"),
                        new PermissionInfo("Administrators", PermissionType.Group, "Administrators"),
                    };
                }

                return users;
            }
        }

        private List<UserInfo> currentUsers;

        public List<UserInfo> CurrentUsers
        {
            get
            {
                if (this.currentUsers == null)
                {
                    this.currentUsers = new List<UserInfo>() 
                    {
                        new UserInfo("Users", "James Miller", "jmiller", "jmiller@example.com"),
                        new UserInfo("Administrators", "John Smith", "jsmith", "jsmith@example.com"),
                        new UserInfo("Administrators", "Robert Brown", "rbrown", "rbrown@example.com"),
                    };
                }

                return this.currentUsers;
            }
        }
    }
}
