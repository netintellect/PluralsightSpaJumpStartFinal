using Telerik.Windows.Controls;
using System.Windows.Controls;
using System;
using System.Windows;
#if SILVERLIGHT
using System.Windows.Browser;
#endif
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows.Threading;

namespace Telerik.Windows.Examples.Book.Performance
{
	public partial class Example : UserControl
	{
		IEnumerable data;
		Storyboard ButtonOut, LoadingOut;
		public Example()
		{
			InitializeComponent();
			this.ButtonOut = Resources["ButtonOut"] as Storyboard;
			this.LoadingOut = Resources["LoadingOut"] as Storyboard;
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.ButtonOut.Begin();

			BackgroundWorker worker = new BackgroundWorker();
			worker.DoWork += new DoWorkEventHandler(worker_DoWork);
			worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
			worker.RunWorkerAsync();
		}

		void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			data = Enumerable.Range(0, 1000000);
		}

		void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			book1.ItemsSource = data;

			this.LoadingOut.Begin();
			this.btnFirst.IsEnabled = true;
			this.btnLast.IsEnabled = true;
			this.btnNext.IsEnabled = true;
			this.btnPrevious.IsEnabled = true;
		}

		private void FirstPageButton_Click(object sender, RoutedEventArgs e)
		{
			this.book1.RightPageIndex = 1;
		}

		private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
		{
			this.book1.RightPageIndex = Math.Max(1, (this.book1.RightPageIndex % 2 == 0) ? this.book1.RightPageIndex - 1 : this.book1.RightPageIndex - 2);
		}

		private void NextPageButton_Click(object sender, RoutedEventArgs e)
		{
			this.book1.RightPageIndex = Math.Min(999999, (this.book1.RightPageIndex % 2 == 0) ? this.book1.RightPageIndex + 1 : this.book1.RightPageIndex + 2);
		}

		private void LastPageButton_Click(object sender, RoutedEventArgs e)
		{
			this.book1.RightPageIndex = 999999;
		}
	}
}