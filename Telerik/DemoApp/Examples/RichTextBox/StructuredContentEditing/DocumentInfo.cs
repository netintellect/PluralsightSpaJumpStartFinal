using System;
using System.Windows;

namespace Telerik.Windows.Examples.RichTextBox.StructuredContentEditing
{
    public class DocumentInfo : DependencyObject
    {
        #region Properties

        public string Name { get; set; }
        public string Path { get; set; }
        public Uri Uri { get; set; }
        public string ImagePath { get; set; }

        #endregion

        #region Constructors

        public DocumentInfo(string name, Uri uri, string path, string imagePath)
        {
            this.Name = name;
            this.Uri = uri;
            this.Path = path;
            this.ImagePath = imagePath;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return this.Name;
        }

        #endregion
    }
}
