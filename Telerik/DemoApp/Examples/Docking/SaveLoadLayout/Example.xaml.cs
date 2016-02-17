using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using Telerik.Windows.Controls;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.Docking.SaveLoadLayout
{
	public partial class Example : UserControl
	{
		LayoutData data;

		public Example()
		{
			InitializeComponent();
			this.XmlTextBox.DataContext = this.data = new LayoutData();
		}

		private string SaveLayoutAsString()
		{
			MemoryStream stream = new MemoryStream();
			this.Docking.SaveLayout(stream);

			stream.Seek(0, SeekOrigin.Begin);

			StreamReader reader = new StreamReader(stream);
			return reader.ReadToEnd();
		}

		private void LoadLayoutFromString(string xml)
		{
			using (Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
			{
				stream.Seek(0, SeekOrigin.Begin);
				this.Docking.LoadLayout(stream);
			}
		}

		private void ButtonSave_Click(object sender, RoutedEventArgs e)
		{
			this.data.Xml = this.SaveLayoutAsString();
			this.LoadLayoutButton.IsEnabled = true;
		}

		private void ButtonLoad_Click(object sender, RoutedEventArgs e)
		{
			this.LoadLayoutFromString(this.data.Xml);
		}

		private void CopyTextFromDocumentPane_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.TextBox.Text = this.DocumentTextBox.Text;
		}

		private void CopyTextToDocumentPane_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.DocumentTextBox.Text = this.TextBox.Text;
		}

	}
}
