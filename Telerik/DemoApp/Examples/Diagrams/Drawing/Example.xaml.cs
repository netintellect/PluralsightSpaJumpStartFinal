using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.Examples.Diagrams.Drawing.ViewModels;
using System.Collections.ObjectModel;
using Telerik.Windows.DragDrop;
using Telerik.Windows.Examples.Diagrams.Common;
using System.Globalization;
#if WPF
using Microsoft.Win32;
using Telerik.Windows.Controls.Diagrams.Extensions;
using System.Globalization;
#endif

namespace Telerik.Windows.Examples.Diagrams.Drawing
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
			this.DataContext = new MainViewModel();		
			DragDropManager.AddDragInitializeHandler(this.toolbox, OnDragInitialize);
			SerializationService.Default.ItemSerializing += DefaultSerializationService_ItemSerializing;
		}
		
		private void OnDragInitialize(object sender, DragInitializeEventArgs args)
		{
			args.AllowedEffects = DragDropEffects.All;
			if (args.OriginalSource.GetType() == typeof(Telerik.Windows.Controls.RadListBoxItem))
			{
				var draggedShape = (args.OriginalSource as Telerik.Windows.Controls.RadListBoxItem).ChildrenOfType<RadDiagramShapeBase>().FirstOrDefault();
				if (draggedShape != null)
				{
					var shapeSize = new Size(draggedShape.ActualWidth, draggedShape.ActualHeight);
					if (shapeSize.Width > 0 && shapeSize.Height > 0)
					{
						var dropInfo = new DiagramDropInfo(shapeSize, SerializationService.Default.SerializeItems(new List<IDiagramItem> {draggedShape}));
						args.Data = dropInfo;
						args.DragVisualOffset = new Point(args.RelativeStartPoint.X - (shapeSize.Width / 2), args.RelativeStartPoint.Y - (shapeSize.Height / 2));

						var draggingImage = new System.Windows.Controls.Image
						{
							Source = new Telerik.Windows.Media.Imaging.RadBitmap(draggedShape).Bitmap,
							Width = shapeSize.Width,
							Height = shapeSize.Height
						};
						args.DragVisual = draggingImage;
					}
				}
			}
		}

		private void ImportImageButtonClick(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
#if WPF
			openFileDialog.Filter = "Image Files (*.png, *.jpg, *.bmp)|*.png;*.jpg;*.bmp";
#else
			openFileDialog.Filter = "Image Files (*.png, *.jpg)|*.png;*.jpg";
#endif
			bool? dialogResult = openFileDialog.ShowDialog();
			if (dialogResult.HasValue && dialogResult.Value == true)
			{
				Image image = new Image();
#if WPF
				image.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
#else
					using (var fileOpenRead = openFileDialog.File.OpenRead())
					{
						BitmapImage bitmap = new BitmapImage();
						bitmap.SetSource(fileOpenRead);
						image.Source = bitmap;
					}
#endif
				Viewbox viewBox = new Viewbox() { Stretch = Stretch.Fill, Margin = new Thickness(-4) };
				viewBox.Child = image;
				RadDiagramShape imageShape = new RadDiagramShape()
				{
					Content = viewBox
				};
				this.diagram.Items.Add(imageShape);
			}
		}

		private void PointerToolButtonClick(object sender, RoutedEventArgs e)
		{
			this.diagram.ActiveTool = MouseTool.PointerTool;
		}

		private void PathToolButtonClick(object sender, RoutedEventArgs e)
		{
			this.diagram.ActiveTool = MouseTool.PathTool;
		}

		private void PencilToolButtonClick(object sender, RoutedEventArgs e)
		{
			this.diagram.ActiveTool = MouseTool.PencilTool;
		}

		private void TextToolButtonClicked(object sender, RoutedEventArgs e)
		{
			this.diagram.ActiveTool =  MouseTool.TextTool;
		}

		private void StrokeBrushesGalleryMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			this.strokeButton.IsOpen = false;
		}

		private void FillBrushesGalleryMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			this.fillButton.IsOpen = false;
		}

		private void StrokeThicknessListBoxMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			this.strokeThicknessButton.IsOpen = false;
		}

		private void FillRuleListBoxMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			this.fillRuleButton.IsOpen = false;
		}

		private void DiagramShapeDeserialized(object sender, ShapeSerializationRoutedEventArgs e)
		{
			if (e.Shape as RadDiagramShape != null)
			{
				RadDiagramShape shape = e.Shape as RadDiagramShape;
				var savedGeometry = e.SerializationInfo["MyGeometry"];
				if (savedGeometry != null)
				{
					shape.Geometry = GeometryParser.GetGeometry(savedGeometry.ToString());
					shape.Background = new SolidColorBrush(){Color = Color.FromArgb(255, 0, 192, 255)};
					shape.StrokeThickness = 0;
				}
			}
			this.diagram.ActiveTool = MouseTool.PointerTool;
			this.pointerToolButton.IsChecked = true;
		}
		private void DefaultSerializationService_ItemSerializing(object sender, SerializationEventArgs<IDiagramItem> e)
		{
			if (e.Entity is RadDiagramShape)
			{
				var shape = e.Entity as RadDiagramShape;
				if (shape != null && shape.Geometry != null)
				{
                    string geometryString = string.Empty;
#if WPF
                    geometryString = (e.Entity as RadDiagramShape).Geometry.ToString(CultureInfo.InvariantCulture);
#else
                    geometryString = (e.Entity as RadDiagramShape).Geometry.ToString();
#endif
                    e.SerializationInfo["MyGeometry"] = geometryString;
				}				
			}
		}

		private void ExampleUnloaded(object sender, RoutedEventArgs e)
		{
			SerializationService.Default.ItemSerializing -= DefaultSerializationService_ItemSerializing;
		}
	}
}
