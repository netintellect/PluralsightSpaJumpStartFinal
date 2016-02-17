using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Controls.Diagrams.Extensions;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.Examples.Diagrams.Swimlane.Base;

namespace Telerik.Windows.Examples.Diagrams.Swimlane
{
    public class AdditionalContent : Control
    {
        public static readonly DependencyProperty ContextItemProperty =
           DependencyProperty.Register("ContextItem", typeof(object), typeof(AdditionalContent), new PropertyMetadata(null, OnContextItemPropertyChanged));

        public static readonly DependencyProperty DiagramProperty =
          DependencyProperty.Register("Diagram", typeof(RadDiagram), typeof(AdditionalContent), new PropertyMetadata(null));

        protected SettingsPane settingsPane;
        protected FrameworkElement addRemove;

        public RadDiagram Diagram
        {
            get { return (RadDiagram)GetValue(DiagramProperty); }
            set { SetValue(DiagramProperty, value); }
        }

        public object ContextItem
        {
            get { return (object)GetValue(ContextItemProperty); }
            set { SetValue(ContextItemProperty, value); }
        }

        static AdditionalContent()
        {
            CommandManager.RegisterClassCommandBinding(typeof(AdditionalContent), new CommandBinding(SwimlaneCommands.AddCommand, OnAddCommand));
            CommandManager.RegisterClassCommandBinding(typeof(AdditionalContent), new CommandBinding(SwimlaneCommands.RemoveCommand, OnRemoveCommand, OnCanExecuteRemove));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.settingsPane = this.GetTemplateChild("settingsPane") as SettingsPane;
            this.addRemove = this.GetTemplateChild("addRemoveButtons") as FrameworkElement;

            if (this.ContextItem != null)
                this.OnContextItemChanged(this.ContextItem, null);
        }

        protected virtual void OnRemove()
        {
            var container = this.ContextItem as MainContainerShapeBase;
            if (container != null && container.OrderedChildren.Count > 0)
            {
                var itemToRemove = container.OrderedChildren.LastOrDefault();
                this.RemoveContainer(container, itemToRemove as RadDiagramShapeBase);
            }
        }

        protected virtual void OnAdd()
        {
            var container = this.ContextItem as MainContainerShapeBase;
            if (container != null)
            {
                if (container.ChildrenPositioning == System.Windows.Controls.Orientation.Vertical)
                    this.AddContainer(container, new HorizontalSwimlaneShape() { ContainerPosition = container.Items.Count });
                else
                    this.AddContainer(container, new VerticalSwimlaneShape() { ContainerPosition = container.Items.Count });
            }
        }

        protected virtual void OnContextItemChanged(object newValue, object oldValue)
        {
            if (this.addRemove == null || this.settingsPane == null) return;

            if (newValue == null)
            {
                this.settingsPane.Visibility = Visibility.Collapsed;
                this.addRemove.Visibility = Visibility.Collapsed;
                this.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.Visibility = Visibility.Visible;
                if (newValue is MainContainerShapeBase)
                    this.addRemove.Visibility = Visibility.Visible;
                else
                    this.addRemove.Visibility = Visibility.Collapsed;
                this.settingsPane.Visibility = Visibility.Visible;
            }
        }

        protected virtual void OnCanRemove(CanExecuteRoutedEventArgs e)
        {
            var container = this.ContextItem as MainContainerShapeBase;
            if (container != null && container.OrderedChildren != null && container.OrderedChildren.Count > 0)
            {
                e.CanExecute = true;
            }
        }

        private static void OnCanExecuteRemove(object sender, CanExecuteRoutedEventArgs e)
        {
            var addCont = sender as AdditionalContent;
            if (addCont != null && addCont.Diagram != null)
            {
                addCont.OnCanRemove(e);
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private static void OnRemoveCommand(object sender, ExecutedRoutedEventArgs e)
        {
            var addCont = sender as AdditionalContent;
            if (addCont != null && addCont.Diagram != null)
            {
                addCont.OnRemove();
            }
        }

        private static void OnAddCommand(object sender, ExecutedRoutedEventArgs e)
        {
            var addCont = sender as AdditionalContent;
            if (addCont != null && addCont.Diagram != null)
            {
                addCont.OnAdd();
            }
        }

        private static void OnContextItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var additionalContent = d as AdditionalContent;
            if (additionalContent != null)
            {
                additionalContent.OnContextItemChanged(e.NewValue, e.OldValue);
            }
        }

        private void AddContainer(MainContainerShapeBase container, IShape itemToAdd)
        {
            if (container == null || itemToAdd == null) return;
            CompositeCommand command = new CompositeCommand("Add new container");
            if (container.IsCollapsed)
            {
                command.AddCommand(new UndoableDelegateCommand("Update container",
                   new Action<object>((o) =>
                   {
                       container.IsCollapsed = false;
                   }),
                   new Action<object>((o) =>
                   {
                       container.IsCollapsed = true;
                   })));
            }
            command.AddCommand(new UndoableDelegateCommand("Add Container",
                  new Action<object>((o) =>
                  {
                      container.Items.Add(itemToAdd);
                      container.IsCollapsed = false;
                  }),
                  new Action<object>((o) =>
                  {
                      this.Diagram.RemoveShape(itemToAdd);
                      container.IsCollapsed = false;
                  })));

            this.Diagram.UndoRedoService.ExecuteCommand(command);
        }

        private void RemoveContainer(MainContainerShapeBase container, RadDiagramShapeBase itemToRemove)
        {
            if (container == null || itemToRemove == null) return;

            CompositeCommand command = new CompositeCommand("Remove horizontal container");
            if (container.IsCollapsed)
            {
                command.AddCommand(new UndoableDelegateCommand("Update container",
                   new Action<object>((o) =>
                   {
                       container.IsCollapsed = false;
                   }),
                   new Action<object>((o) =>
                   {
                       container.IsCollapsed = true;
                   })));
            }
            command.AddCommand(this.CreateRemoveShapeCommand(itemToRemove));
            if (container.IsCollapsed)
            {
                command.AddCommand(new UndoableDelegateCommand("Update container",
                   new Action<object>((o) =>
                   {
                   }),
                   new Action<object>((o) =>
                   {
                   })));
            }

            this.Diagram.UndoRedoService.ExecuteCommand(command);
        }

        private CompositeCommand CreateRemoveShapeCommand(RadDiagramShapeBase shape)
        {
            if (shape == null) return null;
            var compositeRemoveShapeCommand = new CompositeCommand(CommandNames.RemoveShapes);
            var removeCommand = new UndoableDelegateCommand(CommandNames.RemoveShape, s => this.Diagram.RemoveShape(shape), s => this.Diagram.AddShape(shape));

            var parentContainer = shape.ParentContainer;
            if (parentContainer != null)
            {
                var execute = new Action<object>((o) => parentContainer.RemoveItem(shape));
                var undo = new Action<object>((o) =>
                {
                    if (!parentContainer.Items.Contains(shape))
                        parentContainer.AddItem(shape);
                });
                compositeRemoveShapeCommand.AddCommand(new UndoableDelegateCommand(CommandNames.RemoveItemFromContainer, execute, undo));
            }

            foreach (var changeSourceCommand in shape.OutgoingLinks.Union(shape.IncomingLinks).ToList().Select(connection => this.CreateRemoveConnectionCommand(connection)))
            {
                compositeRemoveShapeCommand.AddCommand(changeSourceCommand);
            }

            compositeRemoveShapeCommand.AddCommand(removeCommand);

            var container = shape as RadDiagramContainerShape;
            if (container != null)
            {
                for (int i = container.Items.Count - 1; i >= 0; i--)
                {
                    var shapeToRemove = container.Items[i] as RadDiagramShapeBase;
                    if (shapeToRemove != null)
                        compositeRemoveShapeCommand.AddCommand(this.CreateRemoveShapeCommand(shapeToRemove));
                    else
                    {
                        var connection = container.Items[i] as IConnection;
                        if (connection != null && connection.Source == null && connection.Target == null)
                            compositeRemoveShapeCommand.AddCommand(this.CreateRemoveConnectionCommand(container.Items[i] as IConnection));
                    }
                }
            }

            return compositeRemoveShapeCommand;
        }

        private UndoableDelegateCommand CreateRemoveConnectionCommand(IConnection connection)
        {
            var compositeRemoveConnectionCommand = new CompositeCommand(CommandNames.RemoveConnections);

            UndoableDelegateCommand removeCommand = new UndoableDelegateCommand(CommandNames.RemoveConnection, s => this.Diagram.RemoveConnection(connection), s => this.Diagram.AddConnection(connection));

            compositeRemoveConnectionCommand.AddCommand(removeCommand);

            return compositeRemoveConnectionCommand;
        }
    }
}
