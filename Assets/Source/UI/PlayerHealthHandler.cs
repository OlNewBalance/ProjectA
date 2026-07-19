using Source.Health;
using Source.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace Source.UI
{
    public class PlayerHealthHandler: MonoBehaviour
    {
        [SerializeField] public Image hpFillImage;
        
        private IHealth _health;
        private bool _ready;
        
        private void LateUpdate()
        {
            if (_ready && _health != null)
            {
                _health.OnHealthChanged += OnHealthChanged;
                OnHealthChanged(_health.HealthAmount);
            }
        }

        private void OnDestroy()
        {
            _health.OnHealthChanged -= OnHealthChanged;
        }

        public void InitPlayer(IHealth player)
        {
            _health = player;
            _ready = true;
        }

        private void OnHealthChanged(int value)
        {
            hpFillImage.fillAmount = (float)_health.HealthAmount / _health.MaxHealthAmount;
        }
    }
}