using System;
using Core;
using Core.Bootstrap;
using UnityEngine;

namespace Health
{
    [Serializable]
    public class HealthBootstrap : IBootstappable
    {
        public void Bootstrap()
        {
            var health = new PlayerHealth(100);
            PlayerData.Instance.Set(health);
            
            Debug.Log($"{nameof(HealthBootstrap)}: Initializing player health with {health.Health}.");
        }
    }
}