using Source.Shoot;
using UnityEngine;

namespace Source.Objects
{
    public interface IBullet
    {

        void Shoot(Vector2 direction);

        float BulletTimeoutSeconds();
    }
}
