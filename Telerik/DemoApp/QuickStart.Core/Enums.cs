using System;
using System.Linq;

namespace Telerik.Windows.QuickStart
{
	public static class Enums
	{
		public enum ViewMode
		{
			Example,
			Code
		}

		public enum StatusMode
		{
			Normal,
			New,
			Beta,
			Ctp,
			Updated,
			Obsolete
		}

		public enum ExampleType
		{
			Normal,
			Theming
		}

        public enum Platform
        {
            WPF,
            Silverlight
        }

        public enum Mode
        {
            Desktop,
            Touch,
            Both
        }

		public enum OfficialReleaseVersion
		{
			Q1,
			Q2,
			Q3
		}

		public enum ServicePackVersion
		{
			None,
			SP1,
			SP2,
			SP3
		}
	}
}
