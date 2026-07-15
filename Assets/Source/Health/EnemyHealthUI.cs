using System;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Health
{
    [RequireComponent(typeof(IHealth))]
    public class EnemyHealthUI: MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        private IHealth _health;
        private void Awake()
        {
            _health = GetComponent<IHealth>();
            _health.OnHealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged(int value)
        {
            _healthSlider.value = (float)_health.HealthAmount / _health.MaxHealthAmount;
        }
    }
}