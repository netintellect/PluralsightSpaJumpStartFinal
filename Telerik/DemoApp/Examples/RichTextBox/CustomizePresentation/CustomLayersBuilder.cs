using Telerik.Windows.Documents.UI;
using Telerik.Windows.Documents.UI.Extensibility;
using Telerik.Windows.Documents.UI.Layers;

namespace Telerik.Windows.Examples.RichTextBox.CustomizePresentation
{
    [CustomUILayersBuilder]
    public class CustomLayersBuilder : UILayersBuilder
    {
        public bool HighlightCurrentWordLayer { get; set; }
        public bool HighlightCurrentLineLayer { get; set; }

        protected override void BuildUILayersOverride(IUILayerContainer uiLayerContainer)
        {
            if (this.HighlightCurrentWordLayer)
            {
                uiLayerContainer.UILayers.AddAfter(DefaultUILayers.HighlightDecoration, new HighlightCurrentWordLayer());
            }

            if (this.HighlightCurrentLineLayer)
            {
                uiLayerContainer.UILayers.AddAfter(DefaultUILayers.HighlightDecoration, new HighlightCurrentLineLayer());
            }
        }
    }
}
