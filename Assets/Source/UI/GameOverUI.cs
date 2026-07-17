using Source;
using UnityEngine;

namespace Source.UI
{
    public class GameOverUI : MonoBehaviour
    {
        public void StartOver()
        {
            GameOverMain.Instance.ToStateGame();
        }

        public void ToMainMenu()
        {
            GameOverMain.Instance.ToStateMenu();

        }
    }
}

