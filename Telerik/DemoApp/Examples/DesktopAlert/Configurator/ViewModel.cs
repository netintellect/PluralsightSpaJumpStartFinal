using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;

namespace Telerik.Windows.Examples.DesktopAlert.Configurator
{
    public class ViewModel : ViewModelBase
    {
        private RadDesktopAlertManager selectedDesktopAlertManager;
        private bool isAllAlertsClosingInProgress;

        public ViewModel()
        {
            this.DesktopAlertManagers = this.GetAllDesktopAlertManagers();
            this.ShowAlertCommand = new DelegateCommand(this.OnShowAlertCommandExecuted, (p) => { return !this.isAllAlertsClosingInProgress; });
            this.CloseAllAlertsCommand = new DelegateCommand(this.OnCloseAllAlertsCommandExecuted, this.CloseAllAlertsCommandCanExecute);
            this.HeaderText = "MAIL NOTIFICATION";
            this.ContentText = "Hello, you have received new email notification. Please open the message in order to see more details regarding the status of your request. Thank you.";
            this.ShowDuration = 5000;
            this.CanMove = true;
            this.CanAutoClose = true;
            this.ShowMenuButton = true;
            this.ShowCloseButton = true;

            this.ShowAnimations = AnimationService.GetShowAnimations();
            this.HideAnimations = AnimationService.GetHideAnimations();
        }

        public ICommand ShowAlertCommand { get; set; }
        public ICommand CloseAllAlertsCommand { get; set; }
        public List<AnimationItem> ShowAnimations { get; set; }
        public List<AnimationItem> HideAnimations { get; set; }
        public RadAnimation SelectedShowAnimation { get; set; }
        public RadAnimation SelectedHideAnimation { get; set; }
        public List<RadDesktopAlertManager> DesktopAlertManagers { get; set; }
        public string ContentText { get; set; }
        public string HeaderText { get; set; }
        public int ShowDuration { get; set; }
        public bool CanMove { get; set; }
        public bool CanAutoClose { get; set; }
        public bool ShowMenuButton { get; set; }
        public bool ShowCloseButton { get; set; }

        public RadDesktopAlertManager SelectedDesktopAlertManager
        {
            get
            {
                return this.selectedDesktopAlertManager;
            }

            set
            {
                if (this.selectedDesktopAlertManager != value)
                {
                    this.selectedDesktopAlertManager = value;
                    this.OnPropertyChanged(() => this.SelectedDesktopAlertManager);
                    this.OnPropertyChanged(() => this.AlertsDistance);
                }
            }
        }

        public double AlertsDistance
        {
            get
            {
                if (this.SelectedDesktopAlertManager != null)
                {
                    return this.SelectedDesktopAlertManager.AlertsDistance;
                }
                else
                {
                    return 0d;
                }
            }

            set
            {
                if (this.SelectedDesktopAlertManager != null
                    && this.SelectedDesktopAlertManager.AlertsDistance != value)
                {
                    this.SelectedDesktopAlertManager.AlertsDistance = value;
                    this.OnPropertyChanged(() => this.AlertsDistance);
                }
            }
        }

        public int AlertReorderAnimationDuration
        {
            get
            {
                if (this.SelectedDesktopAlertManager != null)
                {
                    return this.SelectedDesktopAlertManager.AlertsReorderAnimationDuration;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                if (this.SelectedDesktopAlertManager != null
                    && this.SelectedDesktopAlertManager.AlertsReorderAnimationDuration != value)
                {
                    this.SelectedDesktopAlertManager.AlertsReorderAnimationDuration = value;
                    this.OnPropertyChanged(() => this.AlertReorderAnimationDuration);
                }
            }
        }

        internal void CloseAllAlerts()
        {
            this.DesktopAlertManagers.ForEach(m => m.CloseAllAlerts());
        }

        private List<RadDesktopAlertManager> GetAllDesktopAlertManagers()
        {
            var managersList = new List<RadDesktopAlertManager>();
            managersList.Add(new RadDesktopAlertManager(AlertScreenPosition.BottomRight, 5d));
            managersList.Add(new RadDesktopAlertManager(AlertScreenPosition.BottomCenter, 5d));
            managersList.Add(new RadDesktopAlertManager(AlertScreenPosition.BottomLeft, 5d));
            managersList.Add(new RadDesktopAlertManager(AlertScreenPosition.TopRight, 5d));
            managersList.Add(new RadDesktopAlertManager(AlertScreenPosition.TopCenter, 5d));
            managersList.Add(new RadDesktopAlertManager(AlertScreenPosition.TopLeft, 5d));

            return managersList;
        }

        private void OnShowAlertCommandExecuted(object parameter)
        {
            if (this.SelectedDesktopAlertManager != null)
            {
                this.SelectedDesktopAlertManager.ShowAnimation = this.SelectedShowAnimation;
                this.SelectedDesktopAlertManager.HideAnimation = this.SelectedHideAnimation;

                this.SelectedDesktopAlertManager.ShowAlert(new DesktopAlertParameters
                {
                    Header = this.HeaderText,
                    Content = this.ContentText,
                    ShowDuration = this.ShowDuration,
                    CanMove = this.CanMove,
                    CanAutoClose = this.CanAutoClose,
                    Icon = new Image { Source = Application.Current.FindResource("DesktopAlertIcon") as ImageSource, Width = 48, Height = 48 },
                    IconColumnWidth = 48,
                    IconMargin = new Thickness(10, 0, 20, 0),
                    ShowMenuButton = this.ShowMenuButton,
                    ShowCloseButton = this.ShowCloseButton,
                    MenuItemsSource = this.GetMenuItems(),
                    Closed = (s, a) =>
                    {
                        (this.CloseAllAlertsCommand as DelegateCommand).InvalidateCanExecute();
                    }
                });

                (this.CloseAllAlertsCommand as DelegateCommand).InvalidateCanExecute();
            }
        }

        private void OnCloseAllAlertsCommandExecuted(object parameter)
        {
            this.isAllAlertsClosingInProgress = true;
            (this.ShowAlertCommand as DelegateCommand).InvalidateCanExecute();
            this.DesktopAlertManagers.ForEach(manager => manager.CloseAllAlerts());
        }

        private bool CloseAllAlertsCommandCanExecute(object parameter)
        {
            var hasOpenedAlerts = this.DesktopAlertManagers.Any(manager => manager.GetAllAlerts().Any());
            if (this.isAllAlertsClosingInProgress && !hasOpenedAlerts)
            {
                this.isAllAlertsClosingInProgress = false;
                (this.ShowAlertCommand as DelegateCommand).InvalidateCanExecute();
            }

            return hasOpenedAlerts;
        }

        private IEnumerable GetMenuItems()
        {
            var menuItems = new List<DesktopAlertMenuItem>();
            menuItems.Add(new DesktopAlertMenuItem { Header = "Item 1" });
            menuItems.Add(new DesktopAlertMenuItem { Header = "Item 2", IsCheckable = true, IsChecked = true });
            menuItems.Add(new DesktopAlertMenuItem { IsSeparator = true });
            menuItems.Add(new DesktopAlertMenuItem { Header = "Item 3" });

            return menuItems;
        }
    }
}
