using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Telerik.Windows.Documents.Layout;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.Documents.UI.Layers;

namespace Telerik.Windows.Examples.RichTextBox.CustomizePresentation
{
    public class HighlightCurrentLineLayer : DecorationUILayerBase
    {
        private static readonly Brush FillBrush = new SolidColorBrush(Color.FromArgb(191, 201, 193, 16));

        public override string Name
        {
            get
            {
                return "HighlightCurrentLineLayer";
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

            InlineLayoutBox currnetInline = this.Document.CaretPosition.GetCurrentInlineBox();
            ParagraphLineInfo lineInfo = this.Document.CaretPosition.GetCurrentInlineBox().LineInfo;
            float lineY = GetLineY(currnetInline);
            RectangleF paragraphRectangle = currnetInline.Parent.ControlBoundingRectangle;

            this.AddRectangle(new RectangleF(
                paragraphRectangle.X,
                lineY,
                paragraphRectangle.Width,
                lineInfo.Height));
        }

        private static float GetLineY(InlineLayoutBox box)
        {
            return box.ControlBoundingRectangle.Top - (box.LineInfo.BaselineOffset - box.BaselineOffset);
        }

        private void AddRectangle(RectangleF rect)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = Math.Max(0, rect.Width);
            rectangle.Height = rect.Height;

            rectangle.Fill = FillBrush;

            Canvas.SetTop(rectangle, rect.Top);
            Canvas.SetLeft(rectangle, rect.Left);
            base.AddDecorationElement(rectangle);
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
