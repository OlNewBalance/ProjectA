using Source.Move;
using Source.Objects;
using Source.Pickup;
using Source.UI;
using Source.WorldEvents;
using Sourceг;
using UnityEngine;

namespace Source
{
    [RequireComponent(typeof(InputService))]
    public class Main: MonoBehaviour
    {
        [SerializeField] private Player playerPrefab;
        [SerializeField] private LevelCoin coinPrefab;
        [SerializeField] private Spawner enemySpawnerPrefab;
        [SerializeField] private Vector2 playerSpawnPosition;
        [SerializeField] private Camera cameraPrefab;
        [SerializeField] private LevelHandler _levelHandler;
        
        private InputService _is;
        private CoinDropper _coinDropper;
        private Spawner _enemySpawner;
        private Player _player;
        private Camera _mainCamera;
        private LevelHandler _levelUI;
        
        private void Awake()
        {
            InitCamera();
            _coinDropper = new CoinDropper();
            InitG();
            InitInputService();
            InitPlayer();
            InitUI();
            InitSpawner();
        }

        private void InitCamera()
        {
            _mainCamera = Camera.main;
        }
        private void InitInputService()
        {
            _is = GetComponent<InputService>();
            
            Debug.Log(_is);
        }

        private void InitPlayer()
        {
            _player = Instantiate<Player>(playerPrefab, playerSpawnPosition, Quaternion.identity);
            _player.InputService = _is;
            _is.InitPlayer(_player);
            _player.InitPlayer(_mainCamera);
        }

        private void InitSpawner()
        {
            _enemySpawner = Instantiate(enemySpawnerPrefab);
            _enemySpawner.Player = _player;
            _enemySpawner.MainCamera = _mainCamera;
            
            _enemySpawner.OnEnemyDie += enemy =>
            {
                _coinDropper.DecideToDropCoin(gameObject, coinPrefab, enemy.transform.position);
            };
        }

        private void InitUI()
        {
            _levelUI = Instantiate(_levelHandler);
        }

        private static void InitG()
        {
            G.InitG(G.DefaultInit);
        }
    }  
}
