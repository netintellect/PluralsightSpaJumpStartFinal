using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Documents;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.PivotGrid.SampleData
{
    public sealed class RandomOrdersGenerator : ViewModelBase
    {
        private CancellationTokenSource cancellationTokenSource;
        private Task generationTask;

        private IList<Order> _Orders;

        private bool _IsGenerating;
        private bool _IsLoaded;
        private int _Progress;

        public RandomOrdersGenerator()
        {
            this._IsLoaded = false;
            this._IsGenerating = false;
            this._Progress = 0;
        }

        public event ProgressChangedEventHandler ProgressChanged;

        public IList<Order> Orders
        {
            get
            {
                return this._Orders;
            }
            private set
            {
                if (this._Orders != value)
                {
                    this._Orders = value;
                    ViewModelBase.InvokeOnUIThread(this.NotifyOrdersChanged);
                }
            }
        }

        public bool IsGenerating
        {
            get
            {
                return this._IsGenerating;
            }
            private set
            {
                if (this._IsGenerating != value)
                {
                    this._IsGenerating = value;
                    ViewModelBase.InvokeOnUIThread(this.NotifyIsGeneratingChanged);
                }
            }
        }

        public int Progress
        {
            get
            {
                return this._Progress;
            }
            private set
            {
                if (this._Progress != value)
                {
                    this._Progress = value;
                    ViewModelBase.InvokeOnUIThread(this.NotifyProgressChanged);
                }
            }
        }

        public bool IsLoaded
        {
            get
            {
                return this._IsLoaded;
            }
            private set
            {
                if (this._IsLoaded != value)
                {
                    this._IsLoaded = value;
                    ViewModelBase.InvokeOnUIThread(this.NotifyIsLoadedChanged);
                }
            }
        }

        public void GenerateOrders()
        {
            if (!this.IsGenerating && !this.IsLoaded)
            {
                TaskFactory factory = new TaskFactory();
                this.cancellationTokenSource = new CancellationTokenSource();
                generationTask = factory.StartNew(new Action(this.GenerationTask), cancellationTokenSource.Token);
                this.IsGenerating = true;
            }
        }

        public void Cancel()
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
        }

        private void GenerationTask()
        {
            CancellationToken token = cancellationTokenSource.Token;

            List<Order> localOrders = new List<Order>();

            List<string> advertisements = new List<string>(3);
            List<string> products = new List<string>(4);
            List<string> promotions = new List<string>(2);

            advertisements.Add("Direct Mail");
            advertisements.Add("Magazine");
            advertisements.Add("Newspaper");

            products.Add("Copy Holder");
            products.Add("Glare Filter");
            products.Add("Mouse Pad");
            products.Add("Printer Stand");

            promotions.Add("1 Free with 10");
            promotions.Add("Extra Discount");

            Random random = new Random(1);
            for (int i = 0; i < 5000000; i++)
            {
                if (i % 5000 == 0)
                {
                    OnProgressChanged((int)i / 50000);
                    token.ThrowIfCancellationRequested();
                }
                Order order = new Order()
                {
                    Net = i % (30 * 365),
                    Date = new DateTime(random.Next(2000, 2032), random.Next(1, 13), random.Next(1, 28)),
                    Advertisement = advertisements[random.Next(0, 3)],
                    Product = products[random.Next(0, 4)],
                    Promotion = promotions[random.Next(0, 2)],
                    Quantity = random.Next(10, 120)
                };
                localOrders.Add(order);
            }
            this.IsLoaded = true;
            this.IsGenerating = false;
            this.Orders = localOrders;
            this.OnProgressChanged(100);
        }

        private void NotifyOrdersChanged()
        {
            this.OnPropertyChanged("Orders");
        }

        private void NotifyIsGeneratingChanged()
        {
            this.OnPropertyChanged("IsGenerating");
        }

        private void NotifyIsLoadedChanged()
        {
            this.OnPropertyChanged("IsLoaded");
        }

        private void NotifyProgressChanged()
        {
            this.OnPropertyChanged("Progress");
        }

        private void OnProgressChanged(int progress)
        {
            this.Progress = progress;
            if (this.ProgressChanged != null)
            {
                this.ProgressChanged(this, new ProgressChangedEventArgs(progress, null));
            }
        }
    }
}
