using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using Telerik.Windows.Controls;
using System.ComponentModel.DataAnnotations;

namespace Telerik.Windows.Examples.TreeListView
{
    public class FolderViewModel : ViewModelBase
    {
        private string name;
        private bool isEmpty;
        private DateTime createdOn;
        private ObservableCollection<FolderViewModel> items;
        private readonly XElement folderElement;

        public FolderViewModel(XElement element)
        {
            this.folderElement = element;
        }

        public FolderViewModel(string name, bool isEmpty, DateTime createdOn, XElement element)
        {
            this.Name = name;
            this.IsEmpty = isEmpty;
            this.folderElement = element;
            this.CreatedOn = createdOn;
            this.items = new ObservableCollection<FolderViewModel>(from f in this.folderElement.Elements("folder")
                                                                   select new FolderViewModel(
                                                                       f.Attribute("Name").Value,
                                                                       bool.Parse(f.Attribute("IsEmpty").Value),
                                                                       DateTime.Parse(f.Attribute("CreationTime").Value, System.Globalization.CultureInfo.InvariantCulture),
                                                                       f
                                                                   ));
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public DateTime CreatedOn
        {
            get
            {
                return this.createdOn;
            }
            set
            {
                this.createdOn = value;
            }
        }

        [Display(AutoGenerateField = false)]
        public bool IsEmpty
        {
            get
            {
                return this.isEmpty;
            }
            set
            {
                this.isEmpty = value;
            }
        }

        [Display(AutoGenerateField = false)]
        public ObservableCollection<FolderViewModel> Items
        {
            get
            {
                return this.items;
            }
        }

        private bool isExpanded;

        [Display(AutoGenerateField = false)]
        public bool IsExpanded
        {
            get
            {
                return this.isExpanded;
            }
            set
            {
                if (this.isExpanded != value)
                {
                    this.isExpanded = value;

                    this.LoadChildren();

                    OnPropertyChanged("IsExpanded");
                }
            }
        }

        public void LoadChildren()
        {
            if (this.items == null)
            {
                this.items = new ObservableCollection<FolderViewModel>(from f in this.folderElement.Elements("folder")
                                                                       select new FolderViewModel(f)
                                                                       {
                                                                           Name = f.Attribute("Name").Value,
                                                                           IsEmpty = bool.Parse(f.Attribute("IsEmpty").Value),
                                                                           CreatedOn = DateTime.Parse(f.Attribute("CreationTime").Value, System.Globalization.CultureInfo.InvariantCulture),
                                                                       });
                this.OnPropertyChanged("Items");
            }
        }
    }
}
