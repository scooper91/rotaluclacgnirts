using NUnit.Framework;

namespace Stringcalculator.Test
{
    public class StringCalculatorTest
    {
        [TestFixture]
        public class TheAddMethodShould
        {
            private StringCalculator _stringCalculator;

            [SetUp]
            public void CreateCalculator()
            {
                _stringCalculator = new StringCalculator();
            }

            [Test]
            public void Return0WhenGivenAnEmptyString()
            {
                Assert.That(_stringCalculator.Add(string.Empty), Is.EqualTo(0));
            }

            [TestCase("1", 1)]
            [TestCase("1,2", 3)]
            [TestCase("1,2,3,4", 10)]
            public void SumCommaSeparatedNumbers(string csv, int sum)
            {
                Assert.That(_stringCalculator.Add(csv), Is.EqualTo(sum));
            }

            [Test]
            public void SumNumbersSeparatedByNewLines()
            {
                Assert.That(_stringCalculator.Add("1\n2,3"), Is.EqualTo(6));
            }

            [Test]
            public void SumNumbersSeparatedByCustomDelimiter()
            {
                Assert.That(_stringCalculator.Add("//;\n1;2"), Is.EqualTo(3));
            }

            [Test]
            public void ReportIfAnyNegativeNumbersAreInTheCsv()
            {
                Assert.That(() => _stringCalculator.Add("1,-2,-4"),
                    Throws.ArgumentException.With.Message.EqualTo("negatives not allowed: -2, -4"));
            }
        }
    }
}