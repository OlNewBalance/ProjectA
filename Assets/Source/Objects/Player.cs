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

        private float _moveSpeed = 15;
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
            Vector2 mraz = _inputService.KeyBoardValue();
            if (mraz == null)
            {
                Debug.Log("MRAZ");
                return;
            }
            Debug.Log("Suka1");
            //Vector2 moveForce = new Vector3(_inputService.KeyBoardValue().x, _inputService.KeyBoardValue().y);
            Debug.Log("Suka2");
            _rigidbody.AddForce(_inputService.KeyBoardValue() * _moveSpeed, ForceMode2D.Force);
            Debug.Log("Suka3");

            //Vector3 lookForce = new Vector3(_inputService.MouseValue().x, _inputService.MouseValue().y);
            Vector2 lookForce = _inputService.MouseValue();
            Debug.Log("Suka4");
            //_rigidbody.AddTorque((lookForce.x ) * _moveSpeed, ForceMode2D.Force);//
            Debug.Log("Suka5");
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
