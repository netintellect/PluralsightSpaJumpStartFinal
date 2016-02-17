using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;

namespace Telerik.Windows.Diagrams.Features
{
	public class SettingsPaneViewModel : ViewModelBase
	{
		#region Fields
		private const double DefaultFontSize = 11;
		private SettingsPaneDataProvider dataProvider = SettingsPaneDataProvider.Empty;
		private bool isInitializationInProgress = false;

		private bool isContentVisible = false;
		private int selectedTabIndex = 0;
		
		private double currentWidth;
		private double currentHeight;
		private double currentPositionX;
		private double currentPositionY;
		private double currentRotaionAngle;

		private CapType? currentSourceCapType = null;
		private CapType? currentTargetCapType = null;
		private double currentStrokeThickness = 1d;
		private DoubleCollection currentStrokeDashArray = null;
		private ColorStyle currentSolidColorStyle = null;
		private ColorStyle currentGradientColorStyle = null;
		private bool isColorSelectionInProgress = false;
		private ColorStyle oldColorStyle = null;

		private string currentLabel = null;
		private string currentLabelOriginalValue = null;
		private FontFamily currentFontFamily = new FontFamily("Segoe UI");
		private double? currentFontSize = DefaultFontSize;
		private Brush currentFontColor = null;
		#endregion

		public SettingsPaneViewModel()
		{
			//// Commands
			this.CommitCurrentLabelCommand = new DelegateCommand(this.OnCommitCurrentLabelCommandExecuted);

			//// Style
			this.CapTypes = GetCapTypes();

			this.StrokeThicknesses = GetStrokeThiknesses();

			this.StrokeDashArrays = GetStrokeDashArrays();

			this.SolidColorStyles = GetSolidColorStyles();

			this.GradientColorStyles = GetGradientColorStyles();

			//// Text
			this.FontSizes = GetFontSizes();

			this.FontFamilies = GetFontFamilies();

			this.FontColors = GetFontColorsStyles();
		}

		#region Properties
		public DelegateCommand CommitCurrentLabelCommand { get; private set; }

		public bool IsContentVisible
		{
			get
			{
				return this.isContentVisible;
			}
			set
			{
				if (this.isContentVisible != value)
				{
					this.isContentVisible = value;
					this.OnPropertyChanged("IsContentVisible");
				}
			}
		}

		public int SelectedTabIndex
		{
			get
			{
				return this.selectedTabIndex;
			}
			set
			{
				if (this.selectedTabIndex != value)
				{
					this.selectedTabIndex = value;
					this.OnPropertyChanged("SelectedTabIndex");
				}
			}
		}

		public bool IsGeneralTabEnabled
		{
			get
			{
				return true;
			}
		}

		public bool IsSizeTabEnabled
		{
			get
			{
				return this.dataProvider.SelectedConnections.Count() <= 0;
			}
		}

		public bool IsStyleTabEnabled
		{
			get
			{
				return this.dataProvider.SelectedItems.Count() == this.dataProvider.SelectedShapes.Count() ||
						this.dataProvider.SelectedItems.Count() == this.dataProvider.SelectedConnections.Count();
			}
		}

		public bool IsTextTabEnabled
		{
			get
			{
				return this.dataProvider.SelectedItems.Count() == 1;
			}
		}

		public bool IsInConnectionEditMode
		{
			get
			{
				return this.dataProvider.SelectedConnections.Count() > 0;
			}
		}

		public bool IsInShapeEditMode
		{
			get
			{
				return this.dataProvider.SelectedShapes.Count() > 0;
			}
		}

		//// Size
		public double CurrentWidth
		{
			get
			{
				return this.currentWidth;
			}
			set
			{
				if (this.currentWidth != value)
				{
					this.currentWidth = value < 0 ? 0 : value;
					this.OnPropertyChanged("CurrentWidth");
					if (!this.isInitializationInProgress)
					{
						this.dataProvider.CommitShapeWidth(this.CurrentWidth);
					}
				}
			}
		}

		public double CurrentHeight
		{
			get
			{
				return this.currentHeight;
			}
			set
			{
				if (this.currentHeight != value)
				{
					this.currentHeight = value < 0 ? 0 : value;
					this.OnPropertyChanged("CurrentHeight");
					if (!this.isInitializationInProgress)
					{
						this.dataProvider.CommitShapeHeight(this.currentHeight);
					}
				}
			}
		}

		public double CurrentPositionX
		{
			get
			{
				return this.currentPositionX;
			}
			set
			{
				if (this.currentPositionX != value)
				{
					this.currentPositionX = this.CoerceDouble(value);
					this.OnPropertyChanged("CurrentPositionX");
					if (!this.isInitializationInProgress)
					{
						this.dataProvider.CommitShapePositionX(this.currentPositionX);
					}
				}
			}
		}

		public double CurrentPositionY
		{
			get
			{
				return this.currentPositionY;
			}
			set
			{
				if (this.currentPositionY != value)
				{
					this.currentPositionY = this.CoerceDouble(value);
					this.OnPropertyChanged("CurrentPositionY");
					if (!this.isInitializationInProgress)
					{
						this.dataProvider.CommitShapePositionY(this.currentPositionY);
					}
				}
			}
		}

		public double CurrentRotaionAngle
		{
			get
			{
				return this.currentRotaionAngle;
			}
			set
			{
				if (this.currentRotaionAngle != value)
				{
					this.currentRotaionAngle = this.CoerceDouble(value) % 360;
					this.OnPropertyChanged("CurrentRotaionAngle");
					if (!this.isInitializationInProgress)
					{
						this.dataProvider.CommitShapeRotaionAngle(this.currentRotaionAngle);
					}
				}
			}
		}

		//// Style
		public IEnumerable<CapType> CapTypes { get; private set; }

		public CapType? CurrentSourceCapType
		{
			get
			{
				return this.currentSourceCapType;
			}
			set
			{
				if (this.currentSourceCapType != value)
				{
					var oldSourceCapType = this.currentSourceCapType;
					this.currentSourceCapType = value;
					this.OnPropertyChanged("CurrentSourceCapType");
					if (!this.isInitializationInProgress)
					{
						this.dataProvider.CommitConnectionSourceCapType(oldSourceCapType, this.currentSourceCapType);
					}
				}
			}
		}

		public CapType? CurrentTargetCapType
		{
			get
			{
				return this.currentTargetCapType;
			}
			set
			{
				if (this.currentTargetCapType != value)
				{
					var oldTargetCapType = this.currentTargetCapType;
					this.currentTargetCapType = value;
					this.OnPropertyChanged("CurrentTargetCapType");
					if (!this.isInitializationInProgress)
					{
						this.dataProvider.CommitConnectionTargetCapType(oldTargetCapType, this.currentTargetCapType);
					}
				}
			}
		}

		public IEnumerable<double> StrokeThicknesses { get; private set; }

		public double CurrentStrokeThickness
		{
			get
			{
				return this.currentStrokeThickness;
			}
			set
			{
				if (this.currentStrokeThickness != value)
				{
					var oldStrokeThickness = this.currentStrokeThickness;
					this.currentStrokeThickness = value;
					this.OnPropertyChanged("CurrentStrokeThickness");
					if (!this.isInitializationInProgress)
					{
						this.dataProvider.CommitItemStrokeThickness(oldStrokeThickness, this.currentStrokeThickness);
					}
				}
			}
		}

		public IEnumerable<DoubleCollection> StrokeDashArrays { get; private set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public DoubleCollection CurrentStrokeDashArray
		{
			get
			{
				return this.currentStrokeDashArray;
			}
			set
			{
				if (this.currentStrokeDashArray != value)
				{
					var oldStrokeDashArray = this.currentStrokeDashArray;
					this.currentStrokeDashArray = value;
					this.OnPropertyChanged("CurrentStrokeDashArray");
					if (!this.isInitializationInProgress)
					{
						this.dataProvider.CommitItemStrokeDashArray(oldStrokeDashArray, this.currentStrokeDashArray);
					}
				}
			}
		}

		public IEnumerable<ColorStyle> SolidColorStyles { get; private set; }

		public ColorStyle CurrentSolidColorStyle
		{
			get
			{
				return this.currentSolidColorStyle;
			}
			set
			{
				if (this.currentSolidColorStyle != value)
				{
					this.currentSolidColorStyle = value;
					this.OnPropertyChanged("CurrentSolidColorStyle");

					if (!this.isColorSelectionInProgress)
					{
						this.isColorSelectionInProgress = true;
						this.CurrentGradientColorStyle = null;
						this.isColorSelectionInProgress = false;

						if (!this.isInitializationInProgress)
						{
							this.dataProvider.CommitItemColorStyle(this.oldColorStyle, this.currentSolidColorStyle);
						}
						this.oldColorStyle = this.currentSolidColorStyle;
					}
				}
			}
		}

		public IEnumerable<ColorStyle> GradientColorStyles { get; private set; }

		public ColorStyle CurrentGradientColorStyle
		{
			get
			{
				return this.currentGradientColorStyle;
			}
			set
			{
				if (this.currentGradientColorStyle != value)
				{
					this.currentGradientColorStyle = value;
					this.OnPropertyChanged("CurrentGradientColorStyle");

					if (!this.isColorSelectionInProgress)
					{
						this.isColorSelectionInProgress = true;
						this.CurrentSolidColorStyle = null;
						this.isColorSelectionInProgress = false;

						if (!this.isInitializationInProgress)
						{
							this.dataProvider.CommitItemColorStyle(this.oldColorStyle, this.currentGradientColorStyle);
						}
						this.oldColorStyle = this.currentGradientColorStyle;
					}
				}
			}
		}

		//// Text
		public string CurrentLabel
		{
			get
			{
				return this.currentLabel;
			}
			set
			{
				if (this.currentLabel != value)
				{
					this.currentLabel = value;
					this.OnPropertyChanged("CurrentLabel");
					if (!this.isInitializationInProgress)
					{
						this.dataProvider.UpdateItemLabel(this.currentLabel);
					}
				}
			}
		}

		public IEnumerable<FontFamily> FontFamilies { get; private set; }

		public FontFamily CurrentFontFamily
		{
			get
			{
				return this.currentFontFamily;
			}
			set
			{
				if (this.currentFontFamily != value)
				{
					var oldFontFamily = this.currentFontFamily;
					this.currentFontFamily = value;
					this.OnPropertyChanged("CurrentFontFamily");
					if (!this.isInitializationInProgress)
					{
						this.dataProvider.CommitItemFontFamily(oldFontFamily, this.currentFontFamily);
					}
				}
			}
		}

		public IEnumerable<double> FontSizes { get; private set; }

		public double? CurrentFontSize
		{
			get
			{
				return this.currentFontSize;
			}
			set
			{
				if (this.currentFontSize != value)
				{
					var oldFontSize = this.currentFontSize;
					if (!value.HasValue)
					{
						this.currentFontSize = DefaultFontSize;
					}
					else
					{
						this.currentFontSize = value;
					}

					this.OnPropertyChanged("CurrentFontSize");

					if (!this.isInitializationInProgress)
					{
						this.dataProvider.CommitItemFontSize(oldFontSize, this.currentFontSize);
					}
				}
			}
		}

		public IEnumerable<Brush> FontColors { get; private set; }

		public Brush CurrentFontColor
		{
			get
			{
				return this.currentFontColor;
			}
			set
			{
				if (this.currentFontColor != value)
				{
					var oldFontColor = this.currentFontColor;
					this.currentFontColor = value;
					this.OnPropertyChanged("CurrentFontColor");
					if (!this.isInitializationInProgress)
					{
						this.dataProvider.CommitItemFontColor(oldFontColor, this.currentFontColor);
					}
				}
			}
		}
		#endregion

		private void SelectAvailableSelectedTabIndex()
		{
			if (this.SelectedTabIndex == 1 && this.IsSizeTabEnabled == false)
			{
				this.SelectedTabIndex = 0;
			}
			else if (this.SelectedTabIndex == 2 && this.IsStyleTabEnabled == false)
			{
				this.SelectedTabIndex = 0;
			}
			else if (this.SelectedTabIndex == 3 && this.IsTextTabEnabled == false)
			{
				this.SelectedTabIndex = 0;
			}
		}

		internal void Reload(SettingsPaneDataProvider provider)
		{
			this.isInitializationInProgress = true;

			this.dataProvider = provider;

			this.OnPropertyChanged("IsGeneralTabEnabled");
			this.OnPropertyChanged("IsSizeTabEnabled");
			this.OnPropertyChanged("IsStyleTabEnabled");
			this.OnPropertyChanged("IsTextTabEnabled");
			this.OnPropertyChanged("IsInConnectionEditMode");
			this.OnPropertyChanged("IsInShapeEditMode");
			
			this.SelectAvailableSelectedTabIndex();
			
			//// Size
			this.CurrentWidth = this.dataProvider.ShapeBounds.Width;
			this.CurrentHeight = this.dataProvider.ShapeBounds.Height;
			this.CurrentPositionX = this.dataProvider.ShapeBounds.X;
			this.CurrentPositionY = this.dataProvider.ShapeBounds.Y;
			this.CurrentRotaionAngle = this.dataProvider.ShapeRotationAngle;

			//// Style
			this.CurrentSourceCapType = this.dataProvider.ConnectionSourceCapType;
			this.CurrentTargetCapType = this.dataProvider.ConnectionTargetCapType;
			this.CurrentStrokeThickness = this.dataProvider.ItemStrokeThickness;
			this.CurrentStrokeDashArray = this.dataProvider.ItemStrokeDashArray;
			this.CurrentSolidColorStyle = this.dataProvider.ItemColorStyle;
			this.CurrentGradientColorStyle = this.dataProvider.ItemColorStyle;

			//// Text
			this.currentLabelOriginalValue = this.dataProvider.ItemLabel;
			this.CurrentLabel = this.currentLabelOriginalValue;
			this.CurrentFontFamily = this.dataProvider.ItemFontFamily;
			this.CurrentFontSize = this.dataProvider.ItemFontSize;
			this.CurrentFontColor = this.dataProvider.ItemFontColor;

			this.isInitializationInProgress = false;
		}

		private void OnCommitCurrentLabelCommandExecuted(object param)
		{
			this.dataProvider.CommitItemLabel(this.currentLabelOriginalValue, this.CurrentLabel);
			this.currentLabelOriginalValue = this.CurrentLabel;
		}

		private double CoerceDouble(double value)
		{
			if (double.IsInfinity(value) || double.IsNaN(value))
				return 0;
			else
				return value;
		}

		#region Collection Generation
		private static List<CapType> GetCapTypes()
		{
			return new List<CapType>()
			{
				CapType.None,
				CapType.Arrow1Filled,
				CapType.Arrow2Filled,
				CapType.Arrow4Filled,
				CapType.Arrow5Filled,
				CapType.Arrow6Filled,
				CapType.Arrow1,
				CapType.Arrow2,
				CapType.Arrow3,
				CapType.Arrow4,
				CapType.Arrow5,
				CapType.Arrow6,
			};
		}

		private static List<double> GetStrokeThiknesses()
		{
			return new List<double>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		}

		private static List<DoubleCollection> GetStrokeDashArrays()
		{
			return new List<DoubleCollection>()
			{
				new DoubleCollection() { 1, 3 },
				new DoubleCollection() { 4, 4 },
				new DoubleCollection() { 10, 10 },
				new DoubleCollection() { 15, 15 },
				new DoubleCollection() { 2, 10 },
				new DoubleCollection() { 10, 3 },
				new DoubleCollection() { 20, 6 },
				new DoubleCollection() { }
			};
		}

		private static List<ColorStyle> GetSolidColorStyles()
		{
			ResourceDictionary solidColorsDictionary = new ResourceDictionary();
			string relativeFilePath = @"/Telerik.Windows.Diagrams.Features;component/Resources/SolidColorsStyles.xaml";
#if WPF
			solidColorsDictionary.Source = new Uri(relativeFilePath, UriKind.RelativeOrAbsolute);
#else
			Application.LoadComponent(solidColorsDictionary, new Uri(relativeFilePath, UriKind.RelativeOrAbsolute));
#endif

			return solidColorsDictionary.Values.OfType<ColorStyle>().OrderBy(cs => cs.OrderId).ToList();
		}

		private static List<ColorStyle> GetGradientColorStyles()
		{
			ResourceDictionary gradientColorsDictionary = new ResourceDictionary();
			string relativeFilePath = @"/Telerik.Windows.Diagrams.Features;component/Resources/GradientColorsStyles.xaml";
#if WPF
			gradientColorsDictionary.Source = new Uri(relativeFilePath, UriKind.RelativeOrAbsolute);
#else
			Application.LoadComponent(gradientColorsDictionary, new Uri(relativeFilePath, UriKind.RelativeOrAbsolute));
#endif

			return gradientColorsDictionary.Values.OfType<ColorStyle>().OrderBy(cs => cs.OrderId).ToList();
		}

		private static List<double> GetFontSizes()
		{
			return new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
		}

		private static List<FontFamily> GetFontFamilies()
		{
			List<string> defaultFontFamilyNames = new List<string>
			{
				"Segoe UI",
				"Arial",
				"Arial Black",
				"Calibri",
				"Comic Sans MS",
				"Courier New",
				"Georgia",
				"Lucida Sans Unicode",
				"Times New Roman",
				"Trebuchet MS",
				"Verdana"
			};

			List<FontFamily> defaultFontFamilies = new List<FontFamily>();
			defaultFontFamilyNames.ForEach(s => defaultFontFamilies.Add(new FontFamily(s)));

			return defaultFontFamilies;
		}

		private static List<Brush> GetFontColorsStyles()
		{
			ResourceDictionary fontColorsDictionary = new ResourceDictionary();
			string relativeFilePath = @"/Telerik.Windows.Diagrams.Features;component/Resources/FontColorsStyles.xaml";
#if WPF
			fontColorsDictionary.Source = new Uri(relativeFilePath, UriKind.RelativeOrAbsolute);
#else
			Application.LoadComponent(fontColorsDictionary, new Uri(relativeFilePath, UriKind.RelativeOrAbsolute));
#endif

			return fontColorsDictionary.Values.OfType<ColorStyle>().OrderBy(cs => cs.OrderId).Select(cs => cs.Fill).ToList();
		}
		#endregion
	}
}
