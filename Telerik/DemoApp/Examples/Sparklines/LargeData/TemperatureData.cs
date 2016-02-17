using System;

namespace Telerik.Windows.Examples.Sparklines.LargeData
{
    public class TemperatureData
    {
            private DateTime timeStamp;
            private double meanTemperature;
            private double minTemperature;
            private double maxTemperature;

            public double MeanTemperature
            {
                get
                {
                    return this.meanTemperature;
                }
                set
                {
                    if (this.meanTemperature != value)
                    {
                        this.meanTemperature = value;
                    }
                }
            }

            public double MaxTemperature
            {
                get
                {
                    return this.maxTemperature;
                }
                set
                {
                    if (this.maxTemperature != value)
                    {
                        this.maxTemperature = value;
                    }
                }
            }

            public double MinTemperature
            {
                get
                {
                    return this.minTemperature;
                }
                set
                {
                    if (this.minTemperature != value)
                    {
                        this.minTemperature = value;
                    }
                }
            }

            public DateTime TimeStamp
            {
                get
                {
                    return this.timeStamp;
                }
                set
                {
                    if (this.timeStamp != value)
                    {
                        this.timeStamp = value;
                    }
                }
            }
    }
}
