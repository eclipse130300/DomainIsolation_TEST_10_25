using System;
using Core;
using Shop.Bundles;
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
            
            playerGold.GoldAmount.Value += _changeAmount;
            Debug.Log($"{nameof(ChangeGoldBundleBrick)}: Changed player gold by {_changeAmount}. New amount: {playerGold.GoldAmount.Value}");
        }

        public bool IsAvailable()
        {
            var playerGold = PlayerData.Instance.GetOrCreate<PlayerGold>();
            return playerGold.GoldAmount.Value + _changeAmount >= 0;
        }
    }
}