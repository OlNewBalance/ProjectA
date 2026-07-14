using UnityEngine;

namespace Source.Health
{
    public class EnemyDie: MonoBehaviour, IDie
    {
        public void Die()
        {
            Destroy(gameObject);
        }
    }
}