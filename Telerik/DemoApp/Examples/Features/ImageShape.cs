using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls.Diagrams;

namespace Telerik.Windows.Diagrams.Features
{
    /// <summary>
    /// Shape displaying an image.
    /// </summary>
    public class ImageShape : RadDiagramShapeBase
    {
        /// <summary>
        /// The Source Dependency Property
        /// </summary>
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageShape),
                new FrameworkPropertyMetadata(null,
                    OnSourceChanged));

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageShape"/> class.
        /// </summary>
        public ImageShape()
        {
            DefaultStyleKey = typeof(ImageShape);
        }

        /// <summary>
        /// Gets or sets the Image source property.  
        /// </summary>
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        /// <summary>
        /// Handles changes to the Source property.
        /// </summary>
        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ImageShape)d).OnSourceChanged(e);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the Source property.
        /// </summary>
        protected virtual void OnSourceChanged(DependencyPropertyChangedEventArgs e)
        {
        }
    }
}