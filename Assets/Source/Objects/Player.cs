using Source.Health;
using Source.Objects.Projectiles.Bullet;
using Source.Shoot;
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

        private Vector2 _position;
        private BulletPool _bulletPool;
        private Move.Move _move;
        private ShootDefault _shoot;
        private IHealth _health;

        private void Awake()
        {
            _bulletPool = new BulletPool();
            _bulletPool.Init(bulletPrefab);
            _move = GetComponent<Move.Move>();
            _shoot = GetComponent<ShootDefault>();

            inputService.OnShoot += Shoot;
        }

        private void FixedUpdate()
        {
            _position = transform.position;

            Move();
        }

        public void Shoot()
        {
            _shoot.Shoot();
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
        public ref readonly Vector2 PlayerPosition()
        {
             return ref _position;
        }
    }
}
