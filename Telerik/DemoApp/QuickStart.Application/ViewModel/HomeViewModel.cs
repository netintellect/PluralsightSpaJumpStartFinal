using System;
using System.Linq;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;
using Telerik.Windows.Controls.QuickStart.Analytics;

namespace Telerik.Windows.QuickStart.ViewModel
{
	public class HomeViewModel : QuickStartViewModelBase
	{
		private bool isDialogOverlayOpen;
		private DialogOverlayState dialogOverlayState;

		public HomeViewModel(INotifyUser ownerView)
			: base(ownerView)
		{
            this.OpenAnalyticsSettingsDialogCommand = new DelegateCommand(this.OnOpenAnalyticsSettingsDialogCommandExecuted, OpenAnalyticsSettingsDialogCommandCanExecuted);
			this.CloseDialogOverlayAndNavigateCommand = new DelegateCommand(this.OnCloseDialogOverlayAndNavigateCommandExecuted);
		}

		public ICommand OpenAnalyticsSettingsDialogCommand { get; private set; }
		public ICommand CloseDialogOverlayAndNavigateCommand { get; private set; }

		public bool HasNewControls
		{
			get
			{
				return this.Data.NewControlsNonTouch.Count() > 0;
			}
		}

		public bool IsDialogOverlayOpen
		{
			get
			{
				return this.isDialogOverlayOpen;
			}
			set
			{
				if (this.isDialogOverlayOpen != value)
				{
					this.isDialogOverlayOpen = value;
					this.OnPropertyChanged("IsDialogOverlayOpen");
				}
			}
		}

		public DialogOverlayState DialogOverlayState
		{
			get
			{
				return this.dialogOverlayState;
			}
			set
			{
				if (this.dialogOverlayState != value)
				{
					this.dialogOverlayState = value;
					this.OnPropertyChanged("DialogOverlayState");
				}
			}
		}

		private bool HasStartupDialogShownOnce
		{
			get
			{
				return SettingsManager.Instance.HasStartupDialogShown;
			}
			set
			{
				SettingsManager.Instance.HasStartupDialogShown = value;
			}
		}

		public void TryOpenStartupDialog()
		{
            if (!this.HasStartupDialogShownOnce && !EqatecMonitor.IsAnalyticsDisabledInRegistry)
			{
				this.DialogOverlayState = DialogOverlayState.StartupDialog;
				this.IsDialogOverlayOpen = true;
			}
		}

		private void OnCloseDialogOverlayAndNavigateCommandExecuted(object parameter)
		{
			this.IsDialogOverlayOpen = false;
			this.HasStartupDialogShownOnce = true;
			if (parameter != null)
			{
				this.NavigateCommand.Execute(parameter);
			}
		}

		private void OnOpenAnalyticsSettingsDialogCommandExecuted(object obj)
		{
            if (!EqatecMonitor.IsAnalyticsDisabledInRegistry)
            {
                this.DialogOverlayState = DialogOverlayState.StartupDialog;
                this.IsDialogOverlayOpen = true;
            }
		}

        private bool OpenAnalyticsSettingsDialogCommandCanExecuted(object obj)
        {
            return !EqatecMonitor.IsAnalyticsDisabledInRegistry;
        }
	}
}