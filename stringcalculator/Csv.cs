using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Stringcalculator
{
    public class Csv
    {
        private const string CustomDelimiterIndicator = "//";
        protected string CsvText;

        public Csv(string csvText)
        {
            CsvText = csvText;
        }
		
	    protected char[] Delimiters
	    {
		    get
		    {
			    if (CsvText.StartsWith(CustomDelimiterIndicator))
			    {
				    return GetCustomDelimiter(CsvText);
			    }
			    else
			    {
					return new char[] { '\n', ',' };
				}

			}
	    }

	    protected string Text
	    {
		    get
		    {
			    if (CsvText.StartsWith(CustomDelimiterIndicator))
			    {
				    return CsvText.Substring(4);
			    }
			    else
			    {
				    return CsvText;
			    }
		    }
	    }

        public IEnumerable<long> GetIndividualElements()
        {
            return Text.Split(Delimiters).Select(long.Parse);
        }

		private static char[] GetCustomDelimiter(string csv)
		{
			return new Regex(@"//(.)\n").Match(csv).Captures[0].Value.ToCharArray();
		}
	}
}