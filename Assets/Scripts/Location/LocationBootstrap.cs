using System;
using Core.Bootstrap;
using UnityEngine;

namespace Location
{
    [Serializable]
    public class LocationBootstrap : IBootstappable
    {
        public void Bootstrap()
        {
            var location = new PlayerLocation("StartLocation");
            Core.PlayerData.Instance.Set(location);
            
            Debug.Log($"{nameof(LocationBootstrap)}: Initializing player location to 'StartLocation'.");
        }
    }
}