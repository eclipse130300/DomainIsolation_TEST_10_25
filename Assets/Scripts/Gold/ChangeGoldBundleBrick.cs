using System;
using Core;
using Shop.Bundles;
using UniRx;
using UnityEngine;

namespace Gold
{
    [Serializable]
    public class ChangeGoldBundleBrick : IBundleBrick
    {
        [SerializeField] private int _changeAmount = 100;
        
        public void Apply()
        {
            var playerGold = PlayerData.Instance.GetOrCreate<PlayerGold>();
            
            playerGold.Add(_changeAmount);
            Debug.Log($"{nameof(ChangeGoldBundleBrick)}: Changed player gold by {_changeAmount}. New amount: {playerGold.Gold.Value}");
        }

        public bool IsAvailable()
        {
            var playerGold = PlayerData.Instance.GetOrCreate<PlayerGold>();
            return playerGold.Gold.Value + _changeAmount >= 0;
        }
        
        public IObservable<bool> ObserveAvailability()
        {
            var playerGold = PlayerData.Instance.GetOrCreate<PlayerGold>();

            // React to gold changes
            return playerGold.Gold
                .Select(_ => IsAvailable()) // recompute availability
                .DistinctUntilChanged();    // only when it actually changes
        }
    }
}