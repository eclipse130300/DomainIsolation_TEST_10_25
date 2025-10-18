using System;
using System.Linq;
using Shop.Bundles;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class BundlePrototype : MonoBehaviour
    {
        [SerializeField] Button _infoButton;
        [SerializeField] private TextMeshProUGUI _bundleNameText;
        
        public ReactiveProperty<bool> CanBePurchased = new(false);
        
        private CompositeDisposable _disposables = new();
        private BundleSO _bundle;
        public BundleSO Bundle => _bundle;
        
        public void Setup(BundleSO bundle, bool withInfoButton)
        {
            _bundle = bundle;
            _disposables.Clear();
            // Setup the bundle prototype with the provided bundle data
            // (e.g., set texts, images, prices, etc.)
            _bundleNameText.text = bundle.BundleName;
            _infoButton.gameObject.SetActive(withInfoButton);
            
            Observable.CombineLatest(bundle.price.Select(p => p.ObserveAvailability()))
                .Select(all => all.All(x => x)) // Check if all bricks are available
                .DistinctUntilChanged()
                .Subscribe(v => CanBePurchased.Value = v)
                .AddTo(_disposables);
        }

        private void OnDestroy()
        {
            _disposables.Clear();
        }
    }
}