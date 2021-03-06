﻿using BetterUnitTests.StopLightTestTakeTwo.Entities;

namespace BetterUnitTests.StopLightTestTakeTwo.States
{
    class EastWestCaution : StopLightState
    {
        public override StopLightState TimerTick()
        {
            return new AllStop(this);
        }

        public override LightColor NorthSouthColor()
        {
            return LightColor.Red;
        }

        public override LightColor EastWestColor()
        {
            return LightColor.Yellow;
        }
    }
}