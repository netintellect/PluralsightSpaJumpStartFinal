using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.TransitionControl.Configurator
{
	public class ConfiguratorViewModel : ViewModelBase, ISupportInitialize
	{
		public ConfiguratorViewModel()
		{
			this._Transitions = new ObservableCollection<TransitionItem>();
			this._Persons = new ObservableCollection<Person>();

			this._SelectNextPerson = new DelegateCommand(this.SelectNextPersonAction);
			this._SelectPreviousPerson = new DelegateCommand(this.SelectePreviousPersonAction);
		}

		private void SelectNextPersonAction(object param)
		{
			int index = this.Persons.IndexOf(this.SelectedPerson) + 1;
			if (index >= this.Persons.Count())
			{
				this.SelectedPerson = this.Persons.FirstOrDefault();
			}
			else
			{
				this.SelectedPerson = this.Persons[index];
			}
		}

		private void SelectePreviousPersonAction(object param)
		{
			int index = this.Persons.IndexOf(this.SelectedPerson) - 1;
			if (index < 0)
			{
				this.SelectedPerson = this.Persons.LastOrDefault();
			}
			else
			{
				this.SelectedPerson = this.Persons[index];
			}
		}

		private ICommand _SelectNextPerson;
		public ICommand SelectNextPerson
		{
			get
			{
				return this._SelectNextPerson;
			}
		}


		private ICommand _SelectPreviousPerson;
		public ICommand SelectPreviousPerson
		{
			get
			{
				return this._SelectPreviousPerson;
			}
		}


		private Person _SelectedPerson;
		public Person SelectedPerson
		{
			get
			{
				return this._SelectedPerson;
			}
			set
			{
				if ((object)(this._SelectedPerson) != value)
				{
					this._SelectedPerson = value;
					this.OnPropertyChanged("SelectedPerson");
				}
			}
		}

		private ObservableCollection<Person> _Persons;
		public ObservableCollection<Person> Persons
		{
			get
			{
				return this._Persons;
			}
		}

		private TransitionItem _SelectedTransition;
		public TransitionItem SelectedTransition
		{
			get
			{
				return this._SelectedTransition;
			}
			set
			{
				if ((object)(this._SelectedTransition) != value)
				{
					this._SelectedTransition = value;
					this.OnPropertyChanged("SelectedTransition");
				}
			}
		}

		private ObservableCollection<TransitionItem> _Transitions;
		public ObservableCollection<TransitionItem> Transitions
		{
			get
			{
				return this._Transitions;
			}
		}

		public void BeginInit()
		{
		}

		public void EndInit()
		{
			this.SelectedTransition = this.Transitions.FirstOrDefault();
			this.SelectedPerson = this.Persons.FirstOrDefault();
		}
	}
}
