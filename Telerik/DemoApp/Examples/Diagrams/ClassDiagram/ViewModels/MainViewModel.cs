using System.ComponentModel;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.ClassDiagram
{
	public class MainViewModel
    {
        public MainViewModel()
        {
            this.ClassDiagramGraphSource = new ClassDiagramGraphSource();
            this.ClassDiagramGraphSource.InternalItems.CollectionChanged += this.OnCollectionChanged;

            this.GroupByAccessCommand = new DelegateCommand((o) => this.GroupItemsByPath(GroupDescriptorPath.Access));
            this.GroupByKindCommand = new DelegateCommand((o) => this.GroupItemsByPath(GroupDescriptorPath.Kind));
            this.SortItemsAscendingCommand = new DelegateCommand((o) => this.SortItems(ListSortDirection.Ascending));
            this.ClearCommand  = new DelegateCommand((o) => this.ClearSource());

            this.CreateSampleDiagram();
        }

		/// <summary>
		/// Gets the class diagram graph source.
		/// </summary>
        public ClassDiagramGraphSource ClassDiagramGraphSource { get; private set; }

        public DelegateCommand GroupByAccessCommand { get; private set; }

        public DelegateCommand GroupByKindCommand { get; private set; }

        public DelegateCommand SortItemsAscendingCommand { get; private set; }

        public DelegateCommand ClearCommand { get; private set; }

        private void GroupItemsByPath(GroupDescriptorPath path)
        {
            foreach (var classViewModel in this.ClassDiagramGraphSource.Items.OfType<ClassViewModel>())
            {
				classViewModel.GroupDescriptorPath = path;
            }
		}

		private void CreateSampleDiagram()
		{
            this.AddShape("Telerik.Windows.Controls.Diagrams", "RadDiagramShapeBase");
            this.AddShape("Telerik.Windows.Controls.Diagrams", "RadDiagramItem");
            this.AddShape("Telerik.Windows.Controls", "RadDiagram");
            this.AddShape("Telerik.Windows.Controls", "RadDiagramShape");
            this.AddShape("Telerik.Windows.Controls", "RadDiagramConnection");
            this.AddShape("Telerik.Windows.Diagrams.Core", "IShape");
            this.AddShape("Telerik.Windows.Diagrams.Core", "IConnection");
		}

        private void AddShape(string namespaceHeader, string classViewModelHeader)
        {
            ClassViewModel classViewModel = this.ClassDiagramGraphSource.Namespaces.First(n => n.Header == namespaceHeader).Types.First(t => t.Header == classViewModelHeader);
            this.ClassDiagramGraphSource.AddNode(classViewModel);
            this.ClassDiagramGraphSource.CreateLinks(classViewModel);
        }

        private void SortItems(ListSortDirection? direction)
        {
	        foreach (var item in this.ClassDiagramGraphSource.Items) (item as ClassViewModel).SortDirection = direction;
        }

        private void ClearSource()
        {
            this.ClassDiagramGraphSource.Clear();
        }

        private void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var firstItem = this.ClassDiagramGraphSource.InternalItems.FirstOrDefault();
            if (firstItem == null) return;
            var isSorted = firstItem.SortDirection != null;

            foreach (var classItem in from object item in e.NewItems select item as ClassViewModel)
            {
	            if (!isSorted) classItem.GroupDescriptorPath = firstItem.GroupDescriptorPath;
	            else classItem.SortDirection = firstItem.SortDirection;
            }
        }
    }
}
