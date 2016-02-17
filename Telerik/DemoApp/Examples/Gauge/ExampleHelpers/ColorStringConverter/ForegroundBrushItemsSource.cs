using System.Collections;
using System.Collections.Generic;
using System.Windows.Media;

namespace Telerik.Examples.Gauge
{
	/// <summary>
	/// Items source that represents solid brush
	/// </summary>
	public class ForegroundBrushItemsSource : IEnumerable
	{
		private static string[] brushNameList = new string[]
			{
				"Black", 
                "Purple",
                "Blue", 
                "Green",
                "Red"
			};

		private static Dictionary<string, Color> brushDictionary = new Dictionary<string, Color>();

		private static Dictionary<Color, string> colorDictionary = new Dictionary<Color, string>();

		static ForegroundBrushItemsSource()
		{
            brushDictionary["Black"] = Colors.Black;
            brushDictionary["Purple"] = Color.FromArgb(255, 102, 51, 153);
            brushDictionary["Blue"] = Color.FromArgb(255, 13, 96, 145);
            brushDictionary["Green"] = Color.FromArgb(255, 39, 118, 39);
            brushDictionary["Red"] = Color.FromArgb(255, 204, 0, 0);
         
			colorDictionary[Colors.Black] = "Black";
            colorDictionary[Color.FromArgb(255, 102, 51, 153)] = "Purple";
            colorDictionary[Color.FromArgb(255, 13, 96, 145)] = "Blue";
            colorDictionary[Color.FromArgb(255, 39, 118, 39)] = "Green";
            colorDictionary[Color.FromArgb(255, 204, 0, 0)] = "Red";
		}

		/// <summary>
		/// Creates instance of the class
		/// </summary>
        public ForegroundBrushItemsSource()
		{
		}

		/// <summary>
		/// Gets color by name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static Color GetColor(string name)
		{
			if (brushDictionary.ContainsKey(name))
			{
				return brushDictionary[name];
			}

			return Colors.Black;
		}

		/// <summary>
		/// Gets name of the color
		/// </summary>
		/// <param name="color"></param>
		/// <returns></returns>
		public static string GetName(Color color)
		{
			if (colorDictionary.ContainsKey(color))
			{
				return colorDictionary[color];
			}

			return null;
		}

		#region IEnumerable Members

		/// <summary>
		/// Gets enumerator
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetEnumerator()
		{
			return brushNameList.GetEnumerator();
		}

		#endregion
	}
}
