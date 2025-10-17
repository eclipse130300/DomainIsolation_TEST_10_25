using System;
using Core;
using Shop.Bundles;
using UniRx;
using UnityEngine;

namespace Location
{
    [Serializable]
    public class ChangeLocationBundleBrick : IBundleBrick
    {
        [SerializeField] private string _newLocationName;
        
        public void Apply()
        {
            var playerLocation = PlayerData.Instance.GetOrCreate<PlayerLocation>();
            playerLocation.Location.Value = _newLocationName;
            
            Debug.Log($"{nameof(ChangeLocationBundleBrick)}: Changed player location to {_newLocationName}");
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