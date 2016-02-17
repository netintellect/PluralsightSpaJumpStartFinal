using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.OutlookBar.FirstLook
{
	public partial class BusinessCard : UserControl
	{
		public BusinessCard()
		{
			InitializeComponent();
		}

		public void SetDataContext(Employee newEmployee)
		{
			this.lastNameOld.Text = newEmployee.LastName;
			this.firstNameOld.Text = newEmployee.FirstName;
			this.jobOld.Text = newEmployee.Title;
			this.cityOld.Text = newEmployee.City;
			this.countryOld.Text = newEmployee.Country;
			this.eMailOld.Text = newEmployee.FirstName + "." + newEmployee.LastName + "@hotmail.com";
			this.extensionOld.Text = newEmployee.Extension;
			this.homePhoneOld.Text = newEmployee.HomePhone;
			this.homeAddressOld.Text = newEmployee.Address;
			this.photo.Source = new BitmapImage(new Uri(newEmployee.Photo, UriKind.RelativeOrAbsolute));
		}
	}
}
