using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;

namespace Telerik.Windows.Examples.Diagrams.Drawing.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		public MainViewModel()
		{
			this.InitializeShapeModels();
			this.InitializeBrushModels();
			this.InitializeFillRuleModels();
			this.InitializeStrokeThicknessViewModels();
			this.AddToGalleryCommand = new DelegateCommand((x) => this.AddToGallery(x));
		}
		public ObservableCollection<ShapeGalleryItemViewModel> ShapeModels { get; set; }
		public ObservableCollection<GalleryItemViewModel> BrushesModels {get;set;}
		public ObservableCollection<FillRuleViewModel> FillRuleModels {get;set;}
		public ObservableCollection<StrokeThicknessViewModel> StrokeThicknessViewModels { get; set; }
		public DelegateCommand AddToGalleryCommand {get; set;}

		private void AddToGallery(object parameter)
		{
			if (parameter != null)
			{
				var geomString = (parameter as Geometry).ToString();
				this.ShapeModels.Insert(0, new ShapeGalleryItemViewModel() { CustomGeometry = GeometryParser.GetGeometry(geomString) });
			}
		}

		private void InitializeShapeModels()
		{
			this.ShapeModels = new ObservableCollection<ShapeGalleryItemViewModel>();
			this.ShapeModels.Add(new ShapeGalleryItemViewModel(){ CustomGeometry = ShapeFactory.CommonGeometries[CommonShapeType.EllipseShape]});
			this.ShapeModels.Add(new ShapeGalleryItemViewModel() { CustomGeometry = ShapeFactory.CommonGeometries[CommonShapeType.RectangleShape] });
			this.ShapeModels.Add(new ShapeGalleryItemViewModel() { CustomGeometry = ShapeFactory.CommonGeometries[CommonShapeType.RightTriangleShape] });
			this.ShapeModels.Add(new ShapeGalleryItemViewModel() { CustomGeometry = ShapeFactory.CommonGeometries[CommonShapeType.TriangleShape] });
			this.ShapeModels.Add(new ShapeGalleryItemViewModel() { CustomGeometry = ShapeFactory.CommonGeometries[CommonShapeType.HexagonShape] });
			this.ShapeModels.Add(new ShapeGalleryItemViewModel() { CustomGeometry = ShapeFactory.CommonGeometries[CommonShapeType.OctagonShape] });
			this.ShapeModels.Add(new ShapeGalleryItemViewModel() { CustomGeometry = ShapeFactory.CommonGeometries[CommonShapeType.Star5Shape] });
		}
		private void InitializeBrushModels()
		{
			this.BrushesModels = new ObservableCollection<GalleryItemViewModel>()
			{
				new GalleryItemViewModel(true) { CustomBrush = new SolidColorBrush(Colors.Transparent)},
				new GalleryItemViewModel(false) { CustomBrush = new SolidColorBrush(Color.FromArgb(255, 237, 174, 0))},
				new GalleryItemViewModel(false) { CustomBrush = new SolidColorBrush(Color.FromArgb(255, 139, 192, 63))},
				new GalleryItemViewModel(false) { CustomBrush = new SolidColorBrush(Color.FromArgb(255,  49, 155, 71))},
				new GalleryItemViewModel(false) { CustomBrush = new SolidColorBrush(Color.FromArgb(255,  14, 184, 241))},

				new GalleryItemViewModel(false) { CustomBrush = new SolidColorBrush(Color.FromArgb(255, 127, 81, 161))},
				new GalleryItemViewModel(false) { CustomBrush = new SolidColorBrush(Color.FromArgb(255, 237, 22, 144))},
				new GalleryItemViewModel(false) { CustomBrush = new SolidColorBrush(Color.FromArgb(255, 229, 30, 37))},
				new GalleryItemViewModel(false) { CustomBrush = new SolidColorBrush(Color.FromArgb(255, 151, 151, 151))},
				new GalleryItemViewModel(false) { CustomBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0))},
			};

			this.CurrentBrushModel = this.BrushesModels[4];
			this.CurrentStrokeModel = this.BrushesModels[1];
		}
		private void InitializeFillRuleModels()
		{
			this.FillRuleModels = new ObservableCollection<FillRuleViewModel>()
			{
				new FillRuleViewModel(){FillRule = FillRule.EvenOdd, StarGeometry = GeometryExtensions.GetPathGeometry("M8.2500048,8.2001801 L6.5416665,13.70018 L11,17.096014 L15.458333,13.70018 L13.770833,8.179347 z M10.999999,0 L13.760999,8.1655445 L22,8.4032526 L15.467391,13.687544 L17.798372,22 L10.999999,17.100328 L4.2016258,22 L6.532608,13.687544 L0,8.4032526 L8.2389994,8.1655445 z")},
				new FillRuleViewModel(){FillRule = FillRule.Nonzero, StarGeometry = GeometryExtensions.GetPathGeometry("M10.999999,0 L13.760999,8.1655445 L22,8.4032526 L15.467391,13.687544 L17.798372,22 L10.999999,17.100328 L4.2016258,22 L6.532608,13.687544 L-2.8865886E-08,8.4032526 L8.2389994,8.1655445 z")}
			};
			this.CurrentFillRuleViewModel = this.FillRuleModels[0];
		}
		private void InitializeStrokeThicknessViewModels()
		{
			this.StrokeThicknessViewModels = new ObservableCollection<StrokeThicknessViewModel>()
			{				
				new StrokeThicknessViewModel(2.0)
				{
					EllipseGeometry = new EllipseGeometry(){ Center = new Point(2, 2), RadiusX = 2, RadiusY = 2 }
				},
				new StrokeThicknessViewModel(3.0)
				{
					EllipseGeometry = new EllipseGeometry(){ Center = new Point(3, 3), RadiusX = 3, RadiusY = 3 }
				},
				new StrokeThicknessViewModel(4.0)
				{
					EllipseGeometry =  new EllipseGeometry(){ Center = new Point(4, 4), RadiusX = 4, RadiusY = 4 }
				},
				new StrokeThicknessViewModel(5.0)
				{
					EllipseGeometry = new EllipseGeometry(){ Center = new Point(5, 5), RadiusX = 5, RadiusY = 5 }
				},
				new StrokeThicknessViewModel(6.0)
				{
					EllipseGeometry =  new EllipseGeometry(){ Center = new Point(6, 6), RadiusX = 6, RadiusY = 6 }
				},
				new StrokeThicknessViewModel(7.0)
				{
					EllipseGeometry =  new EllipseGeometry(){ Center = new Point(7, 7), RadiusX = 7, RadiusY = 7 }
				},
			};	
			this.CurrentStrokeThicknessModel = this.StrokeThicknessViewModels[2];		
		}

		private GalleryItemViewModel currentBrushModel;	
		public GalleryItemViewModel CurrentBrushModel	
		{
			get { return this.currentBrushModel; }
			set
			{
				if (this.currentBrushModel != value)
				{
					this.currentBrushModel = value;
					this.OnPropertyChanged("CurrentBrushModel");
				}
			}
		}

		private GalleryItemViewModel currentStrokeModel;
		public GalleryItemViewModel CurrentStrokeModel
		{
			get { return this.currentStrokeModel; }
			set
			{
				if (this.currentStrokeModel != value)
				{
					this.currentStrokeModel = value;
					this.OnPropertyChanged("CurrentStrokeModel");
				}
			}
		}

		private StrokeThicknessViewModel currentStrokeThicknessModel;
		public StrokeThicknessViewModel CurrentStrokeThicknessModel
		{
			get { return this.currentStrokeThicknessModel; }
			set
			{
				if (this.currentStrokeThicknessModel != value)
				{
					this.currentStrokeThicknessModel = value;
					this.OnPropertyChanged("CurrentStrokeThicknessModel");
				}
			}
		}

		private FillRuleViewModel currentFillruleViewModel;
		public FillRuleViewModel CurrentFillRuleViewModel
		{
			get { return this.currentFillruleViewModel; }
			set
			{
				if (this.currentFillruleViewModel != value)
				{
					this.currentFillruleViewModel = value;
					this.OnPropertyChanged("CurrentFillRuleViewModel");
				}
			}
		}
		
		
	}
}
