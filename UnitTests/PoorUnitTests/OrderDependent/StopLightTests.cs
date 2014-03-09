using NUnit.Framework;

namespace PoorUnitTests.OrderDependent
{
    [TestFixture]
    public class StopLightTests
    {
        StopLight StopLight;

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            StopLight = new StopLight();
        }

        void AssertLightColors(LightColor northSouth, LightColor eastWest)
        {
            Assert.AreEqual(northSouth, StopLight.NorthSouthColor);
            Assert.AreEqual(eastWest, StopLight.EastWestColor);
        }

        [Test]
        public void Test01_InitialState()
        {
            AssertLightColors(LightColor.Green, LightColor.Red);
        }

        [Test]
        public void Test02_AfterTimerTick_01()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Green, LightColor.Red);
        }

        [Test]
        public void Test03_AfterTimerTick_02()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Green, LightColor.Red);
        }

        [Test]
        public void Test04_AfterTimerTick_03()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Green, LightColor.Red);
        }

        [Test]
        public void Test05_AfterTimerTick_04()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Green, LightColor.Red);
        }

        [Test]
        public void Test06_AfterTimerTick_05()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Green, LightColor.Red);
        }

        [Test]
        public void Test07_AfterTimerTick_06()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Green, LightColor.Red);
        }

        [Test]
        public void Test08_AfterTimerTick_07()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Green, LightColor.Red);
        }

        [Test]
        public void Test09_AfterTimerTick_08()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Green, LightColor.Red);
        }

        [Test]
        public void Test10_AfterTimerTick_09()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Yellow, LightColor.Red);
        }

        [Test]
        public void Test11_AfterTimerTick_10()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Red, LightColor.Red);
        }

        [Test]
        public void Test12_AfterTimerTick_11()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Red, LightColor.Green);
        }

        [Test]
        public void Test13_AfterTimerTick_12()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Red, LightColor.Green);
        }

        [Test]
        public void Test14_AfterTimerTick_13()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Red, LightColor.Green);
        }

        [Test]
        public void Test15_AfterTimerTick_14()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Red, LightColor.Green);
        }

        [Test]
        public void Test16_AfterTimerTick_15()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Red, LightColor.Green);
        }

        [Test]
        public void Test17_AfterTimerTick_16()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Red, LightColor.Green);
        }

        [Test]
        public void Test18_AfterTimerTick_17()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Red, LightColor.Green);
        }

        [Test]
        public void Test19_AfterTimerTick_18()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Red, LightColor.Green);
        }

        [Test]
        public void Test20_AfterTimerTick_19()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Red, LightColor.Green);
        }

        [Test]
        public void Test21_AfterTimerTick_20()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Red, LightColor.Yellow);
        }

        [Test]
        public void Test22_AfterTimerTick_21()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Red, LightColor.Red);
        }

        [Test]
        public void Test23_AfterTimerTick_22()
        {
            StopLight.TimerTick();
            AssertLightColors(LightColor.Green, LightColor.Red);
        }
    }
}