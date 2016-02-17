using System;
using System.IO.IsolatedStorage;
using System.Linq;

namespace Telerik.Windows.Controls.QuickStart
{
	public class SettingsManager
	{
		private static readonly SettingsManager instance = new SettingsManager();

		private bool hasStartupDialogShown;

		private bool isAnalyticsTrackingEnabled;

		private const string IsAnalyticsTrackingEnabledKey = "IsAnalyticsTrackingEnabled";
		private const string HasStartupDialogShownKey = "HasStartupDialogShown";

		private SettingsManager()
		{
			this.ReadPersistedSettings();
		}

		public static SettingsManager Instance
		{
			get
			{
				return instance;
			}
		}

		public bool IsAnalyticsTrackingEnabled
		{
			get
			{
				return this.isAnalyticsTrackingEnabled;
			}
			set
			{
				this.isAnalyticsTrackingEnabled = value;
				this.SaveIsAnalayticsTrackingEnabledValue(value);
			}
		}

		public bool HasStartupDialogShown
		{
			get
			{
				return this.hasStartupDialogShown;
			}
			set
			{
				this.hasStartupDialogShown = value;
				this.SaveHasStartupDialogShownValue(value);
			}
		}

		private void ReadPersistedSettings()
		{
			#if SILVERLIGHT
			this.isAnalyticsTrackingEnabled = (bool)
				(IsolatedStorageSettings.ApplicationSettings.Contains(IsAnalyticsTrackingEnabledKey)
				? IsolatedStorageSettings.ApplicationSettings[IsAnalyticsTrackingEnabledKey]
				: false);
			this.hasStartupDialogShown = (bool)
				(IsolatedStorageSettings.ApplicationSettings.Contains(HasStartupDialogShownKey)
				? IsolatedStorageSettings.ApplicationSettings[HasStartupDialogShownKey]
				: false);
			#else
			this.isAnalyticsTrackingEnabled = Properties.Settings.Default.IsAnalyticsTrackingEnabled;
			this.hasStartupDialogShown = Properties.Settings.Default.HasStartupDialogShown;
			#endif
		}

		private void SaveHasStartupDialogShownValue(bool value)
		{
			#if SILVERLIGHT
			if (!IsolatedStorageSettings.ApplicationSettings.Contains(HasStartupDialogShownKey))
			{
				IsolatedStorageSettings.ApplicationSettings.Add(HasStartupDialogShownKey, value);
			}
			else
			{
				IsolatedStorageSettings.ApplicationSettings[HasStartupDialogShownKey] = value;
			}
			#else
			Properties.Settings.Default.HasStartupDialogShown = value;
			Properties.Settings.Default.Save();
			#endif
		}

		private void SaveIsAnalayticsTrackingEnabledValue(bool value)
		{
			#if SILVERLIGHT
			if (!IsolatedStorageSettings.ApplicationSettings.Contains(IsAnalyticsTrackingEnabledKey))
			{
				IsolatedStorageSettings.ApplicationSettings.Add(IsAnalyticsTrackingEnabledKey, value);
			}
			else
			{
				IsolatedStorageSettings.ApplicationSettings[IsAnalyticsTrackingEnabledKey] = value;
			}
			#else
			Properties.Settings.Default.IsAnalyticsTrackingEnabled = value;
			Properties.Settings.Default.Save();
			#endif
		}
	}
}