using System;
using Source.Health;
using Source.Move;
using Source.Objects;
using Source.Pickup;
using Source.UI;
using Source.WorldEvents;
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
        [SerializeField] private LevelHandler playerUIHandlerPrefab;
        [SerializeField] private PlanetOrbit planetOrbitPrefab;
        [SerializeField] private AvailableArea availableAreaPrefab;
        [SerializeField] private float maxRadius;

        private Bootstrap _bootstrap;
        
        private InputService _is;
        private AvailableArea _availableArea;
        private PlanetOrbit _spaceObjectPosition;
        private Transform _playerPosition;
        private CoinDropper _coinDropper;
        private Spawner _enemySpawner;
        private Player _player;
        private Camera _mainCamera;
        private LevelHandler _playerUI;
        private PlayerHealthHandler _healthUi;

        public static Main Instance {get; private set;}
        public float AvailableRadius { get; private set; }

        private void Awake()
        {
            Instance = this;
            _coinDropper = new CoinDropper();
            
            InitG();
            InitCamera();
            InitSpaceObject();
            InitInputService();
            InitPlayer();
            InitAvailableArea();
            InitUI();
            InitSpawner();
        }

        public void OnGameLevelChange()
        {
            InitCamera();
            InitSpaceObject();
            InitPlayer();
            InitUI();
            InitSpawner();
            InitAvailableArea();
        }

        public void SetBootstrap(Bootstrap bs)
        {
            _bootstrap = bs;   
        }
        private void InitCamera()
        {
            _mainCamera = Camera.main;
        }
        private void InitInputService()
        {
            _is = GetComponent<InputService>();
        }

        private void InitAvailableArea()
        {
            AvailableRadius = maxRadius;
            _availableArea = Instantiate(availableAreaPrefab);
        }

        private void InitSpaceObject()
        {
            _spaceObjectPosition = Instantiate(planetOrbitPrefab);
        }

        private void InitPlayer()
        {
            _player = Instantiate(playerPrefab, playerSpawnPosition, Quaternion.identity);
            _player.InputService = _is;
            _is.InitPlayer(_player);
            _player.InitPlayer(_mainCamera);
            _player.GetComponent<PlayerDie>().InitPlayerDie();
            _playerPosition = _player.GetComponent<Transform>();
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
            _playerUI = Instantiate(playerUIHandlerPrefab);
            _healthUi = _playerUI.GetComponent<PlayerHealthHandler>();
            
            _healthUi.InitPlayer(_player.GetComponent<IHealth>());
        }

        private static void InitG()
        {
            G.InitG(G.DefaultInit);
        }

        public void Die()
        {
            Destroy(_availableArea);
            Destroy(_spaceObjectPosition);
            Destroy(_enemySpawner);
            Destroy(_player);
            _bootstrap.ToStateGameOver();
        }

        public void Victory()
        {
            Destroy(_availableArea);
            Destroy(_spaceObjectPosition);
            Destroy(_enemySpawner);
            Destroy(_player);
            _bootstrap.ToStateVictory();
        }
    }  
}
