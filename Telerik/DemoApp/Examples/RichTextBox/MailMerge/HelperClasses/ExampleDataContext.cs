using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Telerik.Windows.Examples.RichTextBox.MailMerge.HelperClasses
{
    public class ExampleDataContext : INotifyPropertyChanged
    {
        #region Constants

        private static List<MailMessageInfo> GetMailMessageInfos()
        {
            return new List<MailMessageInfo>()
            {
                new MailMessageInfo()
                {
                    SenderFirstName = "Andrew",
                    SenderLastName = "Fuller", 
                    SenderJobTitle = "Director - Finance",
                    SenderAdress = "908 W. Capital Way",
                    RecipientFirstName = "Maria",
                    RecipientLastName = "Anders",
                    RecipientPhoto = @"/RichTextBox;component/Images/RichTextBox/MailMerge/female1.png",
                    SupportOfficerFirstName = "Matti",
                    SupportOfficerLastName = "Karttunen"
                }, 

                new MailMessageInfo()
                {
                    SenderFirstName = "Nancy",
                    SenderLastName = "Davolio", 
                    SenderJobTitle = "Sales Representative",
                    SenderAdress = "507 - 20th Ave. E.",
                    RecipientFirstName = "Antonio",
                    RecipientLastName = "Taquería",
                    RecipientPhoto = @"/RichTextBox;component/Images/RichTextBox/MailMerge/male1.png",
                    SupportOfficerFirstName = "Paula",
                    SupportOfficerLastName = "Parente"
                }, 

                new MailMessageInfo()
                {
                    SenderFirstName = "Janet",
                    SenderLastName = "Leverling", 
                    SenderJobTitle = "Sales Representative",
                    SenderAdress = "722 Moss Bay Blvd.",
                    RecipientFirstName = "Thomas",
                    RecipientLastName = "Hardy",
                    RecipientPhoto = @"/RichTextBox;component/Images/RichTextBox/MailMerge/male2.png",
                    SupportOfficerFirstName = "Paula",
                    SupportOfficerLastName = "Parente"
                }, 

                new MailMessageInfo()
                {
                    SenderFirstName = "Margaret",
                    SenderLastName = "Peacock", 
                    SenderJobTitle = "Sales Representative",
                    SenderAdress = "4110 Old Redmond Rd.",
                    RecipientFirstName = "Martín",
                    RecipientLastName = "Sommer",
                    RecipientPhoto = @"/RichTextBox;component/Images/RichTextBox/MailMerge/male3.png",
                    SupportOfficerFirstName = "Palle",
                    SupportOfficerLastName = "Ibsen"
                }, 

                new MailMessageInfo()
                {
                    SenderFirstName = "Robert",
                    SenderLastName = "King", 
                    SenderJobTitle = "Sales Representative",
                    SenderAdress = "Edgeham Hollow",
                    RecipientFirstName = "Anabela",
                    RecipientLastName = "Domingues",
                    RecipientPhoto = @"/RichTextBox;component/Images/RichTextBox/MailMerge/female2.png",
                    SupportOfficerFirstName = "Carlos",
                    SupportOfficerLastName = "Hernández"
                }, 

                new MailMessageInfo()
                {
                    SenderFirstName = "Horst",
                    SenderLastName = "Kloss", 
                    SenderJobTitle = "Inside Sales Coordinator",
                    SenderAdress = "4726 - 11th Ave. N.E.",
                    RecipientFirstName = "Anne",
                    RecipientLastName = "Dodsworth",
                    RecipientPhoto = @"/RichTextBox;component/Images/RichTextBox/MailMerge/female3.png",
                    SupportOfficerFirstName = "Sergio",
                    SupportOfficerLastName = "Gutiérrez"
                }
            };
        }

        #endregion

        #region Fields

        private readonly ObservableCollection<MailMessageInfo> mailMessageInfos;

        #endregion

        #region Properties

        public ObservableCollection<MailMessageInfo> MailMessageInfos
        {
            get
            {
                return this.mailMessageInfos;
            }
        }


        private MailMessageInfo selectedMessageInfo;
        public MailMessageInfo SelectedMessageInfo 
        {
            get
            {
                return this.selectedMessageInfo;
            }
            set
            {
                if (this.selectedMessageInfo != value)
                {
                    this.selectedMessageInfo = value;
                    this.OnPropertyChanged("SelectedMessageInfo");
                }
            }
        }

        #endregion

        #region Constructors

        public ExampleDataContext()
        {
            this.mailMessageInfos = new ObservableCollection<MailMessageInfo>(ExampleDataContext.GetMailMessageInfos());           
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
