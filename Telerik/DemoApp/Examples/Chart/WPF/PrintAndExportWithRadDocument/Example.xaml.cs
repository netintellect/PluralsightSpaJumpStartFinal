using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Telerik.Windows.Controls.QuickStart;
using Telerik.Windows.Documents.Model;
using Telerik.Windows.Documents.FormatProviders.Pdf;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.Chart.PrintAndExportWithRadDocument
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = "*.pdf";
            dialog.Filter = "Adobe PDF Document (*.pdf)|*.pdf";

            if (dialog.ShowDialog() == true)
            {
                {
                    RadDocument document = this.CreateDocument();
                    document.LayoutMode = DocumentLayoutMode.Paged;
                    document.Measure(RadDocument.MAX_DOCUMENT_SIZE);
                    document.Arrange(new RectangleF(PointF.Empty, document.DesiredSize));

                    PdfFormatProvider provider = new PdfFormatProvider();

                    using (Stream output = dialog.OpenFile())
                    {
                        provider.Export(document, output);
                    }
                }
            }
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                RadRichTextBox1.Document = CreateDocument();
            }));

            RadRichTextBox1.Print("MyDocument", Documents.UI.PrintMode.Native);
        }

        private RadDocument CreateDocument()
        {
            RadDocument document = new RadDocument();

            this.CreateChartDocumentPart(document);
            this.CreateGridDocumentPart(document);

            return document;
        }

        private void CreateChartDocumentPart(RadDocument document)
        {
            Section section = new Section();
            Paragraph paragraph = new Paragraph();

            MemoryStream ms = new MemoryStream();
            RadChart1.ExportToImage(ms, new PngBitmapEncoder());

            double imageWidth = RadChart1.ActualWidth;
            double imageHeight = RadChart1.ActualHeight;
            if (imageWidth > 625)
            {
                imageWidth = 625;
                imageHeight = RadChart1.ActualHeight * imageWidth / RadChart1.ActualWidth;
            }

            ImageInline image = new ImageInline(ms, new Size(imageWidth, imageHeight), "png");

            paragraph.Inlines.Add(image);
            section.Blocks.Add(paragraph);
            document.Sections.Add(section);

            ms.Close();
        }

        private void CreateGridDocumentPart(RadDocument document)
        {
            List<GridViewBoundColumnBase> columns = (from c in RadGridView1.Columns.OfType<GridViewBoundColumnBase>()
                                                     orderby c.DisplayIndex
                                                     select c).ToList();

            Table table = new Table();

            Section section = new Section();
            section.Blocks.Add(table);
            document.Sections.Add(section);

            if (RadGridView1.ShowColumnHeaders)
            {
                TableRow headerRow = new TableRow();

                if (RadGridView1.GroupDescriptors.Count() > 0)
                {
                    TableCell indentCell = new TableCell();
                    indentCell.PreferredWidth = new TableWidthUnit(RadGridView1.GroupDescriptors.Count() * 20);
                    headerRow.Cells.Add(indentCell);
                }

                for (int i = 0; i < columns.Count(); i++)
                {
                    TableCell cell = new TableCell();
                    AddCellValue(cell, columns[i].UniqueName);
                    cell.PreferredWidth = new TableWidthUnit((float)columns[i].ActualWidth);
                    headerRow.Cells.Add(cell);
                }

                table.Rows.Add(headerRow);
            }

            if (RadGridView1.Items.Groups != null)
            {
                for (int i = 0; i < RadGridView1.Items.Groups.Count(); i++)
                {
                    AddGroupRow(table, RadGridView1.Items.Groups[i] as QueryableCollectionViewGroup, columns);
                }
            }
            else
            {
                AddDataRows(table, RadGridView1.Items, columns);
            }
        }

        private void AddDataRows(Table table, IList items, IList<GridViewBoundColumnBase> columns)
        {
            for (int i = 0; i < items.Count; i++)
            {
                TableRow row = new TableRow();

                if (RadGridView1.GroupDescriptors.Count() > 0)
                {
                    TableCell indentCell = new TableCell();
                    indentCell.PreferredWidth = new TableWidthUnit(RadGridView1.GroupDescriptors.Count() * 20);
                    row.Cells.Add(indentCell);
                }

                for (int j = 0; j < columns.Count(); j++)
                {
                    TableCell cell = new TableCell();

                    object value = columns[j].GetValueForItem(items[i]);

                    AddCellValue(cell, value != null ? value.ToString() : string.Empty);

                    cell.PreferredWidth = new TableWidthUnit((float)columns[j].ActualWidth);

                    row.Cells.Add(cell);
                }

                table.Rows.Add(row);
            }
        }

        private void AddGroupRow(Table table, QueryableCollectionViewGroup group, IList<GridViewBoundColumnBase> columns)
        {
            TableRow row = new TableRow();

            int level = GetGroupLevel(group);
            if (level > 0)
            {
                TableCell cell = new TableCell();
                cell.PreferredWidth = new TableWidthUnit(level * 20);
                row.Cells.Add(cell);
            }

            TableCell aggregatesCell = new TableCell();
            aggregatesCell.ColumnSpan = columns.Count() + (RadGridView1.GroupDescriptors.Count() > 0 ? 1 : 0) - (level > 0 ? 1 : 0);

            AddCellValue(aggregatesCell, group.Key != null ? group.Key.ToString() : string.Empty);

            foreach (AggregateResult result in group.AggregateResults)
            {
                AddCellValue(aggregatesCell, result.FormattedValue != null ? result.FormattedValue.ToString() : string.Empty);
            }

            row.Cells.Add(aggregatesCell);

            table.Rows.Add(row);

            if (group.HasSubgroups)
            {
                for (int i = 0; i < group.Subgroups.Count(); i++)
                {
                    AddGroupRow(table, group.Subgroups[i] as QueryableCollectionViewGroup, columns);
                }
            }
            else
            {
                for (int i = 0; i < group.ItemCount; i++)
                {
                    AddDataRows(table, group.Items, columns);
                }
            }
        }

        private void AddCellValue(TableCell cell, string value)
        {
            Paragraph paragraph = new Paragraph();
            cell.Blocks.Add(paragraph);

            Span span = new Span();
            span.Text = value;

            paragraph.Inlines.Add(span);
        }

        private int GetGroupLevel(IGroup group)
        {
            int level = 0;

            IGroup parent = group.ParentGroup;

            while (parent != null)
            {
                level++;
                parent = parent.ParentGroup;
            }

            return level;
        }
	}
}
