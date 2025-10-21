using System.Collections.Generic;
using UniRx;
using Shop.Bundles;

namespace Shop
{
    public static class PurchaseStateService
    {
        private static readonly Dictionary<BundleSO, ReactiveProperty<bool>> _states = new();

        public static ReactiveProperty<bool> GetProcessing(BundleSO key)
        {
            if (key == null) return new ReactiveProperty<bool>(false);
            if (!_states.TryGetValue(key, out var prop))
            {
                prop = new ReactiveProperty<bool>(false);
                _states[key] = prop;
            }
            return prop;
        }

        public static void SetProcessing(BundleSO key, bool value)
        {
            if (key == null) return;
            var prop = GetProcessing(key);
            if (prop.Value != value) prop.Value = value;
        }
    }
}