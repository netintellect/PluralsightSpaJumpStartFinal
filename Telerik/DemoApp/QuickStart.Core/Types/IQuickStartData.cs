using System;
using System.Collections.Generic;
using System.Linq;

namespace Telerik.Windows.QuickStart
{
    public interface IQuickStartData
    {
        IEnumerable<IControlInfo> NewControlsNonTouch { get; }
        IEnumerable<IControlInfo> NewControlsTouch { get; }
        IEnumerable<IControlInfo> HighlightedControlsNonTouch { get; }
        IEnumerable<IControlInfo> HighlightedControlsTouch { get; }

        IEnumerable<IControlInfo> Controls { get; }
        IEnumerable<IControlInfo> ControlsNonTouch { get; }
        IEnumerable<IControlInfo> ControlsTouch { get; }

        IEnumerable<IExampleInfo> Examples { get; }
        IEnumerable<IExampleInfo> ExamplesNonTouch { get; }
        IEnumerable<IExampleInfo> ExamplesTouch { get; }

        IEnumerable<ISampleAppInfo> SampleApps { get; }
    }
}
