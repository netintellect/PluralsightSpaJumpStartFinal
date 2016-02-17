using System;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	/// <summary>
	/// Defines an upper or lower case type.
	/// </summary>
	/// <seealso cref="DataGenerator.RandomLetter(Telerik.Windows.Examples.Diagrams.Dashboard.CaseType)"/>.
	public enum CaseType
	{
		UpperCase,
		LowerCase
	}

	[Flags]
	public enum CharType
	{
		French = 0x1,
		Brackets = 0x2,
		Special = 0x4,
		UpperCaseLetters = 0x8,
		LowerCaseLetters = 0x10,
		Numbers = 0x12
	}
}