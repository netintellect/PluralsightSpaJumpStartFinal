using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Examples.ChartView.InverseAxis.Models;

namespace Telerik.Windows.Examples.ChartView.InverseAxis.Views
{
	public partial class ResourcesDrillData : UserControl
	{
		public ResourcesDrillData()
		{
			InitializeComponent();
		}

		private void ChartTrackBallBehavior_TrackInfoUpdated(object sender, Telerik.Windows.Controls.ChartView.TrackBallInfoEventArgs e)
		{
			var dataPointInfo = e.Context.DataPointInfos.FirstOrDefault();
			if (dataPointInfo != null)
			{
                WellDrillData wellDrillData = (WellDrillData)dataPointInfo.DataPoint.DataItem;
				this.TextBoxTrackBallDate.Text = string.Format("{0:MMMM dd, yyyy}", wellDrillData.Date);
				this.TextBoxTrackBallDepth.Text = string.Format("{0:F0} m", wellDrillData.Depth);
			}
			else
			{
                this.TextBoxTrackBallDate.Text = "June 30, 1949";
                this.TextBoxTrackBallDepth.Text = "5682 m";
			}
		}
	}
}
