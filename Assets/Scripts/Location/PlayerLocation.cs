using UniRx;

namespace Location
{
    public struct PlayerLocation
    {
        public ReactiveProperty<string> Location;
        public PlayerLocation(string location)
        {
            Location = new ReactiveProperty<string>(location);
        }
    }
}