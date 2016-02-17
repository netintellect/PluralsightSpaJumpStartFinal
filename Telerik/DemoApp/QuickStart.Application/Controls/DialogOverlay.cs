using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Telerik.Windows.QuickStart
{
	[TemplatePart(Name = PartDialogBackground)]
	[TemplateVisualState(GroupName = "IsOpenState", Name = "Opened")]
	[TemplateVisualState(GroupName = "IsOpenState", Name = "Closed")]
	public class DialogOverlay : ContentControl
	{
		// Using a DependencyProperty as the backing store for IsOpen.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsOpenProperty =
			DependencyProperty.Register("IsOpen", typeof(bool), typeof(DialogOverlay), new PropertyMetadata(false, OnIsOpenPropertyChanged));

		private const string PartDialogBackground = "PART_DialogBackground";

		private DependencyObject dialogBackground;

		public DialogOverlay()
		{
			this.DefaultStyleKey = typeof(DialogOverlay);
		}

		public bool IsOpen
		{
			get
			{
				return (bool)this.GetValue(IsOpenProperty);
			}
			set
			{
				this.SetValue(IsOpenProperty, value);
			}
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.dialogBackground = this.GetTemplateChild(PartDialogBackground);
		}

		protected override void OnKeyUp(System.Windows.Input.KeyEventArgs e)
		{
			base.OnKeyUp(e);
			this.CloseDialogOnPointerUp(e.OriginalSource);
		}

		protected override void OnMouseUp(System.Windows.Input.MouseButtonEventArgs e)
		{
			base.OnMouseUp(e);
			this.CloseDialogOnPointerUp(e.OriginalSource);
		}

		protected override void OnTouchUp(System.Windows.Input.TouchEventArgs e)
		{
			base.OnTouchUp(e);
			this.CloseDialogOnPointerUp(e.OriginalSource);
		}

		protected override void OnStylusUp(System.Windows.Input.StylusEventArgs e)
		{
			base.OnStylusUp(e);
			this.CloseDialogOnPointerUp(e.OriginalSource);
		}

		private static void OnIsOpenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var dialogOverlay = d as DialogOverlay;
			bool isOpened = (bool)e.NewValue;
			string stateName = isOpened ? "Opened" : "Closed";

			VisualStateManager.GoToState(dialogOverlay, stateName, true);
		}

		private void CloseDialogOnPointerUp(object originalSource)
		{
			if (originalSource == this.dialogBackground)
			{
				if (this.IsOpen)
				{
					this.IsOpen = false;
				}
			}
		}
	}
}