using System.Windows;
using System.Windows.Automation;
using Telerik.Windows.Controls;
using System.Linq;
using Telerik.Windows.Persistence;
using Telerik.Windows.Persistence.SerializationMetadata;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.PersistenceFramework.TileViewConfigurator
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		System.IO.Stream stream;

		public Example()
		{
			InitializeComponent();
			this.BindConfigurationPanel();

			var viewModel = new MainViewModel();
			foreach (Person item in viewModel.Items)
			{
				RadTileViewItem tileViewItem = new RadTileViewItem();
				tileViewItem.Content = item;
				this.tileView.Items.Add(tileViewItem);
			}
			this.EnsureLoadState();
		}

		private void BindConfigurationPanel()
		{
			ConfiguratorViewModel model = new ConfiguratorViewModel();
			this.ColumnWidth.ItemsSource = model.ColumnWidthsList;
			this.RowHeight.ItemsSource = model.RowHeightsList;
			this.minColumnWidth.ItemsSource = model.MinColumnWidths;
			this.minRowHeight.ItemsSource = model.MinRowHeights;
		}

		private void OnSave(object sender, System.Windows.RoutedEventArgs e)
		{
			SerializationMetadataCollection collection = new SerializationMetadataCollection();
			foreach (var item in metadataOptions.Items.OfType<CheckBox>().Where(i => i.IsChecked.GetValueOrDefault()))
			{
				PropertyNameMetadata metadata = new PropertyNameMetadata();
				metadata.Condition = SerializationMetadataCondition.Only;
				metadata.IsRecursive = true;
				metadata.SearchType = MetadataSearchCriteria.PropertyName;
				metadata.Expression = "^" + item.Content.ToString() + "$";
				collection.Add(metadata);
			}
			PersistenceManager.SetSerializationOptions(this.tileView, collection);
			PersistenceManager manager = new PersistenceManager();
			this.stream = manager.Save(this.tileView);
			this.EnsureLoadState();
		}

		private void OnLoad(object sender, System.Windows.RoutedEventArgs e)
		{
			this.stream.Position = 0L;
			PersistenceManager manager = new PersistenceManager();
			manager.Load(this.tileView, this.stream);
			this.EnsureLoadState();
		}

		private bool CanLoad()
		{
			return this.stream != null && this.stream.Length > 0;
		}

		private void EnsureLoadState()
		{
			this.buttonLoad.IsEnabled = this.CanLoad();
		}

		private void TileViewTileStateChanged(object sender, RadRoutedEventArgs e)
		{
			RadTileViewItem item = e.OriginalSource as RadTileViewItem;
			if (item != null)
			{
				RadFluidContentControl fluid = item.ChildrenOfType<RadFluidContentControl>().FirstOrDefault();
				if (fluid != null)
				{
					switch (item.TileState)
					{
						case TileViewItemState.Maximized:
							fluid.State = FluidContentControlState.Large;
							break;
						case TileViewItemState.Minimized:
							fluid.State = FluidContentControlState.Small;
							break;
						case TileViewItemState.Restored:
							fluid.State = FluidContentControlState.Normal;
							break;
						default:
							break;
					}
				}
			}
		}
	}
}