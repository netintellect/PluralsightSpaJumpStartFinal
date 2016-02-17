using System;
using System.Windows.Interop;
using System.Windows.Resources;
using System.Windows;
using System.Reflection;
using System.IO;
using System.ComponentModel;
using Telerik.Windows.Controls;
using System.Xml.Linq;
using System.Linq;
using System.Collections.ObjectModel;
using System.Xml;
using System.Collections.Generic;

namespace Telerik.Windows.Examples
{
	public static class ExamplesDB
	{
		public static object GetCustomers()
		{
			return LoadCustomers();
		}

		public static ObservableCollection<Customer> GetCustomersCollection()
		{
			return LoadCustomers();
		}

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

		private static ObservableCollection<Customer> LoadCustomers()
		{
			StreamResourceInfo resourceInfo = Application.GetResourceStream(GetResourceUri("DataSources/Customers.xml"));
			XmlReader reader = XmlReader.Create(resourceInfo.Stream);

			XElement el = XElement.Load(reader);
			XName elementName = XName.Get("Customers", "http://tempuri.org/NWindDataSet.xsd");

			ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

			foreach (XElement customerElement in el.Elements(elementName))
				customers.Add(CreateCustomer(customerElement));

			return customers;
		}

		private static ObservableCollection<Employee> LoadEmployees()
		{
			StreamResourceInfo resourceInfo = Application.GetResourceStream(GetResourceUri("DataSources/Employees.xml"));
			XmlReader reader = XmlReader.Create(resourceInfo.Stream);

			XElement el = XElement.Load(reader);
			XName elementName = XName.Get("Employee", "http://tempuri.org/NWindDataSet.xsd");

			ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

			foreach (XElement employeeElement in el.Elements(elementName))
				employees.Add(CreateEmployee(employeeElement));

			return employees;
		}

		private static Customer CreateCustomer(XContainer customerElement)
		{
			Customer newCustomer = new Customer();
			XName customerID = XName.Get("CustomerID", "http://tempuri.org/NWindDataSet.xsd");
			XName companyName = XName.Get("CompanyName", "http://tempuri.org/NWindDataSet.xsd");
			XName country = XName.Get("Country", "http://tempuri.org/NWindDataSet.xsd");
			XName city = XName.Get("City", "http://tempuri.org/NWindDataSet.xsd");
			XName contactName = XName.Get("ContactName", "http://tempuri.org/NWindDataSet.xsd");
			XName boolean = XName.Get("Bool", "http://tempuri.org/NWindDataSet.xsd");

			newCustomer.CustomerID = customerElement.Element(customerID).Value;
			newCustomer.CompanyName = customerElement.Element(companyName).Value;
			newCustomer.Country = customerElement.Element(country).Value;
			newCustomer.City = customerElement.Element(city).Value;
			newCustomer.ContactName = customerElement.Element(contactName).Value;
			newCustomer.Bool = bool.Parse(customerElement.Element(boolean).Value);

			return newCustomer;
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
			newEmployee.Photo = employeeElement.Element(photo).Value;
			newEmployee.PostalCode = employeeElement.Element(postalCode).Value;
			newEmployee.Region = employeeElement.Element(region).Value;
			newEmployee.Title = employeeElement.Element(title).Value;
			newEmployee.TitleOfCourtesy = employeeElement.Element(titleOfCourtesy).Value;
			
			return newEmployee;
		}
	}
}
