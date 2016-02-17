using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Diagrams.Core;

namespace Telerik.Windows.Diagrams.Features
{
	internal class SettingsPaneDataProvider
	{
		internal static SettingsPaneDataProvider Empty = new SettingsPaneDataProvider(null);

		private readonly RadDiagram owner = null;

		internal SettingsPaneDataProvider(RadDiagram owner)
		{
			this.owner = owner;
		}

		internal event EventHandler BoundsChanged;

		internal IEnumerable<RadDiagramItem> SelectedItems
		{
			get
			{
				if (this.owner != null)
				{
					return this.owner.SelectedItems.OfType<RadDiagramItem>();
				}
				return Enumerable.Empty<RadDiagramItem>();
			}
		}

		internal IEnumerable<RadDiagramShapeBase> SelectedShapes
		{
			get
			{
				if (this.owner != null)
				{
					return this.owner.SelectedItems.OfType<RadDiagramShapeBase>();
				}
				return Enumerable.Empty<RadDiagramShapeBase>();
			}
		}

		internal IEnumerable<RadDiagramConnection> SelectedConnections
		{
			get
			{
				if (this.owner != null)
				{
					return this.owner.SelectedItems.OfType<RadDiagramConnection>();
				}
				return Enumerable.Empty<RadDiagramConnection>();
			}
		}

		private RadDiagramItem SelectedItem
		{
			get
			{
				return this.SelectedItems.FirstOrDefault();
			}
		}

		private RadDiagramShapeBase SelectedShape
		{
			get
			{
				return this.SelectedShapes.FirstOrDefault();
			}
		}

		private RadDiagramConnection SelectedConnection
		{
			get
			{
				return this.SelectedConnections.FirstOrDefault();
			}
		}

		internal Rect ShapeBounds
		{
			get
			{
				if (this.SelectedShape != null)
				{
					return this.SelectedShape.Bounds;
				}
				return Rect.Empty;
			}
		}

		internal double ShapeRotationAngle
		{
			get
			{
				if (this.SelectedShape != null)
				{
					return this.SelectedShape.RotationAngle;
				}
				return 0;
			}
		}

		internal CapType? ConnectionSourceCapType
		{
			get
			{
				if (this.SelectedConnection != null)
				{
					return this.SelectedConnection.SourceCapType;
				}
				return null;
			}
		}

		internal CapType? ConnectionTargetCapType
		{
			get
			{
				if (this.SelectedConnection != null)
				{
					return this.SelectedConnection.TargetCapType;
				}
				return null;
			}
		}

		internal double ItemStrokeThickness
		{
			get
			{
				if (this.SelectedItem != null)
				{
					return this.SelectedItem.StrokeThickness;
				}
				return 0;
			}
		}

		internal DoubleCollection ItemStrokeDashArray
		{
			get
			{
				if (this.SelectedItem != null)
				{
					return this.SelectedItem.StrokeDashArray;
				}
				return null;
			}
		}

		internal ColorStyle ItemColorStyle
		{
			get
			{
				var item = this.SelectedItem;
				if (item != null)
				{
					var colorStyle = new ColorStyle()
					{
						Fill = item.Background,
						Stroke = item.BorderBrush,
						OrderId = -1
					};
					return colorStyle;
				}
				return null;
			}
		}

		internal string ItemLabel
		{
			get
			{
				if (this.SelectedItem != null && this.SelectedItem.Content as string != null)
				{
					return this.SelectedItem.Content as string;
				}
				return null;
			}
		}

		internal FontFamily ItemFontFamily
		{
			get
			{
				if (this.SelectedItem != null)
				{
					return this.SelectedItem.FontFamily;
				}
				return null;
			}
		}

		internal double? ItemFontSize
		{
			get
			{
				if (this.SelectedItem != null)
				{
					return this.SelectedItem.FontSize;
				}
				return null;
			}
		}

		internal SolidColorBrush ItemFontColor
		{
			get
			{
				if (this.SelectedItem != null && this.SelectedItem.Foreground as SolidColorBrush != null)
				{
					return this.SelectedItem.Foreground as SolidColorBrush;
				}
				return null;
			}
		}

		private void OnBoundsChanged()
		{
			if (this.BoundsChanged != null)
			{
				this.BoundsChanged(this, EventArgs.Empty);
			}
		}

		private void ManipulateItems(Action<RadDiagramItem> manipulation)
		{
			this.SelectedItems.ToList().ForEach(manipulation);
		}

		internal void CommitShapeWidth(double newWidth)
		{
			if (this.owner == null)
			{
				return;
			}

			var compositeCommand = new CompositeCommand(CommandNames.ResizeShapes);

			foreach (var shape in this.SelectedShapes)
			{
				var ensureDifferentShape = shape;
				var ensureOldValue = ensureDifferentShape.Width;
				var command = new UndoableDelegateCommand(CommandNames.ResizeShape,
					p => ensureDifferentShape.Width = newWidth,
					p => ensureDifferentShape.Width = ensureOldValue);
				compositeCommand.AddCommand(command);
			}

			this.owner.UndoRedoService.ExecuteCommand(compositeCommand);

			this.OnBoundsChanged();
		}

		internal void CommitShapeHeight(double newHeight)
		{
			if (this.owner == null)
			{
				return;
			}

			var compositeCommand = new CompositeCommand(CommandNames.ResizeShapes);

			foreach (var shape in this.SelectedShapes)
			{
				var ensureDifferentShape = shape;
				var ensureOldValue = ensureDifferentShape.Height;
				var command = new UndoableDelegateCommand(CommandNames.ResizeShape,
					p => ensureDifferentShape.Height = newHeight,
					p => ensureDifferentShape.Height = ensureOldValue);
				compositeCommand.AddCommand(command);
			}

			this.owner.UndoRedoService.ExecuteCommand(compositeCommand);

			this.OnBoundsChanged();
		}

		internal void CommitShapePositionX(double newPositionX)
		{
			if (this.owner == null)
			{
				return;
			}

			var compositeCommand = new CompositeCommand(CommandNames.MoveItems);

			foreach (var shape in this.SelectedShapes)
			{
				var ensureDifferentShape = shape;
				var ensureOldValue = ensureDifferentShape.Position.X;
				var command = new UndoableDelegateCommand(CommandNames.MoveItem,
					p => ensureDifferentShape.Position = new Point(newPositionX, ensureDifferentShape.Position.Y),
					p => ensureDifferentShape.Position = new Point(ensureOldValue, ensureDifferentShape.Position.Y));
				compositeCommand.AddCommand(command);
			}

			this.owner.UndoRedoService.ExecuteCommand(compositeCommand);

			this.OnBoundsChanged();
		}

		internal void CommitShapePositionY(double newPositionY)
		{
			if (this.owner == null)
			{
				return;
			}

			var compositeCommand = new CompositeCommand(CommandNames.MoveItems);

			foreach (var shape in this.SelectedShapes)
			{
				var ensureDifferentShape = shape;
				var ensureOldValue = ensureDifferentShape.Position.Y;
				var command = new UndoableDelegateCommand(CommandNames.MoveItem,
					p => ensureDifferentShape.Position = new Point(ensureDifferentShape.Position.X, newPositionY),
					p => ensureDifferentShape.Position = new Point(ensureDifferentShape.Position.X, ensureOldValue));
				compositeCommand.AddCommand(command);
			}

			this.owner.UndoRedoService.ExecuteCommand(compositeCommand);

			this.OnBoundsChanged();
		}

		internal void CommitShapeRotaionAngle(double newRotaionAngle)
		{
			if (this.owner == null)
			{
				return;
			}

			var compositeCommand = new CompositeCommand(CommandNames.RotateItems);

			foreach (var shape in this.SelectedShapes)
			{
				var ensureDifferentShape = shape;
				var ensureOldValue = ensureDifferentShape.RotationAngle;
				var command = new UndoableDelegateCommand(CommandNames.RotateItem,
					p => ensureDifferentShape.RotationAngle = newRotaionAngle,
					p => ensureDifferentShape.RotationAngle = ensureOldValue);
				compositeCommand.AddCommand(command);
			}

			this.owner.UndoRedoService.ExecuteCommand(compositeCommand);

			this.OnBoundsChanged();
		}

		internal void CommitConnectionSourceCapType(CapType? oldSourceCapType, CapType? newSourceCapType)
		{
			if (this.owner == null)
			{
				return;
			}

			var compositeCommand = new CompositeCommand("Change Connections Source Cap Type");

			foreach (var conn in this.SelectedConnections)
			{
				var ensureDifferentConnection = conn;
				var command = new UndoableDelegateCommand("Change Connection Source Cap Type",
					p => ensureDifferentConnection.SourceCapType = newSourceCapType.HasValue ? newSourceCapType.Value : CapType.None,
					p => ensureDifferentConnection.SourceCapType = oldSourceCapType.HasValue ? oldSourceCapType.Value : CapType.None);
				compositeCommand.AddCommand(command);
			}

			this.owner.UndoRedoService.ExecuteCommand(compositeCommand);
		}

		internal void CommitConnectionTargetCapType(CapType? oldTargetCapType, CapType? newTargetCapType)
		{
			if (this.owner == null)
			{
				return;
			}

			var compositeCommand = new CompositeCommand("Change Connections Target Cap Type");

			foreach (var conn in this.SelectedConnections)
			{
				var ensureDifferentConnection = conn;
				var command = new UndoableDelegateCommand("Change Connection Target Cap Type",
					p => ensureDifferentConnection.TargetCapType = newTargetCapType.HasValue ? newTargetCapType.Value : CapType.None,
					p => ensureDifferentConnection.TargetCapType = oldTargetCapType.HasValue ? oldTargetCapType.Value : CapType.None);
				compositeCommand.AddCommand(command);
			}

			this.owner.UndoRedoService.ExecuteCommand(compositeCommand);
		}

		internal void CommitItemStrokeThickness(double oldStrokeThickness, double newStrokeThickness)
		{
			if (this.owner == null)
			{
				return;
			}

			var compositeCommand = new CompositeCommand("Change Items Border Thickness");

			foreach (var item in this.SelectedItems)
			{
				var ensureDifferentItem = item;
				var command = new UndoableDelegateCommand("Change Item Border Thikness",
					p => ensureDifferentItem.StrokeThickness = newStrokeThickness,
					p => ensureDifferentItem.StrokeThickness = oldStrokeThickness);
				compositeCommand.AddCommand(command);
			}

			this.owner.UndoRedoService.ExecuteCommand(compositeCommand);
		}

		internal void CommitItemStrokeDashArray(DoubleCollection oldStrokeDashArray, DoubleCollection newStrokeDashArray)
		{
			if (this.owner == null)
			{
				return;
			}

			var compositeCommand = new CompositeCommand("Change Items Border Dash Style");

			foreach (var item in this.SelectedItems)
			{
				var ensureDifferentItem = item;
				var command = new UndoableDelegateCommand("Change Item Border Dash Style",
					p => ensureDifferentItem.StrokeDashArray = newStrokeDashArray,
					p => ensureDifferentItem.StrokeDashArray = oldStrokeDashArray);
				compositeCommand.AddCommand(command);
			}

			this.owner.UndoRedoService.ExecuteCommand(compositeCommand);
		}

		internal void CommitItemColorStyle(ColorStyle oldColorStyle, ColorStyle newColorStyle)
		{
			if (this.owner == null)
			{
				return;
			}

			var compositeCommand = new CompositeCommand("Change Items Color Style");

			foreach (var item in this.SelectedItems)
			{
				var ensureDifferentItem = item;
				var command = new UndoableDelegateCommand("Change Item Color Style",
					p =>
						{
							if (newColorStyle != null)
							{
								ensureDifferentItem.Background = newColorStyle.Fill;
								ensureDifferentItem.BorderBrush = newColorStyle.Stroke;
								ensureDifferentItem.Stroke = newColorStyle.Stroke;
							}
						},
					p =>
						{
							if (oldColorStyle != null)
							{
								ensureDifferentItem.Background = oldColorStyle.Fill;
								ensureDifferentItem.BorderBrush = oldColorStyle.Stroke;
								ensureDifferentItem.Stroke = oldColorStyle.Stroke;
							}
						});
				compositeCommand.AddCommand(command);
			}

			this.owner.UndoRedoService.ExecuteCommand(compositeCommand);
		}

		internal void UpdateItemLabel(string newLabel)
		{
			var manipulation = new Action<RadDiagramItem>(item => { item.Content = newLabel; });
			this.ManipulateItems(manipulation);
		}

		internal void CommitItemLabel(string oldLabel, string newLabel)
		{
			if (this.owner == null)
			{
				return;
			}

			var compositeCommand = new CompositeCommand("Change Items Content");

			foreach (var item in this.SelectedItems)
			{
				var ensureDifferentItem = item;
				var command = new UndoableDelegateCommand("Change Item Content",
					p => ensureDifferentItem.Content = newLabel,
					p => ensureDifferentItem.Content = oldLabel);
				compositeCommand.AddCommand(command);
			}

			this.owner.UndoRedoService.ExecuteCommand(compositeCommand);
		}

		internal void CommitItemFontFamily(FontFamily oldFontFamily, FontFamily newFontFamily)
		{
			if (this.owner == null)
			{
				return;
			}

			var compositeCommand = new CompositeCommand("Change Items Font Family");

			foreach (var item in this.SelectedItems)
			{
				var ensureDifferentItem = item;
				var command = new UndoableDelegateCommand("Change Item Font Family",
					p => ensureDifferentItem.FontFamily = newFontFamily,
					p => ensureDifferentItem.FontFamily = oldFontFamily);
				compositeCommand.AddCommand(command);
			}

			this.owner.UndoRedoService.ExecuteCommand(compositeCommand);
		}

		internal void CommitItemFontSize(double? oldFontSize, double? newFontSize)
		{
			if (this.owner == null)
			{
				return;
			}

			var compositeCommand = new CompositeCommand("Change Items Font Size");

			foreach (var item in this.SelectedItems)
			{
				var ensureDifferentItem = item;
				var command = new UndoableDelegateCommand("Change Item Font Size",
					p =>
						{
							if (newFontSize.HasValue)
							{
								ensureDifferentItem.FontSize = newFontSize.Value;
							}
						},
					p =>
						{
							if (oldFontSize.HasValue)
							{
								ensureDifferentItem.FontSize = oldFontSize.Value;
							}
						});
				compositeCommand.AddCommand(command);
			}

			this.owner.UndoRedoService.ExecuteCommand(compositeCommand);
		}

		internal void CommitItemFontColor(Brush oldFontColor, Brush newFontColor)
		{
			if (this.owner == null)
			{
				return;
			}

			var compositeCommand = new CompositeCommand("Change Items Font Color");

			foreach (var item in this.SelectedItems)
			{
				var ensureDifferentItem = item;
				var command = new UndoableDelegateCommand("Change Item Font Color",
					p =>
						{
							if (newFontColor != null)
							{
								ensureDifferentItem.Foreground = newFontColor;
							}
						},
					p =>
						{
							if (oldFontColor != null)
							{
								ensureDifferentItem.Foreground = oldFontColor;
							}
						});
				compositeCommand.AddCommand(command);
			}

			this.owner.UndoRedoService.ExecuteCommand(compositeCommand);
		}
	}
}
