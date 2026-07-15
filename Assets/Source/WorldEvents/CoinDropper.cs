using Source.Pickup;
using Sourceг;
using UnityEngine;

namespace Source.WorldEvents
{
    public class CoinDropper
    {
        public void DecideToDropCoin(GameObject parent, LevelCoin levelCoinPrefab, Vector3 position)
        {
            LevelCoin lc = Object.Instantiate(levelCoinPrefab, parent.transform);
            lc.transform.position = position;
            lc.expValue = G.CurrentCoinExpValue;
        }
    }
}