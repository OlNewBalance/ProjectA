using UnityEngine;

namespace Source.Shoot
{
    public class EnemyShoot : IShoot
    {
        private Transform _origin;
        
        public EnemyShoot(Transform origin)
        {
            
        }
        
        public void Shoot(Vector2 vector)
        {
            
        }

        public void Shoot(System.Numerics.Vector2 vector)
        {
            throw new System.NotImplementedException();
        }
    }
}