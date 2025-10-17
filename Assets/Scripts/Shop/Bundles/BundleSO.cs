using Core.Runtime;
using UnityEngine;

namespace Shop.Bundles
{
    [CreateAssetMenu(fileName = "Bundle", menuName = "Shop/Bundle", order = 0)]
    public class BundleSO : ScriptableObject
    {
        public string BundleName;
        
        [SerializeReference] [SelectableImpl] 
        public IBundleBrick [] price;
        
        [SerializeReference] [SelectableImpl]
        public IBundleBrick [] rewards;
        
        public bool CanBePurchased()
        {
            foreach (var priceBrick in price)
            {
                if (!priceBrick.IsAvailable())
                {
                    return false;
                }
            }

            return true;
        }
    }
}