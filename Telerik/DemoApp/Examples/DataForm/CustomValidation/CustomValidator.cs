using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel.DataAnnotations;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace Telerik.Windows.Examples.DataForm.CustomValidation
{
	public class CustomValidator
	{
		public static ValidationResult ValidateOccupation(Occupations occupation, ValidationContext validationContext)
		{
			Employee employee = validationContext.ObjectInstance as Employee;
			if (employee.Occupation == Occupations.QAEngineer && employee.Department == Departments.Chicago)
			{
				return new ValidationResult("No QA engineers are employed in the Chicago office.", new string[] { validationContext.MemberName });
			}
			else if (employee.Occupation == Occupations.SupportSpecialist && employee.Department == Departments.London)
			{
				return new ValidationResult("No support specialists are employed in the London office.", new string[] { validationContext.MemberName });
			}
			else
			{
				return ValidationResult.Success;
			}
		}

		public static ValidationResult ValidateHireDate(DateTime time)
		{			
			if (time.CompareTo(DateTime.Now) > 0)
			{
				return new ValidationResult("HireDate should be past from the present date.", new string[] { "HireDate" });
			}
			else
			{
				return ValidationResult.Success;
			}
		}			
	}
}
