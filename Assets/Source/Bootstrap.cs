using System;
using System.Collections;
using Source.StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class Bootstrap: MonoBehaviour
    {
        [SerializeField] private LoadingPlaceholder loadingPrefab;
        [SerializeField] private Main mainPrefab;
        [SerializeField] private GameOverMain gameOverPrefab;
        [SerializeField] private VictoryMain victoryPrefab;
        [SerializeField] private MenuMain  menuPrefab;
        [SerializeField] public Toggle SoundCheck;
        
        public LoadingPlaceholder Loading { get;  private set; }
        public StateMachine.StateMachine stateMachine;
        
        private Main _main;
        private GameOverMain _gameOver;
        private VictoryMain _victory;
        private MenuMain _menu;
        
        public static Bootstrap Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        private void Start()
        {
            if (Instance != this) return; // дубликат, уже помечен на удаление
            InitLoading();
            stateMachine = new StateMachine.StateMachine(this, StateName.Menu);
        }
        
        private void InitLoading()
        {
            Loading = Instantiate(loadingPrefab, transform);
            
        }
        public bool LoadScene(GameScene sceneName, Action callback)
        {
            StartCoroutine(Loading.LoadLevelAsync(sceneName, callback));
            return Loading.IsLoaded();
        }
        public bool LoadScene(string sceneName, Action callback)
        {
            StartCoroutine(Loading.LoadLevelAsync(sceneName, callback));
            return Loading.IsLoaded();
        }
        public IEnumerator TestStateTransition()
        {
            yield return new WaitForSeconds(2f);
            ToStateGame();
        }

        public void ToStateGame()
        {
            stateMachine.SwitchState(StateName.Game);
        }

        public void StartGame()
        {
            if (!Main.Instance)
            {
                _main = Instantiate(mainPrefab);
                DontDestroyOnLoad(_main);
            }
            _main.SetBootstrap(this);
        }
        
        public void ToStateMenu()
        {
            stateMachine.SwitchState(StateName.Menu);
        }

        public void StartMenu()
        {
            _menu = Instantiate(menuPrefab);
        }

        public void ToStateGameOver()
        {
            stateMachine.SwitchState(StateName.GameOver);
        }

        public void StartGameOver()
        {
            _gameOver = Instantiate(gameOverPrefab);

        }
        public void CleanupFromGame()
        {
            Destroy(_main);
        }

        public void ChangeGameScene(GameScene holeRank)
        {
            StartCoroutine(Loading.LoadLevelAsync(holeRank, () =>
            {
                _main.OnGameLevelChange();
            }));
            
            
        }

        public void ToStateVictory()
        {
            stateMachine.SwitchState(StateName.Victory);
            
        }

        public void StartVictory()
        {
            _victory = Instantiate(victoryPrefab);
        }
    }
}