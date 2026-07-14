using System;
using Source.Health;
using UnityEngine;
using UnityEngine.UI;

namespace Source.UI
{
    [RequireComponent(typeof(IHealth))]
    public class PlayerHealthHandler: MonoBehaviour
    {
        [SerializeField] public Slider slider;
        
        private IHealth _health;
        private void Awake()
        {
            _health = GetComponent<IHealth>();
            _health.OnHealthChanged += OnHealthChanged;
        }
        
        private void OnHealthChanged(int value)
        {
            slider.value = (float)_health.HealthAmount / _health.MaxHealthAmount;
        }
    }
}