using System;
using Shop.Requests;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Shop
{
    public class BuyItemButton : MonoBehaviour
    {
        [SerializeField] private Button  _buyButton;
        [SerializeField] private BundlePrototype _bundlePrototype;
        [SerializeField] private GameObject _processingGameobject;

        private void Awake()
        {
            _buyButton.onClick.AddListener(OnClick);
        }

        private void Start()
        {
            if (_bundlePrototype == null || _bundlePrototype.Bundle == null)
            {
                _buyButton.interactable = false;
                return;
            }

            var processing = PurchaseStateService.GetProcessing(_bundlePrototype.Bundle);

            _buyButton.interactable = _bundlePrototype.CanBePurchased.Value && !processing.Value;

            Observable.CombineLatest(_bundlePrototype.CanBePurchased, processing, (can, proc) => can && !proc)
                .DistinctUntilChanged()
                .Subscribe(OnPurchasePossibilityChanged)
                .AddTo(this);
            
            processing
                .Subscribe(OnProcessingChanged)
                .AddTo(this);
        }
        
        private void OnPurchasePossibilityChanged(bool canBePurchased)
        {
            if (_bundlePrototype == null || _bundlePrototype.Bundle == null)
                return;

            _buyButton.interactable = canBePurchased;
        }

        private void OnProcessingChanged(bool isProcessing)
        {
            _processingGameobject.SetActive(isProcessing);
        }

        private async void OnClick()
        {
            if (_bundlePrototype == null || _bundlePrototype.Bundle == null)
                return;

            try
            {
                PurchaseStateService.SetProcessing(_bundlePrototype.Bundle, true);
                _buyButton.interactable = false;

                var request = new BuyItemRequestMock(_bundlePrototype.Bundle).SendAsyncMock();

                var result = await request;

                // после результата — обновляем interactable через общий флаг
                PurchaseStateService.SetProcessing(_bundlePrototype.Bundle, false);
            }
            catch (Exception e)
            {
                PurchaseStateService.SetProcessing(_bundlePrototype.Bundle, false);
                Debug.LogError($"Error during BuyItemRequest: {e.Message}");
            }
        }
    }
}
