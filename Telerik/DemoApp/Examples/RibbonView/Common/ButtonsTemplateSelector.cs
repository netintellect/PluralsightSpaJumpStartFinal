using System.Windows;
using Telerik.Windows.Examples.RibbonView.MVVM.ViewModels;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.RibbonView.MVVM
{
	public class ButtonsTemplateSelector : DataTemplateSelector
	{
		public DataTemplate Button { get; set; }
		public DataTemplate SplitButton { get; set; }
		public DataTemplate ButtonsGroup { get; set; }
		public DataTemplate SmallButtonGroup { get; set; }

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (item is SplitButtonViewModel)
			{
				return SplitButton;
			}
			else if (item is ButtonGroupViewModel)
			{
				return ((ButtonGroupViewModel)item).IsSmallGroup ? SmallButtonGroup : ButtonsGroup;
			}
			else
			{
				return Button;
			}
		}
	}
}
