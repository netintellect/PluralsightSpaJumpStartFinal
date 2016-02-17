using System;
using System.Windows;
using System.Windows.Data;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ScheduleView.Common
{
	public class TVGroupHeaderStyleSelector : OrientedGroupHeaderStyleSelector
	{
        private Style liveCastNewsGroupHeaderStyle;
        private Style voozyGroupHeaderStyle;
        private Style sportixGroupHeaderStyle;

        public Style LiveCastNewsGroupHeaderStyle
        {
            get
            {
                return this.liveCastNewsGroupHeaderStyle;
            }
            set
            {
                this.liveCastNewsGroupHeaderStyle = value;
            }
        }

        public Style VoozyGroupHeaderStyle
        {
            get
            {
                return this.voozyGroupHeaderStyle;
            }
            set
            {
                this.voozyGroupHeaderStyle = value;
            }
        }

        public Style SportixGroupHeaderStyle
        {
            get
            {
                return this.sportixGroupHeaderStyle;
            }
            set
            {
                this.sportixGroupHeaderStyle = value;
            }
        }        

		public override Style SelectStyle(object item, DependencyObject container, ViewDefinitionBase activeViewDeifinition)
		{
            GroupHeader groupHeader = container as GroupHeader;
            if (groupHeader != null)
            {
                Resource groupKey = groupHeader.GroupKey as Resource;
                if (groupKey != null)
                {
                    if (groupKey.ResourceType == "TV")
                    {
                        switch (groupKey.ResourceName)
                        {
                            case "LiveCastNews": return this.LiveCastNewsGroupHeaderStyle;
                            case "Voozy": return this.VoozyGroupHeaderStyle;
                            case "Sportix": return this.SportixGroupHeaderStyle;

                            default:
                                break;
                        }
                    }                  
                }                
            }
            return base.SelectStyle(item, container, activeViewDeifinition);
		}
	}
}