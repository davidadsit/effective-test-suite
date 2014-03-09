using BetterUnitTests.StopLightTestTakeTwo.Entities;
using BetterUnitTests.StopLightTestTakeTwo.States;
using NUnit.Framework;

namespace BetterUnitTests.StopLightTestTakeTwo
{
    [TestFixture]
    public class StopLightTests
    {
        [Test]
        public void Initial_state_is_north_south_flow()
        {
            var stopLight = new StopLight();
            Assert.That(stopLight.CurrentState, Is.TypeOf<NorthSouthFlow>());
        }

        [Test]
        public void When_ticked_new_internal_state_becomes_result_of_ticking_the_old_internal_state()
        {
            var stopLight = new StopLight();
            var initialState = stopLight.CurrentState;
            var nextStateOfInternalState = initialState.TimerTick();
            stopLight.TimerTick();
            Assert.That(stopLight.CurrentState, Is.TypeOf(nextStateOfInternalState.GetType()));
        }
    }
}