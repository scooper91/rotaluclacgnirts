using System.Collections.Generic;
using System.Linq;

namespace Stringcalculator
{
	public static class Counter
	{
		public static long Sum(IEnumerable<long> e)
		{
			return e.Sum();
		}

		public static int Nothing()
		{
			return 0;
		}
	}
}