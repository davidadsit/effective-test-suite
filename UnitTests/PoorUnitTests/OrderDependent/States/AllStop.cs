namespace PoorUnitTests.OrderDependent.States
{
    class AllStop : StopLightState
    {
        readonly StopLightState PreviousState;

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