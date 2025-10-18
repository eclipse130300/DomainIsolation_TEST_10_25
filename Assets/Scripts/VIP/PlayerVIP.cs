using System;
using UniRx;

namespace VIP
{
    public class PlayerVIP : IDisposable
    {
        private readonly ReactiveProperty<TimeSpan> _vipTime;
        public IReadOnlyReactiveProperty<TimeSpan> VipTime => _vipTime;

        public PlayerVIP()
        {
            _vipTime = new ReactiveProperty<TimeSpan>(TimeSpan.Zero);
        }

        public PlayerVIP(TimeSpan initialVip = default)
        {
            _vipTime = new ReactiveProperty<TimeSpan>(initialVip);
        }

        public void Add(TimeSpan delta)
        {
            _vipTime.Value = _vipTime.Value + delta;
        }

        public void Set(TimeSpan time)
        {
            _vipTime.Value = time;
        }

        public void Dispose()
        {
            _vipTime.Dispose();
        }
    }
}