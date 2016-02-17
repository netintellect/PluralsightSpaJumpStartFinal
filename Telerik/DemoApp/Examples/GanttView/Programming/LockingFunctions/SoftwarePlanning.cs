using System;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls.GanttView;

namespace Telerik.Windows.Examples.GanttView.Programming.LockingFunctions
{
	public class SoftwarePlanning : ObservableCollection<LockingTask>
	{
		public SoftwarePlanning()
		{
			var date = DateTime.Today;

			var scopeTaskChild1 = new LockingTask { Id = 2, Start = date.AddHours(8), End = date.AddDays(2).AddHours(23), Title = "Determine project scope" };

			var scopeTaskChild2 = new LockingTask { Id = 3, Start = date.AddHours(13), End = date.AddDays(1).AddHours(12), Title = "Secure project sponsorship" };
			var scopeTaskChild3 = new LockingTask { Id = 4, Start = date.AddDays(1).AddHours(13), End = date.AddDays(2).AddHours(12), Title = "Define preliminary resources" };
			var scopeTaskChild4 = new LockingTask { Id = 5, Start = date.AddDays(2).AddHours(13), End = date.AddDays(3), Title = "Secure core resources" };
			var scopeTaskChild5 = new LockingTask { Id = 6, Start = date.AddDays(3), End = date.AddDays(3), Title = "Scope complete" };

			scopeTaskChild2.Dependencies.Add(new Dependency { FromTask = scopeTaskChild1 });
			scopeTaskChild3.Dependencies.Add(new Dependency { FromTask = scopeTaskChild2 });
			scopeTaskChild4.Dependencies.Add(new Dependency { FromTask = scopeTaskChild3 });
			scopeTaskChild5.Dependencies.Add(new Dependency { FromTask = scopeTaskChild4 });

			var scopeTask = new LockingTask
			{
				Start = date.AddHours(8),
				End = date.AddDays(3),
				Title = "Scope",
				Children = { scopeTaskChild1, scopeTaskChild2, scopeTaskChild3, scopeTaskChild4, scopeTaskChild5 },
				Id = 1
			};
			this.Add(scopeTask);

			var softwareRequirementsTaskChild1 = new LockingTask { Id = 8, Start = date.AddDays(3).AddHours(13), End = date.AddDays(9), Title = "Conduct needs analysis" };
			var softwareRequirementsTaskChild2 = new LockingTask { Id = 9, Start = date.AddDays(10).AddHours(13), End = date.AddDays(15), Title = "Draft preliminary software specifications" };
			var softwareRequirementsTaskChild3 = new LockingTask { Id = 10, Start = date.AddDays(15).AddHours(13), End = date.AddDays(17), Title = "Develop preliminary budget" };
			var softwareRequirementsTaskChild4 = new LockingTask { Id = 11, Start = date.AddDays(18).AddHours(8), End = date.AddDays(18).AddHours(17), Title = "Review software specifications/budget with team" };
			var softwareRequirementsTaskChild5 = new LockingTask { Id = 12, Start = date.AddDays(18).AddHours(8), End = date.AddDays(18).AddHours(17), Title = "Incorporate feedback on software specifications" };
			var softwareRequirementsTaskChild6 = new LockingTask { Id = 13, Start = date.AddDays(21).AddHours(8), End = date.AddDays(21).AddHours(17), Title = "Develop delivery timeline" };
			var softwareRequirementsTaskChild7 = new LockingTask { Id = 14, Start = date.AddDays(22).AddHours(8), End = date.AddDays(22).AddHours(12), Title = "Obtain approvals to proceed (concept, timeline, budget)" };
			var softwareRequirementsTaskChild8 = new LockingTask { Id = 15, Start = date.AddDays(22).AddHours(13), End = date.AddDays(25), Title = "Secure required resources" };
			var softwareRequirementsTaskChild9 = new LockingTask { Id = 16, Start = date.AddDays(23), End = date.AddDays(23), Title = "Analysis complete" };

			softwareRequirementsTaskChild2.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild1 });
			softwareRequirementsTaskChild3.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild2 });
			softwareRequirementsTaskChild4.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild3 });
			softwareRequirementsTaskChild5.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild4 });
			softwareRequirementsTaskChild6.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild5 });
			softwareRequirementsTaskChild7.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild6 });
			softwareRequirementsTaskChild8.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild7 });
			softwareRequirementsTaskChild9.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild8 });

			var softwareRequirementsTask = new LockingTask
			{
				Id = 7,
				Start = date.AddDays(3).AddHours(13),
				End = date.AddDays(23),
				Title = "Analysis/Software Requirements",
				Children = { softwareRequirementsTaskChild1, softwareRequirementsTaskChild2, softwareRequirementsTaskChild3, softwareRequirementsTaskChild4, softwareRequirementsTaskChild5, softwareRequirementsTaskChild6, softwareRequirementsTaskChild7, softwareRequirementsTaskChild8, softwareRequirementsTaskChild9 }
			};

			this.Add(softwareRequirementsTask);
		}
	}
}
