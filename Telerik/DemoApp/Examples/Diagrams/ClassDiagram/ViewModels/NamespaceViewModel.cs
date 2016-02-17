using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.ClassDiagram
{
    public class NamespaceViewModel : ViewModelBase
    {
        private string header;

        public NamespaceViewModel()
        {
            this.Types = new ObservableCollection<ClassViewModel>();
            this.IsExpanded = false;
        }

        public NamespaceViewModel(string header) : this()
        {
            this.Header = header;
        }

        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
                OnPropertyChanged("Header");
            }
        }

        private bool isExpanded;
        public bool IsExpanded
        {
            get { return this.isExpanded; }
            set
            {
                if (this.isExpanded != value)
                {
                    this.isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }
            }
        }
        

        public ObservableCollection<ClassViewModel> Types
        { get; private set; }

        public void AddNewType(ClassViewModel type)
        {
            if (!this.Types.Contains(type))
                this.Types.Add(type);
        }
    }
}
