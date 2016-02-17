using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls.FixedDocumentViewersUI.Dialogs;
using Telerik.Windows.Documents.Fixed.UI.Extensibility;

namespace Telerik.Windows.Examples.PdfViewer.Theming
{
    public partial class Example : UserControl
    {
        public Example()
        {
            ExtensibilityManager.RegisterFindDialog(new FindDialog());
            InitializeComponent();
        }
    }
}