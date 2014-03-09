using BetterUnitTests.StopLightTestTakeTwo.Entities;
using BetterUnitTests.StopLightTestTakeTwo.States;
using NUnit.Framework;

namespace BetterUnitTests.StopLightTestTakeTwo
{
    [TestFixture]
    public class AllStopWhenPreviouslyEastWestCautionTests
    {
        [SetUp]
        public void Setup()
        {
            InitialState = new AllStop(new EastWestCaution());
        }

        StopLightState InitialState;

        [Test]
        public void After_tick_becomes_north_south()
        {
            Assert.That(InitialState.TimerTick(), Is.TypeOf<NorthSouthFlow>());
        }

        [Test]
        public void East_west_is_red()
        {
            Assert.That(InitialState.EastWestColor(), Is.EqualTo(LightColor.Red));
        }

        [Test]
        public void North_south_is_red()
        {
            Assert.That(InitialState.NorthSouthColor(), Is.EqualTo(LightColor.Red));
        }
    }
}