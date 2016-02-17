using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.Pdf;
using Telerik.Windows.Documents.Spreadsheet.Model;
using Telerik.Windows.Documents.Spreadsheet.Model.Filtering;
using Telerik.Windows.Documents.Spreadsheet.Model.Sorting;
using Telerik.Windows.Examples.Spreadsheet.Common;

namespace Telerik.Windows.Examples.Spreadsheet.SortingAndFiltering
{
    public partial class Example : UserControl
    {
        private const string SampleDocumentPath = "SampleData/OrdersLog.xlsx";

        private static readonly CellRange filterRange = new CellRange(2, 0, 48, 7);
        private static readonly CellRange sortRange = new CellRange(3, 0, 48, 7);
        
        private Workbook workbook;

        static Example()
        {
            WorkbookFormatProvidersManager.RegisterFormatProvider(new PdfFormatProvider());
            WorkbookFormatProvidersManager.RegisterFormatProvider(new XlsxFormatProvider());
        }

        public Example()
        {
            InitializeComponent();

            using (var stream = Application.GetResourceStream(FileHelper.GetResourceUri(SampleDocumentPath, typeof(Example))).Stream)
            {
                this.workbook = new XlsxFormatProvider().Import(stream);
                this.workbook.ActiveWorksheet.Filter.FilterRange = filterRange;
                this.workbook.Protect(string.Empty);

                this.radSpreadsheet.Workbook = this.workbook;
            }

            this.Loaded += this.Example_Loaded;
        }

        private void Example_Loaded(object sender, RoutedEventArgs e)
        {
            this.radSpreadsheet.Focus();
        }

        private void ApplyFilterByMonthAndSortByCompany(object sender, RoutedEventArgs e)
        {
            this.workbook.History.BeginUndoGroup();

            ValuesCollectionFilter valuesCollectionFilter = new ValuesCollectionFilter(1, null, new DateGroupItem[] { new DateGroupItem(2014, 6) });
            this.ApplyFilter(valuesCollectionFilter);

            ISortCondition[] conditions = new ISortCondition[] { new ValuesSortCondition(4, SortOrder.Ascending) };
            this.SetSortState(conditions);

            this.workbook.History.EndUndoGroup();
        }

        private void ApplyFilterByCompanySortByFill(object sender, RoutedEventArgs e)
        {
            this.workbook.History.BeginUndoGroup();

            ValuesCollectionFilter valuesCollectionFilter = new ValuesCollectionFilter(4, new string[] { "Plan Smart" }, null);
            this.ApplyFilter(valuesCollectionFilter);
         
            ISortCondition[] conditions = this.GetSortingConditions();
            this.SetSortState(conditions);

            this.workbook.History.EndUndoGroup();
        }
 
        private ISortCondition[] GetSortingConditions()
        {
            Worksheet definitionsWorksheet = this.workbook.Worksheets["Definitions"];
         
            return new ISortCondition[] 
            {
                new FillColorSortCondition(7, definitionsWorksheet.Cells[1, 0, 1, 0].GetFill().Value, SortOrder.Ascending),
                new FillColorSortCondition(7, definitionsWorksheet.Cells[2, 0, 2, 0].GetFill().Value, SortOrder.Ascending),
                new FillColorSortCondition(7, definitionsWorksheet.Cells[3, 0, 3, 0].GetFill().Value, SortOrder.Ascending),
                new FillColorSortCondition(7, definitionsWorksheet.Cells[4, 0, 4, 0].GetFill().Value, SortOrder.Ascending)
            };
        }

        private void ApplyTopFilterAndCustomSort(object sender, RoutedEventArgs e)
        {
            this.workbook.History.BeginUndoGroup();

            TopFilter topFilter = new TopFilter(6, TopFilterType.TopPercent, 20);
            this.ApplyFilter(topFilter);

            CustomValuesSortCondition customValuesSortCondition = new CustomValuesSortCondition(5, new string[] { "express", "1 day", "2 days", "regular" }, SortOrder.Ascending);
            this.SetSortState(customValuesSortCondition);

            this.workbook.History.EndUndoGroup();
        }

        private void RemoveFiltersAndSortConditions(object sender, RoutedEventArgs e)
        {
            this.workbook.History.BeginUndoGroup();

            Worksheet worksheet = this.workbook.ActiveWorksheet;

            worksheet.Filter.ClearFilters();
            worksheet.SortState.Clear();

            this.workbook.History.EndUndoGroup();
        }

        private void ApplyFilter(IFilter filter)
        {
            this.workbook.ActiveWorksheet = this.workbook.Worksheets[0];
            AutoFilter autoFilter = this.workbook.ActiveWorksheet.Filter;
            autoFilter.ClearFilters();
            autoFilter.FilterRange = filterRange;
            autoFilter.SetFilter(filter);
        }

        private void SetSortState(params ISortCondition[] conditions)
        {
            this.workbook.ActiveWorksheet = this.workbook.Worksheets[0];
            SortState sortState = this.workbook.ActiveWorksheet.SortState;
            sortState.Set(sortRange, conditions);
        }
    }
}