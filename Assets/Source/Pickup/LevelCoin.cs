using System;
using Sourceг;
using UnityEngine;

namespace Source.Pickup
{
    [RequireComponent(typeof(Collider2D))]
    public class LevelCoin: MonoBehaviour, IPickup
    {
        private int _expValue;

        private void Awake()
        {
            _expValue =  G.CurrentCoinExpValue;
        }

        public void OnPickup()
        {
            G.CurrentExp +=  G.CurrentCoinExpValue;
            
            Destroy(gameObject);
        }
    }
}