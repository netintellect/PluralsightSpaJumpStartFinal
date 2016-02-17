using System;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public class FinancialShape : RadDiagramShape
	{
		private const string SymbolTag = "Symbol";

		public static readonly DependencyProperty SymbolProperty = DependencyProperty.Register("Symbol", typeof(string), typeof(FinancialShape), new FrameworkPropertyMetadata(null, OnSymbolChanged));
		
		public string Symbol
		{
			get
			{
				return (string)this.GetValue(SymbolProperty);
			}
			set
			{
				this.SetValue(SymbolProperty, value);
			}
		}
		
		public override void Deserialize(SerializationInfo info)
		{
			base.Deserialize(info);
			if (info[SymbolTag] != null) this.Symbol = info[SymbolTag].ToString();
		}

		public override SerializationInfo Serialize()
		{
			var info = base.Serialize();
			info[SymbolTag] = this.Symbol ?? string.Empty;
			return info;
		}
		
		protected virtual void UpdateData()
		{
		}

		private static void OnSymbolChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((FinancialShape)d).OnSymbolChanged(e);
		}

		private void OnSymbolChanged(DependencyPropertyChangedEventArgs e)
		{
			this.UpdateData();
		}
	}
}