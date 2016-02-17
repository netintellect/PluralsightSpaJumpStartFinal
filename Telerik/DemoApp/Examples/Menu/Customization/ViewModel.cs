using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.TransitionControl;

namespace Telerik.Windows.Examples.Menu.Customization
{
	public class ViewModel : ViewModelBase
	{
		private PopularControl selectedItem;
		private ObservableCollection<PopularControl> popularControls;

		public ViewModel()
		{
			this.popularControls = new ObservableCollection<PopularControl>
			{
				new PopularControl{ DisplayName="GridView", DisplayImage="/Menu;component/Images/Customization/Menu_Grid.png", DisplayPage=1},
				new PopularControl{ DisplayName="PivotGrid", DisplayImage="/Menu;component/Images/Customization/Menu_Pivot.png", DisplayPage=2},
				new PopularControl{ DisplayName="Diagrams", DisplayImage="/Menu;component/Images/Customization/Menu_Diagrams.png", DisplayPage=3},
				new PopularControl{ DisplayName="Spreadsheet", DisplayImage="/Menu;component/Images/Customization/Menu_Spreadsheet.png", DisplayPage=4},
				new PopularControl{ DisplayName="ScheduleView", DisplayImage="/Menu;component/Images/Customization/Menu_ScheduleView.png", DisplayPage=5},
				new PopularControl{ DisplayName="RichTextBox", DisplayImage="/Menu;component/Images/Customization/Menu_RTB.PNG", DisplayPage=6},
				new PopularControl{ DisplayName="Map", DisplayImage="/Menu;component/Images/Customization/Menu_Map.png", DisplayPage=7},
				new PopularControl{ DisplayName="ComboBox", DisplayImage="/Menu;component/Images/Customization/Menu_ComboBox.png", DisplayPage=8},
				new PopularControl{ DisplayName="ChartView", DisplayImage="/Menu;component/Images/Customization/Menu_Chart.png", DisplayPage=9},
				new PopularControl{ DisplayName="Docking", DisplayImage="/Menu;component/Images/Customization/Menu_Docking.png", DisplayPage=10}
			};

			this.SelectedItem = this.PopularControls.FirstOrDefault();

			this.SelectPrevControlCommand = new DelegateCommand(this.OnSelectPrevControlCommandExecuted);
			this.SelectNextControlCommand = new DelegateCommand(this.OnSelectNextControlCommandExecuted);
		}

		public ICommand SelectPrevControlCommand { get; set; }
		public ICommand SelectNextControlCommand { get; set; }

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

		public ObservableCollection<PopularControl> PopularControls
		{
			get
			{
				return this.popularControls;
			}
		}

		private void OnSelectPrevControlCommandExecuted(object obj)
		{
			int prevIndex = this.PopularControls.IndexOf(this.SelectedItem) - 1;

			if (prevIndex < 0)
			{
				this.SelectedItem = this.PopularControls[0];
			}
			else
			{
				this.SelectedItem = this.PopularControls[prevIndex];
			}
		}

		private void OnSelectNextControlCommandExecuted(object obj)
		{
			int nextIndex = this.PopularControls.IndexOf(this.SelectedItem) + 1;

			if (nextIndex >= this.PopularControls.Count())
			{
				this.SelectedItem = this.PopularControls[this.PopularControls.Count() - 1];
			}
			else
			{
				this.SelectedItem = this.PopularControls[nextIndex];
			}
		}
	}
}
