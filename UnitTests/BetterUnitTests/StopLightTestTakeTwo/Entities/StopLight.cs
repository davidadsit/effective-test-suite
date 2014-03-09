using BetterUnitTests.StopLightTestTakeTwo.States;

namespace BetterUnitTests.StopLightTestTakeTwo.Entities
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

        internal StopLightState CurrentState
        {
            get { return lightState; }
        }

        public void TimerTick()
        {
            lightState = lightState.TimerTick();
        }
    }
}