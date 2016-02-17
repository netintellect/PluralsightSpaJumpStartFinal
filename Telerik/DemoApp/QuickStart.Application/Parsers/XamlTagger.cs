namespace Telerik.Windows.QuickStart.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Telerik.Windows.Documents.Code.Editor;
    using Telerik.Windows.Documents.Code.Tagging;
    using Telerik.Windows.Documents.Code.Text;

    public class XamlTagger : TaggerBase<ClassificationTag>
    {
        public XamlTagger(ITextDocumentEditor editor)
            : base(editor)
        {
        }

        public override IEnumerable<TagSpan<ClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            foreach (var span in spans)
            {
                string spanText = span.GetText();
                string stringToMatch = this.PrepareRegexString();
                string[] regexGroups = new string[] { "attribute", "element", "comment", "tag", "string", "content" };

                Regex regularExpression = new Regex(stringToMatch, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
                MatchCollection matches = regularExpression.Matches(spanText);

                foreach (Match match in matches)
                {
                    foreach (var description in regexGroups)
                    {
                        if (match.Groups[description].Success)
                        {
                            var start = span.Start + match.Index;
                            var length = match.Length;
                            var textSnapshot = this.Document.CurrentSnapshot;
                            var tagSpan = CreateTagSpan(textSnapshot, start, length, description);
                            
                            yield return tagSpan;
                        }
                    }
                }
            }

            yield break;
        }
  
        private string PrepareRegexString()
        {
            string attributes = @"\G(?<attribute>\s*[a-zA-Z][a-zA-Z0-9.:*_]*\s*(?==))";
            string elements = @"\G(?<element>(?<=(<)|(</))[a-zA-Z][a-zA-Z0-9.:*_]*\s*)";
            string comments = @"\G(?<comment><!--\s*[\s\S]*\s*-->\s*)";
            string tags = @"\G(?<tag>(</|<|/>|>)\s*)";
            string strings = "\\G(?<string>=\\s*\"[_=#{}a-zA-Z0-9.:;\\s-/,*]*\\s*\"\\s*)";
            string content = @"\G(?<content>[^<]+\s*)";
            string[] xamlClassifications = new string[] { attributes, elements, comments, tags, strings, content };

            StringBuilder builder = new StringBuilder();
            
            builder.Append(@"\s*");
            for (int i = 0; i < xamlClassifications.Count() - 1; i++)
            {
                builder.AppendFormat("{0}|", xamlClassifications[i]);
            }
            builder.AppendFormat("{0}", xamlClassifications[xamlClassifications.Count() - 1]);
            builder.Append(@"\s*");
            
            return builder.ToString();
        }
  
        private static TagSpan<ClassificationTag> CreateTagSpan(TextSnapshot snapshot, int start, int len, string description)
        {
            var textSnapshotSpan = new TextSnapshotSpan(snapshot, new Span(start, len));
            var classificationType = XamlSyntaxHighlightingHelper.GetXamlClassificationType(description);
            var classificationTag = new ClassificationTag(classificationType);
            var tagSpan = new TagSpan<ClassificationTag>(textSnapshotSpan, classificationTag);

            return tagSpan;
        }
    }
}
