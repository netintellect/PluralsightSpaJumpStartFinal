using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.QuickStart
{
	public class ExampleInfo : ViewModelBase, IExampleInfo
	{
		private XElement element;
		private string description;
        private ObservableCollection<IExampleFile> resources;

        public ExampleInfo(ExampleGroupInfo exampleGroup, XElement element)
        {
			this.ExampleGroup = exampleGroup;
			this.element = element;
			this.Initialize();
		}

		public IExampleGroupInfo ExampleGroup { get; private set; }

		public string Text { get; private set; }

		public string Name { get; private set; }

		public Enums.StatusMode Status { get; private set; }

		public bool IsDefault { get; private set; }

		public string PackageName { get; private set; }

		public string Keywords { get; private set; }

        public Enums.ExampleType Type { get; private set; }

        public Enums.Platform Platform { get; private set; }

        public Enums.Mode Mode { get; set; }

        public string Description
        {
			get
			{
				return this.description;
			}
			set
			{
				if (this.description != value)
				{
					this.description = value;
					this.OnPropertyChanged("Description");
				}
			}
		}

		public List<string> CommonFolders { get; private set; }

        public ObservableCollection<IExampleFile> Resources
        {
            get
            {
                return this.resources;
            }
            private set
            {
                if (this.resources != value)
                {
                    this.resources = value;
                    this.OnPropertyChanged("Resources");
                }
            }
        }

		public override int GetHashCode()
		{
			return this.Name == null ? 0 : this.Name.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			ExampleInfo e = obj as ExampleInfo;
			if (e == null)
			{
				return false;
			}
			else
			{
				return this.Name == e.Name && this.ExampleGroup.Name == e.ExampleGroup.Name && this.ExampleGroup.Control == e.ExampleGroup.Control;
			}
		}

        public override string ToString()
        {
            return this.Name;
        }

		private void Initialize()
		{
			if (this.element == null)
			{
				return;
			}

			var status = this.element.GetAttribute("status", null);
			this.Status = string.IsNullOrEmpty(status) ? Enums.StatusMode.Normal : (Enums.StatusMode)Enum.Parse(typeof(Enums.StatusMode), status, true);
			this.Text = this.element.GetAttribute("text", null);
			this.Name = this.element.GetAttribute("name", null);
			this.IsDefault = this.element.GetAttribute("isDefault", false);
			var type = this.element.GetAttribute("type", null);
			this.Type = string.IsNullOrEmpty(type) ? Enums.ExampleType.Normal : (Enums.ExampleType)Enum.Parse(typeof(Enums.ExampleType), type, true);
			this.PackageName = this.element.GetAttribute("packageName", null);
			this.Keywords = this.element.GetAttribute("keywords", null);
			this.CommonFolders = new List<string>(this.element.GetAttribute("commonFolders", null).Split(';'));
			this.Resources = new ObservableCollection<IExampleFile>();

            var mode = this.element.GetAttribute("mode", null);
            this.Mode = string.IsNullOrEmpty(mode) ? Enums.Mode.Desktop : (Enums.Mode)Enum.Parse(typeof(Enums.Mode), mode, true);
            
            var platform = this.element.GetAttribute("platform", null);
            this.Platform = string.IsNullOrEmpty(platform) ? Enums.Platform.WPF : (Enums.Platform)Enum.Parse(typeof(Enums.Platform), platform, true);
		}
	}
}
