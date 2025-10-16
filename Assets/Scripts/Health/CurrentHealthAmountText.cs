using System;
using Core;
using TMPro;
using UniRx;
using UnityEngine;

namespace Health
{
    public class CurrentHealthAmountText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void Awake()
        {
            PlayerData.Instance.GetOrCreate<PlayerHealth>().Health.Subscribe(OnHealthChanged).AddTo(this);
        }

        private void OnHealthChanged(int health)
        {
            _text.text = $"Health: {health}";
        }
    }
}