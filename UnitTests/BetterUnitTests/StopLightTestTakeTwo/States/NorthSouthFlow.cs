using BetterUnitTests.StopLightTestTakeTwo.Entities;

namespace BetterUnitTests.StopLightTestTakeTwo.States
{
    class NorthSouthFlow : StopLightState
    {
        public const int TicksRequiredForStateTransition = 9;
        public readonly int Ticks;

        public NorthSouthFlow(int previousTicks = 0)
        {
            Ticks = previousTicks;
        }

        public override StopLightState TimerTick()
        {
            if (Ticks < TicksRequiredForStateTransition)
                return new NorthSouthFlow(Ticks + 1);
            return new NorthSouthCaution();
        }

        public override LightColor NorthSouthColor()
        {
            return LightColor.Green;
        }

        public override LightColor EastWestColor()
        {
            return LightColor.Red;
        }
    }
}