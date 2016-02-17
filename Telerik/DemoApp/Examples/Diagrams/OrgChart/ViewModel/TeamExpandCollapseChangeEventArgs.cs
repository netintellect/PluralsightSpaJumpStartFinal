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

namespace Telerik.Windows.Examples.Diagrams.OrgChart.ViewModel
{
    public class TeamExpandCollapseChangeEventArgs : EventArgs
    {
        public OrgTeamViewModel Team { get; private set; }

        public TeamExpandCollapseChangeEventArgs(OrgTeamViewModel node)
        {
            this.Team = node;
		}
	}
}