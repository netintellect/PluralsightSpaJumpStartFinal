using System;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.ChartView.SmartLabels
{
    public class FuelChart
    {
        private IEnumerable<FuelChartData> data;
        private string name;
        private string titleNote;
        private string fullName;
        private string additionalInformation;

        private double chartAxisMinimum;
        private double chartAxisMaximum;
        private double chartAxisMajorStep;

        public FuelChart(string name, string titleNote, string fullName, string additionalInformation, IEnumerable<FuelChartData> data, double chartAxisMinimum, double chartAxisMaximum, double chartAxisMajorStep)
        {
            this.name = name;
            this.titleNote = titleNote;
            this.data = data;
            this.fullName = fullName;
            this.additionalInformation = additionalInformation;

            this.chartAxisMinimum = chartAxisMinimum;
            this.chartAxisMaximum = chartAxisMaximum;
            this.chartAxisMajorStep = chartAxisMajorStep;
        }

        public IEnumerable<FuelChartData> Data
        {
            get
            {
                return this.data;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string TitleNote
        {
            get
            {
                return this.titleNote;
            }
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
        }

        public string AdditionalInformation
        {
            get
            {
                return this.additionalInformation;
            }
        }

        public double ChartAxisMinimum
        {
            get
            {
                return this.chartAxisMinimum;
            }
        }

        public double ChartAxisMaximum
        {
            get
            {
                return this.chartAxisMaximum;
            }
        }

        public double ChartAxisMajorStep
        {
            get
            {
                return this.chartAxisMajorStep;
            }
        }
    }
}
