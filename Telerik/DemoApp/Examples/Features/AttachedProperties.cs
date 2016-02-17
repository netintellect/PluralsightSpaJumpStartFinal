using System;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;

namespace Telerik.Windows.Diagrams.Features
{
	public class AttachedProperties
	{
		public static readonly DependencyProperty ShouldDetachConnectionsProperty =
			DependencyProperty.RegisterAttached("ShouldDetachConnections", typeof(bool), typeof(AttachedProperties), new PropertyMetadata(false, OnShouldDetachConnectionsPropertyChanged));

		public static readonly DependencyProperty PendingCommandProperty =
			DependencyProperty.RegisterAttached("PendingCommand", typeof(ICommand), typeof(AttachedProperties), new PropertyMetadata(null));

		/// <summary>
		/// Gets the pending command.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <returns></returns>
		public static ICommand GetPendingCommand(DependencyObject obj)
		{
			return (ICommand)obj.GetValue(PendingCommandProperty);
		}

		/// <summary>
		/// Sets the pending command.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="value">The value.</param>
		public static void SetPendingCommand(DependencyObject obj, ICommand value)
		{
			obj.SetValue(PendingCommandProperty, value);
		}

		/// <summary>
		/// Gets the should detach connections.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <returns></returns>
		public static bool GetShouldDetachConnections(DependencyObject obj)
		{
			return (bool)obj.GetValue(ShouldDetachConnectionsProperty);
		}

		/// <summary>
		/// Sets the should detach connections.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <param name="value">The value.</param>
		public static void SetShouldDetachConnections(DependencyObject obj, bool value)
		{
			obj.SetValue(ShouldDetachConnectionsProperty, value);
		}

		private static void OnShouldDetachConnectionsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var diagram = d as RadDiagram;

			if (diagram != null)
			{
				if ((bool)e.NewValue)
				{
					diagram.PreviewDrag += OnPreviewDrag;
					diagram.PreviewRotate += OnPreviewRotate;
					diagram.CommandExecuted += OnCommandExecuted;
				}
				else
				{
					diagram.PreviewDrag -= OnPreviewDrag;
					diagram.PreviewRotate -= OnPreviewRotate;
					diagram.CommandExecuted -= OnCommandExecuted;
				}
			}
		}

		private static void OnCommandExecuted(object sender, Controls.Diagrams.CommandRoutedEventArgs e)
		{
			var diagram = sender as RadDiagram;
			var lastCompositeCommand = diagram.UndoRedoService.UndoStack.LastOrDefault(x => x.Name == CommandNames.RotateItems || x.Name == CommandNames.MoveItems) as CompositeCommand;
			var pendingCommand = AttachedProperties.GetPendingCommand(diagram);
			if (lastCompositeCommand != null && pendingCommand != null)
			{
				lastCompositeCommand.AddCommand(pendingCommand);
				AttachedProperties.SetPendingCommand(diagram, null);
			}
		}

		private static void OnPreviewRotate(object sender, RoutedEventArgs e)
		{
			DetachConnections(sender as RadDiagram);
		}

		private static void OnPreviewDrag(object sender, Controls.Diagrams.DragRoutedEventArgs e)
		{
			DetachConnections(sender as RadDiagram);
		}

		private static void DetachConnections(RadDiagram diagram)
		{
			if (diagram.SelectedItems.Count() > 1)
			{
				CompositeCommand changeSourcesCompositeCommand = new CompositeCommand("Detach ends");
				foreach (var connection in diagram.SelectedItems.OfType<IConnection>())
				{
					if (!diagram.SelectedItems.Contains(connection.Source))
					{
						changeSourcesCompositeCommand.AddCommand(new ChangeSourceCommand(connection, null, connection.StartPoint));
					}

					if (!diagram.SelectedItems.Contains(connection.Target))
					{
						changeSourcesCompositeCommand.AddCommand(new ChangeTargetCommand(connection, null, connection.EndPoint));
					}
				}
				changeSourcesCompositeCommand.Execute();
				AttachedProperties.SetPendingCommand(diagram, changeSourcesCompositeCommand);
			}
		}
	}
}
