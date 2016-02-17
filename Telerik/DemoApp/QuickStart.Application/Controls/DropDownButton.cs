using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Telerik.Windows.QuickStart
{
	public class DropDownButton : ContentControl, ICommandSource
	{
		public object DropDownContent
		{
			get { return (object)GetValue(DropDownContentProperty); }
			set { SetValue(DropDownContentProperty, value); }
		}

		// Using a DependencyProperty as the backing store for DropDownContent.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty DropDownContentProperty =
			DependencyProperty.Register("DropDownContent", typeof(object), typeof(DropDownButton), null);

		public DataTemplate DropDownContentTemplate
		{
			get { return (DataTemplate)GetValue(DropDownContentTemplateProperty); }
			set { SetValue(DropDownContentTemplateProperty, value); }
		}

		// Using a DependencyProperty as the backing store for DropDownContentTemplate.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty DropDownContentTemplateProperty =
			DependencyProperty.Register("DropDownContentTemplate", typeof(DataTemplate), typeof(DropDownButton), null);

		public bool IsOpen
		{
			get { return (bool)GetValue(IsOpenProperty); }
			protected set { SetValue(IsOpenProperty, value); }
		}

		// TODO: make read only:
		public static readonly DependencyProperty IsOpenProperty =
			DependencyProperty.Register("IsOpen", typeof(bool), typeof(DropDownButton), new PropertyMetadata(false, OnIsOpenChanged));

		private static void OnIsOpenChanged(object sender, DependencyPropertyChangedEventArgs args)
		{
			((DropDownButton)sender).OnIsOpenChanged(args);
		}

		private void OnIsOpenChanged(DependencyPropertyChangedEventArgs args)
		{
			if ((bool)args.NewValue)
			{
				Mouse.Capture(this, CaptureMode.SubTree);
			}
			else
			{
				Mouse.Capture(null);
			}
		}

		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CommandProperty =
			DependencyProperty.Register("Command", typeof(ICommand), typeof(DropDownButton), null);

		public object CommandParameter
		{
			get { return (object)GetValue(CommandParameterProperty); }
			set { SetValue(CommandParameterProperty, value); }
		}

		// Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CommandParameterProperty =
			DependencyProperty.Register("CommandParameter", typeof(object), typeof(DropDownButton), null);

		public IInputElement CommandTarget
		{
			get { return (IInputElement)GetValue(CommandTargetProperty); }
			set { SetValue(CommandTargetProperty, value); }
		}

		// Using a DependencyProperty as the backing store for CommandTarget.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CommandTargetProperty =
			DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(DropDownButton), null);

		static DropDownButton()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DropDownButton), new FrameworkPropertyMetadata(typeof(DropDownButton)));
			IsTabStopProperty.OverrideMetadata(typeof(DropDownButton), new FrameworkPropertyMetadata(false));
			CommandBinding commandBinding = new CommandBinding(DropDownButtonCommands.DropDownItemClick, OnDropDownButtonItemClick);
			CommandManager.RegisterClassCommandBinding(typeof(DropDownButton), commandBinding);
		}

		private static void OnDropDownButtonItemClick(object sender, ExecutedRoutedEventArgs args)
		{
			DropDownButton button = (DropDownButton)sender;
			ICommand command = button.Command;
			if (command != null)
			{
				object parameter = button.CommandParameter ?? args.Parameter;
				args.Handled = true;
				button.IsOpen = false;
				RoutedCommand routedCommand = command as RoutedCommand;
				if (routedCommand != null && button.CommandTarget != null)
				{
					routedCommand.Execute(parameter, button.CommandTarget);
				}
				else
				{
					command.Execute(parameter);
				}
			}
		}

		private ButtonBase openButton;

		public DropDownButton()
		{
			this.IsMouseCaptureWithinChanged += OnIsMouseCaptureWithinChanged;
			this.IsKeyboardFocusWithinChanged += OnIsKeyboardFocusWithinChanged;
		}

		private void OnIsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (!(bool)e.NewValue)
			{
				this.IsOpen = false;
			}
		}

		private void OnIsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsOpen && !(bool)e.NewValue)
			{
				Mouse.Capture(this, CaptureMode.SubTree);
			}
		}

		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			if (e.OriginalSource == this && this.IsOpen)
			{
				this.IsOpen = false;
				this.Focus();
				e.Handled = true;
			}
		}

		public override void OnApplyTemplate()
		{
			if (this.openButton != null)
			{
				this.openButton.Click -= OnOpenButtonClick;
			}
			
			base.OnApplyTemplate();
			this.openButton = this.GetTemplateChild("PART_OpenButton") as ButtonBase;
			
			if (this.openButton != null)
			{
				this.openButton.Click += OnOpenButtonClick;
			}
		}

		private void OnOpenButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.IsOpen)
            {
                this.IsOpen = false;
                if (this.openButton != null)
                {
                    this.openButton.Focus();
                }
            }
            else
            {
                this.IsOpen = true;
            }
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.Key == Key.Escape && e.Handled == false && this.IsOpen == true)
			{
				this.IsOpen = false;
				e.Handled = true;
			}
			base.OnKeyDown(e);
		}
	}
}
