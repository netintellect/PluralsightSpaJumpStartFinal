using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Telerik.Windows.Documents;
using Telerik.Windows.Documents.Layout;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.Documents.Selection;
using Telerik.Windows.Documents.UI.Layers;

namespace Telerik.Windows.Examples.RichTextBox.CustomizePresentation
{
    public class HighlightCurrentWordLayer : DecorationUILayerBase
    {
        private static readonly double StrokeThikness = 1.0;
        private static readonly Brush StrokeBrush = new SolidColorBrush(Color.FromArgb(255, 160, 160, 160));
        private static readonly Brush FillBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 31));

        public override string Name
        {
            get
            {
                return "HighlightCurrentWordLayer";
            }
        }

        public UILayerUpdateContext LastUpdateContext
        {
            get;
            private set;
        }

        public override void UpdateUIViewPortOverride(UILayerUpdateContext context)
        {
            this.LastUpdateContext = context;

            string currentWord = this.GetCurrentWord();
            if (string.IsNullOrEmpty(currentWord))
            {
                return;
            }

            List<SpanLayoutBox> list = new List<SpanLayoutBox>();
            LayoutBox currentParagraphBox = null;
            foreach (SpanLayoutBox spanBox in context.GetVisibleTextLayoutBoxes())
            {
                if (spanBox.IsFormattingSymbol)
                {
                    this.FlushBoxes(list, currentWord);
                }
                else if (currentParagraphBox != null && currentParagraphBox != spanBox.Parent)
                {
                    this.FlushBoxes(list, currentWord);
                    list.Add(spanBox);
                }
                else
                {
                    list.Add(spanBox);
                }

                currentParagraphBox = spanBox.Parent;
            }
            this.FlushBoxes(list, currentWord);

        }

        private void FlushBoxes(List<SpanLayoutBox> spanList, string word)
        {
            if (spanList.Count == 0)
            {
                return;
            }

            StringBuilder builder = new StringBuilder();
            spanList.ForEach((SpanLayoutBox spanBox) => builder.Append(spanBox.Text));

            if (builder.ToString() == word)
            {
                RectangleF rect = new RectangleF();
                rect.X = spanList[0].ControlBoundingRectangle.Left;
                rect.Width = spanList[spanList.Count - 1].ControlBoundingRectangle.Right - rect.X;

                rect.Y = spanList.Min((SpanLayoutBox s) => s.ControlBoundingRectangle.Top);
                rect.Height = spanList.Min((SpanLayoutBox s) => s.ControlBoundingRectangle.Bottom) - rect.Y;

                this.AddRectangle(rect);
            }

            spanList.Clear();
        }

        private void AddRectangle(RectangleF rect)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = Math.Max(0, rect.Width + 2 * StrokeThikness);
            rectangle.Height = rect.Height + 3 * StrokeThikness;

            rectangle.Fill = FillBrush;
            rectangle.Stroke = StrokeBrush;
            rectangle.StrokeThickness = StrokeThikness;

            Canvas.SetTop(rectangle, rect.Top);
            Canvas.SetLeft(rectangle, rect.Left - StrokeThikness);
            base.AddDecorationElement(rectangle);
        }

        private string GetCurrentWord()
        {
            DocumentPosition pos = new DocumentPosition(this.Document.CaretPosition);
            pos.MoveToCurrentWordStart();

            DocumentSelection selection = new DocumentSelection(this.Document);
            selection.AddSelectionStart(pos);

            pos.MoveToCurrentWordEnd();
            selection.AddSelectionEnd(pos);

            return selection.GetSelectedText().Trim();
        }

        protected override void OnDocumentChanged()
        {
            base.OnDocumentChanged();
            if (this.Document != null)
            {
                this.Document.CaretPosition.PositionChanged += CaretPosition_PositionChanged;
            }
        }

        protected override void OnDocumentChanging()
        {
            base.OnDocumentChanging();
            if (this.Document != null)
            {
                this.Document.CaretPosition.PositionChanged -= CaretPosition_PositionChanged;
            }
        }

        private void CaretPosition_PositionChanged(object sender, EventArgs e)
        {
            this.UpdateViewPort(this.LastUpdateContext);
        }
    }
}
