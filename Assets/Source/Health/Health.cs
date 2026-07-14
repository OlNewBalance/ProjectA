using System;
using UnityEngine;

namespace Source.Health
{
    [RequireComponent(typeof(IDie))]
    public class Health: MonoBehaviour, IHealth
    {
        [SerializeField] private int maxHealth;
        private int _health;
        private IDie _dieHandler;

        private void Awake()
        {
            _health = maxHealth;
            _dieHandler = GetComponent<IDie>();
        }
        
        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Die();
            }
        }

        public void Heal(int heal)
        {
            if (_health + heal > maxHealth)
            {
                _health = maxHealth;
                return;
            }
            _health += heal;
        }

        public void Die()
        {
            _dieHandler.Die();
        }

        public void SetMaxHealth(int maxHealth)
        {
            this.maxHealth = maxHealth;
        }

        public void SetHealth(int health)
        {
            _health = health;
        }
    }
}