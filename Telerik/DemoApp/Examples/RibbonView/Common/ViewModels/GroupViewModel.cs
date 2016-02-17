using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.RibbonView.MVVM.ViewModels
{
    public class GroupViewModel : ViewModelBase
    {
        private string text;

		private ObservableCollection<ButtonViewModel> buttons;

		public GroupViewModel()
		{
			buttons = new ObservableCollection<ButtonViewModel>();
		}

		public ObservableCollection<ButtonViewModel> Buttons
		{
			get
			{
				return buttons;
			}
		}

        /// <summary>
        ///     Gets or sets Text.
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                if (this.text != value)
                {
                    this.text = value;
					this.OnPropertyChanged("Text");
                }
            }
        }  
    }
}
