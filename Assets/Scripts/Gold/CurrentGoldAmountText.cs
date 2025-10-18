using System;
using Core;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gold
{
    public class CurrentGoldAmountText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        private void Awake()
        {
            var gold = PlayerData.Instance.GetOrCreate<PlayerGold>();
            gold.Gold.Subscribe(UpdateText).AddTo(this);
        }

        private void UpdateText(int amount)
        {
            text.text = $"Gold: {amount}";
        }
    }
}