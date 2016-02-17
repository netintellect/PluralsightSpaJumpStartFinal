namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.ComponentModel;
	using System.Windows.Threading;


	/// <summary>
	/// Fetches data of a data source on a regular interval and feeds it to a graphlet.
	/// </summary>
	public abstract class DataAgent : INotifyPropertyChanged
	{
		public string Source { get; private set; }
		#region PropertyChanged

		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Raises the <see cref="PropertyChanged"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
		public void RaisePropertyChanged(string name)
		{
			var handler = this.PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(name));
		}

		#endregion
		public event EventHandler Tick;

		public void RaiseTick()
		{
			var handler = this.Tick;
			if (handler != null) handler(this, EventArgs.Empty);
			this.RaisePropertyChanged("Data");
		}

		private readonly DispatcherTimer timer;

		private TimeSpan updateInterval = TimeSpan.FromMilliseconds(1200);

		/// <summary>
		/// Gets or sets the update interval of the internal timer.
		/// </summary>
		/// <value>
		/// The update interval.
		/// </value>
		public TimeSpan UpdateInterval
		{
			get
			{
				return this.updateInterval;
			}
			set
			{
				if (value == updateInterval) return;
				this.timer.Stop();
				this.timer.Interval = value;
				this.updateInterval = value;
				this.timer.Start();
			}
		}

		protected DataAgent(string source)
		{
			this.Source = source;
			this.Data = new ObservableCollection<int>();
			this.timer = new DispatcherTimer { Interval = UpdateInterval };
			this.timer.Tick += this.TimerOnTick;
			this.timer.Start();
		}

		private void TimerOnTick(object sender, EventArgs eventArgs)
		{
			this.UpdateData();

		}

		protected virtual void UpdateData()
		{
			this.RaiseTick();
		}

		public string Name { get; set; }
		public ObservableCollection<int> Data { get; protected set; }

	}
}