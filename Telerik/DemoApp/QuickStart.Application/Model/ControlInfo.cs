using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Telerik.Windows.QuickStart
{
	public class ControlInfo : IControlInfo
	{
		private XElement element;
        private Guid uniqueId;

        private ControlInfo()
        {
            this.uniqueId = Guid.NewGuid();
        }

		public ControlInfo(XElement element)
            :this()
		{
			this.element = element;
			this.Initialize();
		}

		public string Name { get; set; }

		public string Text { get; set; }

		public string ShortDescription { get; set; }

		public string Description { get; set; }

		public Enums.StatusMode Status { get; private set; }

        public Enums.Platform Platform { get; private set; }

		public List<IExampleGroupInfo> ExampleGroups { get; private set; }

		public List<IExampleInfo> Examples { get; private set; }

        public List<IExampleInfo> NonTouchExamples { get; private set; }

        public List<IExampleInfo> TouchExamples { get; private set; }

		public override int GetHashCode()
		{
			return this.uniqueId.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			ControlInfo c = obj as ControlInfo;
			if (c == null)
			{
				return false;
			}
			else
			{
                return object.ReferenceEquals(this, c);
			}
		}

        public IControlInfo Clone()
        {
            var result = new ControlInfo()
            {
                ShortDescription = this.ShortDescription,
                Description = this.Description,
                ExampleGroups = this.ExampleGroups,
                Examples = this.Examples,
                TouchExamples = this.TouchExamples,
                NonTouchExamples = this.NonTouchExamples,
                Name = this.Name,
                Platform = this.Platform,
                Status = this.Status,
                Text = this.Text
            };

            return result;
        }

		private void Initialize()
		{
			if (this.element == null)
			{
				return;
			}

			this.Name = this.element.GetAttribute("name", null);
			var text = this.element.GetAttribute("text", null);
			this.Text = string.IsNullOrEmpty(text) ? this.Name : text;
			this.ShortDescription = this.element.GetAttribute("shortDescription", null);
			this.Description = this.element.GetAttribute("description", null);
			this.Examples = new List<IExampleInfo>();
			this.ExampleGroups = this.LoadExampleGroupsData();

            var platform = this.element.GetAttribute("platform", null);
            this.Platform = string.IsNullOrEmpty(platform) ? Enums.Platform.WPF : (Enums.Platform)Enum.Parse(typeof(Enums.Platform), platform, true);

			this.LoadExamplesData();
            this.TouchExamples = this.Examples.FilterTouchExamples().ToList();
            this.NonTouchExamples = this.Examples.FilterNonTouchExamples().ToList();

            var status = this.element.GetAttribute("status", null);
            this.Status = string.IsNullOrEmpty(status) 
                ? (this.Examples.Any(e => e.Type != Enums.ExampleType.Theming && (e.Status == Enums.StatusMode.New || e.Status == Enums.StatusMode.Updated)) ? Enums.StatusMode.Updated : Enums.StatusMode.Normal) 
                : (Enums.StatusMode)Enum.Parse(typeof(Enums.StatusMode), status, true);
		}

		private void LoadExamplesData()
		{
			this.ExampleGroups.ForEach(g => this.Examples.AddRange(g.Examples));
		}

		private List<IExampleGroupInfo> LoadExampleGroupsData()
		{
			var result = new List<IExampleGroupInfo>();
			var exampleGroups = this.element.Elements("Group");

			if (exampleGroups != null)
			{
				foreach (var item in exampleGroups)
				{
					result.Add(new ExampleGroupInfo(this, item));
				}
			}

            return result.Where(eg => ((ExampleGroupInfo)eg).IsEmpty == false).ToList();
		}
	}
}
