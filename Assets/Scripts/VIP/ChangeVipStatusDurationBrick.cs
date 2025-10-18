using System;
using Shop.Bundles;
using UniRx;
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
            //ensure we have more than -_changeVipDurationSeconds
            var playerVipStatus = Core.PlayerData.Instance.GetOrCreate<PlayerVIP>();
            return playerVipStatus.VipTime.Value.TotalSeconds + _changeVipDurationSeconds >= 0;
        }
        
        public IObservable<bool> ObserveAvailability()
        {
            var playerVipStatus = Core.PlayerData.Instance.GetOrCreate<PlayerVIP>();

            // React to VIP time changes
            return playerVipStatus.VipTime
                .Select(_ => IsAvailable()) // recompute availability
                .DistinctUntilChanged();    // only when it actually changes
        }
    }
}