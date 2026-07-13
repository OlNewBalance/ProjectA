using UnityEngine;

namespace Source.Objects
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour, Source.Shoot.IShoot, Source.Health.IHealth, Source.Move.IMove
    {
        [SerializeField] private Source.Move.InputService inputService;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private UnityEngine.Camera camera;
        [SerializeField] private Transform bulletOrigin;
        [SerializeField]private int health = 100;
        private BulletPool _bulletPool;
        private Rigidbody2D _rigidbody;

        public float ShootPower { get; }
        public float MoveSpeed { get; }

        private float _moveSpeed = 15;
        private float _rotationSpeed = 5;

        private void Awake()
        {
            
            health = 100;
            _bulletPool = new BulletPool();
            _bulletPool.Init(bulletPrefab);
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void Shoot()
        {
            Bullet bullet = _bulletPool.GetBullet();
            StartCoroutine(_bulletPool.ReturnBulletCallback(bullet, bullet.BulletTimeoutSeconds()));
            
            bullet.transform.position = bulletOrigin.position;
            bullet.transform.rotation = bulletOrigin.rotation;

            bullet.Shoot(bulletOrigin.transform.position - bulletOrigin.parent.position);
            
        }

        public void Move()
        {
            HandleMovement();
            HandleRotation();
        }

        private void HandleRotation()
        {
            var target = camera.ScreenToWorldPoint(inputService.MouseValue());
            Vector2 direction = target - transform.position;

            var q = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, q - 90);
        }

        private void HandleMovement()
        {
            Vector2 mraz = inputService.KeyBoardValue();
            _rigidbody.AddForce(inputService.KeyBoardValue() * _moveSpeed, ForceMode2D.Force);
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
