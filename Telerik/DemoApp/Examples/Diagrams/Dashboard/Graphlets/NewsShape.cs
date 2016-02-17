using System;
using System.Windows;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public sealed class NewsShape : RadDiagramShape
	{
		public static readonly DependencyProperty AddressProperty = DependencyProperty.Register("Address", typeof(string), typeof(NewsShape), new FrameworkPropertyMetadata((string)"", OnAddressChanged));

		private const string AddressName = "Address";
		
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

		public override void Deserialize(SerializationInfo info)
		{
			base.Deserialize(info);
			if (info[AddressName] != null) this.Address = info[AddressName].ToString();
		}

		public override SerializationInfo Serialize()
		{
			var info = base.Serialize();
			info[AddressName] = this.Address ?? "";
			return info;
		}

		public void UpdateData()
		{
			this.Content = DataProvider.FetchNews();
		}

		protected void OnAddressChanged(DependencyPropertyChangedEventArgs e)
		{
			this.UpdateData();
		}

		private static void OnAddressChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((NewsShape)d).OnAddressChanged(e);
		}
	}

	public sealed class RssItem
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Link { get; set; }
		public DateTime PublicationDate { get; set; }
	}
}