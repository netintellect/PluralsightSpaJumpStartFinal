using System.Globalization;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.CloudUpload.Common
{
	public class FileExtensionRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			if (value == null)
			{
				return new ValidationResult(false, null);
			}

			var fileName = value.ToString();
			if (fileName.Contains(".rar"))
			{
				return new ValidationResult(false, "You can not upload '.rar' files.");
			}

			return ValidationResult.ValidResult;
		}
	}
}
