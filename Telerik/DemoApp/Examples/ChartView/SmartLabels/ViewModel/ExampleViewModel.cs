using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Telerik.Windows.Examples.ChartView.SmartLabels
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        public ExampleViewModel()
        {
            this.GetData("AirlineFuelCostAndConsumptionData.csv");
        }

        private IEnumerable<FuelChart> charts;
        private FuelChart selectedChart;
        private double chartAxisMaximum;
        private double chartAxisMinimum;
        private double chartAxisMajorStep;
        private bool isConsumptionDataVisible;

        public IEnumerable<FuelChart> Charts
        {
            get
            {
                return this.charts;
            }
            set
            {
                if (this.charts == value)
                    return;

                this.charts = value;
                this.OnPropertyChanged("Charts");
            }
        }

        public FuelChart SelectedChart
        {
            get
            {
                return this.selectedChart;
            }
            set
            {
                if (this.selectedChart == value)
                    return;

                this.selectedChart = value;
                this.OnPropertyChanged(() => this.SelectedChart);
                this.IsConsumptionDataVisible = this.selectedChart != null && this.selectedChart.Name == "DOMESTIC CHART";
            }
        }

        public bool IsConsumptionDataVisible
        {
            get { return this.isConsumptionDataVisible; }
            private set 
            {
                if (this.isConsumptionDataVisible != value)
                {
                    this.isConsumptionDataVisible = value;
                    this.OnPropertyChanged(() => this.IsConsumptionDataVisible);
                }
            }
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            Charts = data as List<FuelChart>;
            SelectedChart = Charts.First();
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            List<FuelChart> charts = new List<FuelChart>();
            List<FuelChartData> chartData = new List<FuelChartData>();
            FuelChart fuelChart = null;
            int currentChartIndex = -1;
            int minYear = 2007;
            int maxYear = 2012;

            string line;
            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                DateTime date = DateTime.Parse(data[2], CultureInfo.InvariantCulture);

                if (date.Year < minYear || date.Year > maxYear)
                    continue;

                int chartIndex = int.Parse(data[0], CultureInfo.InvariantCulture);
                string name = data[1];

                if (currentChartIndex != chartIndex)
                {
                    currentChartIndex++;

                    string titleNote;
                    string fullName;
                    string additionalInformation;

                    double chartAxisMinimum;
                    double chartAxisMaximum;
                    double chartAxisMajorStep;

                    switch (chartIndex)
                    {
                        case 0:
                            titleNote = "domestic, monthly";
                            fullName = "Cost and consumption";
                            additionalInformation = "monthly";

                            chartAxisMaximum = 4500;
                            chartAxisMinimum = 0;
                            chartAxisMajorStep = 500;
                            break;
                        case 1:
                            titleNote = "% change, previous month";
                            fullName = "Cost per galon";
                            additionalInformation = "% change, previous month";

                            chartAxisMaximum = 20;
                            chartAxisMinimum = -30;
                            chartAxisMajorStep = 5;
                            break;
                        case 2:
                            titleNote = "% change, same month previous year";
                            fullName = "Cost per galon";
                            additionalInformation = "% change, previous year";

                            chartAxisMaximum = 100;
                            chartAxisMinimum = -60;
                            chartAxisMajorStep = 20;
                            break;
                        default:
                            titleNote = String.Empty;
                            fullName = String.Empty;
                            additionalInformation = String.Empty;

                            chartAxisMinimum = 0;
                            chartAxisMaximum = 0;
                            chartAxisMajorStep = 0;
                            break;
                    }

                    chartData = new List<FuelChartData>();
                    fuelChart = new FuelChart(name, titleNote, fullName, additionalInformation, chartData, chartAxisMinimum, chartAxisMaximum, chartAxisMajorStep);

                    charts.Add(fuelChart);
                }

                if (data.Length == 5)
                {
                    double consumption = double.Parse(data[3], CultureInfo.InvariantCulture);
                    double cost = double.Parse(data[4], CultureInfo.InvariantCulture);

                    chartData.Add(new FuelChartData(date, cost, consumption));
                }
                else
                {
                    double cost = double.Parse(data[3], CultureInfo.InvariantCulture);

                    chartData.Add(new FuelChartData(date, cost));
                }
            }

            return charts;
        }
    }
}
