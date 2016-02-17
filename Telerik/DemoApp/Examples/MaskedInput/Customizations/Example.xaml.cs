using System.Globalization;
using Telerik.Windows.Controls.MaskedInput.Tokens;

namespace Telerik.Windows.Examples.MaskedInput.Customizations
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
            InitializeCustomTokens();

			InitializeComponent();

            bankInput.Culture = this.CreateBankCulture();
		}


        private CultureInfo CreateBankCulture()
        {
            CultureInfo bankCulture = new CultureInfo("en-US");
            bankCulture.NumberFormat.CurrencyGroupSeparator = ((char)'\x0964').ToString();
            bankCulture.NumberFormat.CurrencyGroupSizes = new int[] { 1 };

            return bankCulture;
        }

        private void InitializeCustomTokens()
        {
            FirstCharCapitalFormatToken fccFormatToken = new FirstCharCapitalFormatToken();
            if (TokenLocator.GetTokenRule(fccFormatToken.Token, TokenTypes.Modifier) == null)
            {
                TokenLocator.AddCustomValidationRule(new FirstCharCapitalFormatToken());
            }
        }
	}
}
