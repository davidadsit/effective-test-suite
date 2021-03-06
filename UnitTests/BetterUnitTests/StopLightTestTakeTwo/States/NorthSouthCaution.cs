﻿using BetterUnitTests.StopLightTestTakeTwo.Entities;

namespace BetterUnitTests.StopLightTestTakeTwo.States
{
    class NorthSouthCaution : StopLightState
    {
        public override StopLightState TimerTick()
        {
            return new AllStop(this);
        }

        public override LightColor NorthSouthColor()
        {
            return LightColor.Yellow;
        }

        public override LightColor EastWestColor()
        {
            return LightColor.Red;
        }
    }
}