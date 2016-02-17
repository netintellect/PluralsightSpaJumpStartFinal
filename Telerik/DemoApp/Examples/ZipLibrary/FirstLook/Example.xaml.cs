using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using System.Collections.ObjectModel;
using Telerik.Windows.Zip;
using System.IO;
using System.Text;

#if WPF
using Microsoft.Win32;
#endif

namespace Telerik.Windows.Examples.ZipLibrary.FirstLook
{
    public partial class Example : UserControl
    {
        ObservableCollection<DataItem> items;

        public Example()
        {
            InitializeComponent();

            items = new ObservableCollection<DataItem>();

            for (int i = 1; i <= 7; i++)
            {
                items.Add(new DataItem() { IsSelected = true, FileName = "sample text file " + i + ".txt" });
            }

            FileList.ItemsSource = items;
        }

        private void ButtonSaveClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Zip File | *.zip";
            bool? dialogResult = dialog.ShowDialog();
            if (dialogResult == true)
            {
                using (ZipArchive zipArchive = new ZipArchive(dialog.OpenFile(), ZipArchiveMode.Create, false, null))
                {
                    IEnumerable<DataItem> selectedFiles = items.Where(CheckIsFileSelected);
                    foreach (DataItem file in selectedFiles)
                    {
                        MemoryStream stream = CreateNewFile(file);
                        using (ZipArchiveEntry archiveEntry = zipArchive.CreateEntry(file.FileName))
                        {
                            Stream entryStream = archiveEntry.Open();
                            stream.CopyTo(entryStream);
                        }
                    }
                }
            }
        }

        private void ButtonOpenClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Zip File | *.zip";
            bool? dialogResult = dialog.ShowDialog();

            if (dialogResult == true)
            {
#if WPF
                Stream stream = dialog.OpenFile();
#else
                Stream stream = dialog.File.OpenRead();
#endif
                using (ZipArchive zipArchive = new ZipArchive(stream))
                {
                    OpenedFileList.ItemsSource = zipArchive.Entries;
                }
            }
        }

        private void ButtonClearClick(object sender, RoutedEventArgs e)
        {
            OpenedFileList.ItemsSource = null;
        }


        private bool CheckIsFileSelected(DataItem file)
        {
            return file.IsSelected;
        }

        private MemoryStream CreateNewFile(DataItem file)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream, new UTF8Encoding());
            writer.Write(file.FileName);
            writer.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
    }

    public class DataItem : ViewModelBase
    {
        private bool isSelected;
        private string fileName;

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
                OnPropertyChanged("FileName");
            }
        }
    }
}
