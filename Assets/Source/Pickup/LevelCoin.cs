using UnityEngine;

namespace Source.Pickup
{
    [RequireComponent(typeof(Collider2D))]
    public class LevelCoin: MonoBehaviour, IPickup
    {
        public int expValue;
        
        public void OnPickup()
        {
            G.CurrentExp += G.CurrentCoinExpValue;
            
            Destroy(gameObject);
        }
    }
}