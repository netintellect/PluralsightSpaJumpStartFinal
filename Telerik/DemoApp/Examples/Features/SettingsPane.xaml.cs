using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams.Primitives;

namespace Telerik.Windows.Diagrams.Features
{
	public partial class SettingsPane : UserControl
	{
		private RadDiagram diagram;
		private ItemInformationAdorner informationAdorner;
		private Popup rootPopup;
		private SettingsPaneDataProvider dataProvider = null;
		private SettingsPaneViewModel dataModel = new SettingsPaneViewModel();

		public SettingsPane()
		{
			InitializeComponent();

			this.DataContext = this.dataModel;
			this.ContentHolder.DataContext = this.dataModel;

			this.Loaded += this.SettingsPane_Loaded;
		}

		private void SettingsPane_Loaded(object sender, RoutedEventArgs e)
		{
			var diagram = this.ParentOfType<RadDiagram>();
			if (diagram == null)
			{
				throw new InvalidOperationException("SettingsPane must be placed in valid not null RadDiagram object.");
			}

			var informationAdorner = this.ParentOfType<ItemInformationAdorner>();
			if (informationAdorner == null)
			{
				throw new InvalidOperationException("SettingsPane must be placed in valid not null ItemInformationAdorner object.");
			}

			var rootPopup = this.ChildrenOfType<System.Windows.Controls.Primitives.Popup>().FirstOrDefault();
			if (rootPopup == null)
			{
				throw new InvalidOperationException("SettingsPane must contain a valid not null Popup object to present the content.");
			}

			this.Initialize(diagram, informationAdorner, rootPopup);
		}

		private void Initialize(RadDiagram diagram, ItemInformationAdorner informationAdorner, Popup rootPopup)
		{
			this.diagram = diagram;
			this.informationAdorner = informationAdorner;
			this.informationAdorner.IsAdditionalContentVisibleChanged += this.InformationAdorner_IsAdditionalContentVisibleChanged;
			this.rootPopup = rootPopup;

			this.dataProvider = new SettingsPaneDataProvider(this.diagram);
			this.dataProvider.BoundsChanged += (_, __) => this.PlacePopup();
		}

		private void InformationAdorner_IsAdditionalContentVisibleChanged(object sender, EventArgs e)
		{
			if (this.informationAdorner.IsAdditionalContentVisible == false)
			{
				this.rootPopup.IsOpen = false;
			}
		}

		private void SettingsPaneDropDownButton_DropDownOpened(object sender, RoutedEventArgs e)
		{
			this.dataModel.Reload(this.dataProvider);
#if WPF
			this.rootPopup.PlacementTarget = this.informationAdorner;
			this.rootPopup.Placement = System.Windows.Controls.Primitives.PlacementMode.Right;
#endif
			this.PlacePopup();
			var selectedTab = this.Tabs.ItemContainerGenerator.ContainerFromIndex(this.Tabs.SelectedIndex) as Control;
			if (selectedTab != null)
			{
				selectedTab.Focus();
			}
		}

		private void PlacePopup()
		{
			this.ContentHolder.UpdateLayout(); //// Ensure a layout pass will be executed.
#if WPF
			this.rootPopup.HorizontalOffset = -this.Margin.Right - this.ActualWidth - 0.1;
#endif
			this.rootPopup.HorizontalOffset += .1; //// Ensure offset will be marked as changed.
			this.rootPopup.HorizontalOffset -= .1;
			this.rootPopup.VerticalOffset = (this.informationAdorner.ActualHeight / 2) - (this.ContentHolder.ActualHeight / 2);
		}

		private void LabelTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			this.dataModel.CommitCurrentLabelCommand.Execute(null);
		}

		/// <summary>
		/// Handle the mouse wheel event in order to prevent diagram zooming while settings are displayed.
		/// </summary>
		private void Root_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
		{
			e.Handled = true;
		}

		/// <summary>
		/// Handle the mouse left button down event in order to prevent popup closing when user clicks in the content.
		/// </summary>
		private void Root_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
#if WPF
			e.Handled = true;
#endif
		}
	}
}
