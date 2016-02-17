using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Common.FormatProviders;
using Telerik.Windows.Documents.Flow.FormatProviders.Docx;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.FormatProviders.Pdf;
using Telerik.Windows.Documents.Flow.FormatProviders.Rtf;
using Telerik.Windows.Documents.Flow.FormatProviders.Txt;
using Telerik.Windows.Documents.Flow.Model;
using Telerik.Windows.Documents.Flow.Model.Editing;
using Telerik.Windows.Documents.Flow.Model.Styles;
using Telerik.Windows.Examples.WordsProcessing.Common;

namespace Telerik.Windows.Examples.WordsProcessing.Replace
{
    public class ExampleViewModel : ViewModelBase
    {
        private readonly ICommand openCommand;
        private readonly ICommand openSampleCommand;
        private readonly ICommand replaceAndSaveCommand;

        private readonly Dictionary<IFormatProvider<RadFlowDocument>, string> providers;
        private readonly List<ReplaceOption> replaceOptions;

        private RadFlowDocument document;
        private string fileName;
        private string defaultDocumentThumbnailPath;
        private bool isDocumentLoaded;
        private string sampleDocumentFile;
        private string selectedFormat;

        private bool replaceAndSaveIsEnabled;
        private bool replaceOptionsFieldsAreEnabled;
        private bool highlightTextOptionsFieldsAreEnabled;

        private ReplaceOption selectedReplaceOption;
        private bool useRegex;
        private bool matchCase;
        private bool matchWholeWord;
        private string stylingFindWhat;
        private string findWhat;
        private string replaceWith;
        

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

        public ICommand ReplaceAndSaveCommand
        {
            get
            {
                return this.replaceAndSaveCommand;
            }
        }

        public IEnumerable<ReplaceOption> ReplaceOptions
        {
            get
            {
                return this.replaceOptions;
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
                    this.UpdateReplaceAndSaveIsEnabledValue();
                }
            }
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

        public bool ReplaceAndSaveIsEnabled
        {
            get
            {
                return this.replaceAndSaveIsEnabled;
            }
            set
            {
                if (this.replaceAndSaveIsEnabled != value)
                {
                    this.replaceAndSaveIsEnabled = value;
                    this.OnPropertyChanged("ReplaceAndSaveIsEnabled");
                }
            }
        }

        public bool ReplaceOptionsFieldsAreEnabled
        {
            get
            {
                return this.replaceOptionsFieldsAreEnabled;
            }
            set
            {
                if (this.replaceOptionsFieldsAreEnabled != value)
                {
                    this.replaceOptionsFieldsAreEnabled = value;
                    this.OnPropertyChanged("ReplaceOptionsFieldsAreEnabled");
                }
            }
        }

        public bool HighlightTextOptionsFieldsAreEnabled
        {
            get
            {
                return this.highlightTextOptionsFieldsAreEnabled;
            }
            set
            {
                if (this.highlightTextOptionsFieldsAreEnabled != value)
                {
                    this.highlightTextOptionsFieldsAreEnabled = value;
                    this.OnPropertyChanged("HighlightTextOptionsFieldsAreEnabled");
                }
            }
        }

        public ReplaceOption SelectedReplaceOption
        {
            get
            {
                return this.selectedReplaceOption;
            }
            set
            {
                if (this.selectedReplaceOption != value)
                {
                    this.selectedReplaceOption = value;
                    this.OnPropertyChanged("SelectedReplaceOption");
                    this.UpdateReplaceAndSaveIsEnabledValue();
                    this.UpdateReplaceOptionsFields();
                }
            }
        }

        public bool UseRegex
        {
            get
            {
                return this.useRegex;
            }
            set
            {
                if (this.useRegex != value)
                {
                    this.useRegex = value;
                    this.OnPropertyChanged("UseRegex");
                }
            }
        }

        public bool MatchCase
        {
            get
            {
                return this.matchCase;
            }
            set
            {
                if (this.matchCase != value)
                {
                    this.matchCase = value;
                    this.OnPropertyChanged("MatchCase");
                }
            }
        }

        public bool MatchWholeWord
        {
            get
            {
                return this.matchWholeWord;
            }
            set
            {
                if (this.matchWholeWord != value)
                {
                    this.matchWholeWord = value;
                    this.OnPropertyChanged("MatchWholeWord");
                }
            }
        }

        public string StylingFindWhat
        {
            get
            {
                return this.stylingFindWhat;
            }
            set
            {
                if (this.stylingFindWhat != value)
                {
                    this.stylingFindWhat = value;
                    this.OnPropertyChanged("StylingFindWhat");
                }
            }
        }

        public string FindWhat
        {
            get
            {
                return this.findWhat;
            }
            set
            {
                if (this.findWhat != value)
                {
                    this.findWhat = value;
                    this.OnPropertyChanged("FindWhat");
                }
            }
        }

        public string ReplaceWith
        {
            get
            {
                return this.replaceWith;
            }
            set
            {
                if (this.replaceWith != value)
                {
                    this.replaceWith = value;
                    this.OnPropertyChanged("ReplaceWith");
                }
            }
        }

        public ExampleViewModel()
        {
            this.openCommand = new DelegateCommand(o => this.Open());
            this.openSampleCommand = new DelegateCommand(o => this.OpenSample());
            this.replaceAndSaveCommand = new DelegateCommand(o => this.ReplaceAndSave());

            this.providers = new Dictionary<IFormatProvider<RadFlowDocument>, string>()
            {
                {new DocxFormatProvider(), "Docx"},
                {new RtfFormatProvider(), "Rtf"},
                {new HtmlFormatProvider(), "Html"},
                {new TxtFormatProvider(), "Txt"}, 
                {new PdfFormatProvider(), "Pdf"}
            };

            this.replaceOptions = new List<ReplaceOption>();
            foreach(ReplaceOption replaceOption in Enum.GetValues(typeof(ReplaceOption)))
            {
                replaceOptions.Add(replaceOption);
            }

            this.replaceOptionsFieldsAreEnabled = true;

            this.stylingFindWhat = string.Empty;
            this.findWhat = string.Empty;
            this.replaceWith = string.Empty;
        }

        private void Open()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Docx files|*.docx|Rtf files|*.rtf|Html files|*.html|Text files|*.txt|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                string extension = Path.GetExtension(dialog.FileName);
                IFormatProvider<RadFlowDocument> provider = this.providers.Keys
                    .FirstOrDefault(p => p.SupportedExtensions
                        .Any(e => string.Equals(extension, e, StringComparison.InvariantCultureIgnoreCase)));

                if (provider == null)
                {
                    MessageBox.Show("Not supported file type.");
                    return;
                }

                this.selectedFormat = this.providers[provider];

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

                this.selectedFormat = "Docx";
            }
        }

        private void ReplaceAndSave()
        {
            this.Replace();

            string selectedFromat = this.selectedFormat;
            bool result = FileHelper.SaveDocument(this.Document, selectedFromat);

            if (result)
            {
                this.CleanDocument();
            }
        }

        private void Replace()
        {
            switch (this.SelectedReplaceOption)
            {
                case ReplaceOption.ReplaceText:
                    this.ReplaceText();
                    break;
                case ReplaceOption.ReplaceStyling:
                    this.ReplaceStyling();
                    break;
            }
        }

        private void ReplaceText()
        {
            if(string.IsNullOrEmpty(this.FindWhat))
            {
                return;
            }

            RadFlowDocumentEditor editor = new RadFlowDocumentEditor(this.Document);

            if (this.useRegex)
            {
                Regex oldTextRegex = new Regex(this.FindWhat);
                editor.ReplaceText(oldTextRegex, this.ReplaceWith);
            }
            else
            {
                editor.ReplaceText(this.FindWhat, this.ReplaceWith, this.MatchCase, this.MatchWholeWord);
            }
        }

        private void ReplaceStyling()
        {
            if(string.IsNullOrEmpty(this.StylingFindWhat))
            {
                return;
            }

            RadFlowDocumentEditor editor = new RadFlowDocumentEditor(this.Document);

            if (this.useRegex)
            {
                Regex searchedTextRegex = new Regex(this.StylingFindWhat);
                editor.ReplaceStyling(searchedTextRegex, properties => properties.HighlightColor.LocalValue = Colors.Yellow);
            }
            else
            {
                editor.ReplaceStyling(this.StylingFindWhat, this.MatchCase, this.MatchWholeWord, properties => properties.HighlightColor.LocalValue = Colors.Yellow);
            }
        }

        private void UpdateReplaceAndSaveIsEnabledValue()
        {
            this.ReplaceAndSaveIsEnabled = this.IsDocumentLoaded && this.SelectedReplaceOption != null;
        }

        private void UpdateReplaceOptionsFields()
        {
            switch (this.SelectedReplaceOption)
            {
                case ReplaceOption.ReplaceText:
                    this.ReplaceOptionsFieldsAreEnabled = true;
                    this.HighlightTextOptionsFieldsAreEnabled = false;
                    break;
                case ReplaceOption.ReplaceStyling:
                    this.ReplaceOptionsFieldsAreEnabled = false;
                    this.HighlightTextOptionsFieldsAreEnabled = true;
                    break;
                default:
                    this.ReplaceOptionsFieldsAreEnabled = true;
                    this.HighlightTextOptionsFieldsAreEnabled = false;
                    break;
            }
        }

        private void CleanDocument()
        {
            this.Document = null;
            this.FileName = null;
        }
    }
}
