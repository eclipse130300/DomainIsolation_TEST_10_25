using System;
using UniRx;

namespace VIP
{
    public struct PlayerVIP
    {
        public ReactiveProperty<TimeSpan> VipTime;
        
        public PlayerVIP(TimeSpan vipTime)
        {
            VipTime = new ReactiveProperty<TimeSpan>(vipTime);
        }
    }
}