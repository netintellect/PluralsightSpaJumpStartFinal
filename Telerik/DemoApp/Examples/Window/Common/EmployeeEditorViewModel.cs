using System.Windows.Input;

namespace Telerik.Windows.Examples.Window.Common
{
	public class EmployeeEditorViewModel
	{
		public Employee Employee { get; private set; }
		public ICommand OKCommand { get; private set; }
		public ICommand CancelCommand { get; private set; }

		public EmployeeEditorViewModel(Employee employee, ICommand okCommand, ICommand cancelCommand)
		{
			this.Employee = employee;
			this.OKCommand = okCommand;
			this.CancelCommand = cancelCommand;
		}
	}
}
