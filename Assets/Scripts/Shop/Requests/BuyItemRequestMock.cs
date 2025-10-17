using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Bundles;

namespace Shop.Requests
{
    public class BuyItemRequestMock : BuyItemRequest
    {
        BundleSO _bundle;
        
        //we need to check if there are enough resources to spend in the mock request
        public BuyItemRequestMock(BundleSO bundleSo) : base(new Dictionary<string, string>())
        {
            _bundle = bundleSo;
        }

        public override async Task<bool> SendAsyncMock()
        {
            await Task.Delay(1000); // Simulate some processing delay
            
            foreach(var price in _bundle.price)
            {
                price.Apply();
            }
            
            foreach(var price in _bundle.rewards)
            {
                price.Apply();
            }
            
            return true;
        }
    }
}