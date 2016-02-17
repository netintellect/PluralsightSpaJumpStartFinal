using System.Collections;
using System.Collections.Generic;
using System.Windows.Media;

namespace Telerik.Examples.Gauge
{
	/// <summary>
	/// Items source that represents solid brush
	/// </summary>
	public class SolidBrushItemsSource : IEnumerable
	{
		private static string[] brushNameList = new string[]
			{
				"Black",
			    "AntiqueWhite",
				"Black",
				"Blue",
                "DarkBlue",
				"Brown",
				"Cyan",
				"DarkGray",
                "DarkSlateBlue",
				"Gray",
				"Green",
				"LightGray",
				"Magenta",
				"Orange",
				"Purple",
				"Red",
                "Thistle",
				"Yellow",
				"White"
			};

		private static Dictionary<string, Color> brushDictionary = new Dictionary<string, Color>();

		private static Dictionary<Color, string> colorDictionary = new Dictionary<Color, string>();

		static SolidBrushItemsSource()
		{
			brushDictionary["Transparent"] = Colors.Transparent;
            brushDictionary["AntiqueWhite"] = Color.FromArgb(255, 250, 235, 215); 
			brushDictionary["Black"] = Colors.Black; 
			brushDictionary["Blue"] = Color.FromArgb(255,9,111,172);
            brushDictionary["DarkBlue"] = Color.FromArgb(255, 3, 28, 75);
			brushDictionary["Brown"] = Colors.Brown;
			brushDictionary["Cyan"] = Colors.Cyan;
            brushDictionary["DarkGray"] = Colors.DarkGray;
            brushDictionary["DarkSlateBlue"] = Color.FromArgb(255, 72, 61, 139); 
			brushDictionary["Gray"] = Colors.Gray;
			brushDictionary["Green"] = Colors.Green;
			brushDictionary["LightGray"] = Colors.LightGray;
			brushDictionary["Magenta"] = Colors.Magenta;
			brushDictionary["Orange"] = Colors.Orange;
			brushDictionary["Purple"] = Colors.Purple;
			brushDictionary["Red"] = Colors.Red;
            brushDictionary["Thistle"] = Color.FromArgb(255, 216, 191, 216); 
            brushDictionary["Yellow"] = Colors.Yellow;
            brushDictionary["White"] = Colors.White;

			colorDictionary[Colors.Transparent] = "Transparent";
            colorDictionary[Color.FromArgb(255, 250, 235, 215)] = "AntiqueWhite";
			colorDictionary[Colors.Black] = "Black";
			colorDictionary[Color.FromArgb(255, 9, 111, 172)] = "Blue";
            colorDictionary[Color.FromArgb(255, 3, 28, 75)] = "DarkBlue";
			colorDictionary[Colors.Brown] = "Brown";
			colorDictionary[Colors.Cyan] = "Cyan";
            colorDictionary[Colors.DarkGray] = "DarkGray";
            colorDictionary[Color.FromArgb(255, 72, 61, 139)] = "DarkSlateBlue";
			colorDictionary[Colors.Gray] = "Gray";
			colorDictionary[Colors.Green] = "Green";
			colorDictionary[Colors.LightGray] = "LightGray";
			colorDictionary[Colors.Magenta] = "Magenta";
			colorDictionary[Colors.Orange] = "Orange";
			colorDictionary[Colors.Purple] = "Purple";
			colorDictionary[Colors.Red] = "Red";
            colorDictionary[Color.FromArgb(255, 216, 191, 216)] = "Thistle";
            colorDictionary[Colors.Yellow] = "Yellow";
            colorDictionary[Colors.White] = "White"; 
		}

		/// <summary>
		/// Creates instance of the class
		/// </summary>
		public SolidBrushItemsSource()
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

			return Colors.Transparent;
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
