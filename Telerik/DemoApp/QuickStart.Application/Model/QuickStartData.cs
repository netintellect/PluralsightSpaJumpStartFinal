using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Telerik.Windows.QuickStart
{
    public class QuickStartData : IQuickStartData
    {
        private XElement element;
        private static QuickStartData instance;
        private IEnumerable<IControlInfo> allControls;

        public static QuickStartData Instance
        {
            get
            {
                if (instance == null)
                {
                    XElement rootElement = DownloadExamplesXml().Root;
                    instance = new QuickStartData(rootElement);
                }

                return instance;
            }
        }

        internal XElement Element
        {
            get
            {
                return this.element;
            }
        }

        private QuickStartData(XElement element)
        {
            this.element = element;
            this.LoadData();
        }


        public IEnumerable<IControlInfo> ControlsNonTouch { get; private set; }

        public IEnumerable<IControlInfo> ControlsTouch { get; private set; }

        public IEnumerable<IControlInfo> Controls { get; private set; }

        public IEnumerable<IControlInfo> NewControlsNonTouch { get; private set; }

        public IEnumerable<IControlInfo> NewControlsTouch { get; private set; }

        public IEnumerable<IControlInfo> HighlightedControlsNonTouch { get; private set; }

        public IEnumerable<IControlInfo> HighlightedControlsTouch { get; private set; }

        public IEnumerable<IExampleInfo> Examples { get; private set; }

        public IEnumerable<IExampleInfo> ExamplesNonTouch { get; private set; }

        public IEnumerable<IExampleInfo> ExamplesTouch { get; private set; }

        public IEnumerable<ISampleAppInfo> SampleApps { get; private set; }

        public ReleaseVersionInfo ReleaseVersion { get; set; }

        private static XDocument DownloadExamplesXml()
        {
            var streamResourceInfo = System.Windows.Application.GetResourceStream(new Uri("/Application;component/Examples.xml", UriKind.RelativeOrAbsolute));
            if (streamResourceInfo == null)
            {
                throw new Exception("Cannot find examples.xml");
            }

            return XDocument.Load(XmlReader.Create(streamResourceInfo.Stream));
        }

        private void LoadData()
        {
            var controlsList = this.LoadControlsData();

            this.allControls = controlsList.OrderBy(c => c.Name).ToList();
            this.HighlightedControlsNonTouch = this.LoadHighLightedControls(controlsList, false);
            this.HighlightedControlsTouch = this.LoadHighLightedControls(controlsList, true);

            this.Controls = this.allControls;
            this.ControlsNonTouch = this.allControls.Where(c => c.NonTouchExamples.Count > 0).ToList();
            this.ControlsTouch = this.allControls.Where(c => c.TouchExamples.Count > 0).ToList();

            this.NewControlsNonTouch = this.ControlsNonTouch.Where(c => c.Status == Enums.StatusMode.New || c.Status == Enums.StatusMode.Beta || c.Status == Enums.StatusMode.Ctp).ToList();
            this.NewControlsTouch = this.ControlsTouch.Where(c => c.Status == Enums.StatusMode.New || c.Status == Enums.StatusMode.Beta || c.Status == Enums.StatusMode.Ctp).ToList();

            this.Examples = this.allControls.SelectMany(c => c.Examples).ToList();
            this.ExamplesNonTouch = this.Examples.FilterNonTouchExamples().ToList();
            this.ExamplesTouch = this.Examples.FilterTouchExamples().ToList();

            this.LoadSampleApps();
            this.ReleaseVersion = new ReleaseVersionInfo(this.element.Element("ReleaseVersion"));
        }

        private List<IControlInfo> LoadControlsData()
        {
            List<IControlInfo> controlsList = new List<IControlInfo>();

            var controls = this.element.Element("Controls");
            if (controls != null)
            {
                foreach (var item in controls.Elements("Control").Select(e => new ControlInfo(e)))
                {
                    if (item.Status != Enums.StatusMode.Obsolete)
                    {
                        controlsList.Add(item);
                    }
                }
            }

            return controlsList.Where(c => c.Platform == Enums.Platform.WPF).ToList();
        }

        private IEnumerable<IControlInfo> LoadHighLightedControls(List<IControlInfo> controlsList, bool loadTouchControls)
        {
            string highlightedControlsElementName = loadTouchControls ? "HighlightedControlsTouch" : "HighlightedControls";
            var highlightedControls = this.element.Element(highlightedControlsElementName).Elements("HighlightedControl");
            var wpfHighlightedControls = highlightedControls.Where(node => (Enums.Platform)Enum.Parse(typeof(Enums.Platform), node.GetAttribute("platform", "WPF"), true) == Enums.Platform.WPF);
            return wpfHighlightedControls.Select((node) => controlsList.FirstOrDefault((ici) => node.Attribute("name").Value == ici.Name));
        }

        private void LoadSampleApps()
        {
            var sampleApps = this.element.Element("SampleApps").Elements("SampleApp");
            if (sampleApps != null)
            {
                this.SampleApps = sampleApps.Select(app => new SampleAppInfo(app));
            }
        }
    }
}
