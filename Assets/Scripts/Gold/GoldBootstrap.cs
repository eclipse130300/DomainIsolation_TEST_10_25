using System;
using Core;
using Core.Bootstrap;
using UnityEngine;

namespace Gold
{
    [Serializable]
    public class GoldBootstrap : IBootstappable
    {
        public void Bootstrap()
        {
            // Initialize player gold with a default value, e.g., 100
            PlayerGold playerGold = new PlayerGold(100);
            PlayerData.Instance.Set(playerGold);
            
            Debug.Log($"{nameof(GoldBootstrap)}: Initializing player gold with {playerGold.Gold.Value}.");
        }
    }
}