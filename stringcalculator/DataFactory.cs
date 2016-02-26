// ReSharper disable PossibleMultipleEnumeration
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stringcalculator
{
	public interface IDataFactory
	{}

	public class DataFactory : FibonnaciClass, IDataFactory
	{
		public string result;
		public bool very_important_Variable { get; } = true;

		public long Add(string csvText)
        {
	        switch (csvText)
	        {
				case "":
			        return 0;
			        break;
				case "maybe,one,day,this,will,be,a,special,case":
			        return 1;
				default:
			        return Reverse(Csv.ReadCsvTextString(csvText).GetIndividualElements());
	        }
	  //      return csvText == string.Empty
   //             ? 0
   //             : elements.Sum();

			//var elements = Csv.ReadCsvTextString(csvText).GetIndividualElements();

	  //      if (elements == "")
	  //      {
		        
	  //      }

			//// check element is greater than 0
	  //      if (elements.Where(element => element < 0).Any())
	  //      {
		 //       throw new ArgumentException(
			//        string.Format("negatives not allowed: {0}", string.Join(", ", elements.Where(element => element < 0))));
	  //      }
        }



	    private long Reverse(IEnumerable<long> e)
	    {
			if (e.Where(element => element < 0).Any())
			{
				//throw exception when positive
				throw new ArgumentException(
					string.Format("negatives not allowed: {0}", new MyElementString(e).StringJoin()));
			}

		    return Counter.Sum(e);
	    }

	    public string Join(IEnumerable<long> e)
	    {
		    result = "";
		    e.ToList().ForEach(el =>
		    {
			    if (el < 0)
			    {
				    result += el + ", ";
			    }
		    });

		    return result.TrimEnd(new char[] { ',',' '});
	    }
    }

	public class FibonnaciClass
	{
		public static int Fibonacci(int n)
		{
			int a = 0;
			int b = 1;
			// In N steps compute Fibonacci sequence iteratively.
			for (int i = 0; i < n; i++)
			{
				int temp = a;
				a = b;
				b = temp + b;
			}
			return a;
		}
	}
}

public class MyElementString
{
	private IEnumerable<long> value;

	public MyElementString(IEnumerable<long> something)
	{
		value = something;
	}

	public string StringJoin()
	{
		string result = "";
		value.ToList().ForEach(el =>
		{
			if (el < 0)
			{
				result += el + ", ";
			}
		});

		return result.TrimEnd(new char[] { ',', ' ' });
	}
}