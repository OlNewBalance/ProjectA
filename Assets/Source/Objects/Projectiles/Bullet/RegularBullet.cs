using System;
using UnityEngine;

namespace Source.Objects.Projectiles.Bullet
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(IInitiator))]
    public class RegularBullet: MonoBehaviour ,IBullet
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float startSpeed;
        
        private Rigidbody2D _rb;
        private IInitiator _initiator;
        private int _damage;

        private void Awake()
        {
            _initiator = GetComponent<IInitiator>();
            _rb = GetComponent<Rigidbody2D>();
        }

        public int Damage
        {
            get
            {
                switch (_initiator.GetInitiatorType())
                {
                    case InitiatorType.EnemyCorvette:
                        return G.EnemyCorvetteDamage;
                    case InitiatorType.Player:
                        return G.PlayerDamage;
                    default:
                        throw new UnexpectedBulletInitiatorType(gameObject.name);
                }
            }
        }

        public void Shoot(Vector2 direction, Quaternion rotation, Vector2 origin)
        {
            // TODO: Вынести в фабрику
            Instantiate(bulletPrefab, origin, new Quaternion(rotation.x, rotation.y, 0, 0));

            if (!bulletPrefab.TryGetComponent<Rigidbody2D>(out var rb))
            {
                rb = bulletPrefab.AddComponent<Rigidbody2D>();
            }
            rb.linearVelocity = direction * startSpeed;
            
        }
    }

    public class UnexpectedBulletInitiatorType : Exception
    {
        public UnexpectedBulletInitiatorType(string unexpectedInitiatorType) : base("unexpected initiator type") {}
    }
}