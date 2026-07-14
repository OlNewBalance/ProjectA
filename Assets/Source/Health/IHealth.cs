using UnityEngine;

namespace Source.Health
{
    public interface IHealth
    {
        public void SetMaxHealth(int maxHealth);
        public void SetHealth(int health);
        void TakeDamage(int damage);
        void Heal(int heal);
        void Die();
    }
}
