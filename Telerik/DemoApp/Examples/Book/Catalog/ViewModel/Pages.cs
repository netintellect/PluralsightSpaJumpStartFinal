using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.Book.Catalog
{
	public class Pages : ObservableCollection<Page>
	{
		public Pages()
		{
			for (int i = 1; i <= 22; i++)
			{
				Page myPage = new Page();
				string filePath = string.Format("../Images/Catalog/{0}.jpg", i);
				myPage.ImagePath = filePath;
				myPage.Index = i;
				this.Add(myPage);
			}
		}
	}
}
