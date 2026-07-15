using UnityEngine;

namespace Source.Health
{
    public class Die: MonoBehaviour, IDie
    {
        public void Dying()
        {
            Destroy(gameObject);
        }
    }
}