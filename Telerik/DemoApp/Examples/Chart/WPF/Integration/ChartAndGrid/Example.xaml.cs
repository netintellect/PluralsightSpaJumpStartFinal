using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes; 
using System.Windows.Threading;
using System.Data;
using Telerik.Windows.Controls.Charting;
using Telerik.Windows.Data;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Chart.Integration.ChartAndGrid
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		private bool initialBind = true;
		private static readonly int MaxRows = 15;
		private DispatcherTimer timer;

		public Example()
		{
			InitializeComponent();
            radGridViewSelection.Loaded += this.radGridViewSelection_Loaded;

            radGridViewSelection.ItemsSource = ExamplesDB.GetInvoices();

            RadChart1.DefaultView.ChartTitle.Content = "Selected Rows";
            RadChart1.DefaultView.ChartLegend.Header = "Series";

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.8);
            timer.Tick += this.timer_Tick;
		}

        void radGridViewSelection_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < MaxRows && i < radGridViewSelection.Items.Count; i++)
            {
                radGridViewSelection.SelectedItems.Add(radGridViewSelection.Items[i]);
            }

            ShowSelectedRecordsInChart();
        }

		private void CreateSeriesMappings(DataTable table)
		{
			RadChart1.SeriesMappings.Clear();

			List<DataColumn> visualizedColumns = new List<DataColumn>();

			visualizedColumns.Add(table.Columns["UnitPrice"]);
			visualizedColumns.Add(table.Columns["Quantity"]);

			foreach (DataColumn column in visualizedColumns)
			{
				SeriesMapping seriesMapping = new SeriesMapping();

                ISeriesDefinition definition = new BarSeriesDefinition();
                if (table.Rows.Count > 1)
                {
                    LinearSeriesDefinition lineDef = new LineSeriesDefinition();
                    lineDef.LabelSettings.ShowConnectors = true;
                    definition = lineDef;
                }

				seriesMapping.SeriesDefinition = definition;
				seriesMapping.LegendLabel = column.ColumnName;

				ItemMapping itemMapping = new ItemMapping();
				itemMapping.DataPointMember = DataPointMember.YValue;
				itemMapping.FieldName = column.ColumnName;
				seriesMapping.ItemMappings.Add(itemMapping);

				RadChart1.SeriesMappings.Add(seriesMapping);
			}
		}

		private void SetChartItemsSource(DataTable table)
		{
			DataTable chartTable = table.Clone();

			for (int i = 0; i < table.Rows.Count; i++)
			{
				DataRow newRow = chartTable.NewRow();

				for (int j = 0; j < table.Rows[i].ItemArray.Length; j++)
				{
					newRow[j] = table.Rows[i].ItemArray[j];
				}

				chartTable.Rows.Add(newRow);
			}

			RadChart1.ItemsSource = chartTable;
		}

		private void ShowSelectedRecordsInChart()
		{
			DataTable table = new DataTable();

			DataColumn col = new DataColumn("UnitPrice", typeof(double));
			DataColumn col1 = new DataColumn("Quantity", typeof(double));

			table.Columns.Add(col);
			table.Columns.Add(col1);

			foreach (object item in radGridViewSelection.SelectedItems)
			{
				DataRow row = table.NewRow();

				row["UnitPrice"] = ((DataRow)item)["UnitPrice"];
				row["Quantity"] = ((DataRow)item)["Quantity"];

				table.Rows.Add(row);
			}

			CreateSeriesMappings(table);
			SetChartItemsSource(table);
		}

		private void radGridViewSelection_SelectionChanged(object sender, SelectionChangeEventArgs e)
		{
            timer.Stop();
            timer.Start();
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if (!initialBind)
				ShowSelectedRecordsInChart();
			else
				initialBind = false;

			timer.Stop();
		}
	}
}
