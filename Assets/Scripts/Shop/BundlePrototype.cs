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

        // Общий флаг обработки для данного bundle (берётся из PurchaseStateService)
        public ReactiveProperty<bool> Processing => _bundle != null ? PurchaseStateService.GetProcessing(_bundle) : null;
        
        public void Setup(BundleSO bundle, bool withInfoButton)
        {
            _bundle = bundle;
            _disposables.Clear();

            _bundleNameText.text = bundle.BundleName;
            _infoButton.gameObject.SetActive(withInfoButton);
            
            Observable.CombineLatest(bundle.price.Select(p => p.ObserveAvailability()))
                .Select(all => all.All(x => x))
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