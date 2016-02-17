using System.Collections.ObjectModel;
using System;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.RibbonView;

namespace Telerik.Windows.Examples.RibbonView.MVVM.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private TabViewModel selectedTab;
		private DelegateCommand removeTab;
		private DelegateCommand addButton;
		private DelegateCommand addGroup;
		private DelegateCommand addTab;
		private ObservableCollection<ButtonViewModel> applicationMenuItems;
		private ObservableCollection<ButtonViewModel> quickAccessItems;
		private ObservableCollection<TabViewModel> tabs;

		public MainViewModel()
		{
			GenerateTabs();

			this.SelectedTab = this.Tabs[0];
		}

		private void GenerateTabs()
		{
			tabs = new ObservableCollection<TabViewModel>();

			TabViewModel homeTab = new TabViewModel();
			homeTab.Text = "Home";
			TabViewModel viewTab = new TabViewModel();
			viewTab.Text = "View";
			TabViewModel textTab = new TabViewModel();
			textTab.Text = "Text";

			homeTab.Groups.Add(GetClipboardGroup());
			homeTab.Groups.Add(GetImageGroup());
			homeTab.Groups.Add(GetToolsGroup());
			homeTab.Groups.Add(GetBrushesGroup());

			viewTab.Groups.Add(GetGroup("Zoom"));
			viewTab.Groups.Add(GetGroup("Show"));
			viewTab.Groups.Add(GetGroup("Display"));

			textTab.Groups.Add(GetGroup("Clipboard"));
			textTab.Groups.Add(GetGroup("Font"));
			textTab.Groups.Add(GetGroup("Background"));
			textTab.Groups.Add(GetGroup("colors"));

			Tabs.Add(homeTab);
			Tabs.Add(viewTab);
			Tabs.Add(textTab);

			quickAccessItems = new ObservableCollection<ButtonViewModel>();
			quickAccessItems.Add(GetButton("save", "Save", false));
			quickAccessItems.Add(GetButton("undo", "Undo", false));
			quickAccessItems.Add(GetButton("print", "Print", false));

			applicationMenuItems = new ObservableCollection<ButtonViewModel>();
			applicationMenuItems.Add(GetButton("save", "Save", true));
			applicationMenuItems.Add(GetButton("undo", "Undo", true));
			applicationMenuItems.Add(GetButton("print", "Print", true));

			addTab = new DelegateCommand(AddTabHandler);
			addGroup = new DelegateCommand(AddGroupHandler);
			addButton = new DelegateCommand(AddButtonHandler);
			removeTab = new DelegateCommand(RemoveTabHandler);
		}

		private GroupViewModel GetGroup(string name)
		{
			GroupViewModel group = new GroupViewModel();
			group.Text = name;
			return group;
		}

		private void RemoveTabHandler(object o)
		{
			if (this.SelectedTab != null)
			{
				this.Tabs.Remove(this.SelectedTab);
				if (this.Tabs.Count > 0)
				{
					this.SelectedTab = this.Tabs[0];
				}
			}
		}

		private void AddButtonHandler(object o)
		{
			if (this.SelectedTab != null && this.SelectedTab.Groups.Count > 0)
			{
				int group = (new Random()).Next(SelectedTab.Groups.Count);
				ButtonViewModel b = new ButtonViewModel(); b.Text = "New button"; b.Size = ButtonSize.Medium;
				SelectedTab.Groups[group].Buttons.Add(b);
			}
		}

		private void AddGroupHandler(object o)
		{
			if (this.SelectedTab != null)
			{
				GroupViewModel group = new GroupViewModel();
				group.Text = "New group";
				this.SelectedTab.Groups.Add(group);
			}
		}

		private void AddTabHandler(object o)
		{
			TabViewModel tab = new TabViewModel();
			tab.Text = "New tab";
			this.Tabs.Add(tab);
		}

		public ObservableCollection<TabViewModel> Tabs
		{
			get
			{
				return tabs;
			}
		}

		public ObservableCollection<ButtonViewModel> QuickAccessItems
		{
			get
			{
				return quickAccessItems;
			}
		}

		public ObservableCollection<ButtonViewModel> ApplicationMenuItems
		{
			get
			{
				return applicationMenuItems;
			}
		}

		public TabViewModel SelectedTab
		{
			get
			{
				return this.selectedTab;
			}
			set
			{
				if (this.selectedTab != value)
				{
					this.selectedTab = value;
					OnPropertyChanged("SelectedTab");
				}
			}
		}

		public string Title
		{
			get { return "Untitled"; }
		}

		public string AppName
		{
			get
			{
				return "Paint";
			}
		}

		public DelegateCommand AddTab
		{
			get
			{
				return addTab;
			}
		}

		public DelegateCommand AddGroup
		{
			get
			{
				return addGroup;
			}
		}

		public DelegateCommand AddButton
		{
			get
			{
				return addButton;
			}
		}

		public DelegateCommand RemoveTab
		{
			get
			{
				return removeTab;
			}
		}

		private GroupViewModel GetClipboardGroup()
		{
			GroupViewModel clipboard = new GroupViewModel();
			clipboard.Text = "Clipboard";
			SplitButtonViewModel split = new SplitButtonViewModel();
			split.Text = "Paste";
			split.Size = ButtonSize.Large;
			split.LargeImage = GetPath("MVVM/paste.png");
			clipboard.Buttons.Add(split);

			ButtonGroupViewModel buttonsGroup = new ButtonGroupViewModel();
			buttonsGroup.Buttons.Add(GetButton("cut", "Cut"));
			buttonsGroup.Buttons.Add(GetButton("copy", "Copy"));

			clipboard.Buttons.Add(buttonsGroup);
			return clipboard;
		}

		private GroupViewModel GetImageGroup()
		{
			GroupViewModel image = new GroupViewModel();
			image.Text = "Image";
			SplitButtonViewModel split = new SplitButtonViewModel();
			split.Text = "Select";
			split.Size = ButtonSize.Large;
			split.LargeImage = GetPath("MVVM/select.png");
			image.Buttons.Add(split);

			ButtonGroupViewModel buttonsGroup = new ButtonGroupViewModel();
			buttonsGroup.Buttons.Add(GetSmallButton("crop", "Crop"));
			buttonsGroup.Buttons.Add(GetSmallButton("resize", "Resize"));
			buttonsGroup.Buttons.Add(GetSmallButton("rotate", "Rotate"));

			image.Buttons.Add(buttonsGroup);
			return image;
		}

		private GroupViewModel GetToolsGroup()
		{
			GroupViewModel image = new GroupViewModel();
			image.Text = "Tools";

			ButtonGroupViewModel buttonsGroup = new ButtonGroupViewModel();
			buttonsGroup.IsSmallGroup = true;
			buttonsGroup.Buttons.Add(GetSmallButton("pen"));
			buttonsGroup.Buttons.Add(GetSmallButton("paint-bucket"));
			buttonsGroup.Buttons.Add(GetSmallButton("text"));
			buttonsGroup.Buttons.Add(GetSmallButton("eraser"));
			buttonsGroup.Buttons.Add(GetSmallButton("eyedropper"));
			buttonsGroup.Buttons.Add(GetSmallButton("zoom"));

			image.Buttons.Add(buttonsGroup);
			return image;
		}

		private GroupViewModel GetBrushesGroup()
		{
			GroupViewModel brushes = new GroupViewModel();
			brushes.Text = "Brushes";

			SplitButtonViewModel split = new SplitButtonViewModel();
			split.Size = ButtonSize.Large;
			split.Text = "Brushes";
			split.LargeImage = GetPath("MVVM/brush1.png");
			brushes.Buttons.Add(split);

			return brushes;
		}

		private ButtonViewModel GetButton(string image, string text, bool large)
		{
			ButtonViewModel b = new ButtonViewModel();
			b.SmallImage = GetPath(string.Format("MVVM/{0}.png", image));
			if (large)
				b.LargeImage = GetPath(string.Format("MVVM/{0}.png", image));
			b.Text = text;

			return b;
		}

		private ButtonViewModel GetButton(string image, string text)
		{
			return GetButton(image, text, true);
		}

		private ButtonViewModel GetSmallButton(string image)
		{
			ButtonViewModel b = new ButtonViewModel();
			b.SmallImage = GetPath(string.Format("MVVM/{0}.png", image));
			return b;
		}

		private ButtonViewModel GetSmallButton(string image, string text)
		{
			ButtonViewModel b = GetSmallButton(image);
			b.Text = text;
			return b;
		}

		#region Internal

		private const string format = "/RibbonView;component/Images/RibbonView/{0}";

		private string GetPath(string fileName)
		{
			string icon = string.Format(format, fileName);

			return icon;
		}

		#endregion Internal
	}
}
