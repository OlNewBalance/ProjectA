using Source.UI;
using UnityEngine;

namespace Source
{
    public class MenuMain: MonoBehaviour
    {
        public static MenuMain Instance;
        
        [SerializeField] private MenuUI menuUIPrefab;

        private Bootstrap _bs;
        private MenuUI _menuUI;
        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            _bs = Bootstrap.Instance;
            _menuUI = Instantiate(menuUIPrefab);
        }

        public void ToStateGame()
        {
            _bs.ToStateGame();
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}