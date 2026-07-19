using Source.UI;
using UnityEngine;

namespace Source
{
    public class GameOverMain: MonoBehaviour
    {
        public static GameOverMain Instance { get; private set; }
        
        [SerializeField] private GameOverUI gameOverUIPrefab;

        private Bootstrap _bs;
        private GameOverUI _gameOverUI;
        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
            _bs = Bootstrap.Instance;
            _gameOverUI = Instantiate(gameOverUIPrefab, transform);

            Instance = this;
        }
        
        public void ToStateGame()
        {
            _bs.ToStateGame();
        }

        public void ToStateMenu()
        {
            _bs.ToStateMenu();
        }
    }
}