using System;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public static class ApplicationManager
	{
		public static event EventHandler ApplicationStateChanged;

		public static void OnApplicationStateChanged()
		{
			var handler = ApplicationStateChanged;
			if (handler != null) handler(null, EventArgs.Empty);
		}

		private static ApplicationState applicationState = ApplicationState.DesignMode;

		public static ApplicationState ApplicationState
		{
			get
			{
				return applicationState;
			}
			set
			{
				if (value == applicationState) return;
				applicationState = value;
				OnApplicationStateChanged();
			}
		}
	}
}
