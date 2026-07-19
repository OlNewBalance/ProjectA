using System.Collections.Generic;
using Source.Pickup;
using UnityEngine;

namespace Source.WorldEvents
{
    public class CoinDropper
    {
        private List<LevelCoin>  _levelCoins = new List<LevelCoin>();
        
        public void DecideToDropCoin(GameObject parent, LevelCoin levelCoinPrefab, Vector3 position)
        {
            LevelCoin lc = Object.Instantiate(levelCoinPrefab, parent.transform);
            lc.transform.position = position;
            lc.expValue = G.CurrentCoinExpValue;
            lc.OnPickedUp += coin => _levelCoins.Remove(coin);
            _levelCoins.Add(lc);
        }
        
        public void CleanupLevelCoins()
        {
            foreach (var lc in _levelCoins)
            {
                if (lc != null) Object.Destroy(lc.gameObject);
            }
            _levelCoins.Clear();
        }
    }
}