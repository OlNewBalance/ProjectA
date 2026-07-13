using Source.Health;
using UnityEngine;

namespace Source.Objects
{
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

        public Rigidbody2D GetRigidbody() 
        { 
            return _rigidbody;
        }
    }
}
