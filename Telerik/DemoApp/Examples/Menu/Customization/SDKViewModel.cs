using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Menu.Customization
{
	public class SDKViewModel : ViewModelBase
	{
		private PopularControl selectedItem;

		public SDKViewModel()
		{
			this.SDKControls = new ObservableCollection<PopularControl>
			{
				new PopularControl{ DisplayName="Example 1", DisplayImage="/Menu;component/Images/Customization/Image3.png", DisplayPage=1},
				new PopularControl{ DisplayName="Example 2", DisplayImage="/Menu;component/Images/Customization/SalesDashboard.png", DisplayPage=2},
				new PopularControl{ DisplayName="Example 3", DisplayImage="/Menu;component/Images/Customization/Executive Dashboard.png", DisplayPage=3},
				new PopularControl{ DisplayName="Example 4", DisplayImage="/Menu;component/Images/Customization/CRM.PNG", DisplayPage=4},
				new PopularControl{ DisplayName="Example 5", DisplayImage="/Menu;component/Images/Customization/Menu_ThemesGenerator.png", DisplayPage=5}
			};

			this.SelectedItem = this.SDKControls.FirstOrDefault();
		}

		public ObservableCollection<PopularControl> SDKControls { get; set; }
	
		public PopularControl SelectedItem
		{
			get
			{
				return this.selectedItem;
			}
			set
			{
				if (this.selectedItem != value)
				{
					this.selectedItem = value;
					this.OnPropertyChanged(() => this.SelectedItem);
				}
			}
		}
	}
}
