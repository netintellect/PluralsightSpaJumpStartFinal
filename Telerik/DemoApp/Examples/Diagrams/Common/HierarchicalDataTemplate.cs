﻿using System;
using System.Linq;

namespace Telerik.Windows.Examples.Diagrams.Common
{
#if WPF
	public class HierarchicalDataTemplate : System.Windows.HierarchicalDataTemplate
	{
	}
#else
	public class HierarchicalDataTemplate : Telerik.Windows.Controls.HierarchicalDataTemplate
	{
	}
#endif
}
