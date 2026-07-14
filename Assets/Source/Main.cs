using Source.Move;
using Source.Objects;
using Source.Pickup;
using Source.WorldEvents;
using Sourceг;
using UnityEngine;

namespace Source
{
    [RequireComponent(typeof(InputService))]
    public class Main: MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private LevelCoin coinPrefab;
        [SerializeField] private Spawner enemySpawner;
        
        private InputService _is;
        private CoinDropper _coinDropper;
        private void Awake()
        {
            _coinDropper = new CoinDropper();
            
            InitG();
            InitInputService();
            InitSpawner();
        }

        private void InitSpawner()
        {
            enemySpawner.OnEnemyDie += enemy =>
            {
                _coinDropper.DecideToDropCoin(gameObject, coinPrefab, enemy.transform.position);
            };
        }

        private static void InitG()
        {
            G.InitG(G.DefaultInit);
        }

        private void InitInputService()
        {
            _is = GetComponent<InputService>();
            _is.Init(player);
        }
    }  
}
