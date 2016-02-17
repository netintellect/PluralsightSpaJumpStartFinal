using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.ComponentModel;

namespace Telerik.Windows.Examples.DateTimePicker.FirstLook
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

		private void BookHall_Click(object sender, RoutedEventArgs e)
		{
			if ((this.CheckInDate.SelectedValue == null) || (this.CheckOutDate.SelectedValue == null) || this.HallsCombo.SelectedValue == null ||
				this.CheckInDate.SelectedDate.Value.Date < DateTime.Today || this.CheckOutDate.SelectedValue <= this.CheckInDate.SelectedValue)
			{
				HideElement(DefaultText, "HideDefaultAnimation");
				HideElement(bookedHallTransition, "HideTransitionAnimation");
				ShowElement(NoSelectionText,"ShowInfoAnimation");
			}
			else
			{
				HideElement(DefaultText, "HideDefaultAnimation");
				ShowSelectedHall();			
			}
		}

		private void ShowSelectedHall()
		{
			Binding sItemBinding = new Binding("SelectedItem");
			sItemBinding.Source = this.HallsCombo;
			sItemBinding.Mode = BindingMode.TwoWay;
			this.HallsList.SetBinding(ListBox.SelectedItemProperty, sItemBinding);

			HideElement(NoSelectionText, "HideInfoAnimation");

			this.bookedHallTransition.Content = HallsList.SelectedItem;
			ShowElement(bookedHallTransition, "ShowTransitionAnimation");
		}

		public void ShowElement(UIElement el, string animation)
		{
			if (el.Opacity == 0)
			{
				(this.Resources[animation] as Storyboard).Begin();
			}
		}

		public void HideElement(UIElement el, string animation)
		{
			if (el.Opacity == 1)
			{
				(this.Resources[animation] as Storyboard).Begin();	
			}			
		}
    }
}
