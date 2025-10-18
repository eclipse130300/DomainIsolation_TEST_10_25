using System;
using UniRx;

namespace Location
{
    public class PlayerLocation : IDisposable
    {
        private readonly ReactiveProperty<string> _location;
        public IReadOnlyReactiveProperty<string> Location => _location;

        public PlayerLocation()
        {
            _location = new ReactiveProperty<string>(string.Empty);
        }

        public PlayerLocation(string initialLocation)
        {
            _location = new ReactiveProperty<string>(initialLocation);
        }

        public void Set(string location)
        {
            _location.Value = location;
        }

        public void Dispose()
        {
            _location.Dispose();
        }
    }
}