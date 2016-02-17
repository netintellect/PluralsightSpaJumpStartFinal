using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
    public partial class Example
    {
        private const string AreYouSure = "This will delete all existing data and reload the presets. Are you sure?";

        public Example()
        {
            this.InitializeComponent();
            DataProvider.Current = new StochasticProvider();// new YahooProvider();
            this.Loaded += this.OnLoaded;
            this.SizeChanged += this.OnSizeChanged;
            this.ListenToDiagramEvents();

            // this one keeps trach of what the Page stack is and its relation to the storage
            // It will also automatically load the slides from the storage at instantiation.
            this.PageManager = new PageManager(this.diagram);

            // an MVVM model with IoC would be more nice here, sure.
            this.SlidesList.DataContext = this.PageManager;
            this.NameBlock.DataContext = this.PageManager;

            // the isolated storage to support this.
            //this.PageManager.InitializeFromStorage();

            //listen to application mode changes
            ApplicationManager.ApplicationStateChanged += this.OnApplicationStateChanged;
        }

        private PageManager PageManager { get; set; }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Clip = new RectangleGeometry { Rect = new Rect(0, 0, e.NewSize.Width, e.NewSize.Height) };
        }

        private void ListenToDiagramEvents()
        {
            this.diagram.Deserialized += DiagramOnDeserialized;
            diagram.ItemsChanged += OnDiagramOnItemsChanged;
        }

        private void OnDiagramOnItemsChanged(object sender, DiagramItemsChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                e.NewItems.OfType<HyperlinkShape>().ToList().ForEach(s =>
                {
                    s.PageManager = this.PageManager;
                });
            }
        }

        private void DiagramOnDeserialized(object sender, RadRoutedEventArgs radRoutedEventArgs)
        {
            this.SetMode(ApplicationManager.ApplicationState);
        }

        private void OnApplicationStateChanged(object sender, EventArgs eventArgs)
        {
            if (Application.Current == null)
                return;
            this.SetMode(ApplicationManager.ApplicationState);
        }

        private void SetMode(ApplicationState mode)
        {
            switch (mode)
            {
                case ApplicationState.DesignMode:
                    this.diagram.IsEditable = true;
                    this.diagram.IsResizingEnabled = true;
                    this.diagram.IsDraggingEnabled = true;
                    this.diagram.IsRotationEnabled = true;
                    this.diagram.AllowCopy = true;
                    this.diagram.AllowDelete = true;
                    this.diagram.AllowPaste = true;
                    this.diagram.AllowDrop = true;
                    this.Toolbox.Visibility = Visibility.Visible;
                    this.diagram.SelectionMode = Telerik.Windows.Diagrams.Core.SelectionMode.Extended;

                    break;
                case ApplicationState.RunMode:
                    this.diagram.IsEditable = false;
                    this.diagram.IsResizingEnabled = false;
                    this.diagram.IsDraggingEnabled = false;
                    this.Toolbox.Visibility = Visibility.Collapsed;
                    this.diagram.IsRotationEnabled = false;
                    this.diagram.AllowDrop = false;
                    this.diagram.AllowCopy = false;
                    this.diagram.AllowDelete = false;
                    this.diagram.AllowPaste = false;
                    this.diagram.SelectionMode = Telerik.Windows.Diagrams.Core.SelectionMode.None;

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            this.diagram.SnapX = this.diagram.SnapY = 5;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            if (this.PageManager.CurrentPage == null)
                this.FirstTimeDashboard();

            ApplicationManager.ApplicationState = ApplicationState.RunMode;
        }

        /// <summary>
        /// Adds some material when the storage is empty.
        /// </summary>
        private void FirstTimeDashboard()
        {
            this.PageManager.ImportAllPagesFromAssembly();
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.PageManager.DiagramDoesnShowASlideRightNow)
            {
                RadWindow.Alert("The page flow cannot be save, it's dynamically generated.");
                return;
            }
            this.PageManager.SaveCurrent();
        }

        private void NewButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (PageManager.Pages.Count == 9)
            {
                RadWindow.Alert("The maximum number of pages has been reached, remove another page first.");
                return;
            }
            RadWindow.Prompt("Please provide a new name for the Page:", (o, args) =>
            {
                if (args.DialogResult.GetValueOrDefault())
                {
                    var title = args.PromptResult;
                    if (string.IsNullOrEmpty(title) || title.Trim() == "Info")
                        RadWindow.Alert("The name is not valid.");
                    else
                    {
                        this.PageManager.AddSlide(title);
                        if (this.PageManager.CurrentPage != null)
                            this.PageManager.SaveSlide(this.PageManager.CurrentPage);
                    }
                }
            });
        }

        private void ResetButton_OnClick(object sender, RoutedEventArgs e)
        {
            RadWindow.Confirm(AreYouSure, (o, args) =>
            {
                if (args.DialogResult.HasValue && args.DialogResult.Value)
                {
                    this.PageManager.Reset();
                    this.FirstTimeDashboard();
                }
            });
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            ApplicationManager.ApplicationState = ApplicationManager.ApplicationState == ApplicationState.RunMode ? ApplicationState.DesignMode : ApplicationState.RunMode;

            EditButton.Geometry = ApplicationManager.ApplicationState == ApplicationState.RunMode ? GeometryExtensions.GetPathGeometry("M7,5 L13.125,5 L13.125,11 L7,11 z M2,2 L2,14 L18,14 L18,2 z M0,0 L20,0 L20,16 L0,16 z") : GeometryExtensions.GetPathGeometry("M8,5 L14,8 L8,11 z M2,2 L2,14 L18,14 L18,2 z M0,0 L20,0 L20,16 L0,16 z");
            EditButton.Content = ApplicationManager.ApplicationState == ApplicationState.RunMode ? "edit" : "run";
            SecondaryButtons.Visibility = ApplicationManager.ApplicationState == ApplicationState.RunMode ? Visibility.Collapsed : Visibility.Visible;
            if (ApplicationManager.ApplicationState == ApplicationState.RunMode)
                this.diagram.DeselectAll();

            //switching to run mode should always display a Page, not an hypergraph
            if (ApplicationManager.ApplicationState == ApplicationState.RunMode && this.PageManager.DiagramDoesnShowASlideRightNow)
                this.PageManager.CurrentPage = this.PageManager.Pages[0];
        }

        private void BackwardsButton_OnClick(object sender, RoutedEventArgs e)
        {
            PageManager.MovePrevious();
        }

        private void ForwardsButton_OnClick(object sender, RoutedEventArgs e)
        {
            PageManager.MoveNext();
        }

        private void DeleteMenuItem_OnClick(object sender, RoutedEventArgs radRoutedEventArgs)
        {
            var control = sender as Control;
            if (control == null)
                return;
            var slide = control.DataContext as Page;
            if (slide != null)
                this.PageManager.RemoveSlide(slide.Id);
        }

        private void RadContextMenu_OnOpening(object sender, RoutedEventArgs e)
        {
#if WPF
			e.Handled = ApplicationManager.ApplicationState == ApplicationState.RunMode;
#endif
        }

        private void RenameMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            RadWindow.Prompt("Please specify the new name:", (o, args) =>
            {
                if (args.DialogResult.HasValue && args.DialogResult.Value)
                {
                    var res = args.PromptResult;
                    if (!string.IsNullOrEmpty(res))
                        this.PageManager.CurrentPage.Name = res.Trim();
                }
#if WPF
				e.Handled = true;
#endif
            });
        }

        private void TempSave(object sender, RoutedEventArgs e)
        {
            Telerik.Windows.Controls.Diagrams.Extensions.FileManager manager = new Controls.Diagrams.Extensions.FileManager(this.diagram);

            manager.SaveToFile();
        }
    }
}