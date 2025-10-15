using System;
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
            
            Debug.Log($"{nameof(GoldBootstrap)}: Initializing player gold with 100.");
        }
    }
}