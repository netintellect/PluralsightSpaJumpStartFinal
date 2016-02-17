using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.DragDrop.Behaviors;
using System.Collections;

namespace Telerik.Windows.Examples.DragAndDrop.DragOverTab
{
	public class CustomListBoxDragDropBehavior : ListBoxDragDropBehavior
	{
		private static IList lastSource = null;

		public override void Drop(DragDropState state)
		{
			base.Drop(state);
			lastSource = state.DestinationItemsSource;
		}

		public override void DragDropCompleted(DragDropState state)
		{
			if (lastSource != null)
			{
				base.DragDropCompleted(state);

				lastSource = null;
			}
		}
	}
}
