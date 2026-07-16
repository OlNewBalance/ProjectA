using Source;
using UnityEngine;

namespace Source.UI
{
    public class GameOverUI : MonoBehaviour
    {
        private GameOverMain _main;
        public void InitGameOverUI(GameOverMain main)
        {
            _main = main;
        }

        public void StartOver()
        {
            _main.ToStateGame();
        }

        public void ToMainMenu()
        {
            _main.ToStateMenu();
        }
    }
}

