#if WPF
using System.Windows.Input;
#endif
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Controls.Diagrams.Primitives;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.Controls.Diagrams.Extensions;
using Telerik.Windows.DragDrop;
using System.Windows.Controls;
using Telerik.Windows.Examples.Diagrams.Common;

namespace Telerik.Windows.Examples.Diagrams.Swimlane
{
    public partial class Example : UserControl
    {
        private FileManager fileManager;

        static Example()
        {
            var saveBinding = new CommandBinding(DiagramCommands.Save, ExecuteSave, CanExecutedSave);
            var openBinding = new CommandBinding(DiagramCommands.Open, ExecuteOpen);

            CommandManager.RegisterClassCommandBinding(typeof(Example), saveBinding);
            CommandManager.RegisterClassCommandBinding(typeof(Example), openBinding);
        }

        public Example()
        {
            DiagramConstants.ContainerMargin = 0;

            InitializeComponent();

            this.fileManager = new FileManager(this.diagram);
            this.diagram.ServiceLocator.Register<IResizingService>(new CustomResizingService(this.diagram));
            this.PopulateToolbox();
            var newRouter = new AStarRouter(this.diagram) { WallOptimization = true };
            this.diagram.RoutingService.Router = newRouter;
            this.diagram.RoutingService.FreeRouter = newRouter;
            this.Loaded += this.OnLoaded;
        }

        private void PopulateToolbox()
        {
            var itemsSource = new HierarchicalGalleryItemsCollection();
            var containerGallerty = itemsSource.LastOrDefault();
            if (containerGallerty != null)
            {
                containerGallerty.Items.Add(new GalleryItem("Horizontal Main Shape", new HorizontalMainContainerShape()));
                containerGallerty.Items.Add(new GalleryItem("Vertical Main Shape", new VerticalMainContainerShape()));
                containerGallerty.Items.Add(new GalleryItem("Horizontal Swimlane", new HorizontalSwimlaneShape()));
                containerGallerty.Items.Add(new GalleryItem("Vertical Swimlane", new VerticalSwimlaneShape()));
            }
            this.toolBox.ItemsSource = itemsSource;
        }

        private void OnDiagramConnectionManipulationCompleted(object sender, Telerik.Windows.Controls.Diagrams.ManipulationRoutedEventArgs e)
        {
            e.Handled = e.Shape == null;
        }

        private static void CanExecutedSave(object sender, CanExecuteRoutedEventArgs e)
        {
            var owner = sender as Example;
            e.CanExecute = owner != null && owner.diagram != null && owner.diagram.Items.Count > 0;
        }

        private static void ExecuteSave(object sender, ExecutedRoutedEventArgs e)
        {
            var owner = sender as Example;
            if (owner != null)
                owner.fileManager.SaveToFile();
        }

        private static void ExecuteOpen(object sender, ExecutedRoutedEventArgs e)
        {
            var owner = sender as Example;
            if (owner != null)
            {
                owner.ClearDiagram();
                owner.fileManager.LoadFromFile();
            }
        }

        private void OnNewClick(object sender, RoutedEventArgs e)
        {
            this.RefreshDiagram();
        }

        private void LoadDefaultContainer()
        {
            SamplesFactory.LoadSample(this.diagram, "SwimlaneDiagram");
        }

        private void ClearDiagram()
        {
            this.diagram.UndoRedoService.Clear();
            this.diagram.Items.Clear();
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            this.RefreshDiagram();
        }

        private void RefreshDiagram()
        {
            this.ClearDiagram();
            this.LoadDefaultContainer();
        }
    }
}
