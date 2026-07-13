using UnityEngine;

namespace Source.Health
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private int health;

        private void Awake()
        {
            if (G.EnemyHP != 0)
            {
                health = G.EnemyHP;
            }
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public void Heal(int heal)
        {
            health += heal;
        }

        public void Die()
        {
            
        }
    }
    
    
}