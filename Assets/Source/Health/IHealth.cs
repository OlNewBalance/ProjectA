using UnityEngine;

namespace Source.Health
{
    public interface IHealth
    {
        void TakeDamage(int damage, Source.Objects.Bullet bullet);
        void Heal(int heal);
    }
}
