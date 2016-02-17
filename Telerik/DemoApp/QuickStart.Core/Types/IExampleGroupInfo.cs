using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.QuickStart
{
	public interface IExampleGroupInfo
	{
		IControlInfo Control { get; }
		string Name { get; }
		List<IExampleInfo> Examples { get; }
        List<IExampleInfo> TouchExamples { get; }
        List<IExampleInfo> NonTouchExamples { get; }
	}
}
