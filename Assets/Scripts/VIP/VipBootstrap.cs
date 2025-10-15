using System;
using Core.Bootstrap;
using UnityEngine;

namespace VIP
{
    [Serializable]
    public class VipBootstrap : IBootstappable
    {
        public void Bootstrap()
        {
            //make 2 minutes of vip time for testing
            var vip = new PlayerVIP(System.TimeSpan.FromMinutes(2));
            Core.PlayerData.Instance.Set(vip);
            
            Debug.Log($"{nameof(VipBootstrap)}: Initializing player VIP with {vip.VipTime.TotalMinutes} minutes.");
        }
    }
}