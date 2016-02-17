using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;

namespace Telerik.Windows.Examples.Diagrams.ClassDiagram
{
    public class ClassLinkViewModel : LinkViewModelBase<NodeViewModelBase>
    {
        public ClassLinkViewModel(NodeViewModelBase source, NodeViewModelBase target)
            : base(source, target)
        { }
    }
}
