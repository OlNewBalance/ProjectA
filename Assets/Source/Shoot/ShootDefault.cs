using Source.Objects;
using Source.Objects.Projectiles.Bullet;
using UnityEngine;

namespace Source.Shoot
{
    public class ShootDefault: MonoBehaviour, IShoot
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform bulletOrigin;
        [SerializeField] private InitiatorType initiator;
        [SerializeField] private AudioSource onFireSoundPrefab;
        private BulletPool _bulletPool;
        private AudioSource _onFireSound;
        private void Awake()
        {
            _bulletPool = new BulletPool();
            _bulletPool.Init(bulletPrefab);
            if (onFireSoundPrefab) _onFireSound = Instantiate(onFireSoundPrefab, transform);
        }

        public void Shoot(int damage)
        {
            Bullet bullet = _bulletPool.GetBullet();
            
            bullet.SetDamage(damage);
            bullet.SetInitiator(initiator);
            
            StartCoroutine(_bulletPool.ReturnBulletCallback(bullet, bullet.BulletTimeoutSeconds()));
            
            bullet.transform.position = bulletOrigin.position;
            bullet.transform.rotation = bulletOrigin.rotation;

            bullet.Shoot(bulletOrigin.transform.position - bulletOrigin.parent.position);
            if (_onFireSound) _onFireSound.Play();
        }
        
    }
}