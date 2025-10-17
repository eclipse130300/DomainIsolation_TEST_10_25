using System;
using System.Collections.Generic;
using Shop.Requests;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Shop
{
    public class BuyItemButton : MonoBehaviour
    {
        [SerializeField] private Button  buyButton;
        [SerializeField] private BundlePrototype bundlePrototype;

        public UnityEvent onRequestStarted;
        public UnityEvent onRequestFinished;

        private void Awake()
        {
            buyButton.onClick.AddListener(OnClick);
        }

        private void Start()
        {
            buyButton.interactable = bundlePrototype.CanBePurchased.Value;
            bundlePrototype.CanBePurchased.Subscribe(OnPurchaseAvailabilityChanged).AddTo(this);
        }
        
        private void OnPurchaseAvailabilityChanged(bool canBePurchased)
        {
            buyButton.interactable = canBePurchased;
        }

        private async void OnClick()
        {
            try
            {
                onRequestStarted?.Invoke();
                
                buyButton.interactable = false;
                var request = new BuyItemRequestMock(bundlePrototype.Bundle).SendAsyncMock();
            
                //todo: use real result for error handling
                var result = await request;
                buyButton.interactable = bundlePrototype.CanBePurchased.Value;
                
                
                onRequestFinished?.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogError($"Error during BuyItemRequest: {e.Message}");
            }
        }
    }
}