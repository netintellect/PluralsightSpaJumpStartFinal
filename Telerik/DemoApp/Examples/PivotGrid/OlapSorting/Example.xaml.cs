using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Telerik.Pivot.Core;
using Telerik.Pivot.Core.Olap;
using Telerik.Pivot.Xmla;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.PivotGrid.OlapSorting
{
    public partial class Example : UserControl
    {
        private XmlaDataProvider dataProvider;
        private bool alreadyUpdated;

        public Example()
        {
            InitializeComponent();
            this.dataProvider = this.SecondPivot.DataProvider as XmlaDataProvider;
            this.alreadyUpdated = true;
            this.Unloaded += this.OnExampleUnloaded;
        }

        private void OnExampleUnloaded(object sender, RoutedEventArgs e)
        {
            RadWindowManager.Current.CloseAllWindows();
        }

        private void CopyProviderSettings()
        {
            var sourceProvider = this.Resources["DataProvider"] as XmlaDataProvider;

            this.dataProvider.RowGroupDescriptions.Clear();
            this.dataProvider.ColumnGroupDescriptions.Clear();
            this.dataProvider.FilterDescriptions.Clear();
            this.dataProvider.AggregateDescriptions.Clear();

            this.ChangeDescriptions(sourceProvider.RowGroupDescriptions, "row");
            this.ChangeDescriptions(sourceProvider.ColumnGroupDescriptions, "column");

            foreach (var aggregate in sourceProvider.AggregateDescriptions)
            {
                this.dataProvider.AggregateDescriptions.Add((XmlaAggregateDescription)aggregate.Clone());
            }

            foreach (var filter in sourceProvider.FilterDescriptions)
            {
                this.dataProvider.FilterDescriptions.Add((XmlaFilterDescription)filter.Clone());
            }

            this.dataProvider.Refresh();
        }

        private void ChangeDescriptions(Collection<XmlaGroupDescription> descriptions, string type)
        {
            var newDescriptions = new Collection<XmlaGroupDescription>();
            foreach (var item in descriptions)
            {
                var groupDescription = (XmlaGroupDescription)item.Clone();
                groupDescription.GroupComparer = new GroupNameComparer();

                foreach (OlapLevelGroupDescription levelGroupDescription in groupDescription.Levels)
                {
                    levelGroupDescription.GroupComparer = new GroupNameComparer();
                }

                if (type == "row")
                {
                    this.dataProvider.RowGroupDescriptions.Add(groupDescription);
                }
                else
                {
                    this.dataProvider.ColumnGroupDescriptions.Add(groupDescription);
                }
            }
        }

        private void XmlaDataProvider_PrepareDescriptionForField(object sender, Pivot.Core.PrepareDescriptionForFieldEventArgs e)
        {
            if (e.DescriptionType == Telerik.Pivot.Core.DataProviderDescriptionType.Group)
            {
                var desc = e.Description as OlapGroupDescription;

                if (desc != null)
                {
                    desc.GroupComparer = new OlapGroupComparer();

                    foreach (OlapLevelGroupDescription levelGroupDescription in desc.Levels)
                    {
                        levelGroupDescription.GroupComparer = new OlapGroupComparer();
                    }
                }
            }
        }

        private void XmlaDataProvider_StatusChanged(object sender, DataProviderStatusChangedEventArgs e)
        {
            var dataProvider = sender as XmlaDataProvider;

            if (e.NewStatus == DataProviderStatus.RetrievingData && !this.alreadyUpdated)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    this.CopyProviderSettings();
                    this.alreadyUpdated = true;
                }));
            }
            else if (e.NewStatus == DataProviderStatus.Ready)
            {
                Dispatcher.BeginInvoke(new Action(() => this.alreadyUpdated = false));
            }
        }
    }
}
