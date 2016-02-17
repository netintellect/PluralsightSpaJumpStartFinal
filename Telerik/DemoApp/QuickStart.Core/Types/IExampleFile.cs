using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.QuickStart
{
	public interface IExampleFile
	{
		Uri ExampleUri { get; }
		string DisplayName { get; }
	}
}
