using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using Telerik.Windows.Core;

namespace Telerik.Windows.Examples.GanttView.Utils
{
	public class ExamplesViewModel : PropertyChangedBase
	{
		public ExamplesViewModel()
		{
			var exampleTypes = typeof(ExamplesViewModel).Assembly.GetExportedTypes().Where(type => type.Namespace.StartsWith("Telerik.Windows.Examples.GanttView") && type.Name.Equals("Example")).ToArray();
			this.Examples = new ObservableCollection<ExampleViewModel>(exampleTypes.Select(type => new ExampleViewModel { Title = type.Namespace.Split('.').Last(), Content = Activator.CreateInstance(type) }));
		}

		public IList Examples { get; private set; }
	}
}