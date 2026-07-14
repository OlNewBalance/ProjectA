using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Source.Objects.Projectiles.Bullet;
using UnityEngine;

namespace Source.Objects
{
    public class BulletPool
    {
        private int _maxBullets = 25;
        private List<Bullet> _bullets = new List<Bullet>();
        private Bullet _bulletPrefab;

        public void Init(Bullet bulletPrefab)
        {
            _bulletPrefab = bulletPrefab;
        }

        public Bullet GetBullet()
        {
            if (_bullets.Count == 0)
            {
                SetBullets(_bulletPrefab);
            }

            Bullet bullet = _bullets.FirstOrDefault();
            _bullets.Remove(bullet);
            bullet.gameObject.SetActive(true);
            bullet.OnHit += () => PutBullet(bullet);
            return bullet;
        }

        public IEnumerator ReturnBulletCallback(Bullet bullet, float timeout)
        {
            yield return new WaitForSeconds(timeout);
            this.PutBullet(bullet);
        }

        public void PutBullet(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
            _bullets.Add(bullet);
        }

        private void SetBullets(Bullet bulletPrefab)
        {
            for (int i = 0; i < _maxBullets; i++)
            {
                Bullet bullet = UnityEngine.MonoBehaviour.Instantiate(bulletPrefab);
                bullet.gameObject.SetActive(false);
                _bullets.Add(bullet);
            }
        }
    }
}
