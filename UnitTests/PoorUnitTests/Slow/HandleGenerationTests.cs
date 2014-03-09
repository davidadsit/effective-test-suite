using System;
using NUnit.Framework;

namespace PoorUnitTests.Slow
{
    [TestFixture]
    public class HandleGenerationTests
    {
        /// <summary>
        ///     There are 141,167,095,653,376 possible handles.
        ///     As slow as this test is, it has a pretty good chance
        ///     of passing even if the code is broken.
        /// </summary>
        [Test]
        public void Generated_handles_are_unique()
        {
            var handleFactory = new HandleFactory();
            for (var i = 0; i < 5000; i++)
            {
                var existingHandlesBeforeGeneration = handleFactory.AllHandles();
                var newHandle = handleFactory.CreateNewHandle();
                Assert.That(existingHandlesBeforeGeneration, Is.Not.Contains(newHandle));
                Console.Out.WriteLine(newHandle);
            }
        }
    }
}