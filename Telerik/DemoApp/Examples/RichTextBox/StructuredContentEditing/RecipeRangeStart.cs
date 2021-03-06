﻿using System;
using Telerik.Windows.Documents.Model;

namespace Telerik.Windows.Examples.RichTextBox.StructuredContentEditing
{
    public class RecipeRangeStart : AnnotationRangeStart
    {
        #region Properties

        [XamlSerializable]
        public string Name { get; set; }

        public RecipeRangeStart(string name)
        {
            this.Name = name;
        }

        public override bool SkipPositionBefore
        {
            get { return true; }
        }

        #endregion

        #region constructors

        public RecipeRangeStart()
        {
        }

        #endregion

        #region Methods

        protected override void CopyContentFromOverride(DocumentElement fromElement)
        {
            this.Name = ((RecipeRangeStart)fromElement).Name;
        }

        protected override DocumentElement CreateNewElementInstance()
        {
            return new RecipeRangeStart();
        }

        #endregion
    }
}
