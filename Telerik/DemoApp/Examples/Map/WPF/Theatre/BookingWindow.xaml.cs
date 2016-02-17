using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Map.Theatre
{
    public partial class BookingWindow : RadWindow
    {
        public BookingWindow()
        {
            InitializeComponent();
        }

        private BookingViewModel ViewModel
        {
            get
            {
                return this.DataContext as BookingViewModel;
            }
        }

        private void SubmitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Validation.GetHasError(EmailInput) ||
                Validation.GetHasError(CardNameInput) ||
                Validation.GetHasError(CardNumberInput) ||
                Validation.GetHasError(ExpirationDateInput))
                return;

            (this.DataContext as BookingViewModel).IsFormSubmitted = true;

            this.Close();
        }

        private void BuyButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.ViewModel == null)
                return;

            this.ViewModel.IsBuyOptionSelected = true;
            this.ViewModel.IsReserveOptionSelected = false;
        }

        private void ReserveButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.ViewModel == null)
                return;

            this.ViewModel.IsReserveOptionSelected = true;
            this.ViewModel.IsBuyOptionSelected = false;
        }
    }
}
