using System.Collections.Generic;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.BulletGraph.Gallery
{
    public class GalleryViewModel : ViewModelBase
    {
        private Brush _additionalComparativeMeasureBrush;
        private List<Brush> _qualitativeRangeBrushes;

        public GalleryViewModel()
        {
            this._qualitativeRangeBrushes = new List<Brush>();
            this._qualitativeRangeBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x76, 0x76, 0x76)));
            this._qualitativeRangeBrushes.Add(new SolidColorBrush(Color.FromArgb(0xBF, 0x76, 0x76, 0x76)));
            this._qualitativeRangeBrushes.Add(new SolidColorBrush(Color.FromArgb(0x7F, 0x76, 0x76, 0x76)));
            this._qualitativeRangeBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xD6, 0xD4, 0xD4)));
            this._qualitativeRangeBrushes.Add(new SolidColorBrush(Color.FromArgb(0x99, 0xD6, 0xD4, 0xD4)));

            this._additionalComparativeMeasureBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
        }

        public Brush AdditionalComparativeMeasureBrush
        {
            get
            {
                return _additionalComparativeMeasureBrush;
            }
        }

        public IList<Brush> QualitativeRangesBrushes
        {
            get
            {
                return _qualitativeRangeBrushes;
            }
        }
    }
}

