﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class SamplesFactory
    {
        /// <summary>
        /// Gets the samples.
        /// </summary>
        /// <param name="diagram">The diagram.</param>
        /// <returns></returns>
        public static IEnumerable<SampleItem> GetSamples(RadDiagram diagram = null)
        {
            return new[] 
			{
				new SampleItem
				{
					Title = "Simple Diagram",
					Description = "A basic diagram of geometric shapes.",
					Icon = "../Images/Diagrams/FirstLook/flow.jpg",
					Run = SimpleDiagramSample
				},
				new SampleItem
				{
					Title = "Cycle Diagram",
					Description = "Example of a cycle process aka methodology.",
					Icon = "../Images/Diagrams/FirstLook/circle.jpg",
					Run = CycleSample
				},
				new SampleItem
				{
					Title = "Bezier Diagram",
					Description = "Sample demonstrating a stakeholder diagram.",
					Icon = "../Images/Diagrams/FirstLook/bezier.jpg",
					Run = BezierSample
				},
				new SampleItem
				{
					Title = "Linear Process Diagram",
					Description = "Linear sequence of dependence.",
					Icon = "../Images/Diagrams/FirstLook/rolls.jpg",
					Run = SequenceSample
				},
				new SampleItem
				{
					Title = "Floor plan",
					Description = "Sample which demonstrates the possibility to use RadDiagram to create floor plans.",
					Icon = "../Images/Diagrams/FirstLook/floorplan.jpg",
					Run = FloorPlanSample
				},
				new SampleItem
				{
					Title = "Decision Flowchart",
					Description = "A typical flowchart using RadDiagram.",
					Icon = "../Images/Diagrams/FirstLook/simpleflow.jpg",
					Run = SimpleFlowSample
				}
			};
        }

        /// <summary>
        /// Loads the stakeholders sample.
        /// </summary>
        /// <param name="diagram">The diagram.</param>
        public static void StakeholderSample(RadDiagram diagram)
        {
            LoadSample(diagram, "Stakeholder");
        }

        /// <summary>
        /// Loads the decision sample.
        /// </summary>
        /// <param name="diagram">The diagram.</param>
        public static void SimpleFlowSample(RadDiagram diagram)
        {
            LoadSample(diagram, "SimpleFlow");
        }

        /// <summary>
        /// Loads the floor plan sample.
        /// </summary>
        /// <param name="diagram">The diagram.</param>
        public static void FloorPlanSample(RadDiagram diagram)
        {
            LoadSample(diagram, "FloorPlan");
        }

        /// <summary>
        /// Loads the cycle sample.
        /// </summary>
        /// <param name="diagram">The diagram.</param>
        public static void CycleSample(RadDiagram diagram)
        {
            LoadSample(diagram, "Cycle3");
        }

        /// <summary>
        /// Loads the cycle sample.
        /// </summary>
        /// <param name="diagram">The diagram.</param>
        public static void BezierSample(RadDiagram diagram)
        {
            LoadSample(diagram, "Supply");
        }

        /// <summary>
        /// Loads the sequence sample.
        /// </summary>
        /// <param name="diagram">The diagram.</param>
        public static void SequenceSample(RadDiagram diagram)
        {
            LoadSample(diagram, "Rolls");
        }

        /// <summary>
        /// Loads the simple diagram sample.
        /// </summary>
        /// <param name="diagram">The diagram.</param>
        public static void SimpleDiagramSample(RadDiagram diagram)
        {
            LoadSample(diagram, "Flow2");
        }

        public static void LoadSample(RadDiagram diagram, string name)
        {
            if (diagram.GraphSource == null)
                diagram.Clear();
            using (var stream = ExtensionUtilities.GetStream(string.Format("/Common/SampleDiagrams/{0}.xml", name)))
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
#if WPF
			diagram.Dispatcher.BeginInvoke(new Action(() => diagram.AutoFit()), System.Windows.Threading.DispatcherPriority.ApplicationIdle);
#else
            diagram.Dispatcher.BeginInvoke(new Action(() => diagram.AutoFit()));
#endif
        }
    }
}