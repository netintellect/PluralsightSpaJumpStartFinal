using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Documents.FormatProviders.Txt;

namespace Telerik.Windows.Examples.DesktopAlert.FirstLook
{
    public class ViewModel : ViewModelBase
    {
        private Random randomNumberGenerator;
        private RadDesktopAlertManager desktopAlertManager;
        private Email selectedEmail;

        // Timer used to send an email through a specific time interval.
        private DispatcherTimer timer;

        public ViewModel()
        {
            this.ContextMenuOpenedCommand = new DelegateCommand(this.OnContextMenuOpenedCommandExecuted);
            this.PauseResumeMailboxCommand = new DelegateCommand(this.OnPauseResumeMailboxCommandExecuted);
            this.ReceivedEmails = EmailService.GetEmails(30);

            this.randomNumberGenerator = new Random();
            this.desktopAlertManager = new RadDesktopAlertManager(AlertScreenPosition.BottomRight, 5d);
        }

        // Command executed whenever GridView ContextMenu is opened.
        public ICommand ContextMenuOpenedCommand { get; set; }

        // Command used to play/pause the receiving of emails in the mailbox.
        public ICommand PauseResumeMailboxCommand { get; set; }

        // Collection with all the received emails.
        public ObservableCollection<Email> ReceivedEmails { get; set; }

        // Action that should activate the MainWindow when needed.
        public Action ActivateMainWindowAction { get; set; }

        // Represents the currently selected email.
        public Email SelectedEmail
        {
            get
            {
                return this.selectedEmail;
            }
            set
            {
                if (this.selectedEmail != value)
                {
                    this.selectedEmail = value;
                    this.OnPropertyChanged(() => this.SelectedEmail);
                }
            }
        }

        public bool IsTimerEnabled
        {
            set
            {
                if ((bool)value)
                {
                    this.EnableTimer();
                }
                else
                {
                    this.DisableTimer();
                    this.desktopAlertManager.CloseAllAlerts();
                }
            }
        }

        private void EnableTimer()
        {
            this.timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(this.randomNumberGenerator.Next(2)) };
            this.timer.Tick += this.OnTimerTick;
            this.timer.Start();
        }

        private void DisableTimer()
        {
            this.timer.Stop();
            this.timer.Tick -= this.OnTimerTick;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            this.timer.Stop();
            this.timer.Interval = TimeSpan.FromSeconds(this.randomNumberGenerator.Next(8));
            this.ReceiveNewEmail();
            this.timer.Start();
        }

        private void ReceiveNewEmail()
        {
            var newEmail = EmailService.GetEmails(1).First();
            newEmail.Status = EmailStatus.Unread;

            var provider = new TxtFormatProvider();
            string emailContentText = provider.Export(newEmail.Content);

            this.desktopAlertManager.ShowAlert(new DesktopAlertParameters
            {
                Header = newEmail.Sender,
                Content = newEmail.Subject + emailContentText,
                Icon = new Image { Source = Application.Current.FindResource("DesktopAlertIcon") as ImageSource, Width = 48, Height = 48 },
                IconColumnWidth = 48,
                IconMargin = new Thickness(10, 0, 20, 0),
                Command = new DelegateCommand(this.OnAlertCommandExecuted),
                CommandParameter = newEmail
            });

            this.ReceivedEmails.Add(newEmail);
        }

        private void OnAlertCommandExecuted(object param)
        {
            var email = param as Email;

            if (email != null)
            {
                this.SelectedEmail = email;

                if (this.ActivateMainWindowAction != null)
                {
                    this.ActivateMainWindowAction.Invoke();
                }
            }
        }

        private void OnContextMenuOpenedCommandExecuted(object param)
        {
            var openEventArgs = (RadRoutedEventArgs)param;
            var menu = (RadContextMenu)openEventArgs.OriginalSource;
            var row = menu.GetClickedElement<GridViewRow>();
            if (row != null)
            {
                row.IsSelected = row.IsCurrent = true;
                GridViewCell cell = menu.GetClickedElement<GridViewCell>();
                if (cell != null)
                {
                    cell.IsCurrent = true;
                }
            }
            else
            {
                menu.IsOpen = false;
            }
        }

        private void OnPauseResumeMailboxCommandExecuted(object param)
        {
            this.timer.IsEnabled = !this.timer.IsEnabled;

            if (timer.IsEnabled)
            {
                this.ReceiveNewEmail();
            }
        }
    }
}
