using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.TransitionControl;

namespace Telerik.Windows.Examples.TransitionControl.FirstLook
{
	public class TransitionItems : ViewModelBase, ISupportInitialize
	{
		public TransitionItems()
		{
			this.SelectNext = new DelegateCommand(this.SelectNextItem);
			this.currentTransitionIndex = 0;

			this._Persons = new ObservableCollection<Person>();
			this._Transitions = new ObservableCollection<TransitionSet>();
		}

		private int currentTransitionIndex;

		private void SelectNextItem(object param)
		{
			if (this.Persons != null && this.Persons.Count() > 1)
			{
				this.SelectTransition();

				int index = this.Persons.IndexOf(this.SelectedPerson);
				index++;
				if (index >= this.Persons.Count())
				{
					index = 0;
				}
				this.SelectedPerson = this.Persons[index];
			}
		}

		private void SelectTransition()
		{
			if (this.Transitions != null && this.Transitions.Count() > 0)
			{
				this.currentTransitionIndex++;
				if (this.currentTransitionIndex >= this.Transitions.Count())
				{
					this.currentTransitionIndex = 0;
				}
				this.CurrentTransition = this.Transitions[this.currentTransitionIndex].Transition;
			}
			else
			{
				this.CurrentTransition = null;
			}
		}

		private TransitionProvider _CurrentTransition;
		public TransitionProvider CurrentTransition
		{
			get
			{
				return this._CurrentTransition;
			}
			private set
			{
				if (value != this._CurrentTransition)
				{
					this._CurrentTransition = value;
					this.OnPropertyChanged("CurrentTransition");
				}
			}
		}

		private ICommand _SelectNext;
		public ICommand SelectNext
		{
			get
			{
				return this._SelectNext;
			}
			private set
			{
				this._SelectNext = value;
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
				if ((object)this._SelectedPerson != value)
				{
					this._SelectedPerson = value;
					this.OnPropertyChanged("SelectedPerson");
				}
			}
		}


		private ObservableCollection<TransitionSet> _Transitions;
		public ObservableCollection<TransitionSet> Transitions
		{
			get
			{
				return this._Transitions;
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

		public void BeginInit()
		{
		}

		public void EndInit()
		{
			if ((object)this.Persons != null && this.Persons.Count() > 0)
			{
				this.SelectedPerson = this.Persons.FirstOrDefault();
			}
		}
	}
}
