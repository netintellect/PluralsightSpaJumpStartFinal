using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.Gauge.SpeedRacer
{
    public partial class Example : UserControl
    {
        public Example()
        {
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/SpeedRacer/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/SpeedRacer/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
            InitializeComponent();

            this.timer = new DispatcherTimer();
            this.timer.Tick += this.OnTimerTick;
            this.timer.Interval = this.clockInterval;

            this.lapTimer = new DispatcherTimer();
            this.lapTimer.Tick += this.lapTimer_Tick;
            this.lapTimer.Interval = TimeSpan.FromMilliseconds(100);

            this.GetData("trackPoints.csv");
        }

        private IList<TrackWaypoint> points;
        private readonly TimeSpan clockInterval = TimeSpan.FromSeconds(0.3);
        private int currentIndex;
        private TrackWaypoint currentWaypoint;
        private DispatcherTimer timer;
        private DispatcherTimer lapTimer;
        private string labelFormat = @"mm\:ss\.f";

        public IList<TrackWaypoint>  Points
        {
            get
            {
                return this.points;
            }
            set
            {
                if (this.points == value)
                {
                    return;
                }

                this.points = value;
                this.OnPointsChanged();
            }
        }

        private IList<TrackWaypoint> ParseData(TextReader dataReader)
        {
            string line;
            List<TrackWaypoint> points = new List<TrackWaypoint>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');
                Point position = new Point(double.Parse(data[0], CultureInfo.InvariantCulture), double.Parse(data[1], CultureInfo.InvariantCulture));
                double rpm = double.Parse(data[2], CultureInfo.InvariantCulture);
                TrackWaypoint waypoint = new TrackWaypoint(position, rpm);
                points.Add(waypoint);
            }

            return points;
        }

        private void OnPointsChanged()
        {
            this.UpdateTrack();
            this.StartCarAnimation();
        }

        private void UpdateTrack()
        {
            PathGeometry geometry = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.StartPoint = points[0].Position;
            PolyLineSegment segment = new PolyLineSegment();
            for (int i = 1; i < points.Count; i++)
            {
                segment.Points.Add(points[i].Position);
            }
            figure.Segments.Add(segment);
            geometry.Figures.Add(figure);
            this.track.Data = geometry;
        }

        private void StartCarAnimation()
        {
            currentIndex = 0;
            this.currentWaypoint = this.Points[currentIndex];
            currentIndex++;
            Canvas.SetLeft(this.carIndicator, this.currentWaypoint.Position.X - this.carIndicator.Width / 2);
            Canvas.SetTop(this.carIndicator, this.currentWaypoint.Position.Y - this.carIndicator.Width / 2);
            this.carIndicator.Visibility = Visibility.Visible;

            this.lapTimer.Stop();
            this.lapTimer.Start();
            this.timer.Stop();
            this.timer.Start();
        }

        private void lapTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan currentTime = TimeSpan.ParseExact(this.currentLapTimer.Text, this.labelFormat, System.Globalization.CultureInfo.InvariantCulture);
            currentTime = currentTime.Add(TimeSpan.FromMilliseconds(100));
            this.currentLapTimer.Text = currentTime.ToString(this.labelFormat);
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            this.currentWaypoint = points[currentIndex % points.Count];
            if (currentIndex % points.Count == 0)
            {
                this.currentLapTimer.Text = TimeSpan.Zero.ToString(this.labelFormat);
                this.lapIndicator.Value += 1;
                if (this.lapIndicator.Value == 20)
                {
                    this.lapTimer.Stop();
                    this.timer.Stop();
                    return;
                }
            }
            currentIndex++;

            this.AnimateCarIndiactor(this.currentWaypoint.Position);
            this.rpmNeedle.Value = this.currentWaypoint.Rpm / 1000;
            this.speedNeedle.Value = this.RpmToSpeed(this.rpmNeedle.Value);
        }

        private double RpmToSpeed(double rpm)
        {
            return Math.Pow(Math.Log(rpm), 2) * 50;
        }
    }
}
