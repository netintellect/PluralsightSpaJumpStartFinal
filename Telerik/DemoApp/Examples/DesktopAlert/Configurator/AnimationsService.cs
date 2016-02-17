using System.Collections.Generic;
using System.Windows.Controls;
using Telerik.Windows.Controls.Animation;

namespace Telerik.Windows.Examples.DesktopAlert.Configurator
{
    public static class AnimationService
    {
        public static List<AnimationItem> GetShowAnimations()
        {
            var showAnimations = new List<AnimationItem>();
            showAnimations.Add(new AnimationItem
            {
                Title = "None"
            });
            showAnimations.Add(new AnimationItem
            {
                Title = "Fade-In Animation (default)",
                Animation = new FadeAnimation { Direction = AnimationDirection.In, MinOpacity = 0.5d, MaxOpacity = 0.9d, SpeedRatio = 0.5d }
            });
            showAnimations.Add(new AnimationItem
            {
                Title = "Top Slide-In Animation",
                Animation = new SlideAnimation { Direction = AnimationDirection.In, SlideMode = SlideMode.Top, SpeedRatio = 0.3d, PixelsToAnimate = 100 }
            });
            showAnimations.Add(new AnimationItem
            {
                Title = "Bottom Slide-In Animation",
                Animation = new SlideAnimation { Direction = AnimationDirection.In, SlideMode = SlideMode.Bottom, SpeedRatio = 0.3d, PixelsToAnimate = 100 }
            });
            showAnimations.Add(new AnimationItem
            {
                Title = "Left Slide-In Animation",
                Animation = new SlideAnimation { Direction = AnimationDirection.In, SlideMode = SlideMode.Top, Orientation = Orientation.Horizontal, SpeedRatio = 0.3d, PixelsToAnimate = 360 }
            });
            showAnimations.Add(new AnimationItem
            {
                Title = "Right Slide-In Animation",
                Animation = new SlideAnimation { Direction = AnimationDirection.In, SlideMode = SlideMode.Bottom, Orientation = Orientation.Horizontal, SpeedRatio = 0.3d, PixelsToAnimate = 360 }
            });
            showAnimations.Add(new AnimationItem
            {
                Title = "Scale-In Animation",
                Animation = new ScaleAnimation { Direction = AnimationDirection.In, MaxScale = 1d, MinScale = 0.5d, SpeedRatio = 0.5d }
            });

            return showAnimations;
        }

        public static List<AnimationItem> GetHideAnimations()
        {
            var hideAnimations = new List<AnimationItem>();
            hideAnimations.Add(new AnimationItem
            {
                Title = "None"
            });
            hideAnimations.Add(new AnimationItem
            {
                Title = "Fade-out Animation (default)",
                Animation = new FadeAnimation { Direction = AnimationDirection.Out, MinOpacity = 0.5d, MaxOpacity = 0.9d, SpeedRatio = 0.5d }
            });
            hideAnimations.Add(new AnimationItem
            {
                Title = "Top Slide-Out Animation",
                Animation = new SlideAnimation { Direction = AnimationDirection.Out, SlideMode = SlideMode.Top, SpeedRatio = 0.2d, PixelsToAnimate = 100 }
            });
            hideAnimations.Add(new AnimationItem
            {
                Title = "Bottom Slide-Out Animation",
                Animation = new SlideAnimation { Direction = AnimationDirection.Out, SlideMode = SlideMode.Bottom, SpeedRatio = 0.2d, PixelsToAnimate = 100 }
            });
            hideAnimations.Add(new AnimationItem
            {
                Title = "Left Slide-Out Animation",
                Animation = new SlideAnimation { Direction = AnimationDirection.Out, SlideMode = SlideMode.Top, Orientation = Orientation.Horizontal, SpeedRatio = 0.18d, PixelsToAnimate = 360 }
            });
            hideAnimations.Add(new AnimationItem
            {
                Title = "Right Slide-Out Animation",
                Animation = new SlideAnimation { Direction = AnimationDirection.Out, SlideMode = SlideMode.Bottom, Orientation = Orientation.Horizontal, SpeedRatio = 0.18d, PixelsToAnimate = 360 }
            });
            hideAnimations.Add(new AnimationItem
            {
                Title = "Scale-Out Animation",
                Animation = new ScaleAnimation { Direction = AnimationDirection.Out, MaxScale = 1d, MinScale = 0.5d, SpeedRatio = 0.5d }
            });

            return hideAnimations;
        }
    }
}
