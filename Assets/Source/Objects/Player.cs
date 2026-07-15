using Source.Health;
using Source.Move;
using Source.Objects.Projectiles.Bullet;
using Source.Shoot;
using Source;
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
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform bulletOrigin;

        public InputService InputService { get; set; }

        private Vector2 _position;
        private BulletPool _bulletPool;
        private IMove _move;
        private IShoot _shoot;
        private IHealth _health;
        private Camera _camera;
        public Rigidbody2D _rigidbody { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _move = GetComponent<IMove>();
            _shoot = GetComponent<IShoot>();
        }

        public void InitPlayer(Camera camera)
        {
            _camera = Camera.main;
            _bulletPool = new BulletPool();
            _bulletPool.Init(bulletPrefab);
            InputService.OnShoot += Shoot;
        }
        private void FixedUpdate()
        {
            _position = transform.position;
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
            var target = _camera.ScreenToWorldPoint(InputService.MouseValue());
           _move.RotateTo(target);
        }

        private void HandleMovement()
        {
            Vector2 keyBoardValue = InputService.KeyBoardValue();
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
