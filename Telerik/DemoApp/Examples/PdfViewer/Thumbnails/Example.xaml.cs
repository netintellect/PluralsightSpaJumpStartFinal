﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.FixedDocumentViewersUI.Dialogs;
using Telerik.Windows.Documents.Fixed.UI.Extensibility;

namespace Telerik.Windows.Examples.PdfViewer.Thumbnails
{
    public partial class Example : UserControl
    {
        #region Dependency Properties

        public static readonly DependencyProperty ColumnWidthProperty =
            DependencyProperty.Register("ColumnWidth", typeof(double), typeof(Example), new PropertyMetadata(ColumnWidthChanged));
        public double ColumnWidth
        {
            get { return (double)GetValue(ColumnWidthProperty); }
            set { SetValue(ColumnWidthProperty, value); }
        }

        #endregion


        #region Constructors

        public Example()
        {
            ExtensibilityManager.RegisterFindDialog(new FindDialog());
            InitializeComponent();

#if WPF
            System.Windows.Input.FocusManager.SetIsFocusScope(this.toolbar, false);
#endif
        }

        #endregion


        #region Methods

        private void UncheckButton(RadToggleButton btn)
        {
            if (btn.IsChecked == true)
            {
                btn.IsChecked = false;
            }
        }

        #endregion


        #region EventHandlers

        private void TbCurrentPage_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (e.Key == System.Windows.Input.Key.Enter)
                {
                    textBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
        } 

        private void ChangePageNavigationPanelVisibility(object sender, RoutedEventArgs e)
        {
            Storyboard expand = this.Resources["Expand"] as Storyboard;
            Storyboard collapse = this.Resources["Collapse"] as Storyboard;

            if (this.PageButton.IsChecked == true && expand != null)
            {
                expand.Begin();
            }
            if (this.PageButton.IsChecked == false && collapse != null)
            {
                collapse.Begin();
                UncheckButton(this.PageButton);
            }
        }

        private void CollapseButton_Click(object sender, RoutedEventArgs e)
        {
            Storyboard collapse = this.Resources["Collapse"] as Storyboard;

            if (this.PageButton.IsChecked == true && collapse != null)
            {
                collapse.Begin();
                UncheckButton(this.PageButton);
            }
        }

        private static void ColumnWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as Example;
            control.containerColumn.Width = new GridLength((double)e.NewValue);
        }

        #endregion
    }
}