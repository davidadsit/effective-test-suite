using NUnit.Framework;
using PoorUnitTests.OrderDependent;

namespace PoorUnitTests.TooManyConcepts
{
    [TestFixture]
    public class StopLightTestsRevisited
    {
        StopLight StopLight;

        void AssertLightColors(LightColor northSouth, LightColor eastWest)
        {
            Assert.AreEqual(northSouth, StopLight.NorthSouthColor);
            Assert.AreEqual(eastWest, StopLight.EastWestColor);
        }

        /// <summary>
        ///     The words "properly" and "correctly" are good indications
        ///     that this test is doing too much
        /// </summary>
        [Test]
        public void TestThatTheStopLightCyclesProperly()
        {
            StopLight = new StopLight();
            for (var i = 0; i < 9; i++)
            {
                AssertLightColors(LightColor.Green, LightColor.Red);
                StopLight.TimerTick();
            }
            AssertLightColors(LightColor.Yellow, LightColor.Red);
            StopLight.TimerTick();
            AssertLightColors(LightColor.Red, LightColor.Red);
            StopLight.TimerTick();
            for (var i = 0; i < 9; i++)
            {
                AssertLightColors(LightColor.Red, LightColor.Green);
                StopLight.TimerTick();
            }
            AssertLightColors(LightColor.Red, LightColor.Yellow);
            StopLight.TimerTick();
            AssertLightColors(LightColor.Red, LightColor.Red);
            StopLight.TimerTick();
            AssertLightColors(LightColor.Green, LightColor.Red);
        }
    }
}