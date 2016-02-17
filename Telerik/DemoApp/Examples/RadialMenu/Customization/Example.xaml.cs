﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.RadialMenu.Customization
{
	public partial class Example : UserControl
	{
		private readonly string sampleImageFolder = "/RadialMenu;component/Images/Customization/";
		private string lastImage;

		public ICommand ImageTransitionCommand
		{
			get;
			private set;
		}

		public Example()
		{
			InitializeComponent();
			this.DataContext = this;
			this.ImageTransitionCommand = new DelegateCommand(this.OnImageTransitionCommandExecuted);
			this.radTransitionControl.Content = this.sampleImageFolder + "mainImage.jpg";
		}

		private void OnImageTransitionCommandExecuted(object param)
		{
			var currentImage = (string)param;
			if (currentImage != this.lastImage)
			{
				this.radTransitionControl.Content = this.sampleImageFolder + currentImage + ".jpg";
			}

			this.lastImage = currentImage;
		}
	}
}
