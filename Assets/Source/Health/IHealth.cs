using UnityEngine;

namespace Source.Health
{
    public interface IHealth
    {
        void TakeDamage(int damage);
        void Heal(int heal);
    }
}
