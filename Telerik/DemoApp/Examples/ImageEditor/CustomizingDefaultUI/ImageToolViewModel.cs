using System.Collections.ObjectModel;
using Telerik.Windows.Controls;
using Telerik.Windows.Media.Imaging.ImageEditorCommands.RoutedCommands;
using Telerik.Windows.Media.Imaging.Shapes;
using Telerik.Windows.Media.Imaging.Tools;

namespace Telerik.Windows.Examples.ImageEditor.CustomizingDefaultUI
{

    public class ImageToolViewModel
    {
        public bool IsSelected { get; set; }
        public ImageToolItem Item { get; set; }

        public ImageToolViewModel(ImageToolItem item)
        {
            this.Item = item;
            this.IsSelected = true;
        }

        public static ObservableCollection<ImageToolViewModel> GetAllTools()
        {
            ObservableCollection<ImageToolViewModel> toolsCollection = new ObservableCollection<ImageToolViewModel>();

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
             {
                 Text = "Resize",
                 ImageKey = "Resize",
                 Command = ImageEditorRoutedCommands.ExecuteTool,
                 CommandParameter = new ResizeTool()
             }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
             {
                 Text = "Rotate 90",
                 ImageKey = "Rotate90CW",
                 Command = ImageEditorRoutedCommands.Rotate90Clockwise
             }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
             {
                 Text = "Rotate 180",
                 ImageKey = "Rotate180CW",
                 Command = ImageEditorRoutedCommands.Rotate180
             }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
             {
                 Text = "Rotate 270",
                 ImageKey = "Rotate90CCW",
                 Command = ImageEditorRoutedCommands.Rotate90Counterclockwise
             }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
             {
                 Text = "Round Corners",
                 ImageKey = "RoundCorners",
                 Command = ImageEditorRoutedCommands.ExecuteTool,
                 CommandParameter = new RoundCornersTool()
             }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
             {
                 Text = "Flip Horizontal",
                 ImageKey = "FlipHorizontal",
                 Command = ImageEditorRoutedCommands.FlipHorizontal
             }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
             {
                 Text = "Flip Vertical",
                 ImageKey = "FlipVertical",
                 Command = ImageEditorRoutedCommands.FlipVertical
             }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
             {
                 Text = "Crop",
                 ImageKey = "Crop",
                 Command = ImageEditorRoutedCommands.ExecuteTool,
                 CommandParameter = new CropTool()
             }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
            {
                Text = "Draw Text",
                ImageKey = "DrawText",
                Command = ImageEditorRoutedCommands.ExecuteTool,
                CommandParameter = new DrawTextTool()
            }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
            {
                Text = "Draw",
                ImageKey = "Draw",
                Command = ImageEditorRoutedCommands.ExecuteTool,
                CommandParameter = new DrawTool()
            }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
            {
                Text = "Shape",
                ImageKey = "Shape",
                Command = ImageEditorRoutedCommands.ExecuteTool,
                CommandParameter = GetShapeTool()                
            }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
             {
                 Text = "Hue Shift",
                 ImageKey = "HueShift",
                 Command = ImageEditorRoutedCommands.ExecuteTool,
                 CommandParameter = new HueShiftTool()
             }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
             {
                 Text = "Saturation",
                 ImageKey = "Saturation",
                 Command = ImageEditorRoutedCommands.ExecuteTool,
                 CommandParameter = new SaturationTool()
             }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
             {
                 Text = "Contrast",
                 ImageKey = "Contrast",
                 Command = ImageEditorRoutedCommands.ExecuteTool,
                 CommandParameter = new ContrastTool()
             }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
             {
                 Text = "Invert Colors",
                 ImageKey = "Invert",
                 Command = ImageEditorRoutedCommands.InvertColors
             }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
             {
                 Text = "Sharpen",
                 ImageKey = "Sharpen",
                 Command = ImageEditorRoutedCommands.ExecuteTool,
                 CommandParameter = new SharpenTool()
             }));

            toolsCollection.Add(new ImageToolViewModel(new ImageToolItem()
             {
                 Text = "Blur",
                 ImageKey = "Blur",
                 Command = ImageEditorRoutedCommands.ExecuteTool,
                 CommandParameter = new BlurTool()
             }));

            return toolsCollection;
        }

        private static ShapeTool GetShapeTool()
        {
            ShapeTool tool = new ShapeTool();
            tool.Shapes.Add(new RectangleShape());
            tool.Shapes.Add(new EllipseShape());
            tool.Shapes.Add(new LineShape());
            
            return tool;
        }
    }
}
