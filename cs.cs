using System;
using System.Collections.Generic;	

public class Day
{
	public string date;
	public int open;
	public int high;
	public int low;
	public int close;
	public float avg;
}

public class Program
{
	
		public static readonly int ARRAY_SIZE = 4;
	public static Dictionary<string, int> monthsMap = new Dictionary<string, int>();
		// Function which initializes the monthsMap
	public static void sort_months()
	{
		monthsMap["Jan"] = 1;
		monthsMap["Feb"] = 2;
		monthsMap["Mar"] = 3;
		monthsMap["Apr"] = 4;
		monthsMap["May"] = 5;
		monthsMap["Jun"] = 6;
		monthsMap["Jul"] = 7;
		monthsMap["Aug"] = 8;
		monthsMap["Sep"] = 9;
		monthsMap["Oct"] = 10;
		monthsMap["Nov"] = 11;
		monthsMap["Dec"] = 12;
	}

	public static bool comp(Day a, Day b)
	{
		// Comparing the years
		string str1 = a.date.Substring(7, 5);
		string str2 = b.date.Substring(7, 5);
		if (str1.CompareTo(str2) != 0)
		{
			if (str1.CompareTo(str2) > 0)
			{
				return true;
			}
			return false;
		}

		// Comparing the months
		string month_sub_a = a.date.Substring(3, 3);
		string month_sub_b = b.date.Substring(3, 3);

		// Taking numeric value of months from monthsMap
		int month_a = monthsMap[month_sub_a];
		int month_b = monthsMap[month_sub_b];
		if (month_a != month_b)
		{
			return month_a > month_b;
		}

		// Comparing the days
		string day_a = a.date.Substring(0, 2);
		string day_b = b.date.Substring(0, 2);
		if (day_a.CompareTo(day_b) > 0)
		{
			return true;
		}
		return false;
	}

	public static string todayDate()
	{
		time_t t = new time_t();
		tm tmp;
		string MY_TIME = new string(new char[50]);
		time(t);
		// localtime() uses the time pointed by t ,
		// to fill a tm structure with the
		// values that represent the
		// corresponding local time.
		tmp = localtime(t);
		// using strftime to display time
		// Copies into ptr the content of format,
		// expanding its format specifiers into the corresponding values
		// that represent the time described in timeptr, with a limit of maxsize characters.
		strftime(MY_TIME, sizeof(char), "%d %b %Y", tmp);

		return MY_TIME;
	}
	//The following function to add the default data to the array
	public static void defaultData(Day[] arr_days)
	{

		//Day 1
		arr_days[0].date = "19 Feb 2021";
		arr_days[0].open = 100;
		arr_days[0].high = 100;
		arr_days[0].low = 100;
		arr_days[0].close = 5;
		arr_days[0].avg = 0F;
		//Day 2
		arr_days[1].date = "29 Jan 2021";
		arr_days[1].open = 100;
		arr_days[1].high = 100;
		arr_days[1].low = 100;
		arr_days[1].close = 10;
		arr_days[1].avg = 0F;
		//Day 3
		arr_days[2].date = "28 Jan 2021";
		arr_days[2].open = 100;
		arr_days[2].high = 100;
		arr_days[2].low = 100;
		arr_days[2].close = 20;
		arr_days[2].avg = 0F;
	}
	
	public static void calculateAVGClosingPrice(Day[] arr_days)
	{
		int sum = 0;
		for (int i = 0 ; i < ARRAY_SIZE ; i++)
		{
			sum += arr_days[i].close;
		}
		arr_days[ARRAY_SIZE-1].avg = (float)sum / ARRAY_SIZE;
	}
	
	public static void Main(string[] args)
	{
			Console.Write(todayDate());
	Console.Write("\n");
	// Array with 4 days, each day has 6 parts [Date - Open - High - Low - Close - AVG]
	Day[] arr_days = Arrays.InitializeWithDefaultInstances<Day>(ARRAY_SIZE);
	defaultData(arr_days);

	arr_days[3].date = todayDate();
	arr_days[3].open = 100;
	arr_days[3].high = 100;
	arr_days[3].low = 100;
	arr_days[3].close = 8;
	arr_days[3].avg = 0;

	calculateAVGClosingPrice(arr_days);

	Console.Write("Before sorting");
	Console.Write("\n");
	Console.Write("Date        - Open  - High  - Low  - Close  - AVG ");
	Console.Write("\n");
	for (int i = 0 ; i < ARRAY_SIZE; i++)
	{
		Console.Write(arr_days[i].date);
		Console.Write(" - ");
		Console.Write(arr_days[i].open);
		Console.Write("   - ");
		Console.Write(arr_days[i].high);
		Console.Write("   - ");
		Console.Write(arr_days[i].low);
		Console.Write("  - ");
		Console.Write(arr_days[i].close);
		Console.Write(" - ");
		Console.Write("{0,10}", arr_days[i].avg);
		Console.Write("{0}", "\n");
	}

	sort_months();

	//sort(arr_days, arr_days + ARRAY_SIZE, comp);
	Console.Write("{0}", "After sorting");
	Console.Write("{0}", "\n");
		for (int i = 0 ; i < ARRAY_SIZE; i++)
		{
		Console.Write("{0}", arr_days[i].date);
		Console.Write("{0}", " - ");
		Console.Write("{0}", arr_days[i].open);
		Console.Write("{0}", "   - ");
		Console.Write("{0}", arr_days[i].high);
		Console.Write("{0}", "   - ");
		Console.Write("{0}", arr_days[i].low);
		Console.Write("{0}", "  - ");
		Console.Write("{0}", arr_days[i].close);
		Console.Write("{0}", " - ");
		Console.Write("{0,10}", arr_days[i].avg);
		Console.Write("{0}", "\n");
		}
	}
}
internal static class Arrays
{
	public static T[] InitializeWithDefaultInstances<T>(int length) where T : new()
	{
		T[] array = new T[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = new T();
		}
		return array;
	}

	public static void DeleteArray<T>(T[] array) where T: System.IDisposable
	{
		foreach (T element in array)
		{
			if (element != null)
				element.Dispose();
		}
	}
}
