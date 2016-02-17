using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Telerik.Windows.Controls;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls.Animation;

namespace Telerik.Windows.Examples.TreeView.Performance
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		private readonly BackgroundWorker dataProvider = new BackgroundWorker();
		private readonly ObservableCollection<FolderViewModel> viewModel = new ObservableCollection<FolderViewModel>();

		public Example()
		{
			this.MergeResourceDictionaries();
			InitializeComponent();
			AnimationManager.AnimationSpeedRatio = 2;
		}

		private void MergeResourceDictionaries()
		{
			try
			{
				ResourceDictionary dict = new ResourceDictionary();
#if WPF
				dict.Source = new Uri("TreeView;component/Performance/TreeViewTemplates_WPF.xaml", UriKind.RelativeOrAbsolute);
#else
				Application.LoadComponent(dict, new Uri("TreeView;component/Performance/TreeViewTemplates_SL.xaml", UriKind.RelativeOrAbsolute));
#endif
				this.Resources.MergedDictionaries.Add(dict);
			}
			catch
			{
			}
		}

		private void LoadButtonClick(object sender, System.Windows.RoutedEventArgs e)
		{
			this.HideLoadingButton();

			this.dataProvider.DoWork += this.BackgroundDataProvider_DoWork;
			this.dataProvider.RunWorkerCompleted += this.BackgroundDataProvider_Completed;
			this.dataProvider.RunWorkerAsync();

			this.xLoadingIndicator.IsBusy = true;
		}

		private void HideLoadingButton()
		{
			var decreaseOpacity = new DoubleAnimation()
			{
				To = 0.0,
				FillBehavior = FillBehavior.HoldEnd,
				Duration = TimeSpan.FromSeconds(.3)
			};

			var hideAnimation = new Storyboard();
			hideAnimation.Completed += (_, __) =>
			{
				this.xLoadButton.Visibility = System.Windows.Visibility.Collapsed;
			};
			hideAnimation.Children.Add(decreaseOpacity);
			Storyboard.SetTarget(decreaseOpacity, this.xLoadButton);
			Storyboard.SetTargetProperty(decreaseOpacity, new PropertyPath(UIElement.OpacityProperty));
			hideAnimation.Begin();
		}

		private void BackgroundDataProvider_DoWork(object sender, DoWorkEventArgs e)
		{
			int parentsCount = 1000 * 1000;
			FolderViewModel.FoldersCount = 0;
			for (int i = 0; i < parentsCount; i++)
			{
				FolderViewModel folder = new FolderViewModel(0);
				this.viewModel.Add(folder);
			}
		}

		private void BackgroundDataProvider_Completed(object sender, RunWorkerCompletedEventArgs e)
		{
			this.dataProvider.DoWork -= this.BackgroundDataProvider_DoWork;
			this.dataProvider.RunWorkerCompleted -= this.BackgroundDataProvider_Completed;

			this.treeView.ItemsSource = this.viewModel;

			this.xLoadingIndicator.IsBusy = false;
			this.xLoadingIndicator.Visibility = System.Windows.Visibility.Collapsed;
		}

		private void TreeView_ItemPrepared(object sender, RadTreeViewItemPreparedEventArgs e)
		{
			e.PreparedItem.IsLoadOnDemandEnabled = e.PreparedItem.Level < 3 && !(e.PreparedItem.Item is FileViewModel);
		}

		private void TreeView_LoadOnDemand(object sender, Telerik.Windows.RadRoutedEventArgs e)
		{
			var itemContainer = e.OriginalSource as RadTreeViewItem;
			var item = itemContainer.Item;
			var folder = item as FolderViewModel;

			if (folder != null && itemContainer.Level < 3)
			{
				var timer = new DispatcherTimer();
				timer.Interval = TimeSpan.FromSeconds(1);
				timer.Tick += (_, __) =>
				{
					timer.Stop();
					folder.BuildChildren();
				};
				timer.Start();
			}
			else
			{
				itemContainer.IsLoadOnDemandEnabled = false;
			}
		}
	}
}

