using Source.Health;
using Source.Move;
using Source.Objects.Projectiles.Bullet;
using Source.Shoot;
using Sourceг;
using UnityEngine;
using IInitiator = Source.Shoot.IInitiator;

namespace Source.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Move.Move))]
    [RequireComponent(typeof(ShootDefault))]
    [RequireComponent(typeof(IHealth))]
    public class Player : MonoBehaviour, IInitiator
    {
        [SerializeField] private Source.Move.InputService inputService;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private UnityEngine.Camera camera;
        [SerializeField] private Transform bulletOrigin;
        private BulletPool _bulletPool;
        private IMove _move;
        private IShoot _shoot;
        private IHealth _health;

        private void Awake()
        {
            _bulletPool = new BulletPool();
            _bulletPool.Init(bulletPrefab);
            _move = GetComponent<IMove>();
            _shoot = GetComponent<IShoot>();
            inputService.OnShoot += Shoot;
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void Shoot()
        {
            _shoot.Shoot(G.PlayerDamage);
        }

        public void Move()
        {
            HandleMovement();
            HandleRotation();
        }

        private void HandleRotation()
        {
            var target = camera.ScreenToWorldPoint(inputService.MouseValue());
           _move.RotateTo(target);
        }

        private void HandleMovement()
        {
            Vector2 keyBoardValue = inputService.KeyBoardValue();
            _move.MoveTo(keyBoardValue);
        }
        
        public InitiatorType GetInitiatorType()
        {
            return InitiatorType.Player;
        }
    }
}
