using UnityEngine;

namespace Source.Health
{
    public class PlayerDie: MonoBehaviour, IDie
    {
        private Main _main;
        
        public void InitPlayerDie(Main main)
        {
            _main = main;
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