using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.VirtualizingWrapPanel
{
    /// <summary>
    /// ExamplesViewModel.
    /// </summary>
    public class ExamplesViewModel : INotifyPropertyChanged
    {
        private IQueryable<MyBusinessObject> randomProducts;
        /// <summary>
        /// Gets the random products.
        /// </summary>
        /// <value>The random products.</value>
        public IQueryable<MyBusinessObject> RandomProducts
        {
            get
            {
                if (this.randomProducts == null)
                {
                    this.randomProducts = new MyBusinessObjects().GetData(45745).AsQueryable();
                }

                return this.randomProducts;
            }
        }

        ObservableCollection<MyBusinessObject> view;
        public ObservableCollection<MyBusinessObject> View
        {
            get
            {
                if (object.Equals(view, null))
                {
                    var data = RandomProducts
                        .Where(i => i.Name.ToLower().Contains(SearchValue.ToLower()))
                        .Sort(new SortDescriptor[] { new SortDescriptor() { Member = SelectedProperty } })
                        .Cast<MyBusinessObject>();

                    view = new ObservableCollection<MyBusinessObject>(data);
                }
                return view;
            }
            private set
            {
                if (!object.Equals(view, value))
                {
                    view = value;

                    OnPropertyChanged("View");
                }
            }
        }

        IEnumerable<string> properties;
        public IEnumerable<string> Properties
        {
            get
            {
                if (properties == null)
                {
                    properties = from p in typeof(MyBusinessObject).GetProperties()
                                 select p.Name;

                    selectedProperty = properties.FirstOrDefault();
                }

                return properties;
            }
        }

        string selectedProperty;
        public string SelectedProperty
        {
            get
            {
                return selectedProperty;
            }
            set
            {
                if (selectedProperty != value)
                {
                    selectedProperty = value;

                    View = null;

                    OnPropertyChanged("SelectedProperty");
                }
            }
        }

        string searchValue = string.Empty;
        public string SearchValue
        {
            get
            {
                return searchValue;
            }
            set
            {
                if (searchValue != value)
                {
                    searchValue = value;

                    View = null;

                    OnPropertyChanged("SearchValue");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
