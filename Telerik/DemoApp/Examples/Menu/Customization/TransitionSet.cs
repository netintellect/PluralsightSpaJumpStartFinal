using System;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.TransitionControl;

namespace Telerik.Windows.Examples.Menu.Customization
{
	public class TransitionSet : TransitionProvider
	{
		public TransitionProvider BackTransition { get; set; }
		public TransitionProvider ForwardTransition { get; set; }

		public override Transition CreateTransition(TransitionContext context)
		{
			PopularControl oldPage = context.OldContent as PopularControl;
			PopularControl newPage = context.CurrentContent as PopularControl;

			if (oldPage.DisplayPage > newPage.DisplayPage)
			{
				return this.BackTransition.CreateTransition(context);
			}
			else
			{
				return this.ForwardTransition.CreateTransition(context);
			}
		}
	}
}
