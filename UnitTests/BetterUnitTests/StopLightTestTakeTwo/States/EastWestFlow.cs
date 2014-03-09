using BetterUnitTests.StopLightTestTakeTwo.Entities;

namespace BetterUnitTests.StopLightTestTakeTwo.States
{
    class EastWestFlow : StopLightState
    {
        public const int TicksRequiredForStateTransition = 9;
        public readonly int Ticks;

        public EastWestFlow(int previousTicks = 0)
        {
            Ticks = previousTicks;
        }

        public override StopLightState TimerTick()
        {
            if (Ticks < TicksRequiredForStateTransition)
                return new EastWestFlow(Ticks + 1);
            return new EastWestCaution();
        }

        public override LightColor NorthSouthColor()
        {
            return LightColor.Red;
        }

        public override LightColor EastWestColor()
        {
            return LightColor.Green;
        }
    }
}