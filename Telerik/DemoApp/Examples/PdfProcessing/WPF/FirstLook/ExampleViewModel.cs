using System;
using System.IO;
using System.Text;
using System.Windows.Input;
using Microsoft.Win32;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf.Export;
using Telerik.Windows.Documents.Fixed.FormatProviders.Text;
using Telerik.Windows.Documents.Fixed.Model;
using Telerik.Windows.Documents.Fixed.Model.ColorSpaces;
using Telerik.Windows.Documents.Fixed.Model.Editing;
using Telerik.Windows.Documents.Fixed.Model.Editing.Flow;
using Telerik.Windows.Documents.Fixed.Model.Resources;
using Telerik.Windows.Examples.PdfProcessing.Common;
using FontFamily = System.Windows.Media.FontFamily;
using FontStyles = System.Windows.FontStyles;
using FontWeights = System.Windows.FontWeights;
using G = Telerik.Windows.Documents.Fixed.Model.Graphics;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

namespace Telerik.Windows.Examples.PdfProcessing.WPF
{
    public class ExampleViewModel
    {
        private FixedContentEditor editor;

        public ExampleViewModel()
        {
            this.Save = new DelegateCommand(this.Export);
        }

        public ICommand Save { get; private set; }

        private void Export(object param)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = String.Format("{0} files|*.{1}|{2} files|*.{3}", "Pdf", "pdf", "Text", "txt");

            if (dialog.ShowDialog() == true)
            {
                using (var stream = dialog.OpenFile())
                {
                    RadFixedDocument document = this.CreateDocument();
                    switch (dialog.FilterIndex)
                    {
                        case 1:
                            PdfFormatProvider pdfFormatProvider = new PdfFormatProvider();
                            pdfFormatProvider.Export(document, stream);
                            break;
                        case 2:
                            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                            {
                                TextFormatProvider textFormatProvider = new TextFormatProvider();
                                writer.Write(textFormatProvider.Export(document));
                            }
                            break;
                    }
                }
            }
        }

        public RadFixedDocument CreateDocument()
        {
            RadFixedDocument document = new RadFixedDocument();
            RadFixedPage page = document.Pages.AddPage();
            page.Size = new Size(600, 800);
            this.editor = new FixedContentEditor(page);
            this.editor.Position.Translate(40, 50);
            using (Stream stream = FileHelper.GetSampleResourceStream("banner.png"))
            {
                ImageSource imageSource = new ImageSource(stream, ImageQuality.High);
                editor.DrawImage(imageSource, new Size(530, 80));
            }

            editor.Position.Translate(ExampleDocumentSizes.DefaultLeftIndent, 160);
            double maxWidth = page.Size.Width - ExampleDocumentSizes.DefaultLeftIndent * 2;

            this.DrawDescription(maxWidth);

            using (editor.SaveProperties())
            {
                using (editor.SavePosition())
                {
                    this.DrawFunnelFigure();
                }
            }

            return document;
        }

        private void SetTextProperties(Block block, ColorBase color, double fontSize, FontFamily fontFamily, bool isBold = false, bool isUnderlined = false)
        {
            block.GraphicProperties.FillColor = color;
            block.HorizontalAlignment = HorizontalAlignment.Left;
            block.TextProperties.FontSize = fontSize;
            System.Windows.FontWeight fontWeight = isBold ? FontWeights.Bold : FontWeights.Normal;
            block.TextProperties.TrySetFont(fontFamily, FontStyles.Normal, fontWeight);
            block.TextProperties.UnderlinePattern = isUnderlined ? UnderlinePattern.Single : UnderlinePattern.None;
        }

        private void DrawDescription(double maxWidth)
        {
            Block block = new Block();

            this.SetTextProperties(block, new RgbColor(155, 199, 5), 18, new FontFamily("Segoe UI"));
            block.InsertText("Thank you for choosing Telerik RadPdfProcessing!");
            editor.DrawBlock(block, new Size(maxWidth, double.PositiveInfinity));

            block = new Block();
            this.SetTextProperties(block, RgbColors.Black, 25, new FontFamily("Segoe UI"));
            block.InsertLineBreak();
            this.SetTextProperties(block, RgbColors.Black, 11, new FontFamily("Segoe UI"), true);
            block.InsertText("RadPdfProcessing");

            this.SetTextProperties(block, RgbColors.Black, 11, new FontFamily("Segoe UI"));
            block.InsertText(" is a document processing library that enables your application to import and export files to and from PDF format. The document model is entirely independent from UI and allows you to generate sleek documents with differently formatted text, images, shapes and more.");
            editor.DrawBlock(block, new Size(maxWidth, double.PositiveInfinity));

            double currentTopOffset = 480;
            editor.Position.Translate(ExampleDocumentSizes.DefaultLeftIndent, currentTopOffset);
            block = new Block();
            this.SetTextProperties(block, RgbColors.Black, 25, new FontFamily("Segoe UI"), true);
            block.InsertLineBreak();
            this.SetTextProperties(block, RgbColors.Black, 13, new FontFamily("Times New Roman"), true);
            block.InsertText("RadPdfProcessing");
            this.SetTextProperties(block, RgbColors.Black, 13, new FontFamily("Times New Roman"));
            block.InsertText(" was built with performance and stability in mind. The document automation is fast and has a low memory footprint even with large amounts of data.");
            editor.DrawBlock(block, new Size(maxWidth, double.PositiveInfinity));

            currentTopOffset += ExampleDocumentSizes.DefaultLineHeight * 3;
            editor.Position.Translate(ExampleDocumentSizes.DefaultLeftIndent, currentTopOffset);

            block = new Block();
            this.SetTextProperties(block, RgbColors.Black, 25, new FontFamily("Miriad pro"));
            block.InsertLineBreak();
            this.SetTextProperties(block, RgbColors.Black, 11, new FontFamily("Miriad pro"), false, true);
            block.InsertText("The intuitive API allows you to swiftly generate documents from scratch. Designed with the user in mind, RadPdfProcessing is straightforward and easy to use.");
            editor.DrawBlock(block, new Size(maxWidth, double.PositiveInfinity));

            block = new Block();
            this.SetTextProperties(block, new RgbColor(45, 178, 0), 35, new FontFamily("Segoe Print"));
            block.InsertLineBreak();

            this.SetTextProperties(block, new RgbColor(45, 178, 0), 12, new FontFamily("Segoe Print"));
            block.InsertText("September, 2014");
            block.InsertLineBreak();
            block.InsertText("by XAML Team");

            currentTopOffset += ExampleDocumentSizes.DefaultLineHeight * 2;

            editor.DrawBlock(block, new Size(maxWidth, double.PositiveInfinity));
            DrawLogo();
        }

        private void DrawLogo()
        {
            using (var stream = FileHelper.GetSampleResourceStream("telerikLogo.jpg"))
            {
                double imageWidth = 200;
                double imageHeight = 60;
                editor.Position.Translate(ExampleDocumentSizes.FunnelCenter.X - (imageWidth / 2), ExampleDocumentSizes.FunnelCenter.Y + ExampleDocumentSizes.FunnelHeight + ExampleDocumentSizes.ArrowLength + 220);

                ImageSource imageSource = new ImageSource(stream, ImageQuality.High);
                editor.DrawImage(imageSource, new Size(imageWidth, imageHeight));
            }
        }

        private void DrawFunnelFigure()
        {
            editor.Position.Translate(0, 0);
            editor.GraphicProperties.IsStroked = false;
            editor.GraphicProperties.FillColor = new RgbColor(147, 208, 237);

            editor.DrawEllipse(ExampleDocumentSizes.EllipseCenter, ExampleDocumentSizes.EllipseRadiuses.Width, ExampleDocumentSizes.EllipseRadiuses.Height);

            double funelBlockGap = (ExampleDocumentSizes.FunnelHeight - 3 * ExampleDocumentSizes.FunnelBlockHeight) / 2;

            double startPercent = 0;
            double endPercent = ExampleDocumentSizes.GetPercentHeight(ExampleDocumentSizes.FunnelBlockHeight);
            this.DrawFunnelBlock(startPercent, endPercent);

            startPercent = ExampleDocumentSizes.GetPercentHeight(ExampleDocumentSizes.FunnelBlockHeight + funelBlockGap);
            endPercent = ExampleDocumentSizes.GetPercentHeight(2 * ExampleDocumentSizes.FunnelBlockHeight + funelBlockGap);
            this.DrawFunnelBlock(startPercent, endPercent);

            startPercent = ExampleDocumentSizes.GetPercentHeight(2 * ExampleDocumentSizes.FunnelBlockHeight + 2 * funelBlockGap);
            endPercent = ExampleDocumentSizes.GetPercentHeight(3 * ExampleDocumentSizes.FunnelBlockHeight + 2 * funelBlockGap);
            this.DrawFunnelBlock(startPercent, endPercent);

            editor.Position.Translate(ExampleDocumentSizes.ArrowStart.X - 18, ExampleDocumentSizes.ArrowStart.Y + ExampleDocumentSizes.ArrowLength + 5);
            editor.TextProperties.FontSize = 18;
            editor.GraphicProperties.FillColor = new RgbColor(41, 156, 206);
            editor.TextProperties.TrySetFont(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold);
            editor.DrawText("PDF");
            this.DrawArrow();
        }

        private void DrawArrow()
        {
            editor.Position.Translate(ExampleDocumentSizes.ArrowStart.X, ExampleDocumentSizes.ArrowStart.Y);

            editor.GraphicProperties.IsStroked = true;
            editor.GraphicProperties.StrokeThickness = 1;
            editor.GraphicProperties.StrokeColor = new RgbColor(191, 191, 191);
            editor.GraphicProperties.IsFilled = true;
            editor.GraphicProperties.FillColor = editor.GraphicProperties.StrokeColor;

            var arrow = new G.PathGeometry();
            var figure = arrow.Figures.AddPathFigure();

            figure.StartPoint = new Point();
            figure.Segments.AddLineSegment(new Point(2, 0));
            figure.Segments.AddLineSegment(new Point(2, 13));
            figure.Segments.AddLineSegment(new Point(7, 7));
            figure.Segments.AddLineSegment(new Point(7, 13));
            figure.Segments.AddLineSegment(new Point(0, ExampleDocumentSizes.ArrowLength));
            figure.Segments.AddLineSegment(new Point(-7, 13));
            figure.Segments.AddLineSegment(new Point(-7, 7));
            figure.Segments.AddLineSegment(new Point(-2, 13));
            figure.Segments.AddLineSegment(new Point(-2, 0));

            figure.IsClosed = true;

            editor.DrawPath(arrow);
        }

        private void DrawFunnelBlock(double startPercentHeight, double endPercentHeight)
        {
            Point[] contourPoints = ExampleDocumentSizes.GetSubFunnelBlockContourPoints(startPercentHeight, endPercentHeight);
            editor.GraphicProperties.IsStroked = false;
            var path = new G.PathGeometry();
            var figure = path.Figures.AddPathFigure();
            figure.StartPoint = contourPoints[0];
            figure.IsClosed = true;
            string funnelBlockText;
            double textYOffset = 0;

            if (startPercentHeight == 0)
            {
                funnelBlockText = "IMAGES";
                editor.GraphicProperties.FillColor = new RgbColor(37, 160, 219);
                var arc = figure.Segments.AddArcSegment();
                arc.Point = contourPoints[1];
                arc.IsLargeArc = false;
                arc.SweepDirection = G.SweepDirection.Counterclockwise;
                arc.RadiusX = ExampleDocumentSizes.EllipseRadiuses.Width;
                arc.RadiusY = ExampleDocumentSizes.EllipseRadiuses.Height;
                textYOffset = arc.RadiusY / 2;
                figure.Segments.AddLineSegment(contourPoints[2]);
                figure.Segments.AddLineSegment(contourPoints[3]);
                textYOffset = ExampleDocumentSizes.EllipseRadiuses.Height;
            }
            else if (endPercentHeight == 1)
            {
                funnelBlockText = "FONTS";
                editor.GraphicProperties.FillColor = new RgbColor(42, 180, 0);
                figure.Segments.AddLineSegment(contourPoints[1]);
                figure.Segments.AddLineSegment(contourPoints[2]);
                var arc = figure.Segments.AddArcSegment();
                arc.Point = contourPoints[3];
                arc.IsLargeArc = false;
                arc.SweepDirection = G.SweepDirection.Clockwise;
                arc.RadiusX = ExampleDocumentSizes.EllipseRadiuses.Width;
                arc.RadiusY = ExampleDocumentSizes.EllipseRadiuses.Height + 100;
            }
            else
            {
                funnelBlockText = "SHAPES";
                editor.GraphicProperties.FillColor = new RgbColor(255, 127, 0);
                figure.Segments.AddLineSegment(contourPoints[1]);
                figure.Segments.AddLineSegment(contourPoints[2]);
                figure.Segments.AddLineSegment(contourPoints[3]);
            }

            editor.DrawPath(path);

            using (editor.SavePosition())
            {
                Size textSize = new Size(contourPoints[1].X - contourPoints[0].X, ExampleDocumentSizes.FunnelBlockHeight - textYOffset);
                editor.Position.Translate(contourPoints[0].X, contourPoints[0].Y + textYOffset);
                DrawCenteredText(editor, funnelBlockText, textSize);
            }
        }

        private static void DrawCenteredText(FixedContentEditor editor, string text, Size size)
        {
            Block block = new Block();

            block.TextProperties.TrySetFont(new FontFamily("Arial"));
            block.HorizontalAlignment = HorizontalAlignment.Center;
            block.VerticalAlignment = VerticalAlignment.Center;
            block.GraphicProperties.FillColor = RgbColors.White;
            block.TextProperties.FontSize = 16;
            block.InsertText(text);

            editor.DrawBlock(block, size);
        }
    }
}
