using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.Map
{
	/// <summary>
	/// Items source that represents solid brush
	/// </summary>
	public class SolidBrushItemsSource : IEnumerable
	{
		private static string[] brushNameList = new string[]
			{
				"Transparent",
				"Black",
				"Blue",
				"DarkBlue",
				"Brown",
				"Cyan",
				"DarkGray",
				"Gray",
				"Green",
				"LightGray",
				"Magenta",
				"Orange",
				"Purple",
				"Red",
				"White",
				"Yellow"
			};

		private static Dictionary<string, Color> brushDictionary = new Dictionary<string, Color>();

		private static Dictionary<Color, string> colorDictionary = new Dictionary<Color, string>();

		static SolidBrushItemsSource()
		{
			brushDictionary["Transparent"] = Colors.Transparent;
			brushDictionary["Black"] = Colors.Black;
			brushDictionary["Blue"] = Color.FromArgb(255, 9, 111, 172);
			brushDictionary["DarkBlue"] = Color.FromArgb(255, 3, 28, 75);
			brushDictionary["Brown"] = Colors.Brown;
			brushDictionary["Cyan"] = Colors.Cyan;
			brushDictionary["DarkGray"] = Colors.DarkGray;
			brushDictionary["Gray"] = Colors.Gray;
			brushDictionary["Green"] = Colors.Green;
			brushDictionary["LightGray"] = Colors.LightGray;
			brushDictionary["Magenta"] = Colors.Magenta;
			brushDictionary["Orange"] = Colors.Orange;
			brushDictionary["Purple"] = Colors.Purple;
			brushDictionary["Red"] = Colors.Red;
			brushDictionary["White"] = Colors.White;
			brushDictionary["Yellow"] = Colors.Yellow;

			colorDictionary[Colors.Transparent] = "Transparent";
			colorDictionary[Colors.Black] = "Black";
			colorDictionary[Colors.Blue] = "Blue";
			colorDictionary[Color.FromArgb(255, 3, 28, 75)] = "DarkBlue";
			colorDictionary[Colors.Brown] = "Brown";
			colorDictionary[Colors.Cyan] = "Cyan";
			colorDictionary[Colors.DarkGray] = "DarkGray";
			colorDictionary[Colors.Gray] = "Gray";
			colorDictionary[Colors.Green] = "Green";
			colorDictionary[Colors.LightGray] = "LightGray";
			colorDictionary[Colors.Magenta] = "Magenta";
			colorDictionary[Colors.Orange] = "Orange";
			colorDictionary[Colors.Purple] = "Purple";
			colorDictionary[Colors.Red] = "Red";
			colorDictionary[Colors.White] = "White";
			colorDictionary[Colors.Yellow] = "Yellow";
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
