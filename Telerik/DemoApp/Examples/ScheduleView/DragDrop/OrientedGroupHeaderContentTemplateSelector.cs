using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ScheduleView.DragDrop
{
	public class OrientedGroupHeaderContentTemplateSelector : ScheduleViewDataTemplateSelector
	{
		private DataTemplate horizontalDayViewDateTemplate;
		private DataTemplate horizontalWeekViewDateTemplate;
		private DataTemplate horizontalMonthViewDateTemplate;
		private DataTemplate verticalDayViewDateTemplate;
		private DataTemplate verticalWeekViewDateTemplate;
		private DataTemplate verticalMonthViewDateTemplate;
		private DataTemplate horizontalResourceTemplate;
		private DataTemplate verticalResourceTemplate;

		public DataTemplate HorizontalDayViewDateTemplate
		{
			get
			{
				return this.horizontalDayViewDateTemplate;
			}
			set
			{
				this.horizontalDayViewDateTemplate = value;
			}
		}

		public DataTemplate HorizontalWeekViewDateTemplate
		{
			get
			{
				return this.horizontalWeekViewDateTemplate;
			}
			set
			{
				this.horizontalWeekViewDateTemplate = value;
			}
		}

		public DataTemplate HorizontalMonthViewDateTemplate
		{
			get
			{
				return this.horizontalMonthViewDateTemplate;
			}
			set
			{
				this.horizontalMonthViewDateTemplate = value;
			}
		}

		public DataTemplate VerticalDayViewDateTemplate
		{
			get
			{
				return this.verticalDayViewDateTemplate;
			}
			set
			{
				this.verticalDayViewDateTemplate = value;
			}
		}

		public DataTemplate VerticalWeekViewDateTemplate
		{
			get
			{
				return this.verticalWeekViewDateTemplate;
			}
			set
			{
				this.verticalWeekViewDateTemplate = value;
			}
		}

		public DataTemplate VerticalMonthViewDateTemplate
		{
			get
			{
				return this.verticalMonthViewDateTemplate;
			}
			set
			{
				this.verticalMonthViewDateTemplate = value;
			}
		}

		public DataTemplate HorizontalResourceTemplate
		{
			get
			{
				return this.horizontalResourceTemplate;
			}
			set
			{
				this.horizontalResourceTemplate = value;
			}
		}

		public DataTemplate VerticalResourceTemplate
		{
			get
			{
				return this.verticalResourceTemplate;
			}
			set
			{
				this.verticalResourceTemplate = value;
			}
		}

		public override DataTemplate SelectTemplate(object item, DependencyObject container, ViewDefinitionBase activeViewDeifinition)
		{
			CollectionViewGroup cvg = item as CollectionViewGroup;
			if (cvg != null && cvg.Name is IResource)
			{
				if (activeViewDeifinition.GetOrientation() == Orientation.Vertical)
				{
					if (this.HorizontalResourceTemplate != null)
					{
						return this.HorizontalResourceTemplate;
					}
				}
				else
				{
					if (this.VerticalResourceTemplate != null)
					{
						return this.VerticalResourceTemplate;
					}
				}
			}
			if (cvg != null && cvg.Name is DateTime)
			{
				if (activeViewDeifinition is DayViewDefinition)
				{
					if (activeViewDeifinition.GetOrientation() == Orientation.Vertical)
					{
						if (this.HorizontalDayViewDateTemplate != null)
						{
							return this.HorizontalDayViewDateTemplate;
						}
					}
					else
					{
						if (this.VerticalDayViewDateTemplate != null)
						{
							return this.VerticalDayViewDateTemplate;
						}
					}
				}
				else if (activeViewDeifinition is WeekViewDefinition)
				{
					if (activeViewDeifinition.GetOrientation() == Orientation.Vertical)
					{
						if (this.HorizontalWeekViewDateTemplate != null)
						{
							return this.HorizontalWeekViewDateTemplate;
						}
					}
					else
					{
						if (this.VerticalWeekViewDateTemplate != null)
						{
							return this.VerticalWeekViewDateTemplate;
						}
					}
				}
				else if (activeViewDeifinition is MonthViewDefinition)
				{
					if (activeViewDeifinition.GetOrientation() == Orientation.Vertical)
					{
						if (this.HorizontalMonthViewDateTemplate != null)
						{
							return this.HorizontalMonthViewDateTemplate;
						}
					}
					else
					{
						if (this.VerticalMonthViewDateTemplate != null)
						{
							return this.VerticalMonthViewDateTemplate;
						}
					}
				}
			}
			return base.SelectTemplate(item, container, activeViewDeifinition);
		}
	}
}
