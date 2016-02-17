using System.Windows;

namespace Telerik.Windows.Examples.Expander.FirstLook
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();
		}

		private void EnableAnimation_Checked(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            if (this.radExpander == null)
			{
				return;
			}
            System.Windows.Controls.CheckBox checkbox = sender as System.Windows.Controls.CheckBox;
            if (checkbox != null)
            {
                bool isChecked = checkbox.IsChecked == true;
                Telerik.Windows.Controls.Animation.AnimationManager.SetIsAnimationEnabled(this.radExpander, isChecked);
            }
#endif
		}

        private void OnDirectionsClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.RadioButton radioButton = e.OriginalSource as System.Windows.Controls.RadioButton;
            if(radioButton != null)
            {
                Telerik.Windows.Controls.ExpandDirection expandDirection = (Telerik.Windows.Controls.ExpandDirection)System.Enum.Parse(typeof(Telerik.Windows.Controls.ExpandDirection), radioButton.Content.ToString(), true);
                this.radExpander.ExpandDirection = expandDirection;

				switch (expandDirection)
				{
					case Telerik.Windows.Controls.ExpandDirection.Down:
						this.radExpander.VerticalContentAlignment = System.Windows.VerticalAlignment.Top;
						this.radExpander.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
						break;
					case Telerik.Windows.Controls.ExpandDirection.Left:
						this.radExpander.VerticalContentAlignment = System.Windows.VerticalAlignment.Stretch;
						this.radExpander.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
						break;
					case Telerik.Windows.Controls.ExpandDirection.Right:
						this.radExpander.VerticalContentAlignment = System.Windows.VerticalAlignment.Stretch;
						this.radExpander.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
						break;
					case Telerik.Windows.Controls.ExpandDirection.Up:
						this.radExpander.VerticalContentAlignment = System.Windows.VerticalAlignment.Bottom;
						this.radExpander.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
						break;
					default:
						break;
				}
            }
        }
	}
}
