using System.Drawing;
using UnityEngine;

namespace Source.Objects
{
    public class Player : MonoBehaviour, Source.Shoot.IShoot, Source.Health.IHealth, Source.Move.IMove
    {
        [SerializeField] private Source.Move.InputService _inputService;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Camera _camera;
        private BulletPool _bulletPool;

        public float ShootPower { get; }
        public float MoveSpeed { get; }
        private int _health = 0;

        private void Awake()
        {
            _health = 100;
            _bulletPool = new BulletPool();
            _bulletPool.Init(_bulletPrefab);
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void Shoot()
        {
            Bullet bullet = _bulletPool.GetBullet();
            Rigidbody2D bulletRigidBody = bullet.GetRigidbody();

            RaycastHit2D hit = Physics2D.Raycast(_camera.transform.position, _inputService.MouseValue());

            bulletRigidBody.AddForce(hit.point, ForceMode2D.Impulse);
        }

        public void Move()
        {
            //Vector2 moveForce = new Vector3(_inputService.KeyBoardValue().x, _inputService.KeyBoardValue().y);
            Vector2 moveForce = _inputService.KeyBoardValue();
            _rigidbody.AddForce(moveForce * MoveSpeed, ForceMode2D.Force);

            //Vector3 lookForce = new Vector3(_inputService.MouseValue().x, _inputService.MouseValue().y);
            Vector3 lookForce = _inputService.MouseValue();
            _rigidbody.AddTorque(lookForce.z * MoveSpeed, ForceMode2D.Impulse);
        }

        public void TakeDamage(int damage, Bullet thisBullet)
        {
            _health -= damage;
            _bulletPool.PutBullet(thisBullet);
        }

        public void Heal(int heal)
        {
            _health += heal;
        }
    }
}
