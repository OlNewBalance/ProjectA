using System;
using Source.Health;
using Source.Shoot;
using UnityEngine;

namespace Source.Objects.Projectiles.Bullet
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] public int damage;
        private Rigidbody2D _rigidbody;
        private InitiatorType _initiator;
        public Action OnHit;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        { 
            
            
            if(other.gameObject.TryGetComponent<IHealth>(out IHealth iHealth))
            {
                if (other.gameObject.TryGetComponent<IInitiator>(out IInitiator initiator) && initiator.GetInitiatorType() != _initiator)
                {
                    Debug.Log(_initiator + " hit " + initiator.GetInitiatorType());
                    iHealth.TakeDamage(damage);
                    OnHit.Invoke();
                }
            }
        }

        public void Shoot(Vector2 direction)
        {
            _rigidbody.AddForce(direction.normalized * 250f,  ForceMode2D.Impulse);
        }

        public float BulletTimeoutSeconds()
        {
            return 10f;
        }

        public void SetDamage(int damage)
        {
            damage = Mathf.Clamp(damage, 0, int.MaxValue);
        }

        public void SetInitiator(InitiatorType initiator)
        {
            _initiator = initiator;
        }
    }
}
