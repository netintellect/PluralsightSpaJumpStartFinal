using System;
using System.Collections.Generic;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public sealed class GaugeShape : FinancialShape
	{
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(GaugeShape), new FrameworkPropertyMetadata(string.Empty));

		private const string TextTag = "Text";
		
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
			if (info[TextTag] != null) this.Text = info[TextTag].ToString();
		}

		public override SerializationInfo Serialize()
		{
			var info = base.Serialize();
			info[TextTag] = this.Text ?? string.Empty;
			return info;
		}

		protected override void UpdateData()
		{
			try
			{
				var quote = new Quote(this.Symbol);
				DataProvider.Fetch(new List<Quote> { quote });
				this.Content = quote;
			}
			catch (Exception)
			{
				RadWindow.Alert("Invalid symbol or the data service is not responding.");
			}
		}
	}
}