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
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Window.Configurator
{
    public partial class ExampleWindow : RadWindow
    {
        public ExampleWindow()
        {
            InitializeComponent();
			this.Width = 390;
			this.Height = 230;
        }
    }
}
