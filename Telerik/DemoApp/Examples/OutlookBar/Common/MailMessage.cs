﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace Examples.OutlookBar.CS
{
	public class Message
	{
		public string Title { get; set; }
		public string From { get; set; }
		public string Sent { get; set; }
		public BitmapImage MessageContent { get; set; }
	}
}
