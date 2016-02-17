using System;
using System.Collections.Generic;
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

namespace Telerik.Windows.Examples.Chart
{
	public static class ExamplesDB
	{
        private static string InvoicesDataSource = "DataSources/Invoices.xml";
        private static Collection<Invoice> invoices;

        public static Collection<Invoice> GetInvoices()
		{
            return LoadInvoices();
		}

		private static Uri GetResourceUri(string resource)
		{
			AssemblyName assemblyName = new AssemblyName(typeof(ExamplesDB).Assembly.FullName);
			string resourcePath = "/" + assemblyName.Name + ";component/" + resource;

			Uri resourceUri = new Uri(resourcePath, UriKind.Relative);

			return resourceUri;
		}

		private static Collection<Invoice> LoadInvoices()
		{
            StreamResourceInfo resourceInfo = Application.GetResourceStream(GetResourceUri(InvoicesDataSource));
            if (resourceInfo == null)
                return null;

            XDocument document = XDocument.Load(XmlReader.Create(resourceInfo.Stream));

            if (invoices == null)
                invoices = GetInvoicesFromDocument(document);

            return invoices;
		}

        private static Collection<Invoice> GetInvoicesFromDocument(XDocument document)
        {
            Collection<Invoice> list = new Collection<Invoice>();

            foreach (XElement element in document.Descendants("Invoices"))
            {
                Invoice invoice = new Invoice();
				invoice.Quantity = int.Parse(element.Element("Quantity").Value, System.Globalization.CultureInfo.InvariantCulture);
				invoice.UnitPrice = double.Parse(element.Element("UnitPrice").Value, System.Globalization.CultureInfo.InvariantCulture);

                list.Add(invoice);
            }

            return list;
        }
	}
}
