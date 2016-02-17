using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using Telerik.Windows.Documents.Spreadsheet.Model;
using Telerik.Windows.Examples.SpreadProcessing.Common;
using Telerik.Windows.Examples.SpreadProcessing.SampleData;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;
#if SILVERLIGHT
using SaveFileDialog = System.Windows.Controls.SaveFileDialog;
#else
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
#endif

namespace Telerik.Windows.Examples.SpreadProcessing.RadGridViewIntegration
{
    public class ExampleViewModel : ViewModelBase
    {
        private const int WidthOfIndentColumns = 20;

        private static readonly Color DefaultHeaderRowColor = Color.FromArgb(255, 127, 127, 127);
        private static readonly Color DefaultGroupHeaderRowColor = Color.FromArgb(255, 216, 216, 216);
        private static readonly Color DefaultDataRowColor = Color.FromArgb(255, 251, 247, 255);

        private List<Product> products;
        private ICommand exportCommand = null;
        private Color headerRowColor;
        private Color dataRowColor;
        private Color groupHeaderRowColor;
        private string selectedExportFormat;
        private CultureInfo cultureToRestore;

        public RadGridView GridView { get; set; }

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

        public IEnumerable<string> ExportFormats
        {
            get
            {
                return FileHelper.ExportFormats;
            }
        }

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
            this.SetCulture();

            IWorkbookFormatProvider formatProvider = FileHelper.GetFormatProvider(this.selectedExportFormat);
            if (formatProvider == null)
            {
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = String.Format("{0} files|*{1}|All files (*.*)|*.*", this.selectedExportFormat,
                formatProvider.SupportedExtensions.First());

            if (dialog.ShowDialog() == true)
            {
                using (var stream = dialog.OpenFile())
                {
                    Workbook workbook = this.CreateWorkbook(this.GridView);
                    formatProvider.Export(workbook, stream);
                }
            }

            this.RestoreCulture();
        }

        private void SetCulture()
        {
            if (GridView.IsLocalizationLanguageRespected)
            {
                CultureInfo cultureInfo = null;

#if SILVERLIGHT
                cultureInfo = new CultureInfo(GridView.Language.IetfLanguageTag);
#else
                cultureInfo = GridView.Language.GetSpecificCulture();
#endif
                if (!string.Equals(System.Threading.Thread.CurrentThread.CurrentCulture.Name, cultureInfo.Name, StringComparison.OrdinalIgnoreCase))
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
                    this.cultureToRestore = cultureInfo;
                }
            }
        }

        private void RestoreCulture()
        {
            if (cultureToRestore != null)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = cultureToRestore;
                cultureToRestore = null;
            }
        }

        private Workbook CreateWorkbook(RadGridView grid)
        {
            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets.Add();
            workbook.History.IsEnabled = false;

            IList<GridViewBoundColumnBase> columns = (from c in grid.Columns.OfType<GridViewBoundColumnBase>()
                                                      orderby c.DisplayIndex
                                                      select c).ToList();

            int rowIndex = 0;
            if (grid.ShowColumnHeaders)
            {
                this.AddHeaderRow(worksheet, grid.GroupDescriptors.Count, columns);
                rowIndex = 1;
            }

            if (grid.Items.Groups != null)
            {
                for (int i = 0; i < grid.Items.Groups.Count; i++)
                {
                    QueryableCollectionViewGroup group = (QueryableCollectionViewGroup)grid.Items.Groups[i];
                    rowIndex = this.AddGroupRow(worksheet, rowIndex, grid.GroupDescriptors.Count, group, columns);
                }
            }
            else
            {
                this.AddDataRows(worksheet, rowIndex, 0, grid.Items, columns);
            }

            this.SetWidthOfColumns(worksheet, grid.GroupDescriptors.Count, columns);

            return workbook;
        }

        private void SetWidthOfColumns(Worksheet worksheet, int numberOfIndentColumns, IList<GridViewBoundColumnBase> columns)
        {
            for (int i = 0; i < numberOfIndentColumns; i++)
            {
                worksheet.Columns[i].SetWidth(new ColumnWidth(WidthOfIndentColumns, false));
            }

            for (int i = 0; i < columns.Count; i++)
            {
                worksheet.Columns[numberOfIndentColumns + i].SetWidth(new ColumnWidth(columns[i].Width.DisplayValue, false));
            }
        }

        private void AddHeaderRow(Worksheet worksheet, int numberOfGroupDescriptors, IList<GridViewBoundColumnBase> columns)
        {
            int headerColumnStartIndex = numberOfGroupDescriptors;

            for (int i = 0; i < columns.Count; i++)
            {
                worksheet.Cells[0, headerColumnStartIndex + i].SetValue(columns[i].Header.ToString());
            }

            IFill fill = new PatternFill(PatternType.Solid, this.HeaderRowColor, Colors.Transparent);
            worksheet.Cells[0, 0, 0, numberOfGroupDescriptors + columns.Count - 1].SetFill(fill);
        }

        private void AddDataRows(Worksheet worksheet, int startRowIndex, int startColumnIndex, IList items, IList<GridViewBoundColumnBase> columns)
        {
            for (int rowIndex = 0; rowIndex < items.Count; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columns.Count; columnIndex++)
                {
                    object value = columns[columnIndex].GetValueForItem(items[rowIndex]);

                    int currentRowIndex = startRowIndex + rowIndex;
                    int cuurentColumnIndex = startColumnIndex + columnIndex;
                    worksheet.Cells[currentRowIndex, cuurentColumnIndex].SetValue(value.ToString());
                }
            }

            IFill fill = new PatternFill(PatternType.Solid, this.DataRowColor, Colors.Transparent);
            worksheet.Cells[startRowIndex, 0, startRowIndex + items.Count - 1, startColumnIndex + columns.Count - 1].SetFill(fill);
        }

        private int AddGroupRow(Worksheet worksheet, int rowIndex, int numberOfIndentCells, QueryableCollectionViewGroup group, IList<GridViewBoundColumnBase> columns)
        {
            int startColumnIndex = this.GetGroupLevel(group);

            CellSelection groupHeaderRow = worksheet.Cells[rowIndex, startColumnIndex, rowIndex, numberOfIndentCells + columns.Count - 1];
            groupHeaderRow.Merge();

            IFill fill = new PatternFill(PatternType.Solid, this.GroupHeaderRowColor, Colors.Transparent);
            groupHeaderRow.SetFill(fill);

            string cellValue = group.Key != null ? group.Key.ToString() : string.Empty;
            groupHeaderRow.SetValue(cellValue);
            groupHeaderRow.SetHorizontalAlignment(RadHorizontalAlignment.Left);

            rowIndex++;
            startColumnIndex++;

            if (group.HasSubgroups)
            {
                foreach (var subGroup in group.Subgroups)
                {
                    int newRowIndex = this.AddGroupRow(worksheet, rowIndex, numberOfIndentCells, subGroup as QueryableCollectionViewGroup, columns);
                    rowIndex = newRowIndex;
                }
            }
            else
            {
                this.AddDataRows(worksheet, rowIndex, startColumnIndex, group.Items, columns);
                rowIndex += group.Items.Count;
            }

            return rowIndex;
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