using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Zip;

namespace Telerik.Windows.Examples.ZipLibrary.CompressStream
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            CompressionMethods.ItemsSource = Enum.GetNames(typeof(CompressionMethod));

            UncompressedText.Text = Constants.XmlText;
        }

        private void CompressString(string str)
        {
            MemoryStream memoryStream = new MemoryStream();
            CompressionMethod method = (CompressionMethod)Enum.Parse(typeof(CompressionMethod), CompressionMethods.SelectedValue.ToString(), false);
            CompressionSettings settins = null;
            switch (method)
            {
                case CompressionMethod.Stored:
                    settins = new StoreSettings();
                    break;
                case CompressionMethod.Deflate:
                    settins = new DeflateSettings();
                    break;
                case CompressionMethod.Lzma:
                    settins = new LzmaSettings();
                    break;
            }

            CompressedStream zipOutputStream = new CompressedStream(memoryStream, StreamOperationMode.Write, settins);
            StreamWriter writer = new StreamWriter(zipOutputStream);
            writer.Write(str);
            writer.Flush();

            CompressedText.Text = Convert.ToBase64String(memoryStream.ToArray());
        }

        private string GetFieldName(FieldInfo field)
        {
            return field.Name;
        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            CompressString(UncompressedText.Text);
        }
    }
}
