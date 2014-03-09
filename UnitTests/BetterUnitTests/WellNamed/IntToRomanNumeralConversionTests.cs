using NUnit.Framework;

namespace BetterUnitTests.WellNamed
{
    [TestFixture]
    public class IntToRomanNumeralConversionTests
    {
        [TestCase(1, "I")]
        [TestCase(50, "L")]
        [TestCase(1999, "MCMXCIX")]
        [TestCase(2999, "MMCMXCIX")]
        public void ConvertValueToRomanNumeral(int value, string romanNumeralRepresentation)
        {
            Assert.That(value.ToRoman(), Is.EqualTo(romanNumeralRepresentation));
        }
    }
}