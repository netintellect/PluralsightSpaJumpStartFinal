namespace Telerik.Windows.QuickStart.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Telerik.Windows.Controls;
    using Telerik.Windows.Documents.Code.Tagging;

    public class VisualBasicTagger : SimpleWordTaggerBase
    {
        private static readonly string[] KEYWORDS = new string[]
		{
            "AddHandler",
            "AddressOf",
            "Alias",
            "AndAlso",
            "And",
            "As",
            "Boolean",
            "ByRef",
            "Byte",
            "ByVal",
            "Call",
            "Case",
            "Catch",
            "CBool",
            "CByte",
            "CChar",
            "CDate",
            "CDec",
            "CDbl",
            "Char",
            "CInt",
            "Class",
            "CLng",
            "CObj",
            "Const",
            "Continue",
            "CSByte",
            "CShort",
            "CSng",
            "CStr",
            "CType",
            "CUInt",
            "CULng",
            "CUShort",
            "Date",
            "Decimal",
            "Declare",
            "Default",
            "Delegate",
            "Dim",
            "DirectCast",
            "Double",
            "Do",
            "Each",
            "ElseIf",
            "Else",
            "EndIf",
            "End",
            "Enum",
            "Erase",
            "Error",
            "Event",
            "Exit",
            "False",
            "Finally",
            "For",
            "Friend",
            "Function",
            "GetType",
            "Get",
            "Global",
            "GoSub",
            "GoTo",
            "Handles",
            "If",
            "Implements",
            "Imports",
            "Inherits",
            "Integer",
            "Interface",
            "In",
            "IsNot",
            "Is",
            "Let",
            "Lib",
            "Like",
            "Long",
            "Loop",
            "Me",
            "Module",
            "Mod",
            "MustInherit",
            "MustOverride",
            "MyBase",
            "MyClass",
            "Namespace",
            "Narrowing",
            "New",
            "Next",
            "Nothing",
            "Not",
            "NotInheritable",
            "NotOverridable",
            "Object",
            "Of",
            "On",
            "Operator",
            "Option",
            "Optional",
            "OrElse",
            "Or",
            "Overloads",
            "Overridable",
            "Overrides",
            "ParamArray",
            "Partial",
            "Private",
            "Property",
            "Protected",
            "Public",
            "RaiseEvent",
            "ReadOnly",
            "ReDim",
            "REM",
            "RemoveHandler",
            "Resume",
            "Return",
            "SByte",
            "Select",
            "Set",
            "Shadows",
            "Shared",
            "Short",
            "Single",
            "Static",
            "Step",
            "Stop",
            "String",
            "Structure",
            "Sub",
            "SyncLock",
            "Then",
            "Throw",
            "To",
            "True",
            "Try",
            "TryCast",
            "TypeOf",
            "Variant",
            "Wend",
            "UInteger",
            "ULong",
            "UShort",
            "Using",
            "When",
            "While",
            "Widening",
            "With",
            "WithEvents",
            "WriteOnly",
            "Xor",
          ////  "#Const",
           //// "#Else",
		  // // "#ElseIf",
		  // // "#End",
		  ////  "#If",
		  // // "-",
		  // // "&",
		  // // "&=",
		  // // "*",
		  // // "*=",
		  // // "/",
		  // // "/=",
		  // // "\\",
		  // // "\\=",
		  // // "^",
		  // // "^=",
		  // // "+",
		  ////  "+=",
		  ////  "=",
		  // // "-=",
        };


        private static readonly string[] COMMENTS = new string[]
		{
            "'",
        };

        private static readonly Dictionary<string, ClassificationType> WordsToClassificationType;

        static VisualBasicTagger()
        {
            WordsToClassificationType = new Dictionary<string, ClassificationType>();

            foreach (var keyword in KEYWORDS)
            {
                WordsToClassificationType.Add(keyword, ClassificationTypes.Keyword);
            }

            foreach (var comment in COMMENTS)
            {
                WordsToClassificationType.Add(comment, ClassificationTypes.Comment);
            }
        }

        public VisualBasicTagger(RadCodeEditor editor)
            : base(editor)
        {
        }

        protected override Dictionary<string, ClassificationType> GetWordsToClassificatoinTypes()
        {
            return VisualBasicTagger.WordsToClassificationType;
        }
    }
}
