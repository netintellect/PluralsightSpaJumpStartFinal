using System.Collections.ObjectModel;
using System.Linq;
using System.Linq;
using System.Reflection;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;

namespace Telerik.Windows.Examples.Diagrams.ClassDiagram
{
	/// <summary>
	/// MVVM source for the diagram.
	/// </summary>
	public class ClassDiagramGraphSource : GraphSourceBase<ClassViewModel, ILink>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ClassDiagramGraphSource"/> class.
		/// </summary>
		public ClassDiagramGraphSource()
		{
			this.Namespaces = new ObservableCollection<NamespaceViewModel>();
			this.ParseAssembly(typeof(RadDiagram).Assembly);
			this.ParseAssembly(typeof(IGraph).Assembly);
            this.Namespaces[0].IsExpanded = true;
		}

		/// <summary>
		/// Gets the namespaces populating the tree.
		/// </summary>
		public ObservableCollection<NamespaceViewModel> Namespaces { get; private set; }

		/// <summary>
		/// Adds a <see cref="ClassViewModel"/> to this source (and hence to the diagram) representing a single public type.
		/// </summary>
		/// <param name="model">The model (representing a type) to add to the diagram.</param>
		public void AddItem(ClassViewModel model)
		{
			if (this.InternalItems.Contains(model))
				return;
			this.AddNode(model);
			this.CreateLinks(model);
		}

		/// <summary>
		/// Seeks relationships with the existing types on the diagram and creat correspondingly connections.
		/// </summary>
		/// <param name="classItem">The class item being added to the diagram surface.</param>
		public void CreateLinks(ClassViewModel classItem)
		{
			foreach (var item in from item in this.InternalItems let baseTypes = item.BaseTypes.Select(t => t.Name) where baseTypes.Any() && baseTypes.Contains(classItem.Header) select item)
			{
				this.AddLink(new ClassLinkViewModel(item, classItem) { TargetCapType = CapType.Arrow1Filled });
			}
			var classItemBaseTypes = classItem.BaseTypes.Select(t => t.Name);
			foreach (var item in this.InternalItems.Where(item => classItemBaseTypes.Any() && classItemBaseTypes.Contains(item.Header)))
			{
				this.AddLink(new ClassLinkViewModel(classItem, item) { TargetCapType = CapType.Arrow1Filled });
			}
		}

		public void Clear()
		{
			this.InternalLinks.Clear();
			this.InternalItems.Clear();
		}

		/// <summary>
		/// Parses the given assembly for its public types and adds them to the <see cref="Namespaces"/> collection.
		/// </summary>
		/// <param name="assembly">The assembly to parse and add as a source.</param>
		private void ParseAssembly(Assembly assembly)
		{
			var coreTypes = assembly.GetExportedTypes().OrderBy(t => t.Name).ToList();
			for (var i = 0; i < coreTypes.Count(); i++)
			{
				var namespaces = this.Namespaces.Select(n => n.Header);
				var classViewModel = new ClassViewModel(coreTypes[i]);
				if (namespaces.Contains(coreTypes[i].Namespace))
				{
					this.Namespaces.First(n => n.Header == coreTypes[i].Namespace).AddNewType(classViewModel);
				}
				else
				{
					var namespaceViewModel = new NamespaceViewModel(coreTypes[i].Namespace);
					namespaceViewModel.AddNewType(classViewModel);
					this.Namespaces.Add(namespaceViewModel);
				}
			}
		}
	}
}