using Source.Objects;
using UnityEngine;

namespace Source.Shoot
{
    public class ShootDefault: MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform bulletOrigin;
        private BulletPool _bulletPool;

        private void Awake()
        {
            _bulletPool = new BulletPool();
            _bulletPool.Init(bulletPrefab);
        }

        public void Shoot()
        {
            Bullet bullet = _bulletPool.GetBullet();
            StartCoroutine(_bulletPool.ReturnBulletCallback(bullet, bullet.BulletTimeoutSeconds()));
            
            bullet.transform.position = bulletOrigin.position;
            bullet.transform.rotation = bulletOrigin.rotation;

            bullet.Shoot(bulletOrigin.transform.position - bulletOrigin.parent.position);
        }
        
    }
}