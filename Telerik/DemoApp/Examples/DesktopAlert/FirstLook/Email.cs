using System;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Model;

namespace Telerik.Windows.Examples.DesktopAlert.FirstLook
{
    // Enum for the different statuses of the email.
    public enum EmailStatus
    {
        Read = 0,
        Unread = 1
    }

    // The Email class.
    public class Email: ViewModelBase
    {
        private EmailStatus status;

        public Email(string sender, string recipient, string subject, DateTime received)
        {
            this.Sender = sender;
            this.Recipient = recipient;
            this.Subject = subject;
            this.Received = received;
        }

        // The content of the email.
        public RadDocument Content { get; set; }

        // The sender of the email.
        public string Sender { get; set; }

        // The recipient of the email.
        public string Recipient { get; set; }

        // The subject of the email.
        public string Subject { get; set; }

        // The DateTime of the moment the email has been received.
        public DateTime Received { get; set; }

        // The status of the email.
        public EmailStatus Status
        {
            get
            {
                return this.status;
            }

            set
            {
                if (this.status != value)
                {
                    this.status = value;
                    this.OnPropertyChanged(() => this.Status);
                }
            }
        }
    }
}
