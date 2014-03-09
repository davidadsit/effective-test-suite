using PoorUnitTests.OrderDependent.States;

namespace PoorUnitTests.OrderDependent
{
    public class StopLight
    {
        StopLightState lightState;

        public StopLight()
        {
            lightState = new NorthSouthFlow();
        }

        public LightColor NorthSouthColor
        {
            get { return lightState.NorthSouthColor(); }
        }

        public LightColor EastWestColor
        {
            get { return lightState.EastWestColor(); }
        }

        public void TimerTick()
        {
            lightState = lightState.TimerTick();
        }
    }
}