using System.Collections.Generic;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Code.Tagging;
using Telerik.Windows.Documents.Code.Text;

namespace Telerik.Windows.QuickStart.Parsers
{
    // TODO: To be removed!
    public abstract class SimpleWordTaggerBase : TaggerBase<ClassificationTag>
    {
        #region Constructors

        public SimpleWordTaggerBase(RadCodeEditor editor)
            : base(editor)
        {
        }

        #endregion


        #region Methods

        protected abstract Dictionary<string, ClassificationType> GetWordsToClassificatoinTypes();

        private static int GetCharType(char c)
        {
            // TODO: Remove this workaround.
            if (c == '#')
            {
                return 0;
            }

            if (char.IsWhiteSpace(c))
            {
                return 1;
            }

            if (char.IsPunctuation(c) || char.IsSymbol(c))
            {
                return 2;
            }

            return 0;
        }

        private List<string> GetWords(string str)
        {
            List<string> words = new List<string>();
            string word;
            int lastCharType = -1;
            int startIndex = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int charType = GetCharType(str[i]);
                if (charType != lastCharType)
                {
                    word = str.Substring(startIndex, i - startIndex);
                    words.Add(word);
                    startIndex = i;
                    lastCharType = charType;
                }
            }

            word = str.Substring(startIndex, str.Length - startIndex);
            words.Add(word);

            return words;
        }

        public override IEnumerable<TagSpan<ClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            TextSnapshot snapshot = base.Document.CurrentSnapshot;

            Dictionary<string, ClassificationType> wordsToClassificationType = this.GetWordsToClassificatoinTypes();
            foreach (TextSnapshotSpan snapshotSpan in spans)
            {
                string inputString = snapshotSpan.GetText();
                var words = GetWords(inputString);

                int startIndex = snapshotSpan.Start;
                foreach (string word in words)
                {
                    ClassificationType classificationType;
                    if (wordsToClassificationType.TryGetValue(word, out classificationType))
                    {
                        TextSnapshotSpan tempSnapshotSpan;
                        if (classificationType == ClassificationTypes.Comment)
                        {
                            tempSnapshotSpan = new TextSnapshotSpan(snapshot, Span.FromBounds(startIndex, snapshotSpan.End));
                            yield return new TagSpan<ClassificationTag>(tempSnapshotSpan, new ClassificationTag(classificationType));
                            break;
                        }
                        else
                        {
                            tempSnapshotSpan = new TextSnapshotSpan(snapshot, new Span(startIndex, word.Length));
                            yield return new TagSpan<ClassificationTag>(tempSnapshotSpan, new ClassificationTag(classificationType));
                        }
                    }

                    startIndex += word.Length;
                }
            }
        }

        #endregion
    }
}