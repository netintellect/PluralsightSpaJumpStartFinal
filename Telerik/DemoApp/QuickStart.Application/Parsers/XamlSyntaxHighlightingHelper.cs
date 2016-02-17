namespace Telerik.Windows.QuickStart.Parsers
{
    using System;
    using System.Windows.Media;
    using Telerik.Windows.Controls.CodeEditor.UI;
    using Telerik.Windows.Documents.Code.Tagging;

    public static class XamlSyntaxHighlightingHelper
    {
        public static readonly ClassificationType XamlAttribute;
        public static readonly ClassificationType XamlElement;
        public static readonly ClassificationType XamlComment;
        public static readonly ClassificationType XamlTag;
        public static readonly ClassificationType XamlString;
        public static readonly ClassificationType XamlContent;
        public static readonly TextFormatDefinition XamlAttributeFormatDefinition;
        public static readonly TextFormatDefinition XamlElementFormatDefinition;
        public static readonly TextFormatDefinition XamlCommentFormatDefinition;
        public static readonly TextFormatDefinition XamlContentFormatDefinition;
        public static readonly TextFormatDefinition XamlStringFormatDefinition;
        public static readonly TextFormatDefinition XamlTagFormatDefinition;

        static XamlSyntaxHighlightingHelper()
        {
            XamlAttribute = new ClassificationType("xamlAttribute");
            XamlElement = new ClassificationType("xamlElement");
            XamlComment = new ClassificationType("xamlComment");
            XamlTag = new ClassificationType("xamlTag");
            XamlString = new ClassificationType("xamlString");
            XamlContent = new ClassificationType("xamlContent");

            XamlAttributeFormatDefinition = new TextFormatDefinition(new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x4E)));
            XamlElementFormatDefinition = new TextFormatDefinition(new SolidColorBrush(Color.FromArgb(0xFF, 0xA3, 0x15, 0x15)));
            XamlCommentFormatDefinition = new TextFormatDefinition(new SolidColorBrush(Color.FromArgb(0xFF, 0x53, 0x7D, 0x01)));
            XamlContentFormatDefinition = new TextFormatDefinition(new SolidColorBrush(Color.FromArgb(0xFF, 0x01, 0x60, 0xE5)));
            XamlStringFormatDefinition = new TextFormatDefinition(new SolidColorBrush(Color.FromArgb(0xFF, 0x01, 0x60, 0xE5)));
            XamlTagFormatDefinition = new TextFormatDefinition(new SolidColorBrush(Color.FromArgb(0xFF, 0x01, 0x60, 0xE5)));
        }

        public static ClassificationType GetXamlClassificationType(string type)
        {
            switch (type)
            {
                case "xamlAttribute":
                case "attribute":
                    return XamlAttribute;
                case "xamlElement":
                case "element":
                    return XamlElement;
                case "xamlComment":
                case "comment":
                    return XamlComment;
                case "xamlTag":
                case "tag":
                    return XamlTag;
                case "xamlString":
                case "string":
                    return XamlString;
                case "xamlContent":
                case "content":
                    return XamlContent;
                default:
                    throw new NotImplementedException("GetXamlClassificationType(" + type + ")");
            }
        }
    }
}