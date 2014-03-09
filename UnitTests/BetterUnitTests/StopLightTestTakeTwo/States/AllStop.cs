using BetterUnitTests.StopLightTestTakeTwo.Entities;

namespace BetterUnitTests.StopLightTestTakeTwo.States
{
    class AllStop : StopLightState
    {
        public readonly StopLightState PreviousState;

        public AllStop(StopLightState previousState)
        {
            PreviousState = previousState;
        }

        public override StopLightState TimerTick()
        {
            if (PreviousState is NorthSouthCaution)
            {
                return new EastWestFlow();
            }
            return new NorthSouthFlow();
        }

        public override LightColor NorthSouthColor()
        {
            return LightColor.Red;
        }

        public override LightColor EastWestColor()
        {
            return LightColor.Red;
        }
    }
}