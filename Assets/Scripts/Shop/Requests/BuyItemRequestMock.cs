using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Requests
{
    public class BuyItemRequestMock : BuyItemRequest
    {
        //we need to check if there are enough resources to spend in the mock request
        //should be handled by some separate manager on the local machine for now
        public BuyItemRequestMock(Dictionary<string, string> resourcesToSpend) : base(resourcesToSpend)
        {
        }

        public override async Task<bool> SendAsyncMock()
        {
            //simulate checking resources on the local machine
            bool hasEnoughResources = true; // Replace with actual logic to check resources

            await Task.Delay(3000); // Simulate some processing delay
            
            return hasEnoughResources;
        }
    }
}