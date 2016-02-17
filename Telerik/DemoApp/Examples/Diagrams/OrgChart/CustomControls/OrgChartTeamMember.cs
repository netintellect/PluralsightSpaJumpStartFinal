using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.DragDrop;
using Telerik.Windows.Examples.Diagrams.OrgChart.ViewModel;

namespace Telerik.Windows.Examples.Diagrams.OrgChart.CustomControls
{
    public class OrgChartTeamMember : ListBoxItem
    {
        public static DependencyProperty ScaleLevelProperty = 
            DependencyProperty.Register("ScaleLevel", typeof(double), typeof(OrgChartTeamMember), null);
        public static readonly DependencyProperty IsSettingsWheelVisibleProperty =
            DependencyProperty.Register("IsSettingsWheelVisible", typeof(bool), typeof(OrgChartTeamMember), new PropertyMetadata(false));
         public static readonly DependencyProperty IsButtonOpenProperty =
            DependencyProperty.Register("IsButtonOpen", typeof(bool), typeof(OrgChartTeamMember), new PropertyMetadata(false));     

#if WPF
        static OrgChartTeamMember()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(OrgChartTeamMember), new FrameworkPropertyMetadata(typeof(OrgChartTeamMember)));
        }

        protected override void OnPreviewMouseRightButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnPreviewMouseRightButtonDown(e);
            e.Handled = true;
        }
#endif

        public OrgChartTeamMember()
        {
            this.Loaded += this.OrgChartNodeMemberItem_Loaded;
            this.Unloaded += this.OrgChartNodeMemberItem_Unloaded;
        }

        public double ScaleLevel
        {
            get
            {
                return (double)this.GetValue(OrgChartTeamMember.ScaleLevelProperty);
            }
            set
            {
                this.SetValue(OrgChartTeamMember.ScaleLevelProperty, value);
            }
        }

        public bool IsSettingsWheelVisible
        {
            get
            {
                return (bool)GetValue(OrgChartTeamMember.IsSettingsWheelVisibleProperty);
            }
            set
            {
                SetValue(OrgChartTeamMember.IsSettingsWheelVisibleProperty, value);
            }
        }

        public bool IsButtonOpen
        {
            get { return (bool)GetValue(IsButtonOpenProperty); }
            set { SetValue(IsButtonOpenProperty, value); }
        }

        protected override void OnMouseEnter(System.Windows.Input.MouseEventArgs e)
        {
            this.IsSettingsWheelVisible = true;
        }

        protected override void OnMouseLeave(System.Windows.Input.MouseEventArgs e)
        {
#if !WPF
            if (!this.IsButtonOpen)
            {
                this.IsSettingsWheelVisible = false;
            }
#else
            this.IsSettingsWheelVisible = false;
#endif
        }

        private void OrgChartNodeMemberItem_Loaded(object sender, RoutedEventArgs e)
        {
            DragDropManager.AddDragInitializeHandler(this, this.OnDragInitialized, true);
        }

        private void OrgChartNodeMemberItem_Unloaded(object sender, RoutedEventArgs e)
        {
            DragDropManager.RemoveDragInitializeHandler(this, this.OnDragInitialized);
        }

        private void OnDragInitialized(object sender, DragInitializeEventArgs e)
        {
            e.DragVisual = new OrgChartDragView() { DataContext = this.DataContext };
            e.DragVisualOffset = new Point(e.RelativeStartPoint.X * (1 - this.ScaleLevel), e.RelativeStartPoint.Y * (1 - this.ScaleLevel));
        }
    }
}