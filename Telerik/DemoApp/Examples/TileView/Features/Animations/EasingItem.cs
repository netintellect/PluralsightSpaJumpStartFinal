using System.Collections.Generic;
using System.Windows.Media.Animation;

namespace Telerik.Windows.Examples.TileView.Common
{
	public class EasingItem
	{
		public EasingFunctionBase Easing { get; set; }

		public string Name { get; set; }

		public static IEnumerable<EasingMode> GetEasingModes()
		{
			List<EasingMode> easings = new List<EasingMode>();

			easings.Add(EasingMode.EaseIn);
			easings.Add(EasingMode.EaseInOut);
			easings.Add(EasingMode.EaseOut);
			return easings;
		}

		public static IEnumerable<EasingItem> GetEasings()
		{
			List<EasingItem> items = new List<EasingItem>();
			items.Add(new EasingItem
			{
				Name = "BackEase",
				Easing = new BackEase()
			});
			items.Add(new EasingItem
			{
				Name = "BounceEase",
				Easing = new BounceEase()
			});
			items.Add(new EasingItem
			{
				Name = "CircleEase",
				Easing = new CircleEase()
			});
			items.Add(new EasingItem
			{
				Name = "CubicEase",
				Easing = new CubicEase()
			});
			items.Add(new EasingItem
			{
				Name = "ElasticEase",
				Easing = new ElasticEase()
			});
			items.Add(new EasingItem
			{
				Name = "ExponentialEase",
				Easing = new ExponentialEase()
			});
			items.Add(new EasingItem
			{
				Name = "PowerEase",
				Easing = new PowerEase()
			});
			items.Add(new EasingItem
			{
				Name = "QuadraticEase",
				Easing = new QuadraticEase()
			});
			items.Add(new EasingItem
			{
				Name = "SineEase",
				Easing = new SineEase()
			});

			return items;
		}
	}
}

