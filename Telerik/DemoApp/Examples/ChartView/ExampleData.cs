using System;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.ChartView
{
    public class UserDataPoint
    {
        private double _x;
        private double _y;
        private double _low;
        private double _high;
        private double _open;
        private double _close;
        private double _bubbleSize;
        private string _legendLabel;
        private double _angle;
        private double _value;

        public UserDataPoint()
        {
        }

        public UserDataPoint(double x, double y)
        {
            this._x = x;
            this._y = y;
        }

        public UserDataPoint(double high, double low, double open, double close)
        {
            this._high = high;
            this._low = low;
            this._open = open;
            this._close = close;
        }

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                this._x = value;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                this._y = value;
            }
        }

        public double High
        {
            get
            {
                return _high;
            }
            set
            {
                this._high = value;
            }
        }

        public double Low
        {
            get
            {
                return _low;
            }
            set
            {
                this._low = value;
            }
        }

        public double Open
        {
            get
            {
                return _open;
            }
            set
            {
                this._open = value;
            }
        }

        public double Close
        {
            get
            {
                return _close;
            }
            set
            {
                this._close = value;
            }
        }

        public double BubbleSize
        {
            get
            {
                return _bubbleSize;
            }
            set
            {
                this._bubbleSize = value;
            }
        }

        public string LegendLabel
        {
            get
            {
                return _legendLabel;
            }
            set
            {
                this._legendLabel = value;
            }
        }

        public double Angle
        {
            get
            {
                return this._angle;
            }
            set
            {
                this._angle = value;
            }
        }

        public double Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
    }

    public static class ExampleData
    {
        private static Random rand = new Random(123456);

        private static double[,] constsY = new double[3, 12]
        {
            { 24, 9, 18, 31, 25, 13, 17, 33, 21, 28, 19, 11 },
            { 6, 19, 28, 11, 15, 31, 27, 14, 19, 21, 30, 15 },
            { 17, 8, 31, 22, 26, 12, 23, 17, 28, 19, 24, 29 }
        };
        private static double[,] constsFinancial = new double[4, 7]
        {
            { 24, 29, 31, 28, 25, 22, 26 },
            { 16, 18, 24, 16, 15, 18, 16 },
            { 17, 19, 25, 27, 17, 19, 19 },
            { 19, 25, 27, 17, 19, 19, 17 }
        };

        public static IEnumerable<double> GetUserData(int numberOfItems, int seriesIndex)
        {
            int num = numberOfItems % constsY.GetLength(1) == 0 ? constsY.GetLength(1) : numberOfItems % constsY.GetLength(1);
            int ind = seriesIndex % constsY.GetLength(0);
            List<double> points = new List<double>();
            for (int i = 0; i < num; i++)
            {
                points.Add(constsY[ind, i]);
            }
            return points;
        }

        public static IEnumerable<UserDataPoint> GetUserDataPoints(int numberOfItems, int seriesIndex)
        {
            int num = numberOfItems % constsY.GetLength(1) == 0 ? constsY.GetLength(1) : numberOfItems % constsY.GetLength(1);
            int ind = seriesIndex % constsY.GetLength(0);
            List<UserDataPoint> points = new List<UserDataPoint>();
            for (int i = 0; i < num; i++)
            {
                points.Add(new UserDataPoint(i, constsY[ind, i]));
            }
            return points;
        }

        public static IEnumerable<IEnumerable<UserDataPoint>> GetUserScatterData()
        {
            List<IEnumerable<UserDataPoint>> data = new List<IEnumerable<UserDataPoint>>();
            Random rand = new Random();

            List<UserDataPoint> seriesData = new List<UserDataPoint>();
            for (int i = 0; i < 199; i++)
            {
                seriesData.Add(new UserDataPoint(rand.Next(-100, 100), rand.Next(-990, 990)));
            }
            data.Add(seriesData);

            List<UserDataPoint> seriesData2 = new List<UserDataPoint>();
            for (int i = 0; i < 150; i++)
            {
                seriesData2.Add(new UserDataPoint(rand.Next(0, 30), rand.Next(10, 300)));
            }
            data.Add(seriesData2);

            List<UserDataPoint> seriesData3 = new List<UserDataPoint>();
            for (int i = 0; i < 50; i++)
            {
                seriesData3.Add(new UserDataPoint(rand.Next(-80, 10), rand.Next(10, 600)));
            }
            data.Add(seriesData3);

            return data;
        }

        public static IEnumerable<UserDataPoint> GetUserFinancialData(int numberOfItems)
        {
            List<UserDataPoint> points = new List<UserDataPoint>();
            int num = numberOfItems % constsFinancial.GetLength(1) == 0 ? constsFinancial.GetLength(1) : numberOfItems % constsFinancial.GetLength(1);

            for (int i = 0; i < numberOfItems; i++)
            {
                UserDataPoint point = new UserDataPoint();
                point.Open = constsFinancial[2, i % num];
                point.Close = constsFinancial[3, i % num];
                point.Low = constsFinancial[1, i % num];
                point.High = constsFinancial[0, i % num];

                points.Add(point);
            }

            return points;
        }

        public static IEnumerable<double> GetUserRadialData()
        {
            return GetUserData(10, 0);
        }

        public static IEnumerable<UserDataPoint> GetUserPolarPointData(int numberOfItems, int seriesIndex)
        {
            List<UserDataPoint> points = new List<UserDataPoint>();
            int num = numberOfItems % constsY.GetLength(1) == 0 ? constsY.GetLength(1) : numberOfItems % constsY.GetLength(1);
            int ind = seriesIndex % constsY.GetLength(0);
            double step = Math.Round(360d / (numberOfItems));

            for (int i = 0; i < num; i++)
            {
                UserDataPoint point = new UserDataPoint();
                point.Value = constsY[ind, i];
                point.Angle = i * step;
                points.Add(point);
            }

            return points;
        }

        public static IEnumerable<UserDataPoint> GetUserPolarData(int count, double scale)
        {
            List<UserDataPoint> list = new List<UserDataPoint>();

            double angleStep = 2 * Math.PI / count;

            for (int i = 0; i < count; i++)
            {
                double angle = i * angleStep;
                double c1 = 1.0 * Math.Sin(angle * 3);
                double c2 = 0.3 * Math.Sin(angle * 1.5);
                double c3 = 0.05 * Math.Cos(angle * 26);
                double c4 = 0.05 * (0.5 - rand.NextDouble());
                double value = scale * (Math.Abs(c1 + c2 + c3) + c4);

                if (value < 0)
                    value = 0;

                list.Add(new UserDataPoint() { Angle = angle * 180 / Math.PI, Value = value });
            }

            return list;
        }
    }
}
