using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Flow.Model;
using Telerik.Windows.Documents.Flow.Model.Editing;
using Telerik.Windows.Documents.Flow.Model.Styles;
using Telerik.Windows.Documents.Spreadsheet.Model;
using Telerik.Windows.Examples.WordsProcessing.Common;
using Telerik.Windows.Examples.WordsProcessing.SampleData;

namespace Telerik.Windows.Examples.WordsProcessing.MailMerge
{
    public class ExampleViewModel : ViewModelBase
    {
        private static readonly ThemableColor greenColor = new ThemableColor(Color.FromArgb(255, 92, 230, 0));

        private ICommand mailMergeCommand = null;
        public ICommand MailMergeCommand
        {
            get
            {
                return this.mailMergeCommand;
            }
            set
            {
                if (this.mailMergeCommand != value)
                {
                    this.mailMergeCommand = value;
                    this.OnPropertyChanged("MailMergeCommand");
                }
            }
        }

        private IEnumerable<string> exportFormats;
        public IEnumerable<string> ExportFormats
        {
            get
            {
                if (exportFormats == null)
                {
                    exportFormats = new string[] { "Docx", "Rtf", "Html" };
                }

                return exportFormats;
            }
        }

        private string selectedExportFormat;
        public string SelectedExportFormat
        {
            get
            {
                return selectedExportFormat;
            }
            set
            {
                if (!object.Equals(selectedExportFormat, value))
                {
                    selectedExportFormat = value;

                    this.OnPropertyChanged("SelectedExportFormat");
                }
            }
        }

        private bool includeHeader = true;
        public bool IncludeHeader
        {
            get
            {
                return this.includeHeader;
            }
            set
            {
                if (this.includeHeader != value)
                {
                    this.includeHeader = value;
                    this.OnPropertyChanged("IncludeHeader");
                }
            }
        }

        private bool includeFooter = true;
        public bool IncludeFooter
        {
            get
            {
                return this.includeFooter;
            }
            set
            {
                if (this.includeFooter != value)
                {
                    this.includeFooter = value;
                    this.OnPropertyChanged("IncludeFooter");
                }
            }
        }
        public ExampleViewModel()
        {
            this.MailMergeCommand = new DelegateCommand(this.MailMerge);
        }

        private void MailMerge(object obj)
        {
            RadFlowDocument document = this.CreateDocument();

            RadFlowDocument mailMergeDocument = document.MailMerge(Person.Persons);
            mailMergeDocument.DocumentVariables.Add("sender", "Telerik Team");
            mailMergeDocument.UpdateFields();

            string selectedFromat = this.SelectedExportFormat;
            FileHelper.SaveDocument(mailMergeDocument, selectedFromat);
        }

        private RadFlowDocument CreateDocument()
        {
            RadFlowDocument document = new RadFlowDocument();
            RadFlowDocumentEditor editor = new RadFlowDocumentEditor(document);
            editor.ParagraphFormatting.TextAlignment.LocalValue = Alignment.Justified;
            
            Paragraph paragraphWithText = editor.InsertParagraph();
            editor.MoveToParagraphStart(paragraphWithText);

            editor.InsertText("Dear ");
            editor.InsertField("MERGEFIELD FirstName", "");
            editor.InsertText(" ");
            editor.InsertField("MERGEFIELD LastName", "");
            editor.InsertLine(",");
            editor.InsertLine("We're happy to introduce the new Telerik RadWordsProcessing component for WPF. High performance library that enables you to read, write and manipulate documents in DOCX, RTF, HTML and plain text format.");

            editor.InsertText("The current beta version comes with full rich-text capabilities including ");
            editor.InsertText("bold, ").FontWeight = FontWeights.Bold;
            editor.InsertText("italic, ").FontStyle = FontStyles.Italic;
            Run underlined = editor.InsertText("underline,");
            underlined.Underline.Pattern = UnderlinePattern.Dotted;
            underlined.Underline.Color = new ThemableColor(Colors.Black);
            editor.InsertText(" font sizes and ").FontSize = 20;
            editor.InsertText("colors ").ForegroundColor = greenColor;
            editor.InsertLine("as well as text alignment and indentation. Other options include tables, lists, hyperlinks, bookmarks and comments, inline and floating images. Even more sweetness is added by the built-in styles and themes.");

            editor.InsertLine("We hope you'll enjoy RadWordsProcessing as much as we do. Happy coding!");

            editor.InsertParagraph().Spacing.SpacingAfter = 0;
            editor.InsertLine("Regards,");
            editor.InsertField("DOCVARIABLE sender", "");

            editor.InsertParagraph();
            using (Stream stream = FileHelper.GetSampleResourceStream("TelerikLogoSmall.png"))
            {
                editor.InsertImageInline(stream, "png", new Size(118, 42));
            }

            return document;
        }
    }
}
