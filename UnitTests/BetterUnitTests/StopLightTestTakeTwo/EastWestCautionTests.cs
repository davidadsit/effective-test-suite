using BetterUnitTests.StopLightTestTakeTwo.Entities;
using BetterUnitTests.StopLightTestTakeTwo.States;
using NUnit.Framework;

namespace BetterUnitTests.StopLightTestTakeTwo
{
    [TestFixture]
    public class EastWestCautionTests
    {
        [SetUp]
        public void Setup()
        {
            InitialState = new EastWestCaution();
        }

        StopLightState InitialState;

        [Test]
        public void East_west_is_yellow()
        {
            Assert.That(InitialState.EastWestColor(), Is.EqualTo(LightColor.Yellow));
        }

        [Test]
        public void North_south_is_red()
        {
            Assert.That(InitialState.NorthSouthColor(), Is.EqualTo(LightColor.Red));
        }

        [Test]
        public void When_ticked_becomes_all_stop()
        {
            Assert.That(InitialState.TimerTick(), Is.TypeOf<AllStop>());
        }

        [Test]
        public void When_ticked_next_state_has_this_state_as_previous_state()
        {
            Assert.That(((AllStop) InitialState.TimerTick()).PreviousState, Is.SameAs(InitialState));
        }
    }
}