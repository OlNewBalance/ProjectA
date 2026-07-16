using Source.Move;
using Source.Objects;
using Source.Pickup;
using Source.UI;
using Source.WorldEvents;
using UnityEngine;

namespace Source
{
    [RequireComponent(typeof(InputService))]
    [RequireComponent(typeof(AvailableArea))]
    public class Main: MonoBehaviour
    {
        [SerializeField] private PlanetOrbite _planetOrbite;

        //[SerializeField] private AlterHole[] alterHoles;
        [SerializeField] private Player playerPrefab;
        [SerializeField] private LevelCoin coinPrefab;
        [SerializeField] private Spawner enemySpawnerPrefab;
        [SerializeField] private Vector2 playerSpawnPosition;
        [SerializeField] private Camera cameraPrefab;
        [SerializeField] private LevelHandler _levelHandler;
        
        private InputService _is;
        private AvailableArea _availableArea;
        private Transform _playerPosition;
        private Transform _spaceObjectPosition;

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
            _availableArea = GetComponent<AvailableArea>();
            _playerPosition = _player.GetComponent<Transform>();
            _spaceObjectPosition = _planetOrbite.GetComponent<Transform>();
            
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
            
            G.OnExpChanged += i => Debug.Log(i);
            G.CurrentCoinExpValue = 10;
            G.FastTravelLVL = 5; // УСЛОВНО, ПРЯ НАДОБНОСТИ - ПОМЕНЯТЬ
            //G.GloryHoles = new System.Collections.Generic.Dictionary<int, AlterHole>
            //{
            //    {0, alterHoles[0]},
            //    {1, alterHoles[1]},
            //    {2, alterHoles[2]}
            //};
            G.AttractionForce = 150;
            G.CurrentLevel = 5;
            G.EarthSceneIndex = 1;
            G.MoonSceneIndex = 2;
            G.MarsSceneIndex = 3;
            _enemySpawner.OnEnemyDie += enemy =>
            {
                _coinDropper.DecideToDropCoin(gameObject, coinPrefab, enemy.transform.position);
            };
        }

        private void InitUI()
        {
            _is.InitPlayer(_player);
            _availableArea.Init(ref _playerPosition, ref _spaceObjectPosition);
            _levelUI = Instantiate(_levelHandler);
        }

        private static void InitG()
        {
            G.InitG(G.DefaultInit);
        }
    }  
}
