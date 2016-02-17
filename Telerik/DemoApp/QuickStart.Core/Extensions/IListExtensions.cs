using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.QuickStart
{
	public static class IListExtensions
	{
		public static T NextOrFirstOrDefault<T>(this IList<T> list, T item)
		{
			if (list.Count == 0)
			{
				return default(T);
			}
			int currentIndex = list.IndexOf(item);
			int nextIndex = currentIndex + 1;
			if (nextIndex >= list.Count)
			{
				nextIndex = 0;
			}
			return list[nextIndex];
		}

		public static T PreviousOrLastOrDefault<T>(this IList<T> list, T item)
		{
			if (list.Count == 0)
			{
				return default(T);
			}
			int currentIndex = list.IndexOf(item);
			int prevIndex = currentIndex - 1;
			if (prevIndex < 0)
			{
				prevIndex = list.Count - 1;
			}
			return list[prevIndex];
		}
	}
}
