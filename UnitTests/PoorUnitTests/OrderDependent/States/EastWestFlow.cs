namespace PoorUnitTests.OrderDependent.States
{
    class EastWestFlow : StopLightState
    {
        int ticks;

        public override StopLightState TimerTick()
        {
            ticks++;
            if (ticks < 9)
                return this;
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