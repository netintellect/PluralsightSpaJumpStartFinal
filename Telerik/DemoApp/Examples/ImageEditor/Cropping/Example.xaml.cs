using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Media.Imaging.Tools;

namespace Telerik.Windows.Examples.ImageEditor.Cropping
{
    public partial class Example : UserControl
    {
        private static readonly Size defaultCropSize = new Size(150, 150);

        private readonly ExampleViewModel context;
        private bool shouldCrop;

        public Example()
        {
            InitializeComponent();
             
            this.context = new ExampleViewModel();
            this.DataContext = this.context;

            this.imageEditor.ToolSettingsContainer = this.cropSettings;
        }

      
        private void AttachToEvents()
        {
            this.context.InitialSizeChanged += this.CropTool_InitialSizeChanged;
            this.context.SelectedContactChanged += this.Context_SelectedContactChanged;
            this.imageEditor.ToolCommitted += this.ImageEditor_ToolCommitted;
            this.imageEditor.ToolCommitting += this.ImageEditor_ToolCommitting;
        }

        private void DetachFromEvents()
        {
            this.context.InitialSizeChanged -= this.CropTool_InitialSizeChanged;
            this.context.SelectedContactChanged -= this.Context_SelectedContactChanged;
            this.imageEditor.ToolCommitted -= this.ImageEditor_ToolCommitted;
            this.imageEditor.ToolCommitting -= this.ImageEditor_ToolCommitting;
        }

        private void LoadTool(Size? fixedSize, double aspectRatio, Size initialSize)
        {
            this.imageEditor.CancelExecuteTool();

            CropTool tool = new CropTool();
            tool.FixedSize = fixedSize;
            tool.InitialSize = initialSize;
            if (aspectRatio > 0)
            {
                tool.AspectRatio = aspectRatio;
            }

            this.imageEditor.ExecuteTool(tool);
        }

        private void SaveCroppedImage()
        {
            this.shouldCrop = true;
            this.imageEditor.CommitTool();
            this.context.CroppedImage = this.imageEditor.History.CurrentImage;
            this.Reset();
        }

        private void Reset()
        {
            ITool tool = this.imageEditor.ExecutingTool;
            if (this.imageEditor.History.CanUndo)
            {
                this.imageEditor.History.Undo();
            }
            this.imageEditor.ExecuteTool(tool);
        }

        private void CropTool_InitialSizeChanged(object sender, EventArgs e)
        {
            double aspectRatio = this.context.InitialSize.Width / this.context.InitialSize.Height;
            this.LoadTool(null, aspectRatio, this.context.InitialSize);
        }

        private void ImageEditor_ToolCommitting(object sender, ToolCommittingEventArgs e)
        {
            e.Cancel = !this.shouldCrop;
        }

        private void ImageEditor_ToolCommitted(object sender, ToolCommittedEventArgs e)
        {
            this.shouldCrop = false;
        }

        private void Context_SelectedContactChanged(object sender, EventArgs e)
        {
            this.LoadTool(null, 1, defaultCropSize);
            this.SaveCroppedImage();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.SaveCroppedImage();
        }

        private void Example_Loaded(object sender, RoutedEventArgs e)
        {
            this.AttachToEvents();
            this.LoadTool(null, 1, defaultCropSize);
        }

        private void Example_Unloaded(object sender, RoutedEventArgs e)
        {
            this.DetachFromEvents();
        }
    }
}