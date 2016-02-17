using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Telerik.Windows.QuickStart;

namespace Telerik.Windows.QuickStart
{
	public class ExampleGroupInfo : IExampleGroupInfo
	{
		private XElement element;

		public ExampleGroupInfo(ControlInfo control, XElement element)
		{
			this.element = element;
			this.Control = control;
			this.Initialize();
		}

		public IControlInfo Control { get; private set; }

		public string Name { get; set; }

        /// <summary>
        /// Contains all examples for this example group, including desktop and touch mode ones. TouchExamples and NonTouchExamples are a subset of this collection.
        /// </summary>
		public List<IExampleInfo> Examples { get; private set; }

        /// <summary>
        /// Contains all examples that should be displayed in touch mode. This is a subset of the Examples collection property.
        /// </summary>
        public List<IExampleInfo> TouchExamples { get; private set; }

        /// <summary>
        /// Contains all examples that should be displayed in non-touch (desktop) mode. This is a subset of the Examples collection property.
        /// </summary>
        public List<IExampleInfo> NonTouchExamples { get; private set; }

        public bool IsEmpty
        {
            get
            {
                return this.Examples == null || this.Examples.Count == 0;
            }
        }

		public override int GetHashCode()
		{
			return this.Control.GetHashCode() * 233 + (this.Name == null ? 0 : this.Name.GetHashCode());
		}

		public override bool Equals(object obj)
		{
			ExampleGroupInfo egi = obj as ExampleGroupInfo;
			if (egi == null)
			{
				return false;
			}
			else
			{
				return object.Equals(this.Control, egi.Control) && object.Equals(this.Name, egi.Name);
			}
		}

		private void Initialize()
		{
			if (this.element == null)
			{
				return;
			}

			this.Name = element.GetAttribute("name", null);
			this.Examples = new List<IExampleInfo>();
			this.LoadExamplesData();
            this.TouchExamples = this.Examples.FilterTouchExamples().ToList();
            this.NonTouchExamples = this.Examples.FilterNonTouchExamples().ToList();
		}

		private void LoadExamplesData()
		{
			foreach (var item in element.Elements("Example"))
			{
                var newExample = new ExampleInfo(this, item);
                
                if (newExample.Platform == Enums.Platform.WPF)
                {
                    this.Examples.Add(newExample);
                }
			}
		}
	}
}
