using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Menu.Customization
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles click on the <see cref="RadMenu"/>.
        /// Displays the name of the clicked item in the <see cref="LastClickedItem"/>.
        /// In your application you would usually load a new page in the main area.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RadRoutedEventArgs"/>.</param>
        private void Menu_ItemClick(object sender, RadRoutedEventArgs e)
        {
            RadMenuItem menuItem = (e.OriginalSource as RadMenuItem);
            string concatinatedName = GetMenuItemExpandedName(menuItem);
			this.PagePresenter.Content = concatinatedName;
        }

        /// <summary>
        /// Gets the concatinated 'names' retrieved by <see cref="GetMenuItemName"/> of the <paramref name="menuItem"/> and its <see cref="FrameworkElement.Parent"/> <see cref="RadMenuItems"/>.
        /// </summary>
        /// <param name="menuItem">The <see cref="RadMenuItem"/> for which the 'name' is requested.</param>
        /// <returns>The concatinated 'name' string.</returns>
        private static string GetMenuItemExpandedName(RadMenuItem menuItem)
        {
            string concatinatedName = string.Empty;
            while (menuItem != null)
            {
                string name = GetMenuItemName(menuItem);
                if (!string.IsNullOrEmpty(name))
                {
                    concatinatedName = name + (concatinatedName == string.Empty ? string.Empty : " / " + concatinatedName);
                }

                menuItem = menuItem.Parent as RadMenuItem;
            }

            return concatinatedName;
        }

        /// <summary>
        /// Gets the 'name' of a menu item. Which is either: the <see cref="FrameworkElement.Tag"/>, the <see cref="RadMenuItem.Header"/> or null.
        /// </summary>
        /// <param name="menuItem">The <see cref="RadMenuItem"/> for which the 'name' is requested.</param>
        /// <returns>The 'name' string.</returns>
        private static string GetMenuItemName(RadMenuItem menuItem)
        {
            string name = null;
            if (menuItem.Tag != null)
            {
                name = Convert.ToString(menuItem.Tag, CultureInfo.InvariantCulture);
            }
            else if (menuItem.Header != null)
            {
                name = Convert.ToString(menuItem.Header, CultureInfo.InvariantCulture);
            }

            return name;
        }
    }
}
