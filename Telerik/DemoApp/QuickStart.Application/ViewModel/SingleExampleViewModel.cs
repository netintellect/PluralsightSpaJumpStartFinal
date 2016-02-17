using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.QuickStart.ViewModel
{
	public class SingleExampleViewModel : QuickStartViewModelBase
	{
		private static string[] telerikReferencesNamesForCurrentControl;

		private readonly DeployManager deployManager;
		private IExampleInfo currentExample;
		private object currentExampleInstance;
		private Action exampleInstantiatedCallback;

		private int exampleProgress;
		private IExampleInfo nextExample;
		private IExampleInfo previousExample;
		private Enums.ViewMode viewMode;

		public SingleExampleViewModel()
		{
			this.deployManager = new DeployManager();
			this.CurrentExampleResource = new ObservableCollection<string>();
			ExampleLoader.Instance.Initialize(this.Data, this.deployManager);
			ExampleLoader.Instance.PropertyChanged += OnExampleLoaderPropertyChanged;
			ExampleLoader.Instance.ExampleInstantiated += OnExampleLoaderExampleInstantiated;
		}
  
		public SingleExampleViewModel(INotifyUser ownerView) : this()
		{
			this.OwnerView = ownerView;
		}

		public IExampleInfo CurrentExample
		{
			get
			{
				return this.currentExample;
			}
			private set
			{
				if (this.currentExample != value)
				{
					this.currentExample = value;
					this.OnPropertyChanged("CurrentExample");

					this.SetNextAndPreviousExample();
				}
			}
		}

		public object CurrentExampleInstance
		{
			get
			{
				return this.currentExampleInstance;
			}
			set
			{
				if (this.currentExampleInstance != value)
				{
					this.currentExampleInstance = value;
					this.OnPropertyChanged("CurrentExampleInstance");
				}
			}
		}

		public ObservableCollection<string> CurrentExampleResource { get; private set; }

		public string CurrentTheme
		{
			get
			{
				return ApplicationThemeManager.GetInstance().CurrentTheme;
			}
			set
			{
				if (ApplicationThemeManager.GetInstance().CurrentTheme != value || telerikReferencesNamesForCurrentControl == null)
				{
					string controlName = string.IsNullOrEmpty(this.CurrentExample.PackageName) ? this.CurrentExample.ExampleGroup.Control.Name : this.CurrentExample.PackageName;
					var resourcePathsForControl = GetTelerikReferencesNamesForControl(controlName);
					string[] resourcePaths = resourcePathsForControl;

					ApplicationThemeManager.GetInstance().EnsureResourcesForTheme(value, resourcePaths);

					this.OnPropertyChanged("CurrentTheme");
				}
			}
		}

		public int ExampleProgress
		{
			get
			{
				return this.exampleProgress;
			}

			set
			{
				if (this.exampleProgress != value)
				{
					this.exampleProgress = value;
					this.OnPropertyChanged("ExampleProgress");
				}
			}
		}

		public bool IsFullscreen { get; set; }

		public IExampleInfo NextExample
		{
			get
			{
				return this.nextExample;
			}
			private set
			{
				if (this.nextExample != value)
				{
					this.nextExample = value;
					this.OnPropertyChanged("NextExample");
				}
			}
		}
        
		public IExampleInfo PreviousExample
		{
			get
			{
				return this.previousExample;
			}
			private set
			{
				if (this.previousExample != value)
				{
					this.previousExample = value;
					this.OnPropertyChanged("PreviousExample");
				}
			}
		}

		public IEnumerable<string> Themes
		{
			get
			{
				return ApplicationThemeManager.GetAllThemes();
			}
		}

		public Enums.ViewMode ViewMode
		{
			get
			{
				return this.viewMode;
			}

			set
			{
				if (this.viewMode != value)
				{
					this.viewMode = value;
					this.OnPropertyChanged("ViewMode");
				}
			}
		}

		public void Initialize(IExampleInfo exampleInfo, Action exampleInstantiatedCallback)
		{
			this.exampleInstantiatedCallback = exampleInstantiatedCallback;

			// set IsQsfInTouchMode to Desktop mode if example is only in Desktop mode
			// or to Touch mode if example is only in Touch mode
			// this fixes an issue where searching from touch mode and selecting a Desktop example displays Win8Touch theme 

			if (!ModelExtensions.IsTouchAndDesktopExample(exampleInfo))
			{
				if (ModelExtensions.IsDesktopExample(exampleInfo))
				{
					IsQsfInTouchMode = false;
				}
				else
				{
					IsQsfInTouchMode = true;
				}
			}

			this.SetNextAndPreviousExample();

			this.NavigateToExample(exampleInfo, ApplicationThemeManager.GetDefaultThemeName(IsQsfInTouchMode));
		}

		public void NavigateToExample(IExampleInfo exampleInfo, string themeName)
		{
			if (this.CurrentExample == null)
			{
				this.CurrentExample = exampleInfo;
			}

			if (this.CurrentExample != null &&
				(exampleInfo.ExampleGroup.Control != this.CurrentExample.ExampleGroup.Control || this.CurrentExample.PackageName != exampleInfo.PackageName))
			{
				telerikReferencesNamesForCurrentControl = null;
			}

			ExampleLoader.Instance.LoadExample(exampleInfo, themeName);
		}

		public void RaiseCurrentThemePropertyChanged()
		{
			this.OnPropertyChanged("CurrentTheme");
		}

		private static string[] GetTelerikReferencesNamesForControl(string controlName)
		{
			if (telerikReferencesNamesForCurrentControl == null)
			{
				var referencesListUri = new Uri(string.Format("/{0};component/ReferencesList.txt", controlName), UriKind.RelativeOrAbsolute);
				var referencesResourceStream = Application.GetResourceStream(referencesListUri).Stream;

				string content = AssemblyHelper.GetStringFromStream(referencesResourceStream);
				telerikReferencesNamesForCurrentControl = AssemblyHelper.ParseTelerikReferencesFromContent(content).ToArray();
			}
			return telerikReferencesNamesForCurrentControl;
		}

		private void OnExampleLoaderExampleInstantiated(object s, ExampleInstantiatedEventArgs e)
		{
			this.CurrentExampleInstance = e.ExampleInstance;
			this.ViewMode = Enums.ViewMode.Example;
			if (this.exampleInstantiatedCallback != null)
			{
				this.exampleInstantiatedCallback();
			}
		}

		private void OnExampleLoaderPropertyChanged(object s, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "CurrentTheme":
					this.CurrentTheme = ExampleLoader.Instance.CurrentTheme;
					break;
				case "CurrentExample":
					this.CurrentExample = ExampleLoader.Instance.CurrentExample;
					break;
				case "ExampleProgress":
					this.ExampleProgress = ExampleLoader.Instance.ExampleProgress;
					break;
				default:
					throw new NotImplementedException(e.PropertyName);
			}
		}

		private void SetNextAndPreviousExample()
		{
			if (IsQsfInTouchMode)
			{
				this.NextExample = this.Data.ExamplesTouch.ToList().NextOrFirstOrDefault(this.CurrentExample);
				this.PreviousExample = this.Data.ExamplesTouch.ToList().PreviousOrLastOrDefault(this.CurrentExample);
			}
			else
			{
				this.NextExample = this.Data.ExamplesNonTouch.ToList().NextOrFirstOrDefault(this.CurrentExample);
				this.PreviousExample = this.Data.ExamplesNonTouch.ToList().PreviousOrLastOrDefault(this.CurrentExample);
			}
		}
	}
}