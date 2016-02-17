using System;
using System.Collections.Generic;
using System.Linq;

namespace Telerik.Windows.QuickStart
{
	public interface IControlInfo : IStatusInfo, IPlatformInfo
	{

        string Name { get; }

        List<IExampleGroupInfo> ExampleGroups { get; }

        List<IExampleInfo> Examples { get; }
        List<IExampleInfo> NonTouchExamples { get; }
        List<IExampleInfo> TouchExamples { get; }

        IControlInfo Clone();
	}
}
