using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.Buttons.FirstLook.UIControls
{
    /// <summary>
    /// Interaction logic for ReservationStepsControl.xaml
    /// </summary>
    public partial class ReservationStepsControl : UserControl
    {
        public ReservationStepsControl()
        {
            InitializeComponent();
        }

        public byte CurrentStep
        {
            get
            {
                return (byte)GetValue(CurrentStepProperty);
            }
            set
            {

                SetValue(CurrentStepProperty, value);
            }
        }

        public static readonly DependencyProperty CurrentStepProperty =
            DependencyProperty.Register("CurrentStep", typeof(byte), typeof(ReservationStepsControl), new PropertyMetadata((byte)1, OnCurrentStepChanged));

        private static void OnCurrentStepChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var stepControl = d as ReservationStepsControl;
            if (stepControl != null)
            {
                stepControl.OnCurrentStepChanged((byte)e.NewValue);
            }
        }

        private void OnCurrentStepChanged(byte newValue)
        {
            switch (newValue)
            {
                case 1: this.FirstStep.IsActive = true; this.SecondStep.IsActive = false; this.ThirdStep.IsActive = false; break;
                case 2: this.FirstStep.IsActive = false; this.SecondStep.IsActive = true; this.ThirdStep.IsActive = false; break;
                case 3: this.FirstStep.IsActive = false; this.SecondStep.IsActive = false; this.ThirdStep.IsActive = true; break;
                default:
                    break;
            }
        }
    }
}
