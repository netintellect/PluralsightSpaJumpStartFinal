using Telerik.Windows.Controls;
using Telerik.Windows.Examples.Diagrams.ClassDiagram.ViewModels;

namespace Telerik.Windows.Examples.Diagrams.ClassDiagram
{
    public class MemberViewModel : ViewModelBase
    {
        private string name;
        private AccessType access;
        private KindType kind;
        private string member;
        private bool isEditable;

        public MemberViewModel()
        {
            Member = "Member";
            IsEditable = true;
        }

        public string Name
        {
            get
            { 
                return name; 
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public AccessType Access
        {
            get
            { 
                return access; 
            }
            set
            {
                access = value;
                OnPropertyChanged("Access");
            }
        }

        public KindType Kind
        {
            get
            { 
                return kind;
            }
            set
            {
                kind = value;
                OnPropertyChanged("Kind");
            }
        }

        public string Member
        {
            get
            {
                return member;
            }
            set
            {
                member = value;
                OnPropertyChanged("Member");
            }
        }

        public bool IsEditable
        { 
            get
            { 
                return isEditable; 
            } 
            set 
            { 
                isEditable = value;
                OnPropertyChanged("IsEditable");
            } 
        }
    }

    public enum KindType
    {
        Properties,
        Methods,
        Events,
        Fields
    }
}
