namespace PoorUnitTests.OrderDependent.States
{
    class NorthSouthFlow : StopLightState
    {
        int ticks;

        public override StopLightState TimerTick()
        {
            ticks++;
            if (ticks < 9)
                return this;
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