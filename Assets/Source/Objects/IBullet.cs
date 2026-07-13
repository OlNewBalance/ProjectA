using UnityEngine;

namespace Source.Objects
{
    public interface IBullet
    {
        int Damage { get; }

        void Shoot(Vector2 direction);

        float BulletTimeoutSeconds();
    }
}
