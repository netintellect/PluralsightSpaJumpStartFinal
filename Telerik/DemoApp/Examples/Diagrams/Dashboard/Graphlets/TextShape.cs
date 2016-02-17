using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public sealed class TextShape : RadDiagramShape
	{
		private const string TextName = "Text";

		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextShape), new FrameworkPropertyMetadata("", OnTextChange));

		public string Text
		{
			get { return (string)this.GetValue(TextProperty); }
			set { this.SetValue(TextProperty, value); }
		}

		public override SerializationInfo Serialize()
		{
			var info = base.Serialize();
			info[TextName] = this.Text ?? string.Empty;
			return info;
		}

		public override void Deserialize(SerializationInfo info)
		{
			base.Deserialize(info);
			if (info[TextName] != null) this.Text = info[TextName].ToString();
		}

		private static void OnTextChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((TextShape)d).OnTextChange(e);
		}

		private void OnTextChange(DependencyPropertyChangedEventArgs e)
		{
			this.Content = this.Text;
		}
	}
}