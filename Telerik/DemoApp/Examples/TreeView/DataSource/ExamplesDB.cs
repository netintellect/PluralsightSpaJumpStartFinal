using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Resources;
using System.Xml;
using System.Xml.Linq;

namespace Telerik.Windows.Examples
{
	public static class ExamplesDB
	{
		public static ObservableCollection<Employee> GetEmployeesCollection()
		{
			return LoadEmployees();
		}

		private static Uri GetResourceUri(string resource)
		{
			AssemblyName assemblyName = new AssemblyName(typeof(ExamplesDB).Assembly.FullName);
			string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
			Uri resourceUri = new Uri(resourcePath, UriKind.Relative);

			return resourceUri;
		}

		private static ObservableCollection<Employee> LoadEmployees()
		{
			StreamResourceInfo resourceInfo = Application.GetResourceStream(GetResourceUri("DataSource/Employees.xml"));
			XmlReader reader = XmlReader.Create(resourceInfo.Stream);

			XElement el = XElement.Load(reader);
			XName elementName = XName.Get("Employee", "http://tempuri.org/NWindDataSet.xsd");

			ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

			foreach (XElement employeeElement in el.Elements(elementName))
				employees.Add(CreateEmployee(employeeElement));

			return employees;
		}

        private static Employee CreateEmployee(XContainer employeeElement)
        {
            Employee newEmployee = new Employee();
            XName address = XName.Get("Address", "http://tempuri.org/NWindDataSet.xsd");
            XName birthDate = XName.Get("BirthDate", "http://tempuri.org/NWindDataSet.xsd");
            XName city = XName.Get("City", "http://tempuri.org/NWindDataSet.xsd");
            XName email = XName.Get("Email", "http://tempuri.org/NWindDataSet.xsd");
            XName country = XName.Get("Country", "http://tempuri.org/NWindDataSet.xsd");
            XName employeeID = XName.Get("EmployeeID", "http://tempuri.org/NWindDataSet.xsd");
            XName extension = XName.Get("Extension", "http://tempuri.org/NWindDataSet.xsd");
            XName firstName = XName.Get("FirstName", "http://tempuri.org/NWindDataSet.xsd");
            XName hireDate = XName.Get("HireDate", "http://tempuri.org/NWindDataSet.xsd");
            XName homePhone = XName.Get("HomePhone", "http://tempuri.org/NWindDataSet.xsd");
            XName lastName = XName.Get("LastName", "http://tempuri.org/NWindDataSet.xsd");
            XName notes = XName.Get("Notes", "http://tempuri.org/NWindDataSet.xsd");
            XName photo = XName.Get("Photo", "http://tempuri.org/NWindDataSet.xsd");
            XName postalCode = XName.Get("PostalCode", "http://tempuri.org/NWindDataSet.xsd");
            XName region = XName.Get("Region", "http://tempuri.org/NWindDataSet.xsd");
            XName title = XName.Get("Title", "http://tempuri.org/NWindDataSet.xsd");
            XName titleOfCourtesy = XName.Get("TitleOfCourtesy", "http://tempuri.org/NWindDataSet.xsd");

            newEmployee.Address = employeeElement.Element(address).Value;
            newEmployee.BirthDate = DateTime.Parse(employeeElement.Element(birthDate).Value);
            newEmployee.City = employeeElement.Element(city).Value;
            newEmployee.Email = employeeElement.Element(email).Value;
            newEmployee.Country = employeeElement.Element(country).Value;
            newEmployee.EmployeeID = int.Parse(employeeElement.Element(employeeID).Value);
            newEmployee.Extension = employeeElement.Element(extension).Value;
            newEmployee.FirstName = employeeElement.Element(firstName).Value;
            newEmployee.HireDate = DateTime.Parse(employeeElement.Element(hireDate).Value);
            newEmployee.HomePhone = employeeElement.Element(homePhone).Value;
            newEmployee.LastName = employeeElement.Element(lastName).Value;
            newEmployee.Notes = employeeElement.Element(notes).Value;
            newEmployee.Photo = "../Images/TreeView/Employees/" + employeeElement.Element(photo).Value;
            newEmployee.PostalCode = employeeElement.Element(postalCode).Value;
            newEmployee.Region = employeeElement.Element(region).Value;
            newEmployee.Title = employeeElement.Element(title).Value;
            newEmployee.TitleOfCourtesy = employeeElement.Element(titleOfCourtesy).Value;

            return newEmployee;
        }
	}
}
