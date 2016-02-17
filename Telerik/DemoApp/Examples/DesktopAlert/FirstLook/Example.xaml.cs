using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.DesktopAlert.FirstLook
{
    public partial class Example : UserControl
    {
        private FilterDescriptor unreadDescriptor;
        private ViewModel viewModel;

        public Example()
        {
            InitializeComponent();

            this.viewModel = new ViewModel();
            this.viewModel.ActivateMainWindowAction = new Action(this.ActivateMainWindow);
            this.DataContext = this.viewModel;
            this.configPanel.DataContext = this.viewModel;
            this.InitializeGridViewSettings();
            this.Loaded += (s, e) => { this.viewModel.IsTimerEnabled = true; };
            this.Unloaded += (s, e) => { this.viewModel.IsTimerEnabled = false; };
        }

        private void InitializeGridViewSettings()
        {
            var dateGroupDescriptor = new Telerik.Windows.Data.GroupDescriptor<Email, DateTime, DateTime>();
            dateGroupDescriptor.GroupingExpression = email => email.Received.Date;
            this.gridView.GroupDescriptors.Add(dateGroupDescriptor);

            var dateSortDescriptor = new SortDescriptor<Email, DateTime>();
            dateSortDescriptor.SortingExpression = item => item.Received;
            dateSortDescriptor.SortDirection = System.ComponentModel.ListSortDirection.Descending;
            this.gridView.SortDescriptors.Add(dateSortDescriptor);

            this.unreadDescriptor = new FilterDescriptor
            {
                Member = "Status",
                Operator = FilterOperator.IsEqualTo,
                Value = "Unread",
            };
        }

        private void ActivateMainWindow()
        {
            var mainWindow = Application.Current.MainWindow;

            if (mainWindow != null)
            {
                if (mainWindow.WindowState == WindowState.Minimized)
                {
                    mainWindow.WindowState = WindowState.Normal;
                }

                if (!mainWindow.IsActive)
                {
                    mainWindow.Activate();
                }
            }
        }

        private void OnAllRadioButtonClick(object sender, RoutedEventArgs e)
        {
            this.gridView.FilterDescriptors.Remove(this.unreadDescriptor);
        }

        private void OnUnreadRadioButtonClick(object sender, RoutedEventArgs e)
        {
            this.gridView.FilterDescriptors.Add(this.unreadDescriptor);
        }

        private void OnGridViewSelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (this.viewModel.SelectedEmail != null)
            {
                this.gridView.ScrollIntoView(this.viewModel.SelectedEmail);
                this.richTextBox.Document = this.viewModel.SelectedEmail.Content;
                this.viewModel.SelectedEmail.Status = EmailStatus.Read;
            }
        }
    }
}
