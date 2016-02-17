using System.Globalization;
using Telerik.Windows.Documents.Proofing;

namespace Telerik.Windows.Examples.SpellChecker
{
    /// <summary>
    /// This class is used only to work around limitations for using MEF in examples.
    /// </summary>
    public static class ExamplesSpellCheckersManager
    {
        private static bool registered;

        /// <summary>
        /// This method is used only to work around limitations for using MEF in examples.
        /// </summary>
        public static void RegisterSpellCheckers()
        {
            if (!registered)
            {
                RegisterSpellChecker(new TextBoxSpellChecker());
                RegisterSpellChecker(new RichTextBoxSpellChecker());
                RegisterSpellChecker(new RadRichTextBoxSpellChecker());

                registered = true;
            }
        }

        private static void RegisterSpellChecker(IControlSpellChecker controlSpellChecker)
        {
            DocumentSpellChecker documentSpellChecker = controlSpellChecker.SpellChecker as DocumentSpellChecker;
            if (documentSpellChecker != null)
            {
                documentSpellChecker.AddDictionary(new RadEn_USDictionary(), CultureInfo.InvariantCulture);
            }

            ControlSpellCheckersManager.RegisterControlSpellChecker(controlSpellChecker);
        }
    }
}
