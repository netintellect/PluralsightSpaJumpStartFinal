using System;
using System.Xml.Linq;

namespace Telerik.Windows.QuickStart
{
	public class ReleaseVersionInfo
	{
		private XElement element;

		public ReleaseVersionInfo(XElement element)
		{
			this.element = element;
			this.Initialize();
		}

		public Enums.OfficialReleaseVersion OfficialRelease { get; set; }
        public Enums.ServicePackVersion ServicePack { get; set; }
		public int Year { get; set; }

		private void Initialize()
		{
			this.OfficialRelease = (Enums.OfficialReleaseVersion)Enum.Parse(typeof(Enums.OfficialReleaseVersion), this.element.GetAttribute("official", string.Empty), true);
			this.ServicePack = (Enums.ServicePackVersion)Enum.Parse(typeof(Enums.ServicePackVersion), this.element.GetAttribute("servicePack", string.Empty), true);
			this.Year = int.Parse(this.element.GetAttribute("year", string.Empty));
		}

		public override string ToString()
		{
			var version = string.Format("{0} {1} {2}",
				this.OfficialRelease,
				this.Year,
                this.ServicePack == Enums.ServicePackVersion.None ? string.Empty : this.ServicePack.ToString());

			return version.TrimEnd();
		}
	}
}
