using NUnit.Framework;

namespace PoorUnitTests.PoorlyNamed
{
    [TestFixture]
    public class IntExtensionsTests
    {
        [Test]
        public void Test1()
        {
            Assert.That("I", Is.EqualTo(1.ToRoman()));
        }

        [Test]
        public void Test2()
        {
            Assert.That("MCMXCIX", Is.EqualTo(1999.ToRoman()));
        }

        [Test]
        public void Test2b()
        {
            Assert.That("MMCMXCIX", Is.EqualTo(2999.ToRoman()));
        }

        [Test]
        public void TestAddition()
        {
            Assert.That("L", Is.EqualTo(50.ToRoman()));
        }
    }
}