using System.Collections.Generic;
using UniRx;

namespace Shop
{
    public static class PurchaseStateService
    {
        private static readonly Dictionary<object, ReactiveProperty<bool>> _states = new();

        public static ReactiveProperty<bool> GetProcessing(object key)
        {
            if (key == null) return new ReactiveProperty<bool>(false);
            if (!_states.TryGetValue(key, out var prop))
            {
                prop = new ReactiveProperty<bool>(false);
                _states[key] = prop;
            }
            return prop;
        }

        public static void SetProcessing(object key, bool value)
        {
            var prop = GetProcessing(key);
            if (prop.Value != value) prop.Value = value;
        }
    }
}