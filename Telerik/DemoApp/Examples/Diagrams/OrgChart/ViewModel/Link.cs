using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;

namespace Telerik.Windows.Examples.Diagrams.OrgChart
{
	public class Link : LinkViewModelBase<OrgTeamViewModel>
	{
		public Link(OrgTeamViewModel source, OrgTeamViewModel target)
			: base(source, target)
		{
		}
	}
}