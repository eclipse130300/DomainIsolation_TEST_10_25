using System;
using Core;
using Shop.Bundles;
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
            playerHealth.Health.Value += _changeHealthAmount;
            Debug.Log($"{nameof(ChangeHealthAmountBundleBrick)}: Changed player health by {_changeHealthAmount}. New health: {playerHealth.Health.Value}");
        }

        public bool IsAvailable()
        {
            var playerHealth = PlayerData.Instance.GetOrCreate<PlayerHealth>();
            return playerHealth.Health.Value + _changeHealthAmount >= 0;
        }
    }
}