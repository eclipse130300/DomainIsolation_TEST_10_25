using UniRx;

namespace Health
{
    public struct PlayerHealth
    {
        public ReactiveProperty<int> Health;

        public PlayerHealth(int health)
        {
            Health = new ReactiveProperty<int>(health);
        }
    }
}