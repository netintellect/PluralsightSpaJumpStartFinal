using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.Examples.Diagrams.Common;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public sealed class ImageShape : RadDiagramShape
	{
		private const string AddressTag = "Address";
		private const string LocationTag = "Location";
		private const string NavigationTag = "Url";

		public static readonly DependencyProperty AddressProperty =
			DependencyProperty.Register("Address", typeof(string), typeof(ImageShape),
				new FrameworkPropertyMetadata("",
					OnAddressChanged));

		public static readonly DependencyProperty LocationProperty =
			DependencyProperty.Register("Location", typeof(ImageLocation), typeof(ImageShape),
				new FrameworkPropertyMetadata(ImageLocation.Local,
					OnLocationChanged));

		public static readonly DependencyProperty NavigateUriProperty =
			DependencyProperty.Register("NavigateUri", typeof(Uri), typeof(ImageShape),
				new FrameworkPropertyMetadata(null,
					OnNavigateUriChanged));
				
		public ImageShape()
		{
			ApplicationManager.ApplicationStateChanged += this.OnApplicationStateChanged;
		}

		public string Address
		{
			get
			{
				return (string)this.GetValue(AddressProperty);
			}
			set
			{
				this.SetValue(AddressProperty, value);
			}
		}

		public ImageLocation Location
		{
			get
			{
				return (ImageLocation)this.GetValue(LocationProperty);
			}
			set
			{
				this.SetValue(LocationProperty, value);
			}
		}

		public Uri NavigateUri
		{
			get
			{
				return (Uri)this.GetValue(NavigateUriProperty);
			}
			set
			{
				this.SetValue(NavigateUriProperty, value);
			}
		}

		public override void Deserialize(SerializationInfo info)
		{
			base.Deserialize(info);
			if (info[LocationTag] != null) this.Location = (ImageLocation)Enum.Parse(typeof(ImageLocation), info[LocationTag].ToString(), true);
			if (info[AddressTag] != null) this.Address = info[AddressTag].ToString();
			if (info[NavigationTag] != null) this.NavigateUri = new Uri(info[NavigationTag].ToString());
		}

		public override SerializationInfo Serialize()
		{
			var info = base.Serialize();
			info[AddressTag] = this.Address ?? "";
			info[LocationTag] = this.Location.ToString();
			if (this.NavigateUri != null) info[NavigationTag] = this.NavigateUri.ToString();
			return info;
		}

		protected void OnAddressChanged(DependencyPropertyChangedEventArgs e)
		{
			this.UpdateSource();
		}

		protected void OnLocationChanged(DependencyPropertyChangedEventArgs e)
		{
			this.UpdateSource();
		}
#if WPF
		protected override void OnMouseDown(System.Windows.Input.MouseButtonEventArgs e)
		{
			if (ApplicationManager.ApplicationState == ApplicationState.RunMode && this.NavigateUri != null) 
				Process.Start(this.NavigateUri.ToString());
			base.OnMouseDown(e);
		}
#endif
		protected void OnNavigateUriChanged(DependencyPropertyChangedEventArgs e)
		{
#if WPF
			if (this.NavigateUri != null) this.ToolTip = this.NavigateUri.ToString();
#endif
		}
		
		private static void OnAddressChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((ImageShape)d).OnAddressChanged(e);
		}

		private static void OnLocationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((ImageShape)d).OnLocationChanged(e);
		}

		private static void OnNavigateUriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((ImageShape)d).OnNavigateUriChanged(e);
		}

		private void OnApplicationStateChanged(object sender, EventArgs eventArgs)
		{
			if (this.NavigateUri != null) this.Cursor = ApplicationManager.ApplicationState == ApplicationState.RunMode ? Cursors.Hand : Cursors.Arrow;
		}

		private void UpdateSource()
		{
			switch (this.Location)
			{
				case ImageLocation.Remote:
					if (string.IsNullOrEmpty(this.Address)) return;
					var c = new ImageSourceConverter();
					this.Content = c.ConvertFromString(this.Address) as ImageSource;
					break;
				case ImageLocation.Local:
					var im = ExtensionUtilities.GetBitmap(this.Address, ExtensionUtilities.ExecutingAssemblyName);
					this.Content = im;// new Image { Source = im, Width = im.PixelWidth, Height = im.PixelHeight };
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}