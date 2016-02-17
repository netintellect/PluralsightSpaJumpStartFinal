using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls.Map;

namespace Telerik.Windows.Examples.Map.Hotel
{
    public partial class Example : UserControl
    {
		private const string RoomNumberField = "Name";
		private const string RoomStateField = "RoomState";
		private const string RoomTypeField = "RoomType";

		private const string FreeRoomState = "Free";
		private const string OccupiedRoomState = "Occupied";
		private const string ReservedRoomState = "Reserved";

		private const string BusinessLuxuryRoomType = "Business Luxury";
		private const string BusinessStandardRoomType = "Business Standard";
		private const string ComfortRoomType = "Comfort";
		private const string EconomyRoomType = "Economy";
		private const string LuxuryRoomType = "Luxury";
		private const string StandardRoomType = "Standard";

		private List<MapShapeData> rooms = new List<MapShapeData>();
		private MapShapeData lastSelectedRoom = null;

		private List<string> selectedRoomState = new List<string>()
		{
			FreeRoomState,
			ReservedRoomState,
			OccupiedRoomState
		};
		private List<string> selectedRoomType = new List<string>()
		{
			BusinessLuxuryRoomType,
			BusinessStandardRoomType,
			ComfortRoomType,
			EconomyRoomType,
			LuxuryRoomType,
			StandardRoomType
		};

        public Example()
        {
            InitializeComponent();
#if WPF
			this.visualizationLayer.UseBitmapCache = false;
#endif
        }

		private void OnPreviewReadShapeDataCompleted(object sender, PreviewReadShapeDataCompletedEventArgs e)
		{
			AsyncShapeFileReader reader = sender as AsyncShapeFileReader;
			if (e.Error == null && reader != null)
			{
				// Gets name of the file has been read.
				string shapeFileName = System.IO.Path.GetFileName(reader.Source.OriginalString);

				switch (shapeFileName)
				{
					case "Hotel_base.shp":
						MapShapeData baseShape = e.Items[0] as MapShapeData;
						if (baseShape != null)
						{
							baseShape.ShapeFill = new MapShapeFill()
							{
								Fill = this.Resources["hotelBase"] as Brush
							};
						}
						break;

					case "Hotel_Corridors.shp":
						foreach (MapShapeData corridorShape in e.Items)
						{
							corridorShape.ShapeFill = new MapShapeFill()
							{
								Fill = this.Resources["corridorFill"] as Brush
							};
						}
						break;

					case "Hotel_ServiceRooms.shp":
						foreach (MapShapeData shape in e.Items)
						{
							this.ColorServiceRooms(shape);
						}
						break;

					case "Hotel_LiftsAndLadders.shp":
						foreach (MapShapeData shape in e.Items)
						{
							this.ColorLiftsAndLadders(shape);
						}
						break;

					case "Hotel_Rooms.shp":
						this.AddRooms(e.Items);
						this.RecolorRooms();
						break;
				}

			}
		}

		private void AddRooms(List<ExtendedDataProvider> list)
		{
			DataTemplate tooltipTemplate = this.Resources["TooltipTemplate"] as DataTemplate;

			foreach (MapShapeData shape in list)
			{
				this.rooms.Add(shape);
				this.ColorRoom(shape);
				shape.ToolTipTemplate = tooltipTemplate;

				this.AddRoomNumber(shape);
			}
		}

		private void AddRoomNumber(MapShapeData shape)
		{
			PointData pinPoint = new PointData()
			{
				Location = shape.GeoBounds.Center,
				ZIndex = 7,
				ExtendedData = shape.ExtendedData
			};

			this.visualizationLayer.Items.Add(pinPoint);
		}

		private void ColorRoom(MapShapeData shape)
        {
            if (shape != null)
            {
                string roomState = shape.ExtendedData.GetValue(RoomStateField).ToString();
                string roomStateFillKey = roomState;
                string roomStateStrokeKey = string.Format("{0}Stroke", roomState);
				shape.ShapeFill = new MapShapeFill()
				{
					Fill = this.Resources[roomStateFillKey] as Brush,
					Stroke = this.Resources[roomStateStrokeKey] as Brush,
					StrokeThickness = 1
				};

                string roomStateHighlightFillKey = string.Format("{0}HighlightFill", roomState);
                string roomStateHighlightStrokeKey = string.Format("{0}HighlightStroke", roomState);
				shape.HighlightFill = new MapShapeFill()
				{
					Fill = this.Resources[roomStateHighlightFillKey] as Brush,
					Stroke = this.Resources[roomStateHighlightStrokeKey] as Brush,
					StrokeThickness = 2
				};
                 
				shape.SelectedFill = shape.HighlightFill.Clone();
			}
        }

        private void ColorLiftsAndLadders(MapShapeData shape)
        {
            if (shape != null)
            {
				shape.ShapeFill = new MapShapeFill()
				{
					Stroke = this.Resources["serviceRoomStroke"] as Brush,
					StrokeThickness = 1
				};

				if (shape.ExtendedData.GetValue("Name").ToString().Contains("Ladder"))
				{
					shape.ShapeFill.Fill = this.Resources["ladderVertical"] as Brush;
				}
				if (shape.ExtendedData.GetValue("Name").ToString().Contains("Ladder A"))
				{
					shape.ShapeFill.Fill = this.Resources["ladderHorizontal"] as Brush;
				}
				if (shape.ExtendedData.GetValue("Name").ToString().Contains("Passenger"))
				{
					shape.ShapeFill.Fill = this.Resources["passengerLifts"] as Brush;
				}
				if (shape.ExtendedData.GetValue("Name").ToString().Contains("Service"))
				{
					shape.ShapeFill.Fill = this.Resources["serviceLifts"] as Brush;
				}
            }
        }

        private void ColorServiceRooms(MapShapeData shape)
        {
            if (shape != null)
            {
				shape.ShapeFill = new MapShapeFill()
				{
					Fill = this.Resources["serviceRoomFill"] as Brush,
					Stroke = this.Resources["serviceRoomFill"] as Brush,
					StrokeThickness = 1
				};

				if (shape.ExtendedData.GetValue("Name").ToString().Contains("Vent A"))
				{
					shape.ShapeFill.Fill = this.Resources["vent1"] as Brush;
				}
				else if (shape.ExtendedData.GetValue("Name").ToString().Contains("Vent B"))
				{
					shape.ShapeFill.Fill = this.Resources["vent"] as Brush;
				}
            }
        }

		private void checkBoxFree_Checked(object sender, RoutedEventArgs e)
        {
			this.SetSelectedRoomState(FreeRoomState);
        }

        private void checkBoxFree_Unchecked(object sender, RoutedEventArgs e)
        {
			this.UnsetSelectedRoomState(FreeRoomState);
        }

		private void checkBoxReserved_Checked(object sender, RoutedEventArgs e)
        {
			this.SetSelectedRoomState(ReservedRoomState);
        }

        private void checkBoxReserved_Unchecked(object sender, RoutedEventArgs e)
        {
			this.UnsetSelectedRoomState(ReservedRoomState);
		}

        private void checkBoxOccupied_Checked(object sender, RoutedEventArgs e)
        {
			this.SetSelectedRoomState(OccupiedRoomState);
        }

        private void checkBoxOccupied_Unchecked(object sender, RoutedEventArgs e)
        {
			this.UnsetSelectedRoomState(OccupiedRoomState);
        }

		private void SetSelectedRoomState(string roomState)
		{
			if (!this.selectedRoomState.Contains(roomState))
			{
				this.selectedRoomState.Add(roomState);
				this.RecolorRooms();
			}
		}

		private void UnsetSelectedRoomState(string roomState)
		{
			if (this.selectedRoomState.Contains(roomState))
			{
				this.selectedRoomState.Remove(roomState);
				this.RecolorRooms();
			}
		}

		private void RecolorRooms()
        {
            foreach (MapShapeData room in this.rooms)
            {
				room.ShapeFill.Fill = this.Resources["roomsDefault"] as Brush;
				room.ShapeFill.Stroke = this.Resources["roomsDefaultStroke"] as Brush;

                foreach (string condition in this.selectedRoomState)
                {
                    foreach (string type in this.selectedRoomType)
                    {
                        if ((string)room.ExtendedData.GetValue(RoomStateField) == condition &&
                            (string)room.ExtendedData.GetValue(RoomTypeField) == type)
                        {
                            string roomState = room.ExtendedData.GetValue(RoomStateField).ToString();
                            string roomStateFillKey = roomState;
                            string roomStateStrokeKey = string.Format("{0}Stroke", roomState);
							room.ShapeFill.Fill = this.Resources[roomStateFillKey] as Brush;
							room.ShapeFill.Stroke = this.Resources[roomStateStrokeKey] as Brush;
						}
                    }
                }
            }
        }

        private void checkBoxLuxury_Checked(object sender, RoutedEventArgs e)
        {
			this.SetSelectedRoomType(LuxuryRoomType);
        }

        private void checkBoxLuxury_Unchecked(object sender, RoutedEventArgs e)
        {
			this.UnsetSelectedRoomType(LuxuryRoomType);
        }

        private void checkBoxBusinessLuxury_Checked(object sender, RoutedEventArgs e)
        {
			this.SetSelectedRoomType(BusinessLuxuryRoomType);
        }

        private void checkBoxBusinessLuxury_Unchecked(object sender, RoutedEventArgs e)
        {
			this.UnsetSelectedRoomType(BusinessLuxuryRoomType);
		}

        private void checkBoxComfort_Checked(object sender, RoutedEventArgs e)
        {
			this.SetSelectedRoomType(ComfortRoomType);
        }

        private void checkBoxComfort_Unchecked(object sender, RoutedEventArgs e)
        {
			this.UnsetSelectedRoomType(ComfortRoomType);
		}

        private void checkBoxBusinessStandart_Checked(object sender, RoutedEventArgs e)
        {
			this.SetSelectedRoomType(BusinessStandardRoomType);
        }

        private void checkBoxBusinessStandart_Unchecked(object sender, RoutedEventArgs e)
        {
			this.UnsetSelectedRoomType(BusinessStandardRoomType);
        }

        private void checkBoxStandart_Checked(object sender, RoutedEventArgs e)
        {
			this.SetSelectedRoomType(StandardRoomType);
        }

        private void checkBoxStandart_Unchecked(object sender, RoutedEventArgs e)
        {
			this.UnsetSelectedRoomType(StandardRoomType);
		}

        private void checkBoxEconom_Unchecked(object sender, RoutedEventArgs e)
        {
			this.UnsetSelectedRoomType(EconomyRoomType);
		}

        private void checkBoxEconom_Checked(object sender, RoutedEventArgs e)
        {
			this.SetSelectedRoomType(EconomyRoomType);
		}

		private void SetSelectedRoomType(string roomType)
		{
			if (!this.selectedRoomType.Contains(roomType))
			{
				this.selectedRoomType.Add(roomType);
				this.RecolorRooms();
			}
		}

		private void UnsetSelectedRoomType(string roomType)
		{
			if (this.selectedRoomType.Contains(roomType))
			{
				this.selectedRoomType.Remove(roomType);
				this.RecolorRooms();
			}
		}

#if WPF
		private void RoomSelectionChanged(object sender, SelectionChangedEventArgs e)
#else
		private void RoomSelectionChanged(object sender, Controls.SelectionChangedEventArgs e)
#endif
		{
			if (e.AddedItems != null)
			{
				foreach (object addedItem in e.AddedItems)
				{
					MapShapeData room = addedItem as MapShapeData;
					if (room != null && this.rooms.Contains(room))
					{
						if (this.lastSelectedRoom != null && this.lastSelectedRoom != room)
						{
							this.visualizationLayer.Unselect(this.lastSelectedRoom);
						}

						this.UpdateRoomStatusInfo(room);
						this.lastSelectedRoom = room;
					}
				}
			}
		}

		private void UpdateRoomStatusInfo(MapShapeData roomShape)
		{
			string roomNumber = roomShape.ExtendedData.GetValue(RoomNumberField).ToString();
			string roomType = roomShape.ExtendedData.GetValue(RoomTypeField).ToString();
			string roomState = roomShape.ExtendedData.GetValue(RoomStateField).ToString();

			this.roomInfoTextBlock.Text = string.Format("{0}, {1}", roomNumber, roomType);
			this.statusTextBlock.Text = roomState;
			this.statusMarker.Fill = this.Resources[roomState] as Brush;
			this.statusMarker.Stroke = this.Resources[string.Format("{0}Stroke", roomState)] as Brush;

			switch (roomState)
			{
				case FreeRoomState:
					this.statusChangingDateTextBlock.Text = "";
					this.statusChangingDate.Visibility = System.Windows.Visibility.Collapsed;
					break;
				case ReservedRoomState:
					this.statusChangingDateTextBlock.Text = ((DateTime)roomShape.ExtendedData.GetValue("ResDate")).ToShortDateString();
					this.statusChangingDate.Visibility = System.Windows.Visibility.Visible;
					break;
				case OccupiedRoomState:
					this.statusChangingDateTextBlock.Text = ((DateTime)roomShape.ExtendedData.GetValue("ResDate")).ToShortDateString();
					this.statusChangingDate.Visibility = System.Windows.Visibility.Visible;
					break;
			}
		}
	}
}
