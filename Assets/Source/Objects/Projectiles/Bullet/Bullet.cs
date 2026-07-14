using System;
using Source.Health;
using Source.Shoot;
using UnityEngine;

namespace Source.Objects.Projectiles.Bullet
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour, IBullet
    {
        private Rigidbody2D _rigidbody;
        private InitiatorType _initiator;
        public Action OnHit;
        public int Damage
        {
            get
            {
                switch (_initiator)
                {
                    case(InitiatorType.EnemyCorvette):
                        return 1;
                    case(InitiatorType.Player):
                        return 1;
                    default:
                        return 0;
                }  
            }
        }

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
                    iHealth.TakeDamage(Damage);
                    OnHit.Invoke();
                }
            }
        }

        public void Shoot(Vector2 direction, InitiatorType initiator)
        {
            _initiator = initiator;
            _rigidbody.AddForce(direction.normalized * 250f,  ForceMode2D.Impulse);
        }

        public float BulletTimeoutSeconds()
        {
            return 10f;
        }
    }
}
