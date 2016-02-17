using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
#if WPF
using System.Windows.Controls;
#else
using Telerik.Windows.Controls;
#endif
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.DragDrop;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Diagrams.Features
{
	/// <summary>
	/// Custom animated listbox to collect droppable RadDiagram shapes and other diagram elements.
	/// </summary>
	public class Toolbox : ItemsControl
	{
		/// <summary>
		/// The IsOpen dependency property.
		/// </summary>
		public static readonly DependencyProperty IsOpenProperty =
			DependencyProperty.Register("IsOpen", typeof(bool), typeof(Toolbox), new PropertyMetadata(true, OnIsOpenPropertyChanged));

		/// <summary>
		/// 
		/// </summary>
		public static readonly DependencyProperty SelectedGroupProperty =
			DependencyProperty.Register("SelectedGroup", typeof(CollectionViewGroup), typeof(Toolbox), new PropertyMetadata(null, OnSelectedGroupPropertyChanged));

		/// <summary>
		/// 
		/// </summary>
		public static readonly DependencyProperty ShapePathProperty =
			DependencyProperty.Register("ShapePath", typeof(string), typeof(Toolbox), new PropertyMetadata(null));

		private readonly SerializationService serializator;
		private ListBox groupsPresenter;

		/// <summary>
		/// Initializes static members of the <see cref="Toolbox"/> class.
		/// </summary>
		static Toolbox()
		{
#if WPF
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Toolbox), new FrameworkPropertyMetadata(typeof(Toolbox)));
#endif
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Toolbox"/> class.
		/// </summary>
		public Toolbox()
		{
#if !WPF
			this.DefaultStyleKey = typeof(Toolbox);
#endif
#if WPF
            this.Items.GroupDescriptions.CollectionChanged += this.GroupDescriptionsCollectionChanged;
#endif
			this.serializator = new SerializationService(null);

			this.ShowToolbox = new DelegateCommand(this.ExecuteShowToolbox, this.CanExecuteShowToolbox);
			this.HideToolbox = new DelegateCommand(this.ExecuteHideToolbox);

			this.InitializeDragAndDrop();
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is open.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is open; otherwise, <c>false</c>.
		/// </value>
		public bool IsOpen
		{
			get { return (bool)GetValue(IsOpenProperty); }
			set { SetValue(IsOpenProperty, value); }
		}

		/// <summary>
		/// Gets or sets the shape path.
		/// </summary>
		/// <value>
		/// The shape path.
		/// </value>
		public string ShapePath
		{
			get { return (string)GetValue(ShapePathProperty); }
			set { SetValue(ShapePathProperty, value); }
		}

		/// <summary>
		/// Gets or sets the show toolbox.
		/// </summary>
		/// <value>The show toolbox.</value>
		public DelegateCommand ShowToolbox { get; private set; }

		/// <summary>
		/// Gets or sets the hide toolbox.
		/// </summary>
		/// <value>The hide toolbox.</value>
		public DelegateCommand HideToolbox { get; private set; }

		/// <summary>
		/// Gets or sets the selected group.
		/// </summary>
		/// <value>
		/// The selected group.
		/// </value>
		public CollectionViewGroup SelectedGroup
		{
			get { return (CollectionViewGroup)GetValue(SelectedGroupProperty); }
			set { SetValue(SelectedGroupProperty, value); }
		}

		/// <summary>
		/// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
		/// </summary>
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			this.groupsPresenter = this.GetTemplateChild("groupsPresenter") as ListBox;

			this.UpdateStates();
		}

		/// <summary>
		/// Prepares the specified element to display the specified item.
		/// </summary>
		/// <param name="element">Element used to display the specified item.</param>
		/// <param name="item">Specified item.</param>
		protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
		{
			base.PrepareContainerForItemOverride(element, item);

			var container = element as ToolboxItem;
			if (container != null)
			{
				container.IsVisible = this.SelectedGroup == null || (this.SelectedGroup != null && this.SelectedGroup.Items.Contains(item));

				if (this.ShapePath != null && item != null)
				{
					var propertyInfo = item.GetType().GetProperty(this.ShapePath);
					if (propertyInfo != null)
						container.Shape = propertyInfo.GetValue(item, null) as RadDiagramShape;
				}
			}
		}

		/// <summary>
		/// Determines if the specified item is (or is eligible to be) its own container.
		/// </summary>
		/// <param name="item">The item to check.</param>
		/// <returns>
		/// true if the item is (or is eligible to be) its own container; otherwise, false.
		/// </returns>
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is ToolboxItem;
		}

		/// <summary>
		/// Creates or identifies the element that is used to display the given item.
		/// </summary>
		/// <returns>
		/// The element that is used to display the given item.
		/// </returns>
		protected override DependencyObject GetContainerForItemOverride()
		{
			return new ToolboxItem();
		}

		protected virtual void OnSelectedGroupChanged(CollectionViewGroup newValue, CollectionViewGroup oldValue)
		{
			if (newValue != null)
			{
				foreach (var item in newValue.Items)
				{
					var container = this.ItemContainerGenerator.ContainerFromItem(item) as ToolboxItem;
					if (container != null)
						container.IsVisible = true;
				}
			}

			if (oldValue != null)
			{
				foreach (var item in oldValue.Items)
				{
					var container = this.ItemContainerGenerator.ContainerFromItem(item) as ToolboxItem;
					if (container != null)
						container.IsVisible = false;
				}
			}
		}

		private static void OnIsOpenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var toolbox = d as Toolbox;
			if (toolbox != null) toolbox.UpdateStates();
		}

		private static void OnSelectedGroupPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var toolbox = d as Toolbox;
			if (toolbox != null)
			{
				toolbox.OnSelectedGroupChanged((CollectionViewGroup)e.NewValue, (CollectionViewGroup)e.OldValue);
			}
		}

		private void UpdateStates()
		{
			VisualStateManager.GoToState(this, this.IsOpen ? "Open" : "Closed", false);
		}

		private void ExecuteShowToolbox(object commandParameter)
		{
			this.Visibility = System.Windows.Visibility.Visible;
			this.ShowToolbox.InvalidateCanExecute();
		}

		private bool CanExecuteShowToolbox(object commandParameter)
		{
			if (this.Visibility == System.Windows.Visibility.Collapsed)
				return true;

			return false;
		}

		private void ExecuteHideToolbox(object commandParameter)
		{
			this.Visibility = System.Windows.Visibility.Collapsed;
			this.ShowToolbox.InvalidateCanExecute();
		}

		private void InitializeDragAndDrop()
		{
			DragDropManager.RemoveDragInitializeHandler(this, this.OnDragInitialized);

			DragDropManager.AddDragInitializeHandler(this, this.OnDragInitialized);
		}

		private void OnDragInitialized(object sender, DragInitializeEventArgs args)
		{
			var toolBoxItem = args.OriginalSource as ToolboxItem;
			if (toolBoxItem != null)
			{
				var shape = toolBoxItem.Shape;
				if (shape != null && shape.ActualWidth > 0 && shape.ActualHeight > 0 && this.serializator != null)
				{
					////args.Data = this.shapeToDataMap[toolBoxItem];
					shape.ClearValue(BackgroundProperty);
					args.Data = this.serializator.SerializeItems(new List<IDiagramItem> { shape });

					args.DragVisualOffset = new Point(args.RelativeStartPoint.X - (shape.ActualWidth / 2), args.RelativeStartPoint.Y - (shape.ActualHeight / 2));

					var draggingImage = new System.Windows.Controls.Image
					{
						Source = new Telerik.Windows.Media.Imaging.RadBitmap(shape).Bitmap,
						Width = shape.ActualWidth,
						Height = shape.ActualHeight
					};
					args.DragVisual = draggingImage;
				}
				else
				{
					args.Data = toolBoxItem.Content;
				}

				toolBoxItem.IsMouseOverItem = false;
			}
			args.AllowedEffects = DragDropEffects.All;
			args.Handled = true;
		}

#if WPF
        private void GroupDescriptionsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (this.groupsPresenter != null)
            {
                this.groupsPresenter.ItemsSource = this.Items.Groups;
                if (this.Items.Groups.Count > 0)
                    this.groupsPresenter.SelectedIndex = 0;
            }
        }
#endif
	}
}
