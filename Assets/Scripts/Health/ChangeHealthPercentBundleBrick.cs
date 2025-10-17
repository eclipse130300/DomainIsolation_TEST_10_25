using System;
using Core;
using Shop.Bundles;
using UniRx;
using UnityEngine;

namespace Health
{
    [Serializable]
    public class ChangeHealthPercentBundleBrick : IBundleBrick
    {
        [Range(0f, 100f)]
        private float _changeHealthPercent = 10f;
        
        public void Apply()
        {
            var playerHealth = PlayerData.Instance.GetOrCreate<PlayerHealth>();
            int healthChangeAmount = Mathf.RoundToInt(playerHealth.Health.Value * (_changeHealthPercent / 100f));
            
            //actually we could use extension of kind ClampedReactiveProperty in data container, but let's keep it simple
            playerHealth.Health.Value = Mathf.Max(0, playerHealth.Health.Value + healthChangeAmount);
            
            Debug.Log($"{nameof(ChangeHealthPercentBundleBrick)}: Changed player health by {_changeHealthPercent}%. New health: {playerHealth.Health.Value}");
        }

        public bool IsAvailable()
        {
            return true;
        }
        
        public IObservable<bool> ObserveAvailability()
        {
            // Always available
            return Observable.Return(true);
        }
    }
}