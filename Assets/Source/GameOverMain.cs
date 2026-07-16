using Source.UI;
using UnityEngine;

namespace Source
{
    public class GameOverMain: MonoBehaviour
    {
        [SerializeField] private GameOverUI gameOverUIPrefab;

        private Bootstrap _bs;
        private GameOverUI _gameOverUI;
        private void Awake()
        {
            _gameOverUI = Instantiate(gameOverUIPrefab, transform);
            _gameOverUI.InitGameOverUI(this);
        }

        public void InitBootstrap(Bootstrap bootstrap)
        {
            _bs = bootstrap;
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