using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Diagrams.Features
{
    public static class SamplesFactory
    {
        public static IEnumerable<SampleItem> GetSamples(RadDiagram diagram = null)
        {
            return new[] 
            {
                new SampleItem
                {
                    Title = "Sample: Simple Diagram",
                    Description = "A basic diagram of geometric shapes.",
                    Icon = FeatureUtilities.GetBitmap(new Uri("/Images/flow.jpg", UriKind.RelativeOrAbsolute), "Telerik.Windows.Diagrams.Features"),
                    Run = SimpleDiagramSample,
                    RunCommand = new DelegateCommand((x) => SimpleDiagramSample(diagram))
                },
                new SampleItem
                {
                    Title = "Sample: Cycle Diagram",
                    Description = "Example of a cycle process aka methodology.",
                    Icon = FeatureUtilities.GetBitmap(new Uri("/Images/circle.jpg", UriKind.RelativeOrAbsolute), "Telerik.Windows.Diagrams.Features"),
                    Run = CycleSample,
                    RunCommand = new DelegateCommand((x) => CycleSample(diagram))
                },
                new SampleItem
                {
                    Title = "Sample: Stakeholders Diagram",
                    Description = "Sample demonstrating a stakeholder diagram.",
                    Icon = FeatureUtilities.GetBitmap(new Uri("/Images/stakeholder.jpg", UriKind.RelativeOrAbsolute), "Telerik.Windows.Diagrams.Features"),
                    Run = StakeholderSample,
                    RunCommand = new DelegateCommand((x) => StakeholderSample(diagram))
                },
                new SampleItem
                {
                    Title = "Sample: Linear Process Diagram",
                    Description = "Linear sequence of dependence.",
                    Icon = FeatureUtilities.GetBitmap(new Uri("/Images/rolls.jpg", UriKind.RelativeOrAbsolute), "Telerik.Windows.Diagrams.Features"),
                    Run = SequenceSample,
                    RunCommand = new DelegateCommand((x) => SequenceSample(diagram))
                },
                new SampleItem
                {
                    Title = "Sample: Floor plan",
                    Description = "Sample which demonstrates the possibility to use RadDiagram to create floor plans.",
                    Icon = FeatureUtilities.GetBitmap(new Uri("/Images/floorplan.jpg", UriKind.RelativeOrAbsolute), "Telerik.Windows.Diagrams.Features"),
                    Run = FloorPlanSample,
                    RunCommand = new DelegateCommand((x) => FloorPlanSample(diagram))
                },
                new SampleItem
                {
                    Title = "Sample: Decision Flowchart",
                    Description = "A typical flowchart using RadDiagram.",
                    Icon = FeatureUtilities.GetBitmap(new Uri("/Images/simpleflow.jpg", UriKind.RelativeOrAbsolute), "Telerik.Windows.Diagrams.Features"),
                    Run = DecisionSample,
                    RunCommand = new DelegateCommand((x) => DecisionSample(diagram))
                }
            };
        }

        public static void StakeholderSample(RadDiagram diagram)
        {
            LoadSample(diagram, "Stakeholder");
        }
		public static void DecisionSample(RadDiagram diagram)
        {
			LoadSample(diagram, "SimpleFlow2");
        }

		public static void FloorPlanSample(RadDiagram diagram)
        {
            LoadSample(diagram, "FloorPlan");
        }

        public static void CycleSample(RadDiagram diagram)
        {
            LoadSample(diagram, "Cycle3");
        }

        public static void SequenceSample(RadDiagram diagram)
        {
            LoadSample(diagram, "Rolls");
        }

        public static void SimpleDiagramSample(RadDiagram diagram)
        {
            LoadSample(diagram, "Flow2");
        }

        private static void LoadSample(RadDiagram diagram, string name)
        {
            diagram.Clear();
            using (var stream = FeatureUtilities.GetStream(string.Format("/SampleDiagrams/{0}.xml", name)))
            {
                using (var reader = new StreamReader(stream))
                {
                    var xml = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(xml))
                    {
                        diagram.Load(xml);
                    }
                }
            }
        }
    }
}