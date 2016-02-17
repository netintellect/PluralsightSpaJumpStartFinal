using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Media.Imaging.Tools.UI;

namespace Telerik.Windows.Examples.ImageEditor.CustomTool
{
    public partial class WatermarkToolSettings : ToolSettingsHeader
    {
        public WatermarkToolSettings()
        {
            InitializeComponent();

            this.opacity.Value = WatermarkTool.DefaultOpacity;
            this.scale.Value = WatermarkTool.DefaultScale;
            this.rotation.Value = WatermarkTool.DefaultRotation;
        }
    }
}
