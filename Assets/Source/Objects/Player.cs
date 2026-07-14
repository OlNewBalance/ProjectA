using UnityEngine;

namespace Source.Objects
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Move.Move))]
    [RequireComponent(typeof(Shoot.ShootDefault))]
    public class Player : MonoBehaviour, Source.Shoot.IShoot, Source.Health.IHealth, Source.Move.IMove
    {
        [SerializeField] private Source.Move.InputService inputService;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private UnityEngine.Camera camera;
        [SerializeField] private Transform bulletOrigin;
        [SerializeField]private int health = 100;
        private BulletPool _bulletPool;
        private Rigidbody2D _rigidbody;
        private Move.Move _move;
        private Shoot.ShootDefault _shoot;

        public float ShootPower { get; }
        public float MoveSpeed { get; }

        private float _moveSpeed = 15;

        private void Awake()
        {
            
            health = 100;
            _bulletPool = new BulletPool();
            _bulletPool.Init(bulletPrefab);
            _rigidbody = GetComponent<Rigidbody2D>();
            _move = GetComponent<Move.Move>();
            _shoot = GetComponent<Shoot.ShootDefault>();

            inputService.OnShoot += Shoot;
        }

        private void FixedUpdate()
        {
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
            Vector2 mraz = inputService.KeyBoardValue();
            _move.MoveTo(mraz);
        }

        public void TakeDamage(int damage, Bullet thisBullet)
        {
            health -= damage;
            _bulletPool.PutBullet(thisBullet);
        }

        public void Heal(int heal)
        {
            health += heal;
        }
    }
}
