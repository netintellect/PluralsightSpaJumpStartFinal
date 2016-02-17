using System.ComponentModel.Composition.Hosting;
using Telerik.Windows.Controls.RichTextBoxUI;
using Telerik.Windows.Controls.RichTextBoxUI.Dialogs;
using Telerik.Windows.Documents.FormatProviders.Html;
using Telerik.Windows.Documents.FormatProviders.OpenXml.Docx;
using Telerik.Windows.Documents.FormatProviders.Pdf;
using Telerik.Windows.Documents.FormatProviders.Rtf;
using Telerik.Windows.Documents.FormatProviders.Txt;
using Telerik.Windows.Documents.FormatProviders.Xaml;
using Telerik.Windows.Documents.Proofing;
using Telerik.Windows.Documents.UI.Extensibility;

namespace Telerik.Windows.Examples.RichTextBox.Extensibility
{
    /// <summary>
    /// This class is used only to work around limitations for using the default MEF catalog in Examples.
    /// </summary>
    public static class ExamplesMefCatalogManager
    {
        private static bool isDefaultCatalogChanged = false;

        /// <summary>
        /// This method is used only to work around limitations for using the default MEF catalog in Examples.
        /// </summary>
        public static void ChangeDefaultMefCatalog()
        {
            if (!isDefaultCatalogChanged)
            {
                RadCompositionInitializer.Catalog = new TypeCatalog(
                    // format providers
                    typeof(XamlFormatProvider),
                    typeof(RtfFormatProvider),
                    typeof(DocxFormatProvider),
                    typeof(PdfFormatProvider),
                    typeof(HtmlFormatProvider),
                    typeof(TxtFormatProvider),

                    // mini toolbars
                    typeof(SelectionMiniToolBar),
                    typeof(ImageMiniToolBar),

                    // context menu
                    typeof(ContextMenu),

                    // the default English spellchecking dictionary
                    typeof(RadEn_USDictionary),

                    // dialogs
                    typeof(AddNewBibliographicSourceDialog),
                    typeof(ChangeEditingPermissionsDialog),
                    typeof(EditCustomDictionaryDialog),
                    typeof(FindReplaceDialog),
                    typeof(FloatingBlockPropertiesDialog),
                    typeof(FontPropertiesDialog),
                    typeof(ImageEditorDialog),
                    typeof(InsertCaptionDialog),
                    typeof(CodeFormattingDialog),
                    typeof(InsertCrossReferenceWindow),
                    typeof(InsertDateTimeDialog),
                    typeof(InsertTableDialog),
                    typeof(InsertTableOfContentsDialog),
                    typeof(ManageBibliographicSourcesDialog),
                    typeof(ManageBookmarksDialog),
                    typeof(ManageStylesDialog),
                    typeof(NotesDialog),
                    typeof(ProtectDocumentDialog),
                    typeof(RadInsertHyperlinkDialog),
                    typeof(RadInsertSymbolDialog),
                    typeof(RadParagraphPropertiesDialog),
                    typeof(SetNumberingValueDialog),
                    typeof(SpellCheckingDialog),
                    typeof(StyleFormattingPropertiesDialog),
                    typeof(TableBordersDialog),
                    typeof(TablePropertiesDialog),
                    typeof(TabStopsPropertiesDialog),
                    typeof(UnprotectDocumentDialog),
                    typeof(WatermarkSettingsDialog)
                    );

                isDefaultCatalogChanged = true;
            }
        }
    }
}
