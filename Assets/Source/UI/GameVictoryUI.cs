using UnityEngine;

public class GameVictoryUI : MonoBehaviour
{
    private GameVictotyMain _main;
    public void InitVictoryUI(GameVictotyMain main)
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
