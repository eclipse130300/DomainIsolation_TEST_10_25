using System;
using System.Collections.Generic;
using Shop.Requests;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Shop
{
    public class BuyItemButton : MonoBehaviour
    {
        [SerializeField] private Button  buyButton;

        public UnityEvent onRequestStarted;
        public UnityEvent onRequestFinished;

        private void Awake()
        {
            buyButton.onClick.AddListener(OnClick);
        }
        
        private async void OnClick()
        {
            onRequestStarted?.Invoke();
            
            //actually item id have to be revealed on the scene opening
            var itemMockId = Guid.NewGuid().ToString();
            
            //TODO: make real resource values
            Dictionary<string, string> resourcesToSpend = new Dictionary<string, string>
            {
                { "coins", "100" },
                { "gems", "10" },
                { "itemId", itemMockId }
            };

            var request = new BuyItemRequestMock(resourcesToSpend).SendAsyncMock();
            
            //todo: use result for error handling (at least log it)
            var result = await request;
            
            onRequestFinished?.Invoke();
        }
    }
}