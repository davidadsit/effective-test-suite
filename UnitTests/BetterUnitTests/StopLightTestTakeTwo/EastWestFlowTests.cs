using BetterUnitTests.StopLightTestTakeTwo.Entities;
using BetterUnitTests.StopLightTestTakeTwo.States;
using NUnit.Framework;

namespace BetterUnitTests.StopLightTestTakeTwo
{
    [TestFixture]
    public class EastWestFlowTests
    {
        [Test]
        public void East_west_is_green()
        {
            StopLightState initialState = new EastWestFlow();
            Assert.That(initialState.EastWestColor(), Is.EqualTo(LightColor.Green));
        }

        [Test]
        public void North_south_is_red()
        {
            StopLightState initialState = new EastWestFlow();
            Assert.That(initialState.NorthSouthColor(), Is.EqualTo(LightColor.Red));
        }

        [Test]
        public void When_ticked_few_times_does_not_change([Range(0, EastWestFlow.TicksRequiredForStateTransition - 1, 1)] int timesTicked)
        {
            var initialState = new EastWestFlow(timesTicked);
            var stopLightState = initialState.TimerTick();
            Assert.That(stopLightState, Is.TypeOf<EastWestFlow>());
            Assert.That(((EastWestFlow) stopLightState).Ticks, Is.EqualTo(initialState.Ticks + 1));
        }

        [Test]
        public void When_ticked_sufficient_times_new_state_is_east_west_caution()
        {
            StopLightState initialState = new EastWestFlow(EastWestFlow.TicksRequiredForStateTransition);
            Assert.That(initialState.TimerTick(), Is.TypeOf<EastWestCaution>());
        }
    }
}