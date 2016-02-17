using System;
using Telerik.Windows.Documents.Model;

namespace Telerik.Windows.Examples.RichTextBox.StructuredContentEditing
{
    public class RecipeRangeEnd : AnnotationRangeEnd
    {
        #region Properties

        public override bool SkipPositionBefore
        {
            get { return false; }
        }

        #endregion

        #region Methods

        protected override AnnotationRangeStart CreateRangeStartInstance()
        {
            return new RecipeRangeStart();
        }

        protected override DocumentElement CreateNewElementInstance()
        {
            return new RecipeRangeEnd();
        }

        protected override void CopyContentFromOverride(DocumentElement fromElement)
        {
        }

        #endregion
    }
}
