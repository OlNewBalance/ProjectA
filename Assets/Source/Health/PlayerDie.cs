using UnityEngine;

namespace Source.Health
{
    public class PlayerDie: MonoBehaviour, IDie
    {
        public void Die()
        {
            Destroy(gameObject);
        }
    }
}