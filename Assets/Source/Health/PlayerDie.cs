using UnityEngine;

namespace Source.Health
{
    public class PlayerDie: MonoBehaviour, IDie
    {
        private Main _main;
        
        public void InitPlayerDie()
        {
            _main = Main.Instance;
        }
        
        public void Die()
        {
            if (_main !=null)
            {
                _main.Die();
            }
        }
    }
}