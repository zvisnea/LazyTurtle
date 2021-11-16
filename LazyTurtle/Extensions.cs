using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// A couple of useful extensions I had laying around

namespace LazyTurtle
{
	public static class Extensions
	{
		public static string Delimit<T>(this T[] array, string delimiter) 
		{
			if (array is string[])
				return String.Join(delimiter, array as string[]);
			List<string> strings = new List<string>();
			foreach (T item in array)
				strings.Add(item.ToString());
			return String.Join(delimiter, strings.ToArray());
		}

		public static string FormatNumber(this int amount)
		{
			string samount = amount.ToString();
			StringBuilder sb = new StringBuilder(samount);
			if (amount.ToString().Length > 3)
				for (int i = samount.Length - 3; i > 0; i -= 3)
					sb.Insert(i, ",");
			return sb.ToString();
		}
	}
}