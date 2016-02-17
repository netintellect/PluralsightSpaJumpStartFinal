using System;
using System.Linq;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.Buttons.FirstLook.UIControls
{
    public partial class ActiveStepSelectionControl : UserControl
    {
        public ActiveStepSelectionControl()
        {
            InitializeComponent();
        }

        private bool isActive;
        public bool IsActive
        {
            get
            {
                return this.isActive;
            }

            set
            {
                if (value)
                {
                    this.ActiveStep.Opacity = 1;
                    this.NotActiveStep.Opacity = 0;
                }
                else
                {
                    this.ActiveStep.Opacity = 0;
                    this.NotActiveStep.Opacity = 1;
                }
            }
        }
    }
}