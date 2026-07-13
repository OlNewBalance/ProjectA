using UnityEngine;

namespace Source.Objects
{
    public interface IBullet
    {
        int Damage { get; }
        void Shoot(Vector2 direction, Quaternion rotation, Vector2 origin);
    }
}
