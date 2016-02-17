using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.RichTextBoxUI;
using Telerik.Windows.Documents.FormatProviders.Xaml;
using Telerik.Windows.Documents.Layout;
using Telerik.Windows.Documents.RichTextBoxCommands;

namespace Telerik.Windows.Examples.RadialMenu.WithRichTextBox
{
    public partial class Example : UserControl
    {
        private const string SampleDocumentPath = "SampleData/RadRichTextBox.xaml";
        private const string BaseImagePath = @"/Telerik.Windows.Controls.RichTextBoxUI;component/Images/MSOffice/Modern/";

        public Example()
        {
            InitializeComponent();
            IconSources.ChangeIconsSet(IconsSet.Modern);

            this.SetupRadialMenuItems();
            this.Editor.AddHandler(RichTextBox.MouseUpEvent, new MouseButtonEventHandler(OnEditorMouseUp), true);
            this.Editor.AddHandler(RichTextBox.MouseDownEvent, new MouseButtonEventHandler(OnEditorMouseDown), true);
        }

        private void OnEditorMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                RadialMenuCommands.Hide.Execute(null, sender as IInputElement);
            }
        }

        private void SetupRadialMenuItems()
        {
            this.RadialMenu.Items.Add(new RadRadialMenuItem
            {
                Header = "Cut",
                Command = RichTextBoxCommands.Cut,
                IconContent = new Image()
                {
                    Source = new BitmapImage(
                        new Uri(
                        BaseImagePath + "16/cut.png", UriKind.Relative))
                },
                CanUserSelect = false
            });
            this.RadialMenu.Items.Add(new RadRadialMenuItem
            {
                Header = "Copy",
                Command = RichTextBoxCommands.Copy,
                IconContent = new Image()
                {
                    Source = new BitmapImage(
                        new Uri(
                        BaseImagePath + "16/copy.png", UriKind.Relative))
                },
                CanUserSelect = false
            });
            this.RadialMenu.Items.Add(new RadRadialMenuItem
            {
                Header = "Paste",
                Command = RichTextBoxCommands.Paste,
                IconContent = new Image()
                {
                    Source = new BitmapImage(
                        new Uri(
                        BaseImagePath + "16/paste.png", UriKind.Relative))
                },
                CanUserSelect = false
            });
            this.RadialMenu.Items.Add(new RadRadialMenuItem
            {
                Header = "Bold",
                Command = RichTextBoxCommands.ToggleBold,
                IconContent = new Image()
                {
                    Source = new BitmapImage(
                        new Uri(
                        BaseImagePath + "16/bold.png", UriKind.Relative))
                }
            });
            var hyperlinkItem = new RadRadialMenuItem
            {
                Header = "Hyperlink",
                Command = RichTextBoxCommands.ShowInsertHyperlinkDialog,
                IconContent = new Image()
                {
                    Source = new BitmapImage(
                        new Uri(
                        BaseImagePath + "16/inserthyperlink.png", UriKind.Relative))
                },
                CanUserSelect = false,
            };
            hyperlinkItem.Click += OnOpenDialogItemClick;
            this.RadialMenu.Items.Add(hyperlinkItem);
            var fontItem = new RadRadialMenuItem
            {
                Header = "Font",
                Command = RichTextBoxCommands.ShowFontPropertiesDialog,
                IconContent = new Image()
                {
                    Source = new BitmapImage(
                        new Uri(
                        BaseImagePath + "16/FontProperties.png", UriKind.Relative))
                },
                CanUserSelect = false
            };
            fontItem.Click += OnOpenDialogItemClick;
            this.RadialMenu.Items.Add(fontItem);
            var paragraphItem = new RadRadialMenuItem
            {
                Header = "Paragraph",
                Command = RichTextBoxCommands.ShowParagraphPropertiesDialog,
                IconContent = new Image()
                {
                    Source = new BitmapImage(
                        new Uri(
                        BaseImagePath + "16/ParagraphProperties.png", UriKind.Relative))
                },
                CanUserSelect = false
            };
            paragraphItem.Click += OnOpenDialogItemClick;
            this.RadialMenu.Items.Add(paragraphItem);
            var alignmentItemLeft = new RadRadialMenuItem
            {
                Header = "Left",
                Command = RichTextBoxCommands.ChangeTextAlignment,
                CommandParameter = "Left",
                IconContent = new Image()
                {
                    Source = new BitmapImage(
                        new Uri(
                        BaseImagePath + "16/alignleft.png", UriKind.Relative))
                }
            };
            var alignmentItemCenter = new RadRadialMenuItem
            {
                Header = "Center",
                Command = RichTextBoxCommands.ChangeTextAlignment,
                CommandParameter = "Center",
                IconContent = new Image()
                {
                    Source = new BitmapImage(
                        new Uri(
                        BaseImagePath + "16/aligncenter.png", UriKind.Relative))
                }
            };
            var alignmentItemRight = new RadRadialMenuItem
            {
                Header = "Right",
                Command = RichTextBoxCommands.ChangeTextAlignment,
                CommandParameter = "Right",
                IconContent = new Image()
                {
                    Source = new BitmapImage(
                        new Uri(
                        BaseImagePath + "16/alignright.png", UriKind.Relative))
                }
            };
            var alignmentItemJustify = new RadRadialMenuItem
            {
                Header = "Justify",
                Command = RichTextBoxCommands.ChangeTextAlignment,
                CommandParameter = "Justify",
                IconContent = new Image()
                {
                    Source = new BitmapImage(
                        new Uri(
                        BaseImagePath + "16/alignjustify.png", UriKind.Relative))
                }
            };
            var alignItem = new RadRadialMenuItem
            {
                Header = "Alignment",
                IconContent = new Image()
                {
                    Source = new BitmapImage(
                        new Uri(
                        BaseImagePath + "16/aligncenter.png", UriKind.Relative))
                },
                CanUserSelect = false
            };
            alignItem.ChildItems.Add(alignmentItemLeft);
            alignItem.ChildItems.Add(alignmentItemCenter);
            alignItem.ChildItems.Add(alignmentItemRight);
            alignItem.ChildItems.Add(alignmentItemJustify);
            this.RadialMenu.Items.Add(alignItem);
        }

        private void OnOpenDialogItemClick(object sender, RadRoutedEventArgs e)
        {
            var item = sender as RadRadialMenuItem;
            var menu = item.Menu;
            this.Dispatcher.BeginInvoke(new Action(delegate()
            {
                RadialMenuCommands.Hide.Execute(null, menu.TargetElement as UIElement);
            }));
        }

        private void OnExampleLoaded(object sender, RoutedEventArgs e)
        {
            RadRadialMenu.EnableQuickMode = true;
            using (Stream stream = Application.GetResourceStream(GetResourceUri(SampleDocumentPath)).Stream)
            {
                this.Editor.Document = new XamlFormatProvider().Import(stream);
            }
            var window = Window.GetWindow(this);
            if (window != null)
            {
                window.Deactivated += this.OnMainWindowDeactivated;
            }
        }

        private void OnExampleUnloaded(object sender, RoutedEventArgs e)
        {
            RadRadialMenu.EnableQuickMode = false;
            var window = Window.GetWindow(this);
            if (window != null)
            {
                window.Deactivated -= this.OnMainWindowDeactivated;
            }
        }

        private void OnMainWindowDeactivated(object sender, EventArgs e)
        {
            RadialMenuCommands.Hide.Execute(null, this.Editor);
        }

        private static Uri GetResourceUri(string resource)
        {
            var assemblyName = new AssemblyName(typeof(Example).Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);

            return resourceUri;
        }

        private void OnEditorMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                var radialMenu = RadRadialMenu.GetRadialContextMenu(this.Editor);
                var mousePoint = e.GetPosition(this.Editor as IInputElement);
                radialMenu.PopupHorizontalOffset = mousePoint.X;
                radialMenu.PopupVerticalOffset = mousePoint.Y;
                RadialMenuCommands.Show.Execute(null, this.Editor);
                this.UpdateItemsSelectedStates(radialMenu);
            }
        }

        private void UpdateItemsSelectedStates(RadRadialMenu radialMenu)
        {
            StyleUIHelper helper = new StyleUIHelper(this.Editor);
            var boldRadialMenuItem = radialMenu.Items.FirstOrDefault(i => i.Header.ToString() == "Bold");
            if (boldRadialMenuItem != null)
            {
                FontWeight? fontWeight = helper.GetFontWeightOfSpanStyle();
                var isBold = fontWeight.HasValue && fontWeight.Value == FontWeights.Bold;
                boldRadialMenuItem.IsSelected = isBold;
            }

            var textAlignmentRadialMenuItem = radialMenu.Items.FirstOrDefault(i => i.Header.ToString() == "Alignment");
            if (textAlignmentRadialMenuItem != null)
            {
                RadTextAlignment? textAlignment = helper.GetTextAlignmentOfParagraphStyle();
                foreach (var item in textAlignmentRadialMenuItem.ChildItems)
                {
                    if (item.Header.ToString() == textAlignment.ToString())
                    {
                        item.IsSelected = true;
                    }
                    else
                    {
                        item.IsSelected = false;
                    }
                }
            }
        }

        private void OnRadialMenuMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.UpdateItemsSelectedStates(sender as RadRadialMenu);
        }
    }
}