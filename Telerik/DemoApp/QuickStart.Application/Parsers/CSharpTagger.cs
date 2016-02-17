namespace Telerik.Windows.QuickStart.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Telerik.Windows.Controls;
    using Telerik.Windows.Documents.Code.Tagging;

    public class CSharpTagger : SimpleWordTaggerBase
    {
        private static readonly string[] KEYWORDS = new string[]
		{
            "abstract",
            "base",
            "byte",
            "bool",
            "char",
            "class",
            "const", 
            "decimal",
            "delegate",
            "double",
            "event",
            "explicit",
            "extern",
            "enum", 
            "finally",
            "false",
            "fixed",
            "float",
            "implicit",
            "in", 
            "int",
            "interface",
            "is",
            "internal",
            "lock", 
            "long",
            "new",
            "namespace",
            "null",
            "object",
            "operator",
            "out",
            "override",
            "params",
            "private",
            "protected",
            "public",
            "partial",
            "return",
            "readonly",
            "ref",
            "struct",
            "switch",
            "sbyte",
            "sealed",
            "sizeof",
            "short",
            "stackalloc", 	 
            "static", 	 
            "string",
            "this",
            "throw",
            "true",
            "try",
            "typeof",
            "uint",
            "ulong",
            "unchecked",
            "unsafe",
            "ushort",
            "virtual",
            "volatile",
            "void",
            "as",
            "break",
            "catch",
            "case",
            "checked",
            "continue",
            "default",
            "do",
            "else", 
            "for",
            "foreach",
            "goto",
            "if",
            "while",
            "using"
        };

        private static readonly string[] PREPROCESSORS = new string[]
		{
            "#if",
            "#else",
            "#elif",
            "#endif",
            "#define",
            "#undef",
            "#warning",
            "#error",
            "#line",
            "#region",
            "#endregion",
            "#pragma"
        };

        private static readonly string[] COMMENTS = new string[]
		{
            "//",
            "///"
        };

        private static readonly Dictionary<string, ClassificationType> WordsToClassificationType;

        static CSharpTagger()
        {
            WordsToClassificationType = new Dictionary<string, ClassificationType>();

            foreach (var keyword in KEYWORDS)
            {
                WordsToClassificationType.Add(keyword, ClassificationTypes.Keyword);
            }

            foreach (var preprocessor in PREPROCESSORS)
            {
                WordsToClassificationType.Add(preprocessor, ClassificationTypes.PreprocessorKeyword);
            }

            foreach (var comment in COMMENTS)
            {
                WordsToClassificationType.Add(comment, ClassificationTypes.Comment);
            }
        }

        public CSharpTagger(RadCodeEditor editor)
            : base(editor)
        {
        }

        protected override Dictionary<string, ClassificationType> GetWordsToClassificatoinTypes()
        {
            return CSharpTagger.WordsToClassificationType;
        }
    }
}
