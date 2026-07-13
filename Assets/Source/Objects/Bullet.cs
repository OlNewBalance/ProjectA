using System;
using Source.Health;
using UnityEngine;

namespace Source.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour, IBullet
    {
        public int Damage { get; }

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent<IHealth>(out IHealth iHealth))
            {
                iHealth.TakeDamage(Damage, this);
            }
        }

        public void Shoot(Vector2 direction)
        {
            Debug.Log(direction.normalized);
            _rigidbody.AddForce(direction.normalized * 250f,  ForceMode2D.Impulse);
        }

        public float BulletTimeoutSeconds()
        {
            return 10f;
        }
    }
}
