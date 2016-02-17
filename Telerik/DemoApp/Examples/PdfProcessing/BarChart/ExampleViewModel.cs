using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf.Export;
using Telerik.Windows.Documents.Fixed.FormatProviders.Text;
using Telerik.Windows.Documents.Fixed.Model;
using Telerik.Windows.Documents.Fixed.Model.ColorSpaces;
using Telerik.Windows.Documents.Fixed.Model.Editing;
using Telerik.Windows.Examples.PdfProcessing.Common;
#if SILVERLIGHT
using SaveFileDialog = System.Windows.Controls.SaveFileDialog;
#else
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
#endif

using Editing = Telerik.Windows.Documents.Fixed.Model.Editing;
using FontStyles = System.Windows.FontStyles;
using FontWeights = System.Windows.FontWeights;
using Size = System.Windows.Size;
using Point = System.Windows.Point;
using Rect = System.Windows.Rect;
using Telerik.Windows.Documents.Fixed.Model.Editing.Flow;
using Telerik.Windows.Documents.Fixed.Model.Editing.Tables;
using Telerik.Windows.Documents.Fixed.Model.Resources;

namespace Telerik.Windows.Examples.PdfProcessing.BarChart
{
    public class ExampleViewModel : ViewModelBase
    {
        private static readonly double chartWidth = 600;
        private static readonly double chartHeight = 360;
        private static readonly double markerAreaWidth = 60;
        private static readonly double marginTop = 200;
        private static readonly double valuesMargin = 10;
        private static readonly double rectSize = 8;
        private static readonly double barMargin = 2;
        private static readonly int markersCount = 7;

        private static readonly RgbColor[] colors =
            {
                new RgbColor(46, 204, 113),
                new RgbColor(155, 89, 182),
                new RgbColor(52, 152, 219),
                new RgbColor(241, 196, 15),
                new RgbColor(230, 126, 34),
                new RgbColor(231, 76, 60)
            };

        private readonly Product[] products;
        private readonly Dictionary<int, bool> quartersToExport;

        private bool q1;
        private bool q2;
        private bool q3;
        private bool q4;
        private int exportedProductsCount;
        private double stepValue;

        public ExampleViewModel()
        {
            this.products = Product.GetProducts();
            this.quartersToExport = new Dictionary<int, bool>();
            this.Save = new DelegateCommand(this.Export);

            this.InitializeData();
        }

        private static Size MeasureText(FixedContentEditor editor, string text)
        {
            Block block = CreateBlock(editor);
            block.InsertText(text);

            return block.Measure();
        }

        private static void DrawText(FixedContentEditor editor, string text, double width = double.PositiveInfinity, HorizontalAlignment alignment = HorizontalAlignment.Left)
        {
            Block block = CreateBlock(editor);
            block.HorizontalAlignment = alignment;
            block.InsertText(text);
            editor.DrawBlock(block, new Size(width, double.PositiveInfinity));
        }

        private static Block CreateBlock(FixedContentEditor editor)
        {
            Block block = new Block();
            block.TextProperties.CopyFrom(editor.TextProperties);
            block.GraphicProperties.CopyFrom(editor.GraphicProperties);

            return block;
        }

        private void InitializeData()
        {
            this.quartersToExport.Add(0, false);
            this.quartersToExport.Add(1, false);
            this.quartersToExport.Add(2, false);
            this.quartersToExport.Add(3, false);

            this.Q1 = true;
            this.Q2 = true;
            this.Q3 = true;
            this.Q4 = true;
            this.ExportedProductsCount = this.products.Length;
            this.StepValue = 5000;

            this.Products = new List<int>();
            for (int currentIndex = 0; currentIndex < this.products.Length; currentIndex++)
            {
                this.Products.Add(currentIndex + 1);
            }
        }

        public ICommand Save { get; private set; }

        public List<int> Products { get; private set; }

        public int ExportedProductsCount
        {
            get { return this.exportedProductsCount; }
            set
            {
                if (this.exportedProductsCount != value)
                {
                    this.exportedProductsCount = value;
                    this.OnPropertyChanged("ExportedProductsCount");
                }
            }
        }

        public double StepValue
        {
            get { return this.stepValue; }
            set
            {
                if (this.stepValue != value)
                {
                    this.stepValue = value;
                    this.OnPropertyChanged("StepValue");
                }
            }
        }

        public bool Q1
        {
            get { return this.q1; }
            set
            {
                if (this.q1 != value)
                {
                    this.q1 = value;
                    this.quartersToExport[0] = this.q1;
                    this.OnPropertyChanged("Q1");
                }
            }
        }

        public bool Q2
        {
            get { return this.q2; }
            set
            {
                if (this.q2 != value)
                {
                    this.q2 = value;
                    this.quartersToExport[1] = this.q2;
                    this.OnPropertyChanged("Q2");
                }
            }
        }

        public bool Q3
        {
            get { return this.q3; }
            set
            {
                if (this.q3 != value)
                {
                    this.q3 = value;
                    this.quartersToExport[2] = this.q3;
                    this.OnPropertyChanged("Q3");
                }
            }
        }

        public bool Q4
        {
            get { return this.q4; }
            set
            {
                if (this.q4 != value)
                {
                    this.q4 = value;
                    this.quartersToExport[3] = this.q4;
                    this.OnPropertyChanged("Q4");
                }
            }
        }

        private Stream CompanyLogoImageStream
        {
            get
            {
                return FileHelper.GetSampleResourceStream("abCompany.jpg");
            }
        }

        private void Export(object param)
        {
            if (!this.quartersToExport.Values.Contains(true))
            {
                return;
            }

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

        private RadFixedDocument CreateDocument()
        {
            RadFixedDocument document = new RadFixedDocument();
            RadFixedPage page = document.Pages.AddPage();
            page.Size = new Size(792, 1128);
            FixedContentEditor editor = new FixedContentEditor(page);

            this.DrawBarChartContent(editor);
            this.DrawTableReportContent(editor);

            return document;
        }

        private void DrawTableReportContent(FixedContentEditor editor)
        {
            RgbColor headerColor = new RgbColor(79, 129, 189);
            RgbColor bordersColor = new RgbColor(149, 179, 215);
            RgbColor alternatingRowColor = new RgbColor(219, 229, 241);

            Border border = new Border(1, Editing.BorderStyle.Single, bordersColor);

            Table table = new Table();
            table.Borders = new TableBorders(border);
            table.LayoutType = TableLayoutType.FixedWidth;
            table.DefaultCellProperties.Borders = new TableCellBorders(border, border, border, border);
            table.DefaultCellProperties.Padding = new System.Windows.Thickness(2);

            TableRow headerRow = table.Rows.AddTableRow();
            TableCell headerCell = headerRow.Cells.AddTableCell();
            headerCell.Borders = new TableCellBorders(new Border(BorderStyle.None));
            headerCell.ColumnSpan = GetQuartersToExportCount() + 1;
            Block headerBlock = headerCell.Blocks.AddBlock();
            headerBlock.HorizontalAlignment = HorizontalAlignment.Center;
            ImageSource imageSource = new ImageSource(this.CompanyLogoImageStream, ImageQuality.High);
            headerBlock.InsertImage(imageSource);

            TableRow quartersRow = table.Rows.AddTableRow();
            TableCell cell = quartersRow.Cells.AddTableCell();
            cell.Background = headerColor;
            cell.Borders = new TableCellBorders(border, border, border, border, null, border);

            foreach (KeyValuePair<int, bool> quarter in this.quartersToExport)
            {
                if (quarter.Value)
                {
                    TableCell quarterCell = quartersRow.Cells.AddTableCell();
                    quarterCell.Background = headerColor;

                    Block quarterBlock = quarterCell.Blocks.AddBlock();
                    quarterBlock.GraphicProperties.FillColor = RgbColors.White;
                    quarterBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    quarterBlock.InsertText(String.Format("Q{0}", quarter.Key + 1));
                }
            }

            for (int i = 0; i < this.ExportedProductsCount; i++)
            {
                RgbColor rowColor = i % 2 == 0 ? alternatingRowColor : RgbColors.White;
                Product product = this.products[i];

                TableRow productRow = table.Rows.AddTableRow();
                TableCell productNameCell = productRow.Cells.AddTableCell();
                productNameCell.Background = rowColor;
                Block nameBlock = productNameCell.Blocks.AddBlock();
                nameBlock.InsertText(product.Name);

                foreach (KeyValuePair<int, bool> quarter in this.quartersToExport)
                {
                    if (quarter.Value)
                    {
                        TableCell quarterAmountCell = productRow.Cells.AddTableCell();
                        quarterAmountCell.Background = rowColor;
                        Block amountBlock = quarterAmountCell.Blocks.AddBlock();
                        amountBlock.HorizontalAlignment = HorizontalAlignment.Right;
                        amountBlock.InsertText(string.Format("{0:C}", product.Q[quarter.Key]));
                    }
                }
            }

            double top = marginTop + chartHeight + 50;
            double left = GetLeftMargin(editor.Root.Size.Width);
            table.Draw(editor, new Rect(left, top, chartWidth, double.PositiveInfinity));
        }

        private double GetLeftMargin(double pageWidth)
        {
            return (pageWidth - chartWidth) / 2;
        }

        private void DrawBarChartContent(FixedContentEditor editor)
        {
            editor.GraphicProperties.IsFilled = false;
            this.DrawCompanyLogo(editor);

            double leftMargin = this.GetLeftMargin(editor.Root.Size.Width);
            double offsetX;
            double offsetY;

            this.DrawChartFrame(leftMargin, editor, out offsetX, out offsetY);

            double offset = 20;
            double textWidth = 0;
            double rectMargin = 2;

            for (int i = 0; i < this.ExportedProductsCount; i++)
            {
                textWidth += rectSize + rectMargin + offset;
                textWidth += MeasureText(editor, this.products[i].Name).Width;
            }

            offsetX = leftMargin + ((chartWidth - textWidth) / 2);
            offsetY += 20;
            for (int i = 0; i < this.ExportedProductsCount; i++)
            {
                editor.Position.Translate(offsetX, offsetY);
                Tiling tiling = CreateTiling(offsetX, offsetY, rectSize, colors[i]);

                Block block = new Block();
                block.GraphicProperties.FillColor = tiling;
                block.GraphicProperties.IsStroked = false;
                block.InsertRectangle(new Rect(0, 0, rectSize, rectSize));
                block.GraphicProperties.FillColor = RgbColors.Black;
                block.InsertText(" " + this.products[i].Name);
                editor.DrawBlock(block);
                offsetX += block.DesiredSize.Width + offset;
            }

            offsetX = leftMargin;

            offsetY += 30;
            double markerHeight = (chartHeight - (offsetY - marginTop)) / markersCount;
            editor.Position.Translate(offsetX, offsetY);

            for (int i = markersCount - 1; i >= 0; i--)
            {
                DrawText(editor, string.Format("{0:C}", i * this.StepValue), markerAreaWidth, HorizontalAlignment.Right);
                if (i > 0)
                {
                    offsetY += markerHeight;
                    editor.Position.Translate(offsetX, offsetY);
                }
            }

            offsetX = leftMargin + markerAreaWidth + valuesMargin;
            double center = MeasureText(editor, "X").Height / 2;
            offsetY += center;
            double valueHeight = markerHeight / this.StepValue;
            double dataAreaWidth = chartWidth - markerAreaWidth - 2 * valuesMargin;

            double sectionWidth = dataAreaWidth / this.GetQuartersToExportCount();
            double barWidth = (sectionWidth - 2 * valuesMargin - 2 * this.ExportedProductsCount * barMargin) / this.ExportedProductsCount;
            for (int j = 0; j < this.quartersToExport.Keys.Count; j++)
            {
                if (!this.quartersToExport[j])
                {
                    continue;
                }

                editor.Position.Translate(offsetX, offsetY + 5);
                editor.GraphicProperties.FillColor = RgbColors.Black;
                DrawText(editor, string.Format("Q{0}", j + 1), sectionWidth, HorizontalAlignment.Center);
                editor.Position.Translate(0, 0);
                offsetX += valuesMargin;
                for (int i = 0; i < this.ExportedProductsCount; i++)
                {
                    Product product = this.products[i];
                    double h = product.Q[j] * valueHeight;
                    offsetX += barMargin;
                    Tiling tiling = CreateTiling(offsetX, offsetY - h, barWidth, colors[i]);
                    editor.GraphicProperties.FillColor = tiling;
                    editor.DrawRectangle(new Rect(offsetX, offsetY - h, barWidth, h));
                    offsetX += barWidth + barMargin;
                }

                offsetX += valuesMargin;
            }

            offsetX = leftMargin + markerAreaWidth + valuesMargin;
            DrawBarLine(editor, offsetX, offsetY, dataAreaWidth);
        }

        private void DrawCompanyLogo(FixedContentEditor editor)
        {
            editor.Position.Translate(230, 80);
            using (Stream stream = this.CompanyLogoImageStream)
            {
                ImageSource imageSource = new ImageSource(stream, ImageQuality.High);
                editor.DrawImage(imageSource);
            }
            editor.Position.Translate(0, 0);
        }

        private void DrawChartFrame(double leftMargin, FixedContentEditor editor, out double offsetX, out double offsetY)
        {
            offsetX = leftMargin;
            offsetY = marginTop;
            editor.DrawRectangle(new Rect(offsetX, offsetY, chartWidth, chartHeight));
            offsetY += 10;
            editor.Position.Translate(offsetX, offsetY);

            editor.TextProperties.FontSize = 18;
            editor.TextProperties.TrySetFont(new System.Windows.Media.FontFamily("Calibri"), FontStyles.Normal, FontWeights.Bold);
            DrawText(editor, "2013", chartWidth, HorizontalAlignment.Center);

            offsetY += 30;
            editor.Position.Translate(offsetX, offsetY);

            editor.TextProperties.TrySetFont(new System.Windows.Media.FontFamily("Calibri"));
            editor.TextProperties.FontSize = 10;
            editor.GraphicProperties.IsFilled = true;
            editor.GraphicProperties.IsStroked = false;
        }

        private static Tiling CreateTiling(double offsetX, double offsetY, double width, SimpleColor color)
        {
            Tiling tiling = new Tiling(new Rect(0, 0, width, 2));
            tiling.Position.Translate(offsetX, offsetY);
            var tilingEditor = new FixedContentEditor(tiling);
            tilingEditor.GraphicProperties.IsStroked = false;
            tilingEditor.GraphicProperties.FillColor = color;
            tilingEditor.DrawRectangle(new Rect(0, 0, width, 1));
            LinearGradient gradient = new LinearGradient(new Point(0, 0), new Point(width, 0));
            gradient.GradientStops.Add(new GradientStop(color, 0));
            gradient.GradientStops.Add(new GradientStop(RgbColors.White, .5));
            gradient.GradientStops.Add(new GradientStop(color, 1));
            tilingEditor.GraphicProperties.FillColor = gradient;
            tilingEditor.DrawRectangle(new Rect(0, 1, width, 1));

            return tiling;
        }

        private static void DrawBarLine(FixedContentEditor editor, double offsetX, double offsetY, double width)
        {
            editor.GraphicProperties.FillColor = RgbColors.Black;
            editor.GraphicProperties.StrokeThickness = 1;
            editor.GraphicProperties.IsFilled = false;
            editor.GraphicProperties.IsStroked = true;
            editor.DrawLine(new Point(offsetX, offsetY), new Point(offsetX + width, offsetY));
        }

        private int GetQuartersToExportCount()
        {
            int counter = 0;
            foreach (bool shouldExportQ in this.quartersToExport.Values)
            {
                if (shouldExportQ)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}