using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Telerik.Windows.QuickStart.ViewModel
{

    public class AllControlsTouchViewModel : QuickStartViewModelBase
    {
        public const string NewControlsGroupName = "   ";
        public const string HighlightedControlsGroupName = "    ";
        public const string SampleAppsGroupName = "     ";

        private IEnumerable<IControlInfo> newControlsTouchCloned;
        private IEnumerable<IControlInfo> highlightedControlsTouchCloned;
        private ExampleNameGroupDescription nameGroupDescription;

        public AllControlsTouchViewModel(INotifyUser ownerView)
            : base(ownerView)
        {
            this.nameGroupDescription = new ExampleNameGroupDescription(this);
        }

        /// <summary>
        /// Shows all controls - new, highlighted and non-highlighted, new first.
        /// </summary>
        public ICollectionView AllControls
        {
            get
            {
                if (this.newControlsTouchCloned == null)
                {
                    this.newControlsTouchCloned = this.Data.NewControlsTouch.Select(c => c.Clone()).ToList();
                }

                if (this.highlightedControlsTouchCloned == null)
                {
                    this.highlightedControlsTouchCloned = this.Data.HighlightedControlsTouch.Select(c => c.Clone()).ToList();
                }

                IEnumerable<IControlInfo> union = this.newControlsTouchCloned.Concat(this.highlightedControlsTouchCloned.Concat(this.Data.ControlsTouch).ToList()).ToList();

                var collectionViewSource = new CollectionViewSource() { Source = union };
                collectionViewSource.GroupDescriptions.Add(this.nameGroupDescription);
                return collectionViewSource.View;
            }
        }

        /// <summary>
        /// Collection with the sample applications.
        /// </summary>
        public ICollectionView SampleApps
        {
            get 
            {
                var collectionViewSource = new CollectionViewSource() { Source = this.Data.SampleApps };
                collectionViewSource.GroupDescriptions.Add(this.nameGroupDescription);
                return collectionViewSource.View;
            }
        }

        internal IEnumerable<IControlInfo> NewControls
        {
            get
            {
                return this.newControlsTouchCloned;
            }
        }

        internal IEnumerable<IControlInfo> HighlightedControls
        {
            get
            {
                return this.highlightedControlsTouchCloned;
            }
        }

        /// <summary>
        /// Gets the correct group name for an item - highlighted controls go in one group, the others go to different group, based on their name.
        /// </summary>
        public string GetGroupNameForItem(IControlInfo generatedItem)
        {
            if (this.newControlsTouchCloned.Contains(generatedItem))
            {
                return NewControlsGroupName;
            }
            
            if (this.highlightedControlsTouchCloned.Contains(generatedItem))
            {
                return HighlightedControlsGroupName;
            }

            var groupNames = new string[] { "A-B", "C-D", "E-F", "G-H", "I-J", "K-L", "M-N", "O-P", "Q-R", "S-T", "U-V", "W-X", "Y-Z" };
            char itemNameStartingLetter = generatedItem.Name.First();
            var result = groupNames.Single(gn => gn.Contains(itemNameStartingLetter));
            return result;
        }

        private class ExampleNameGroupDescription : GroupDescription
        {
            private readonly AllControlsTouchViewModel viewModel;

            public ExampleNameGroupDescription(AllControlsTouchViewModel viewModel)
            {
                this.viewModel = viewModel;
            }

            public override object GroupNameFromItem(object item, int level, System.Globalization.CultureInfo culture)
            {
                if (item is ISampleAppInfo)
                {
                    return AllControlsTouchViewModel.SampleAppsGroupName;
                }

                return this.viewModel.GetGroupNameForItem((IControlInfo)item);
            }
        }
    }
}
