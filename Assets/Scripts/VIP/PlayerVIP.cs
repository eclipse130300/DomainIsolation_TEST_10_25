using System;

namespace VIP
{
    public struct PlayerVIP
    {
        public TimeSpan VipTime;
        
        public PlayerVIP(TimeSpan vipTime)
        {
            VipTime = vipTime;
        }
    }
}