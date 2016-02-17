using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public sealed class HyperlinkShape : RadDiagramShape
	{
		public static readonly DependencyProperty AddressProperty =
			DependencyProperty.Register("Address", typeof(string), typeof(HyperlinkShape),
				new FrameworkPropertyMetadata(null,
					OnAddressChanged));

		public static readonly DependencyProperty IsInternalProperty =
			DependencyProperty.Register("IsInternal", typeof(bool), typeof(HyperlinkShape),
				new FrameworkPropertyMetadata(false));

		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(HyperlinkShape), new FrameworkPropertyMetadata("", OnTextChanged));

		private PageManager pageManager;
		private const string AddressTag = "Address";
		private const string InternalTag = "Internal";
		private const string TextTag = "Text";

		public HyperlinkShape()
		{
			Data = new HyperlinkData();
			this.Content = Data;
		}

		private HyperlinkData Data { get; set; }

		public PageManager PageManager
		{
			get
			{
				return this.pageManager;
			}
			set
			{
				this.pageManager = value;
				Data.PageManager = value;
			}
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

		public bool IsInternal
		{
			get
			{
				return (bool)this.GetValue(IsInternalProperty);
			}
			set
			{
				this.SetValue(IsInternalProperty, value);
			}
		}

		public string Text
		{
			get
			{
				return (string)this.GetValue(TextProperty);
			}
			set
			{
				this.SetValue(TextProperty, value);
			}
		}

		public override void Deserialize(SerializationInfo info)
		{
			base.Deserialize(info);
			if (info[TextTag] != null)
			{
				this.Text = info[TextTag].ToString();
			}
			if (info[InternalTag] != null)
			{
				this.IsInternal = bool.Parse(info[InternalTag].ToString());
			}
			if (info[AddressTag] != null)
			{
				this.Address = info[AddressTag].ToString();
			}
		}

		public override SerializationInfo Serialize()
		{
			var info = base.Serialize();
			info[TextTag] = this.Text ?? "";
			info[AddressTag] = this.Address ?? "";
			info[InternalTag] = this.IsInternal.ToString(CultureInfo.InvariantCulture);
			return info;
		}

		protected void OnAddressChanged(DependencyPropertyChangedEventArgs e)
		{
			UpdateData();
		}

		protected void OnTextChanged(DependencyPropertyChangedEventArgs e)
		{
			UpdateData();
		}

		private void UpdateData()
		{
			this.Data.Text = this.Text;
			this.Data.Url = this.Address;
			this.Content = this.Data;
		}

		private static void OnAddressChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((HyperlinkShape)d).OnAddressChanged(e);
		}

		private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((HyperlinkShape)d).OnTextChanged(e);
		}
	}

	public class HyperlinkData
	{
		public string Text { get; set; }
		public string Url { get; set; }
		public DelegateCommand Do { get; set; }
		public PageManager PageManager { get; set; }
		public HyperlinkData()
		{
			Do = new DelegateCommand(new Action<object>(d => { this.Navigate(d); }));

		}
		private void Navigate(object d)
		{
#if WPF
			//var hl =d as Hyperlink;
#else
			//var hl = d as  HyperlinkButton;
#endif
			//if (hl != null)
			{
				//here we should actually move up the visual tree to find the HyperlinkShape and see whether it's an
				//internal or external link, but the shortcut is to see whether it's a Guid (corresponding to a Page)
				Guid guid;
				if (Guid.TryParse(this.Url, out guid))
				{
					var slide = this.PageManager.Pages.SingleOrDefault(s => s.Id == guid.ToString());
					if (slide != null)
					{
						// admire the simplicity of the navigation here... though the WPF/SL navigation framework could be plugged in
						this.PageManager.CurrentPage = slide;
					}
				}
				else
				{
#if WPF
					System.Diagnostics.Process.Start(this.Url);
#else
					System.Windows.Browser.HtmlPage.Window.Navigate(new Uri(this.Url), "_blank");
#endif
				}
			}
		}
	}
}