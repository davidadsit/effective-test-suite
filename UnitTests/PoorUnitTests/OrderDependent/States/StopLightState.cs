namespace PoorUnitTests.OrderDependent.States
{
    abstract class StopLightState
    {
        public abstract StopLightState TimerTick();
        public abstract LightColor NorthSouthColor();
        public abstract LightColor EastWestColor();
    }
}