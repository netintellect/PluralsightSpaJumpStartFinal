using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Common.FormatProviders;
using Telerik.Windows.Documents.Flow.FormatProviders.Docx;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.FormatProviders.Pdf;
using Telerik.Windows.Documents.Flow.FormatProviders.Rtf;
using Telerik.Windows.Documents.Flow.FormatProviders.Txt;
using Telerik.Windows.Documents.Flow.Model;
using Telerik.Windows.Examples.WordsProcessing.Common;

namespace Telerik.Windows.Examples.WordsProcessing.ConversionCommon
{
    public class FileExportViewModel : ViewModelBase
    {
        private string sampleDocumentFile;

        private readonly List<IFormatProvider<RadFlowDocument>> providers;

        private RadFlowDocument document;

        private bool isDocumentLoaded;

        private readonly ICommand openCommand;

        private readonly ICommand openSampleCommand;

        private readonly ICommand saveCommand;

        private string fileName;

        private readonly ObservableCollection<string> exportFormats;

        private string selectedExportFormat;

        private string defaultDocumentThumbnailPath;

        public FileExportViewModel()
        {
            this.exportFormats = new ObservableCollection<string>();
            this.exportFormats.CollectionChanged += this.exportFormats_CollectionChanged;

            this.providers = new List<IFormatProvider<RadFlowDocument>>()
            {
                new DocxFormatProvider(),
                new RtfFormatProvider(),
                new HtmlFormatProvider(),
                new TxtFormatProvider(), 
                new PdfFormatProvider()
            };

            this.saveCommand = new DelegateCommand(o => this.Save());
            this.openCommand = new DelegateCommand(o => this.Open());
            this.openSampleCommand = new DelegateCommand(o => this.OpenSample());
        }

        public string SampleDocumentFile
        {
            get
            {
                return this.sampleDocumentFile;
            }
            set
            {
                this.sampleDocumentFile = value;
            }
        }

        public RadFlowDocument Document
        {
            get
            {
                return this.document;
            }
            set
            {
                if (this.document != value)
                {
                    this.document = value;
                    this.IsDocumentLoaded = value != null;
                    this.OnPropertyChanged("Document");
                }
            }
        }

        public bool IsDocumentLoaded
        {
            get
            {
                return this.isDocumentLoaded;
            }
            set
            {
                if (this.isDocumentLoaded != value)
                {
                    this.isDocumentLoaded = value;
                    this.OnPropertyChanged("IsDocumentLoaded");
                }
            }
        }

        public ICommand OpenCommand
        {
            get
            {
                return this.openCommand;
            }
        }

        public ICommand OpenSampleCommand
        {
            get
            {
                return this.openSampleCommand;
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return this.saveCommand;
            }
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                if (this.fileName != value)
                {
                    this.fileName = value;
                    this.OnPropertyChanged("FileName");
                }
            }
        }

        public string DefaultDocumentThumbnailPath
        {
            get
            {
                return this.defaultDocumentThumbnailPath;
            }

            set
            {
                if (this.defaultDocumentThumbnailPath != value)
                {
                    this.defaultDocumentThumbnailPath = value;
                    this.OnPropertyChanged("DefaultDocumentThumbnailPath");
                }
                this.defaultDocumentThumbnailPath = value;
            }
        }

        public ObservableCollection<string> ExportFormats
        {
            get
            {
                return this.exportFormats;
            }
        }

        public string SelectedExportFormat
        {
            get
            {
                return this.selectedExportFormat;
            }
            set
            {
                if (this.selectedExportFormat != value)
                {
                    this.selectedExportFormat = value;

                    this.OnPropertyChanged("SelectedExportFormat");
                }
            }
        }

        private void Open()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Docx files|*.docx|Rtf files|*.rtf|Html files|*.html|Text files|*.txt|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                string extension = Path.GetExtension(dialog.FileName);
                IFormatProvider<RadFlowDocument> provider = this.providers
                    .FirstOrDefault(p => p.SupportedExtensions
                        .Any(e => string.Equals(extension, e, StringComparison.InvariantCultureIgnoreCase)));

                if (provider == null)
                {
                    MessageBox.Show("Not supported file type.");
                    return;
                }

                using (Stream stream = dialog.OpenFile())
                {
                    try
                    {
                        this.Document = provider.Import(stream);
                        this.FileName = Path.GetFileName(dialog.FileName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Could not open file.");
                        this.Document = null;
                        this.FileName = null;
                    }
                }
            }
        }

        private void OpenSample()
        {
            using (Stream stream = FileHelper.GetSampleResourceStream(this.SampleDocumentFile))
            {
                this.Document = new DocxFormatProvider().Import(stream);
                this.FileName = this.SampleDocumentFile;
            }
        }

        private void Save()
        {
            string selectedFromat = this.SelectedExportFormat;
            FileHelper.SaveDocument(this.Document, selectedFromat);
        }

        private void exportFormats_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (this.exportFormats.Count > 0)
            {
                this.SelectedExportFormat = this.ExportFormats[0];
            }
            else
            {
                this.SelectedExportFormat = string.Empty;
            }
        }
    }
}
