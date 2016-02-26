// ReSharper disable PossibleMultipleEnumeration
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stringcalculator
{
    public class StringCalculator
    {
        public long Add(string csvText)
        {
            return IsEmpty(csvText)
                ? 0
                : TheSumOfTheElementsIn(csvText);
        }

        private static bool IsEmpty(string csvText)
        {
            return csvText == string.Empty;
        }

        private static long TheSumOfTheElementsIn(string csvText)
        {
            var elements = TheIndividualElementsOfThe(csvText);
            ValidateThatThereAreNoNegativesIn(elements);
            return elements.Sum();
        }

        private static IEnumerable<long> TheIndividualElementsOfThe(string csvText)
        {
            return Csv.Read(csvText).GetIndividualElements();
        }

        private static void ValidateThatThereAreNoNegativesIn(IEnumerable<long> elements)
        {
            if (elements.Where(IsNegative).Any())
            {
                throw new ArgumentException(
                    string.Format("negatives not allowed: {0}", string.Join(", ", elements.Where(IsNegative))));
            }
        }

        private static bool IsNegative(long element)
        {
            return element < 0;
        }
    }
}