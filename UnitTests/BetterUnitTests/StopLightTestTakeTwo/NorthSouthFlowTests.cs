using BetterUnitTests.StopLightTestTakeTwo.Entities;
using BetterUnitTests.StopLightTestTakeTwo.States;
using NUnit.Framework;

namespace BetterUnitTests.StopLightTestTakeTwo
{
    [TestFixture]
    public class NorthSouthFlowTests
    {
        [Test]
        public void East_west_is_red()
        {
            StopLightState initialState = new NorthSouthFlow();
            Assert.That(initialState.EastWestColor(), Is.EqualTo(LightColor.Red));
        }

        [Test]
        public void North_south_is_green()
        {
            StopLightState initialState = new NorthSouthFlow();
            Assert.That(initialState.NorthSouthColor(), Is.EqualTo(LightColor.Green));
        }

        [Test]
        public void When_ticked_few_times_does_not_change([Range(0, NorthSouthFlow.TicksRequiredForStateTransition - 1, 1)] int timesTicked)
        {
            var initialState = new NorthSouthFlow(timesTicked);
            var nextState = initialState.TimerTick();
            Assert.That(nextState, Is.TypeOf<NorthSouthFlow>());
            Assert.That(((NorthSouthFlow) nextState).Ticks, Is.EqualTo(initialState.Ticks + 1));
        }

        [Test]
        public void When_ticked_sufficient_times_new_state_is_north_south_caution()
        {
            StopLightState initialState = new NorthSouthFlow(NorthSouthFlow.TicksRequiredForStateTransition);
            Assert.That(initialState.TimerTick(), Is.TypeOf<NorthSouthCaution>());
        }
    }
}