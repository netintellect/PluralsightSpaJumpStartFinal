using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.QuickStart
{
    public class ExampleFile : IExampleFile
    {
        private IControlInfo control;
        private string relativePath;

        public ExampleFile(IControlInfo control, string relativePath)
        {
            this.control = control;
            this.relativePath = relativePath;
            this.Initialize();
        }

        public Uri ExampleUri { get; private set; }

        public string DisplayName { get; private set; }

        public string AssemblyResourcePath { get; private set; }

        private void Initialize()
        {
            if (this.relativePath != null && !string.IsNullOrEmpty(this.relativePath))
            {
                this.ExampleUri = new Uri(string.Format("/{0};component/{1}", this.control.Name, this.relativePath), UriKind.Relative);
                this.DisplayName = this.relativePath.Split('/').Last();
                this.AssemblyResourcePath = this.relativePath.Split('/').Last().Replace("\\", "/");
            }
        }
    }
}