using Source.Pickup;
using Sourceг;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

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