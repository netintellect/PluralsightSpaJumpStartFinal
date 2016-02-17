﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Examples.Gauge;
using Telerik.Windows.Controls.Gauge;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Gauge.Customization.Range
{
	public partial class Example : DynamicBasePage
	{
		public Example()
		{
			InitializeComponent();
		}

		protected override void NewValue()
		{
			marker.Value = radialScale.Min + (radialScale.Max - radialScale.Min) * rnd.NextDouble();
		}
	}
}
