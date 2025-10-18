using System;
using UniRx;

namespace Gold
{
    public class PlayerGold : IDisposable
    {
        private readonly ReactiveProperty<int> _gold;
        public IReadOnlyReactiveProperty<int> Gold => _gold;

        public PlayerGold()
        {
            _gold = new ReactiveProperty<int>(0);
        }

        public PlayerGold(int initialAmount)
        {
            _gold = new ReactiveProperty<int>(initialAmount);
        }

        public void Add(int amount)
        {
            _gold.Value += amount;
        }

        public void Set(int amount)
        {
            _gold.Value = amount;
        }

        public void Dispose()
        {
            _gold.Dispose();
        }
    }
}