using System;
using System.Configuration;
using System.Linq;
using EQATEC.Analytics.Monitor;

namespace Telerik.Windows.Controls.QuickStart.Analytics
{
	public class EqatecMonitor
	{
		private static readonly EqatecMonitor instance = new EqatecMonitor();
		private static IAnalyticsMonitor monitor;
		private static bool isTrackingEnabled;
		
		private const string EqatecProductKey = "eqatecProductKey";
		
		public static EqatecMonitor Instance
		{
			get
			{
				return instance;
			}
		}

        public static bool IsAnalyticsDisabledInRegistry
        {
            get
            {
#if WPF
                return AnalyticsConfiguration.IsAnalyticsDisabledInRegistry;
#else
                return false;
#endif
            }
        }

		public bool IsTrackingEnabled
		{
			get
			{
                return isTrackingEnabled;
			}
			set
			{
                isTrackingEnabled = value && !IsAnalyticsDisabledInRegistry;
				if (isTrackingEnabled)
				{
					TryInitializeMonitor();
				}
				else
				{
					if (monitor != null)
					{
						monitor.Stop();
						monitor = null;
					}
				}
			}
		}

		public void TrackException(Exception exception, string contextMessage = null)
		{
			if (!this.IsTrackingEnabled || monitor == null)
			{
				return;
			}
			
			if (string.IsNullOrEmpty(contextMessage))
			{
				monitor.TrackException(exception);
			}
			else
			{
				monitor.TrackException(exception, contextMessage);
			}
		}

		public void TrackFeature(string featureName)
		{
			if (!this.IsTrackingEnabled || monitor == null)
			{
				return;
			}

			monitor.TrackFeature(featureName);
		}

		public void TrackFeatureCancel(string featureName)
		{
			if (!this.IsTrackingEnabled || monitor == null)
			{
				return;
			}

			monitor.TrackFeatureCancel(featureName);
		}

		public void TrackFeatureStart(string featureName)
		{
			if (!this.IsTrackingEnabled || monitor == null)
			{
				return;
			}

			monitor.TrackFeatureStart(featureName);
		}

		public void TrackFeatureStop(string featureName)
		{
			if (!this.IsTrackingEnabled || monitor == null)
			{
				return;
			}

			monitor.TrackFeatureStop(featureName);
		}

        public void Stop()
        {
            if (monitor != null)
            {
                monitor.Stop();
            }
        }

		private static void TryInitializeMonitor()
		{
			if (!ConfigurationManager.AppSettings.Keys.OfType<string>().Contains(EqatecProductKey))
			{
				return;
			}

			if (!isTrackingEnabled)
			{
				throw new InvalidOperationException("TryInitializeMonitor cannot be called when isTrackingEnabled is false. Set Instance.IsTrackingEnabled to true first.");
			}

			if (monitor != null)
			{
				return;
			}

			string productKey = ConfigurationManager.AppSettings[EqatecProductKey];
			if (!string.IsNullOrEmpty(productKey))
			{
				AnalyticsMonitorSettings settings = new AnalyticsMonitorSettings(productKey);
				monitor = AnalyticsMonitorFactory.Create(settings);
				monitor.Start();
			}
		}
	}
}