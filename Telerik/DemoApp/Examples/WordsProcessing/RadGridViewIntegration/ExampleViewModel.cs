using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using Telerik.Windows.Documents.Flow.Model;
using Telerik.Windows.Documents.Flow.Model.Styles;
using Telerik.Windows.Documents.Spreadsheet.Model;
using Telerik.Windows.Examples.WordsProcessing.Common;
using Telerik.Windows.Examples.WordsProcessing.SampleData;

namespace Telerik.Windows.Examples.WordsProcessing.RadGridViewIntegration
{
    public class ExampleViewModel : ViewModelBase
    {
        private const int WidthOfIndentColumns = 20;

        private static readonly Color DefaultHeaderRowColor = Color.FromArgb(255, 127, 127, 127);
        private static readonly Color DefaultGroupHeaderRowColor = Color.FromArgb(255, 216, 216, 216);
        private static readonly Color DefaultDataRowColor = Color.FromArgb(255, 251, 247, 255);

        private Color headerRowColor;
        public Color HeaderRowColor
        {
            get
            {
                return this.headerRowColor;
            }
            set
            {
                if (this.headerRowColor != value)
                {
                    this.headerRowColor = value;
                    OnPropertyChanged("HeaderRowColor");
                }
            }
        }

        private Color dataRowColor;
        public Color DataRowColor
        {
            get
            {
                return this.dataRowColor;
            }
            set
            {
                if (this.dataRowColor != value)
                {
                    this.dataRowColor = value;
                    OnPropertyChanged("DataRowColor");
                }
            }
        }

        private Color groupHeaderRowColor;
        public Color GroupHeaderRowColor
        {
            get
            {
                return this.groupHeaderRowColor;
            }
            set
            {
                if (this.groupHeaderRowColor != value)
                {
                    this.groupHeaderRowColor = value;
                    OnPropertyChanged("GroupHeaderRowColor");
                }
            }
        }

        private List<Product> products;
        public List<Product> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                if (this.products != value)
                {
                    this.products = value;
                    OnPropertyChanged("Products");
                }
            }
        }

        private ICommand exportCommand = null;
        public ICommand ExportCommand
        {
            get
            {
                return this.exportCommand;
            }
            set
            {
                if (this.exportCommand != value)
                {
                    this.exportCommand = value;
                    OnPropertyChanged("ExportCommand");
                }
            }
        }

        IEnumerable<string> exportFormats;
        public IEnumerable<string> ExportFormats
        {
            get
            {
                if (exportFormats == null)
                {
                    exportFormats = new string[] { "Docx", "Rtf", "Html", "Txt" };
                }

                return exportFormats;
            }
        }

        private bool repeatHeaderRowOnEveryPage = true;
        public bool RepeatHeaderRowOnEveryPage
        {
            get
            {
                return this.repeatHeaderRowOnEveryPage;
            }
            set
            {
                if (this.repeatHeaderRowOnEveryPage != value)
                {
                    this.repeatHeaderRowOnEveryPage = value;
                    OnPropertyChanged("RepeatHeaderRowOnEveryPage");
                }
            }
        }

        string selectedExportFormat;
        public string SelectedExportFormat
        {
            get
            {
                return selectedExportFormat;
            }
            set
            {
                if (!object.Equals(selectedExportFormat, value))
                {
                    selectedExportFormat = value;

                    OnPropertyChanged("SelectedExportFormat");
                }
            }
        }

        public ExampleViewModel()
        {
            this.Products = new Products().GetData(100).ToList();
            this.SelectedExportFormat = this.ExportFormats.First();
            this.ExportCommand = new DelegateCommand(this.Export);

            this.HeaderRowColor = DefaultHeaderRowColor;
            this.DataRowColor = DefaultDataRowColor;
            this.GroupHeaderRowColor = DefaultGroupHeaderRowColor;
        }

        private void Export(object param)
        {
            RadGridView grid = param as RadGridView;
            RadFlowDocument document = this.CreateDocument(grid);
            if (grid == null)
            {
                return;
            }
            string selectedFromat = this.SelectedExportFormat;
            FileHelper.SaveDocument(document, selectedFromat);
        }

        private RadFlowDocument CreateDocument(RadGridView grid)
        {
            List<GridViewBoundColumnBase> columns = (from c in grid.Columns.OfType<GridViewBoundColumnBase>()
                                                     orderby c.DisplayIndex
                                                     select c).ToList();

            RadFlowDocument document = new RadFlowDocument();
            Table table = document.Sections.AddSection().Blocks.AddTable();
            document.StyleRepository.AddBuiltInStyle(BuiltInStyleNames.TableGridStyleId);
            table.StyleId = BuiltInStyleNames.TableGridStyleId;

            int indentColumns = grid.GroupDescriptors.Count;

            // Export header row
            if (grid.ShowColumnHeaders)
            {
                TableRow headerRow = table.Rows.AddTableRow();
                headerRow.RepeatOnEveryPage = this.RepeatHeaderRowOnEveryPage;
                ThemableColor headerBackground = new ThemableColor(this.HeaderRowColor);

                if (grid.GroupDescriptors.Count > 0)
                {
                    this.AddIndentCell(headerRow, indentColumns, headerBackground);
                }

                for (int i = 0; i < columns.Count; i++)
                {
                    TableCell cell = headerRow.Cells.AddTableCell();
                    cell.Shading.BackgroundColor = headerBackground;
                    cell.PreferredWidth = new TableWidthUnit(columns[i].ActualWidth);
                    Run headerRun = cell.Blocks.AddParagraph().Inlines.AddRun(columns[i].UniqueName);
                    headerRun.FontWeight = FontWeights.Bold;
                }
            }

            if (grid.Items.Groups != null)
            {
                int groupDescriptorsCount = grid.GroupDescriptors.Count;
                for (int i = 0; i < grid.Items.Groups.Count; i++)
                {
                    this.AddGroupRow(table, (QueryableCollectionViewGroup)grid.Items.Groups[i], columns, groupDescriptorsCount);
                }
            }
            else
            {
                this.AddDataRows(table, grid.Items, columns, indentColumns);
            }

            document.Sections.First().Blocks.AddParagraph();
            return document;
        }

        private void AddGroupRow(Table table, QueryableCollectionViewGroup group, IList<GridViewBoundColumnBase> columns, int groupDescriptorsCount)
        {
            int level = this.GetGroupLevel(group);
            TableRow row = table.Rows.AddTableRow();

            if (level > 0)
            {
                this.AddIndentCell(row, level, new ThemableColor(this.DataRowColor));
            }

            TableCell cell = row.Cells.AddTableCell();
            cell.Shading.BackgroundColor = new ThemableColor(this.GroupHeaderRowColor);
            cell.ColumnSpan = columns.Count + (groupDescriptorsCount > 0 ? 1 : 0) - (level > 0 ? 1 : 0);
            this.AddCellValue(cell, group.Key);

            if (group.HasSubgroups)
            {
                foreach (var g in group.Subgroups)
                {
                    this.AddGroupRow(table, g as QueryableCollectionViewGroup, columns, groupDescriptorsCount);
                }
            }
            else
            {
                this.AddDataRows(table, group.Items, columns, groupDescriptorsCount);
            }
        }

        private void AddDataRows(Table table, IList items, IList<GridViewBoundColumnBase> columns, int indentColumns)
        {
            ThemableColor background = new ThemableColor(this.DataRowColor);

            for (int i = 0; i < items.Count; i++)
            {
                TableRow row = table.Rows.AddTableRow();

                if (indentColumns > 0)
                {
                    this.AddIndentCell(row, indentColumns, background);
                }

                for (int j = 0; j < columns.Count; j++)
                {
                    TableCell cell = row.Cells.AddTableCell();
                    this.AddCellValue(cell, columns[j].GetValueForItem(items[i]));
                    cell.Shading.BackgroundColor = background;
                    cell.PreferredWidth = new TableWidthUnit(columns[j].ActualWidth);
                }
            }
        }

        private void AddCellValue(TableCell cell, object value)
        {
            string stringValue = value != null ? value.ToString() : string.Empty;
            cell.Blocks.AddParagraph().Inlines.AddRun(stringValue);
        }

        private void AddIndentCell(TableRow row, int indentColumns, ThemableColor background)
        {
            TableCell indentCell = row.Cells.AddTableCell();
            indentCell.PreferredWidth = new TableWidthUnit(indentColumns * WidthOfIndentColumns);
            indentCell.Shading.BackgroundColor = background;
            indentCell.Blocks.AddParagraph();
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
