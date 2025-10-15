using UniRx;

namespace Gold
{
    public struct PlayerGold
    {
        public ReactiveProperty<int> GoldAmount;

        public PlayerGold(int goldAmount)
        {
            GoldAmount = new ReactiveProperty<int>(goldAmount);
        }
    }
}