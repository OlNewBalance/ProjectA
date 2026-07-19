using System;
using UnityEngine;

namespace Source.Pickup
{
    [RequireComponent(typeof(Collider2D))]
    public class LevelCoin: MonoBehaviour, IPickup
    {
        public int expValue;
        public event Action<LevelCoin> OnPickedUp;
        
        public void OnPickup()
        {
            G.CurrentExp += G.CurrentCoinExpValue;
            OnPickedUp?.Invoke(this);
            Destroy(gameObject);
        }
    }
}