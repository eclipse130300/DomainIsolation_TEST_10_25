using System;
using Core;
using Shop.Bundles;
using UniRx;
using UnityEngine;

namespace Health
{
    [Serializable]
    public class ChangeHealthAmountBundleBrick : IBundleBrick
    {
        [SerializeField]
        private int _changeHealthAmount = 10;
        public void Apply()
        {
            var playerHealth = PlayerData.Instance.GetOrCreate<PlayerHealth>();
            playerHealth.Add(_changeHealthAmount);
            Debug.Log($"{nameof(ChangeHealthAmountBundleBrick)}: Changed player health by {_changeHealthAmount}. New health: {playerHealth.Health.Value}");
        }

        public bool IsAvailable()
        {
            var playerHealth = PlayerData.Instance.GetOrCreate<PlayerHealth>();
            return playerHealth.Health.Value + _changeHealthAmount >= 0;
        }
        
        public IObservable<bool> ObserveAvailability()
        {
            var playerHealth = PlayerData.Instance.GetOrCreate<PlayerHealth>();

            // React to health changes
            return playerHealth.Health
                .Select(_ => IsAvailable()) // recompute availability
                .DistinctUntilChanged();    // only when it actually changes
        }
    }
}