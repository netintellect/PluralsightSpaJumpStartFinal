using System;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls.GanttView;

namespace Telerik.Windows.Examples.GanttView
{
	public class SoftwarePlanning : ObservableCollection<IGanttTask>
	{
		public SoftwarePlanning()
		{
			var start = DateTime.Today.AddMonths(-1);
			start = start.AddDays(-start.Day + 1);
			var end = start;

			start = start.AddHours(8);
			end = start.AddHours(4);
			var scopeTaskChild1 = new GanttTask(start, end, "Determine project scope");

			start = start.AddHours(5);
			end = start.AddHours(23);
			var scopeTaskChild2 = new GanttTask(start, end, "Secure project sponsorship");

			start = start.AddHours(24);
			end = start.AddHours(23);
			var scopeTaskChild3 = new GanttTask(start, end, "Define preliminary resources");

			start = start.AddHours(24);
			end = start.AddHours(11);
			var scopeTaskChild4 = new GanttTask(start, end, "Secure core resources");

			start = start.AddHours(11);
			end = start;
			var scopeTaskChild5 = new GanttTask(start, end, "Scope complete");

			scopeTaskChild2.Dependencies.Add(new Dependency { FromTask = scopeTaskChild1 });
			scopeTaskChild3.Dependencies.Add(new Dependency { FromTask = scopeTaskChild2 });
			scopeTaskChild4.Dependencies.Add(new Dependency { FromTask = scopeTaskChild3 });
			scopeTaskChild5.Dependencies.Add(new Dependency { FromTask = scopeTaskChild4 });

			var scopeTask = new GanttTask(start.AddDays(-3).AddHours(8), end, "Scope")
			{
				Children = { scopeTaskChild1, scopeTaskChild2, scopeTaskChild3, scopeTaskChild4, scopeTaskChild5 }
			};
			this.Add(scopeTask);

			start = start.AddHours(13);
			end = start;
			var softwareRequirementsTaskChild1 = new GanttTask(start, end, "Conduct needs analysis");

			start = start.AddDays(2);
			end = start.Date.AddDays(5);
			var softwareRequirementsTaskChild2 = new GanttTask(start, end, "Draft preliminary software specifications");

			start = start.AddHours(13);
			end = start.Date.AddHours(2);
			var softwareRequirementsTaskChild3 = new GanttTask(start, end, "Develop preliminary budget");

			start = start.Date.AddDays(3).AddHours(8);
			end = start.AddHours(9);
			var softwareRequirementsTaskChild4 = new GanttTask(start, end, "Review software specifications/budget with team");

			var softwareRequirementsTaskChild5 = new GanttTask(start, end, "Incorporate feedback on software specifications");

			start = start.AddDays(3);
			end = start.AddHours(9);
			var softwareRequirementsTaskChild6 = new GanttTask(start, end, "Develop delivery timeline");

			start = start.AddDays(1);
			end = start.AddHours(4);
			var softwareRequirementsTaskChild7 = new GanttTask(start, end, "Obtain approvals to proceed (concept, timeline, budget)");

			start = start.AddHours(5);
			end = start.Date.AddDays(1);
			var softwareRequirementsTaskChild8 = new GanttTask(start, end, "Secure required resources");

			start = start.Date.AddDays(1);
			end = start;
			var softwareRequirementsTaskChild9 = new GanttTask(start, end, "Analysis complete");

			softwareRequirementsTaskChild2.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild1 });
			softwareRequirementsTaskChild3.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild2 });
			softwareRequirementsTaskChild4.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild3 });
			softwareRequirementsTaskChild5.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild4 });
			softwareRequirementsTaskChild6.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild5 });
			softwareRequirementsTaskChild7.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild6 });
			softwareRequirementsTaskChild8.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild7 });
			softwareRequirementsTaskChild9.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild8 });

			var softwareRequirementsTask = new GanttTask(start.AddDays(-11).AddHours(13), end, "Analysis/Software Requirements")
			{
				Children = { softwareRequirementsTaskChild1, softwareRequirementsTaskChild2, softwareRequirementsTaskChild3, softwareRequirementsTaskChild4, softwareRequirementsTaskChild5, softwareRequirementsTaskChild6, softwareRequirementsTaskChild7, softwareRequirementsTaskChild8, softwareRequirementsTaskChild9 }
			};

			this.Add(softwareRequirementsTask);

			end = start.AddDays(2);
			var designTaskChild1 = new GanttTask(start, end, "Review preliminary software specifications");

			start = start.AddDays(2).AddHours(13);
			end = start.Date.AddDays(7).AddHours(4);
			var designTaskChild2 = new GanttTask(start, end, "Develop functional specifications");

			start = start.AddDays(7);
			end = start.Date.AddDays(6);
			var designTaskChild3 = new GanttTask(start, end, "Develop prototype based on functional specifications");

			start = start.Date.AddDays(6).AddHours(8);
			end = start.Date.AddDays(4).AddHours(17);
			var designTaskChild4 = new GanttTask(start, end, "Review functional specifications");

			start = start.AddDays(4);
			end = start.Date.AddDays(1).AddHours(17);
			var designTaskChild5 = new GanttTask(start, end, "Incorporate feedback into functional specifications");

			start = start.AddDays(1);
			end = start.AddDays(3).AddHours(9);
			var designTaskChild6 = new GanttTask(start, end, "Obtain approval to proceed");

			start = start.Date.AddDays(5);
			end = start;
			var designTaskChild7 = new GanttTask(start, end, "Design complete");

			designTaskChild2.Dependencies.Add(new Dependency { FromTask = designTaskChild1 });
			designTaskChild3.Dependencies.Add(new Dependency { FromTask = designTaskChild2 });
			designTaskChild4.Dependencies.Add(new Dependency { FromTask = designTaskChild3 });
			designTaskChild5.Dependencies.Add(new Dependency { FromTask = designTaskChild4 });
			designTaskChild6.Dependencies.Add(new Dependency { FromTask = designTaskChild5 });
			designTaskChild7.Dependencies.Add(new Dependency { FromTask = designTaskChild6 });

			var designTask = new GanttTask(start.AddDays(-25), end, "Analysis/Software Requirements")
			{
				Children = { designTaskChild1, designTaskChild2, designTaskChild3, designTaskChild4, designTaskChild5, designTaskChild6, designTaskChild7 }
			};
			this.Add(designTask);

			start = start.AddDays(3).AddHours(8);
            end = start.AddDays(1);

			var developmentTaskChild1 = new GanttTask(start, end, "Review functional specifications");

			start = start.AddDays(1);
			end = start.AddDays(1);
			var developmentTaskChild2 = new GanttTask(start, end, "Identify modular/tiered design parameters");

			start = start.AddDays(1);
            end = start.AddDays(1);
			var developmentTaskChild3 = new GanttTask(start, end, "Assign development staff");

			start = start.AddDays(3);
			end = start.AddDays(17).AddHours(9);
			var developmentTaskChild4 = new GanttTask(start, end, "Develop code");

			start = start.Date.AddDays(16).AddHours(15);
			end = start.AddDays(30);
			var developmentTaskChild5 = new GanttTask(start, end, "Developer testing (primary debugging)");

			start = end;
			var developmentTaskChild6 = new GanttTask(start, end, "Development complete");

			developmentTaskChild2.Dependencies.Add(new Dependency { FromTask = developmentTaskChild1 });
			developmentTaskChild3.Dependencies.Add(new Dependency { FromTask = developmentTaskChild2 });
			developmentTaskChild4.Dependencies.Add(new Dependency { FromTask = developmentTaskChild3 });
			developmentTaskChild5.Dependencies.Add(new Dependency { FromTask = developmentTaskChild4 });
			developmentTaskChild6.Dependencies.Add(new Dependency { FromTask = developmentTaskChild5 });


			var developmentTask = new GanttTask(start.Date.AddMonths(-1).AddDays(-20).AddHours(8), end, "Development")
			{
				Children = { developmentTaskChild1, developmentTaskChild2, developmentTaskChild3, developmentTaskChild4, developmentTaskChild5, developmentTaskChild6 }
			};
			this.Add(developmentTask);

			start = start.Date.AddDays(2).AddHours(8);
			end = start.Date.AddDays(5).AddHours(17);
			var testingTaskChild1 = new GanttTask(start, end, "Develop unit test plans using product specifications");
			var testingTaskChild2 = new GanttTask(start.AddDays(7), end.AddDays(7), "Develop integration test plans using product specifications");

			start = start.AddDays(15);
			end = start.AddDays(20).AddHours(9);
			var testingTaskChild3 = new GanttTask(start, end, "Unit testing");

			start = end.Date.AddHours(8);
			end = start.AddDays(18).AddHours(9);
			var testingTaskChild4 = new GanttTask(start, end, "Integration Testing");

			testingTaskChild2.Dependencies.Add(new Dependency { FromTask = testingTaskChild1 });
			testingTaskChild3.Dependencies.Add(new Dependency { FromTask = testingTaskChild2 });
			testingTaskChild4.Dependencies.Add(new Dependency { FromTask = testingTaskChild3 });

			var testingTask = new GanttTask(start.AddMonths(-2).AddDays(27), end.Date.AddHours(17), "Testing")
			{
				Children = { testingTaskChild1, testingTaskChild2, testingTaskChild3, testingTaskChild4 }
			};
			this.Add(testingTask);

            start = start.AddDays(20);
			end = start.AddDays(7);

			var trainingTaskChild1 = new GanttTask(start, end, "Develop training specifications for end users");
			var trainingTaskChild2 = new GanttTask(start.AddDays(7), end.AddDays(11), "Develop training specifications for helpdesk support staff");
			var trainingTaskChild3 = new GanttTask(start.AddDays(18), end.AddDays(25), "Identify training delivery methodology (computer based training, classroom, etc.)");

			start = start.AddMonths(1).AddDays(4);
			end = start.AddDays(21);
			var trainingTaskChild4 = new GanttTask(start, end, "Develop training materials");

			start = end;
			end = start.AddDays(6);
			var trainingTaskChild5 = new GanttTask(start, end, "Conduct training usability study");

			start = start.AddDays(6);
			end = start.AddDays(5);
			var trainingTaskChild6 = new GanttTask(start, end, "Finalize training materials");

			start = end;
			end = start.AddDays(2);
			var trainingTaskChild7 = new GanttTask(start, end, "Develop training delivery mechanism");

			start = end;
			var trainingTaskChild8 = new GanttTask(start, end, "Training materials complete");

			trainingTaskChild2.Dependencies.Add(new Dependency { FromTask = trainingTaskChild1 });
			trainingTaskChild3.Dependencies.Add(new Dependency { FromTask = trainingTaskChild2 });
			trainingTaskChild4.Dependencies.Add(new Dependency { FromTask = trainingTaskChild3 });
			trainingTaskChild5.Dependencies.Add(new Dependency { FromTask = trainingTaskChild4 });
			trainingTaskChild6.Dependencies.Add(new Dependency { FromTask = trainingTaskChild5 });
			trainingTaskChild7.Dependencies.Add(new Dependency { FromTask = trainingTaskChild6 });
			trainingTaskChild8.Dependencies.Add(new Dependency { FromTask = trainingTaskChild7 });

			var trainingTask = new GanttTask(start.AddMonths(-2).AddDays(-7), end, "Training")
			{
				Children = { trainingTaskChild1, trainingTaskChild2, trainingTaskChild3, trainingTaskChild4, trainingTaskChild5, trainingTaskChild6, trainingTaskChild7, trainingTaskChild8 }
			};
			this.Add(trainingTask);

			start = start.AddDays(4);
			end = start.AddDays(2);
			var documentationTaskChild1 = new GanttTask(start, end, "Develop Help specification");

			start = start.AddDays(4).AddHours(4);
			end = start.AddDays(5);
			var documentationTaskChild2 = new GanttTask(start, end, "Develop Help system");

			start = end.AddHours(1);
			end = start.AddDays(5).AddHours(-1);
			var documentationTaskChild3 = new GanttTask(start, end, "Review Help documentation");

			start = end.AddHours(3);
			end = start.AddDays(2);
			var documentationTaskChild4 = new GanttTask(start, end, "Incorporate Help documentation feedback");

            start = start.AddDays(2);
			end = start.AddDays(1).AddHours(9);
			var documentationTaskChild5 = new GanttTask(start, end, "Develop user manuals specifications");

			start = start.Date.AddDays(5).AddHours(7);
			end = start.AddDays(9);
			var documentationTaskChild6 = new GanttTask(start, end, "Develop user manuals");

			start = end;
			end = start.AddDays(2);
			var documentationTaskChild7 = new GanttTask(start, end, "Review all user documentation");

			start = start.AddDays(2);
			end = start.AddDays(4);
			var documentationTaskChild8 = new GanttTask(start, end, "Incorporate user documentation feedback");

			start = end.AddDays(1);
			end = start;
			var documentationTaskChild9 = new GanttTask(start, end, "Documentation complete");

			documentationTaskChild2.Dependencies.Add(new Dependency { FromTask = documentationTaskChild1 });
			documentationTaskChild3.Dependencies.Add(new Dependency { FromTask = documentationTaskChild2 });
			documentationTaskChild4.Dependencies.Add(new Dependency { FromTask = documentationTaskChild3 });
			documentationTaskChild5.Dependencies.Add(new Dependency { FromTask = documentationTaskChild4 });
			documentationTaskChild6.Dependencies.Add(new Dependency { FromTask = documentationTaskChild5 });
			documentationTaskChild7.Dependencies.Add(new Dependency { FromTask = documentationTaskChild6 });
            documentationTaskChild8.Dependencies.Add(new Dependency { FromTask = documentationTaskChild7 });
            documentationTaskChild9.Dependencies.Add(new Dependency { FromTask = documentationTaskChild8 });

			var documentationTask = new GanttTask(start.AddMonths(-1).AddDays(-6), end, "Documentation")
			{
				Children = { documentationTaskChild1, documentationTaskChild2, documentationTaskChild3, documentationTaskChild4, documentationTaskChild5, documentationTaskChild6, documentationTaskChild7, documentationTaskChild8, documentationTaskChild9 }
			};
			this.Add(documentationTask);

			start = start.Date.AddDays(3).AddHours(8);
			end = start.AddDays(1).AddHours(9);
			var pilotTaskChild1 = new GanttTask(start, end, "Identify test group");

			start = start.AddDays(1).AddHours(4);
			end = start.AddDays(1);
			var pilotTaskChild2 = new GanttTask(start, end, "Develop software delivery mechanism");

			start = start.AddDays(2);
			end = start.AddDays(3);
			var pilotTaskChild3 = new GanttTask(start, end, "Install/deploy software");

			start = end.AddHours(3);
			end = start.AddDays(7);
			var pilotTaskChild4 = new GanttTask(start, end, "Obtain user feedback");

			start = end;
			end = start.AddDays(1);
			var pilotTaskChild5 = new GanttTask(start, end, "Evaluate testing information");

			start = end;
			var pilotTaskChild6 = new GanttTask(start, end, "Pilot complete");

			pilotTaskChild2.Dependencies.Add(new Dependency { FromTask = pilotTaskChild1 });
			pilotTaskChild3.Dependencies.Add(new Dependency { FromTask = pilotTaskChild2 });
			pilotTaskChild4.Dependencies.Add(new Dependency { FromTask = pilotTaskChild3 });
			pilotTaskChild5.Dependencies.Add(new Dependency { FromTask = pilotTaskChild4 });
			pilotTaskChild6.Dependencies.Add(new Dependency { FromTask = pilotTaskChild5 });

			var pilotTask = new GanttTask(start.AddDays(-14).AddHours(-5), end, "Pilot")
			{
				Children = { pilotTaskChild1, pilotTaskChild2, pilotTaskChild3, pilotTaskChild4, pilotTaskChild5, pilotTaskChild6 }
			};
			this.Add(pilotTask);

            start = start.AddDays(1);
			end = start.AddDays(1);
			var deploymentTaskChild1 = new GanttTask(start, end, "Determine final deployment strategy");

			start = end;
			end = start.AddDays(1);
			var deploymentTaskChild2 = new GanttTask(start, end, "Develop deployment methodology");

			start = end;
			end = start.AddDays(3);
			var deploymentTaskChild3 = new GanttTask(start, end, "Secure deployment resources");

			start = end;
			end = start.AddDays(1);
			var deploymentTaskChild4 = new GanttTask(start, end, "Train support staff");

			start = end;
			end = start.AddDays(1);
			var deploymentTaskChild5 = new GanttTask(start, end, "Deploy software");

			start = end;
			var deploymentTaskChild6 = new GanttTask(start, end, "Deployment complete");

			deploymentTaskChild2.Dependencies.Add(new Dependency { FromTask = deploymentTaskChild1 });
			deploymentTaskChild3.Dependencies.Add(new Dependency { FromTask = deploymentTaskChild2 });
			deploymentTaskChild4.Dependencies.Add(new Dependency { FromTask = deploymentTaskChild3 });
			deploymentTaskChild5.Dependencies.Add(new Dependency { FromTask = deploymentTaskChild4 });
			deploymentTaskChild6.Dependencies.Add(new Dependency { FromTask = deploymentTaskChild5 });

			var deploymentTask = new GanttTask(end.AddDays(-7), end, "Deployment")
			{
				Children = { deploymentTaskChild1, deploymentTaskChild2, deploymentTaskChild3, deploymentTaskChild4, deploymentTaskChild5, deploymentTaskChild6 }
			};
			this.Add(deploymentTask);

			end = start.AddDays(1);
			var reviewTaskChild1 = new GanttTask(start, end, "Document lessons learned");

			start = end;
			end = start.AddDays(1);
			var reviewTaskChild2 = new GanttTask(start, end, "Distribute to team members");

			start = end;
			end = start.AddDays(1);
			var reviewTaskChild3 = new GanttTask(start, end, "Create software maintenance team");


			var reviewTaskChild4 = new GanttTask(start, end, "Post implementation review complete");

			reviewTaskChild2.Dependencies.Add(new Dependency { FromTask = reviewTaskChild1 });
			reviewTaskChild3.Dependencies.Add(new Dependency { FromTask = reviewTaskChild2 });
			reviewTaskChild4.Dependencies.Add(new Dependency { FromTask = reviewTaskChild3 });

			var reviewTask = new GanttTask(start.AddDays(-2), end, "Post Implementation Review")
			{
				Children = { reviewTaskChild1, reviewTaskChild2, reviewTaskChild3, reviewTaskChild4 }
			};
			this.Add(reviewTask);

			var endTask = new GanttTask(start, end, "Software development template complete");
			this.Add(endTask);

			softwareRequirementsTaskChild1.Dependencies.Add(new Dependency { FromTask = scopeTaskChild5 });
			designTaskChild1.Dependencies.Add(new Dependency { FromTask = softwareRequirementsTaskChild9 });
			developmentTaskChild1.Dependencies.Add(new Dependency { FromTask = designTaskChild7 });
			testingTaskChild1.Dependencies.Add(new Dependency { FromTask = developmentTaskChild6 });
			trainingTaskChild1.Dependencies.Add(new Dependency { FromTask = testingTaskChild4 });
			documentationTaskChild1.Dependencies.Add(new Dependency { FromTask = trainingTaskChild8 });
			endTask.Dependencies.Add(new Dependency { FromTask = reviewTaskChild3 });
		}
	}
}