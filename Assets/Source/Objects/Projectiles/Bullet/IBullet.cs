using Source.Shoot;
using UnityEngine;

namespace Source.Objects
{
    public interface IBullet
    {
        int Damage { get; }

        void Shoot(Vector2 direction, InitiatorType initiatorType);

        float BulletTimeoutSeconds();
    }
}
