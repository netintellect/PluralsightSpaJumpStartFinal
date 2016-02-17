using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls.Timeline;

namespace Telerik.Windows.Examples.Timeline.CustomRowIndex
{
    public class HouseRowIndexGenerator : IItemRowIndexGenerator
    {
        private List<string> houses;
        private List<King> kings;
        private List<KingEvent> events;

        public HouseRowIndexGenerator(List<string> houses, List<King> kings, List<KingEvent> events)
        {
            this.houses = houses;
            this.kings = kings;
            this.events = events;
        }

        public void GenerateRowIndexes(List<TimelineRowItem> dataItems)
        {
            var kingsTimelineItems = dataItems.Where(item => item.DataItem.GetType() == typeof(King)).ToList();
            var eventsTimelineItems = dataItems.Where(item => item.DataItem.GetType() == typeof(KingEvent)).ToList();

            foreach (var house in this.houses)
            {
                var kingsFromSameHouse = this.kings.Where(king => king.House == house).ToList();

                kingsFromSameHouse.OrderBy(king => king.Begin);
                
                int rowCounter = 0;
                foreach (var king in kingsFromSameHouse)
                {
                    if ((house == "Wessex" && king.Name.Contains("Edward the Confessor")) ||
                       (house == "Stuart" && (king.Name.Contains("Charles II") || king.Name.Contains("Anne"))) ||
                        rowCounter >= 10)
                    {
                        rowCounter = 0;
                    }

                    kingsTimelineItems.Single(item => item.DataItem == king).RowIndex = rowCounter;
                    rowCounter++;
                    var kingsEvents = this.events.Where(eventItem => eventItem.Ruler == king);
                    foreach (var eventItem in kingsEvents)
                    {
                        eventsTimelineItems.Single(item => item.DataItem == eventItem).RowIndex = rowCounter;
                    }
                    rowCounter++;
                }
            }
        }
    }
}