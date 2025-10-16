using System;
using Shop.Bundles;
using UnityEngine;

namespace VIP
{
    [Serializable]
    public class ChangeVipStatusDurationBrick : IBundleBrick
    {
        [SerializeField] private int _changeVipDurationSeconds = 30;
        public void Apply()
        {
            var playerVipStatus = Core.PlayerData.Instance.GetOrCreate<PlayerVIP>();
            playerVipStatus.VipTime.Value += TimeSpan.FromSeconds(_changeVipDurationSeconds);
            //clamp to non-negative
            if (playerVipStatus.VipTime.Value < TimeSpan.Zero)
            {
                playerVipStatus.VipTime.Value = TimeSpan.Zero;
            }
            
            Debug.Log($"{nameof(ChangeVipStatusDurationBrick)}: Changed VIP status duration by {_changeVipDurationSeconds} seconds. New duration: {playerVipStatus.VipTime.Value}");
        }
        
        public bool IsAvailable()
        {
            return true;
        }
    }
}