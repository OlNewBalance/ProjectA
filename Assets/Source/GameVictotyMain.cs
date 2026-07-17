using Source;
using Source.UI;
using UnityEngine;

public class GameVictotyMain : MonoBehaviour
{
    [SerializeField] private GameVictoryUI gameVictoryUIPrefab;

    private Bootstrap _bs;
    private GameVictoryUI _gameVictoryUI;
    private void Awake()
    {
        _gameVictoryUI = Instantiate(gameVictoryUIPrefab, transform);
        _gameVictoryUI.InitVictoryUI(this);
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
