using System;
using Core;
using TMPro;
using UniRx;
using UnityEngine;

namespace VIP
{
    public class CurrentVipDurationText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        private void Awake()
        {
            PlayerData.Instance.GetOrCreate<PlayerVIP>().VipTime.Subscribe(OnVipDurationChanged).AddTo(this);
        }
        
        private void OnVipDurationChanged(TimeSpan vipDuration)
        {
            _text.text = $"VIP Time: {vipDuration.TotalSeconds:N0} s";
        }
    }
}