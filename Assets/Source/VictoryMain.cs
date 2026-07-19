using Source.StateMachine;
using Source.UI;
using UnityEngine;

namespace Source
{
    public class VictoryMain: MonoBehaviour
    {
        public static VictoryMain Instance { get;  private set; }
        
        [SerializeField] private VictoryUI victoryUIPrefab;

        private VictoryUI _gameOverUI;
        private Bootstrap _bs;
        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }
            _bs = Bootstrap.Instance;
            _gameOverUI = Instantiate(victoryUIPrefab, transform);

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