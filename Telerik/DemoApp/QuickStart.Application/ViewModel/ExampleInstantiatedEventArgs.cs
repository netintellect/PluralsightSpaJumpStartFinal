using System;

namespace Telerik.Windows.QuickStart.ViewModel
{
    public class ExampleInstantiatedEventArgs : EventArgs
    {
        public ExampleInstantiatedEventArgs(object instance)
        {
            this.ExampleInstance = instance;
        }

        public object ExampleInstance { get; set; }
    }
}