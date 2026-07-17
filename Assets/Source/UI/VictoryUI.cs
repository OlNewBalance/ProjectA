using UnityEngine;

namespace Source.UI
{
    public class VictoryUI: MonoBehaviour
    {
        public void StartOver()
        {
            VictoryMain.Instance.ToStateGame();
        }

        public void ToMainMenu()
        {
            VictoryMain.Instance.ToStateMenu();
        }
    }
}