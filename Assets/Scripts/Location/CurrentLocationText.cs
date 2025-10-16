using Core;
using TMPro;
using UniRx;
using UnityEngine;

namespace Location
{
    public class CurrentLocationText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void Awake()
        {
            PlayerData.Instance.GetOrCreate<PlayerLocation>().Location.Subscribe(OnLocationChanged).AddTo(this);
        }
        
        private void OnLocationChanged(string location)
        {
            _text.text = $"Location: {location}";
        }
    }
}