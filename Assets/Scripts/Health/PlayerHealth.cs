using System;
using UniRx;

namespace Health
{
    public class PlayerHealth : IDisposable
    {
        private readonly ReactiveProperty<int> _health;
        public IReadOnlyReactiveProperty<int> Health => _health;

        public PlayerHealth()
        {
            _health = new ReactiveProperty<int>(100);
        }

        public PlayerHealth(int initialHealth = 100)
        {
            _health = new ReactiveProperty<int>(initialHealth);
        }
        
        public void Add(int amount)
        {
            _health.Value += amount;
        }

        public void Set(int amount)
        {
            _health.Value = amount;
        }

        public void Dispose()
        {
            _health.Dispose();
        }
    }
}