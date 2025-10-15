using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Unity.Plastic.Newtonsoft.Json;

namespace Shop.Requests
{
    public class BuyItemRequest : HttpRequestBase<bool>
    {
        public override string Url => "api/shop/buyitem";
        public override HttpMethodType Type => HttpMethodType.Get;
    
        public override string Body { get; }

        public BuyItemRequest(Dictionary<string, string> resourcesToSpend)
        {
            Body = JsonConvert.SerializeObject(resourcesToSpend);
        }
    }
}