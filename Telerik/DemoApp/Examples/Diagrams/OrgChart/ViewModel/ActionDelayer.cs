using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace Telerik.Windows.Examples.Diagrams.OrgChart.ViewModel
{
    public class ActionDelayer
    {
        private readonly DispatcherTimer delayTimer;
        private Action actionToExecute;

        public ActionDelayer()
        {
            this.delayTimer = new DispatcherTimer();
            this.delayTimer.Tick += this.ExecuteDelayedAction;
        }

        public void Execute(Action action, TimeSpan delay)
        {
            this.actionToExecute = action;
            this.delayTimer.Interval = delay;
            this.delayTimer.Start();
        }

        public void Cancel()
        {
            this.delayTimer.Stop();
        }

        private void ExecuteDelayedAction(object sender, EventArgs e)
        {
            this.delayTimer.Stop();
            if (this.actionToExecute != null)
            {
                this.actionToExecute();
            }
        }
    }
}