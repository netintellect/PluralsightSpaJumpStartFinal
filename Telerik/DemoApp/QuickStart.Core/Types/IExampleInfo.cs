using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Telerik.Windows.QuickStart
{
    public interface IExampleInfo : IStatusInfo, IPlatformInfo
    {
		IExampleGroupInfo ExampleGroup { get; }
		string Text { get; }
		string Name { get; }
		string Keywords { get; }
		bool IsDefault { get; }
		string PackageName { get; }
		string Description { get; set; }
		ObservableCollection<IExampleFile> Resources { get; }
		List<string> CommonFolders { get; }
		Enums.ExampleType Type { get; }
        Enums.Mode Mode { get; }
    }
}
