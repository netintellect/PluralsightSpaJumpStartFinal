using System.Collections.Generic;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.ScheduleViewConfigurator
{
	public class ViewModel : ExampleViewModel<Appointment>
	{
		private List<ITickProvider> minorTickProviders;
		private List<ITickProvider> majorTickProviders;
		private List<ITickProvider> timelineTickProviders;

		public ViewModel()
			: base()
		{
			this.minorTickProviders = new List<ITickProvider>();
			this.minorTickProviders.Add(new FixedTickProvider(new DateTimeInterval(15, 0, 0, 0, 0)));
			this.minorTickProviders.Add(new FixedTickProvider(new DateTimeInterval(30, 0, 0, 0, 0)));
			this.minorTickProviders.Add(new FixedTickProvider(new DateTimeInterval(0, 1, 0, 0, 0)));
			this.minorTickProviders.Add(new FixedTickProvider(new DateTimeInterval(0, 2, 0, 0, 0)));
			this.minorTickProviders.Add(AutomaticTickLengthProvider.MinorProvider);

			this.majorTickProviders = new List<ITickProvider>();
			this.majorTickProviders.Add(new FixedTickProvider(new DateTimeInterval(0, 1, 0, 0, 0)));
			this.majorTickProviders.Add(new FixedTickProvider(new DateTimeInterval(0, 2, 0, 0, 0)));
			this.majorTickProviders.Add(new FixedTickProvider(new DateTimeInterval(0, 3, 0, 0, 0)));
			this.majorTickProviders.Add(new FixedTickProvider(new DateTimeInterval(0, 6, 0, 0, 0)));
			this.majorTickProviders.Add(AutomaticTickLengthProvider.MajorProvider);

			this.timelineTickProviders = new List<ITickProvider>();
			this.timelineTickProviders.Add(new FixedTickProvider(new DateTimeInterval(1, 0)));
			this.timelineTickProviders.Add(new FixedTickProvider(new DateTimeInterval(2, 0, 0)));
			this.timelineTickProviders.Add(new FixedTickProvider(new DateTimeInterval(3, 0, 0)));
		}

		public List<ITickProvider> MinorTickProviders
		{
			get
			{
				return this.minorTickProviders;
			}
		}

		public List<ITickProvider> MajorTickProviders
		{
			get
			{
				return this.majorTickProviders;
			}
		}

		public List<ITickProvider> TimelineTickProviders
		{
			get
			{
				return this.timelineTickProviders;
			}
		}
	}
}