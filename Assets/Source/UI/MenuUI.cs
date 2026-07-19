using UnityEngine;
using UnityEngine.UI;

namespace Source.UI
{
    public class MenuUI: MonoBehaviour
    {
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button exitGameButton;

        private void Awake()
        {
            startGameButton.onClick.AddListener(MenuMain.Instance.ToStateGame);
            exitGameButton.onClick.AddListener(MenuMain.Instance.Exit);
        }
    }
}