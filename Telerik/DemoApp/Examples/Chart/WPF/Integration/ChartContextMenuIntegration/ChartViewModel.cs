using System;

namespace Telerik.Windows.Examples.Chart.Integration.ChartContextMenuIntegration
{
    public class ChartViewModel
    {
        private ChartDataCollection data;

        public ChartDataCollection Data
        {
            get
            {
                if (data == null)
                {
                    data = new ChartDataCollection();

                    ChartDataItem item = new ChartDataItem(1120000000, "Net Cash from Operating Activities");
                    AddContextMenuItems(item, new string[]{"Net Income", "Non-Cash Items", "Deferred Income Taxes",
                        "Assets/Liabilities Changes", "Other Operating Activities"});
                    data.Add(item);

                    item = new ChartDataItem(881000000, "Net Cash from Investing Activities");
                    AddContextMenuItems(item, new string[] { "Capital Expenditures", "Acquisitions, Divestitues", "Other Investing Activities" });
                    data.Add(item);

                    item = new ChartDataItem(99000000, "Net Cash from Financing Activities");
                    AddContextMenuItems(item, new string[] { "Debt Issued", "Equity Issued" });
                    data.Add(item);
                }

                return data;
            }
        }

        private void AddContextMenuItems(ChartDataItem item, string[] contextMenuItems)
        {
            for (int i = 0, length = contextMenuItems.Length; i < length; i++)
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Text = contextMenuItems[i];
                item.MenuItems.Add(menuItem);
            }
        }
    }
}
