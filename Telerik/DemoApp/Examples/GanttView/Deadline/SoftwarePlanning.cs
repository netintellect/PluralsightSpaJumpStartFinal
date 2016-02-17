using System;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls.GanttView;

namespace Telerik.Windows.Examples.GanttView.Deadline
{
	public class SoftwarePlanning : ObservableCollection<GanttDeadlineTask>
	{
		public SoftwarePlanning()
		{
			var scopeTaskChild1 = new GanttDeadlineTask(new DateTime(2012, 1, 3, 8, 0, 0), new DateTime(2012, 1, 5, 23, 0, 0), "Determine project scope") { Description = "Description: Determine project scope", GanttDeadLine = new DateTime(2012, 1, 5, 8, 0, 0) };

			var scopeTaskChild2 = new GanttDeadlineTask(new DateTime(2012, 1, 3, 16, 0, 0), new DateTime(2012, 1, 4, 15, 0, 0), "Secure project sponsorship") { Description = "Description: Secure project sponsorship", GanttDeadLine = new DateTime(2012, 1, 5, 22, 0, 0) };
			var scopeTaskChild3 = new GanttDeadlineTask(new DateTime(2012, 1, 4, 13, 0, 0), new DateTime(2012, 1, 5, 12, 0, 0), "Define preliminary resources") { Description = "Description: Define preliminary resources", GanttDeadLine = new DateTime(2012, 1, 6, 18, 0, 0) };
			var scopeTaskChild4 = new GanttDeadlineTask(new DateTime(2012, 1, 5, 13, 0, 0), new DateTime(2012, 1, 6, 0, 0, 0), "Secure core resources") { Description = "Description: Secure core resources", GanttDeadLine = new DateTime(2012, 1, 8, 0, 0, 0) };
			var scopeTaskChild5 = new GanttDeadlineTask(new DateTime(2012, 1, 6, 0, 0, 0), new DateTime(2012, 1, 6, 0, 0, 0), "Scope complete") { Description = "Description: Scope complete" };

			scopeTaskChild2.Dependencies.Add(new Dependency { FromTask = scopeTaskChild1 });
			scopeTaskChild3.Dependencies.Add(new Dependency { FromTask = scopeTaskChild2 });
			scopeTaskChild4.Dependencies.Add(new Dependency { FromTask = scopeTaskChild3 });
			scopeTaskChild5.Dependencies.Add(new Dependency { FromTask = scopeTaskChild4 });

			var scopeTask = new GanttDeadlineTask(new DateTime(2012, 1, 3, 8, 0, 0), new DateTime(2012, 1, 6), "Scope")
			{
				Children = { scopeTaskChild1, scopeTaskChild2, scopeTaskChild3, scopeTaskChild4, scopeTaskChild5 },
				Description = "Description: Determine project scope"
			};
			this.Add(scopeTask);

			var softwareRequirementsTaskChild1 = new GanttDeadlineTask(new DateTime(2012, 1, 6, 13, 0, 0), new DateTime(2012, 1, 12, 0, 0, 0), "Conduct needs analysis") { GanttDeadLine = new DateTime(2012, 1, 13, 12, 0, 0) };
			var softwareRequirementsTaskChild2 = new GanttDeadlineTask(new DateTime(2012, 1, 13, 13, 0, 0), new DateTime(2012, 1, 18, 0, 0, 0), "Draft preliminary software specifications") { GanttDeadLine = new DateTime(2012, 1, 16, 0, 0, 0) };
			var softwareRequirementsTaskChild3 = new GanttDeadlineTask(new DateTime(2012, 1, 18, 13, 0, 0), new DateTime(2012, 1, 20, 0, 0, 0), "Develop preliminary budget") { GanttDeadLine = new DateTime(2012, 1, 21, 0, 0, 0) };
			var softwareRequirementsTaskChild4 = new GanttDeadlineTask(new DateTime(2012, 1, 21, 5, 0, 0), new DateTime(2012, 1, 21, 17, 0, 0), "Review software specifications/budget with team") { GanttDeadLine = new DateTime(2012, 1, 21, 23, 0, 0) };
			var softwareRequirementsTaskChild5 = new GanttDeadlineTask(new DateTime(2012, 1, 21, 12, 0, 0), new DateTime(2012, 1, 21, 23, 0, 0), "Incorporate feedback on software specifications") { GanttDeadLine = new DateTime(2012, 1, 22, 14, 0, 0) };
			var softwareRequirementsTaskChild6 = new GanttDeadlineTask(new DateTime(2012, 1, 24, 6, 0, 0), new DateTime(2012, 1, 24, 15, 0, 0), "Develop delivery timeline") { GanttDeadLine = new DateTime(2012, 1, 25, 2, 0, 0) };
			var softwareRequirementsTaskChild7 = new GanttDeadlineTask(new DateTime(2012, 1, 25, 5, 0, 0), new DateTime(2012, 1, 25, 15, 0, 0), "Obtain approvals to proceed (concept, timeline, budget)") { GanttDeadLine = new DateTime(2012, 1, 25, 18, 0, 0) };
			var softwareRequirementsTaskChild8 = new GanttDeadlineTask(new DateTime(2012, 1, 25, 13, 0, 0), new DateTime(2012, 1, 28, 0, 0, 0), "Secure required resources") { GanttDeadLine = new DateTime(2012, 1, 28, 19, 0, 0) };
			var softwareRequirementsTaskChild9 = new GanttDeadlineTask(new DateTime(2012, 1, 26, 0, 0, 0), new DateTime(2012, 1, 26, 0, 0, 0), "Analysis complete");

			softwareRequirementsTaskChild2.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild1 });
			softwareRequirementsTaskChild3.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild2 });
			softwareRequirementsTaskChild4.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild3 });
			softwareRequirementsTaskChild5.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild4 });
			softwareRequirementsTaskChild6.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild5 });
			softwareRequirementsTaskChild7.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild6 });
			softwareRequirementsTaskChild8.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild7 });
			softwareRequirementsTaskChild9.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild8 });

			var softwareRequirementsTask = new GanttDeadlineTask(new DateTime(2012, 1, 6, 13, 0, 0), new DateTime(2012, 1, 26), "Analysis/Software Requirements")
			{
				Children = { softwareRequirementsTaskChild1, softwareRequirementsTaskChild2, softwareRequirementsTaskChild3, softwareRequirementsTaskChild4, softwareRequirementsTaskChild5, softwareRequirementsTaskChild6, softwareRequirementsTaskChild7, softwareRequirementsTaskChild8, softwareRequirementsTaskChild9 }
			};

			this.Add(softwareRequirementsTask);
		}
	}
}
