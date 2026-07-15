using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private int _curentSceneIndex;

    private void Awake()
    {
        _curentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void ChangeScene(int holeRank)
    {
        SceneManager.UnloadSceneAsync(_curentSceneIndex);
        //_curentSceneIndex = SceneManager.GetSceneByBuildIndex(holeRank).buildIndex;

        switch (holeRank)
        {
            case 1:
                _curentSceneIndex = Source.G.EarthSceneIndex;
                break;
            case 2:
                _curentSceneIndex = Source.G.MoonSceneIndex;
                break;
            case 3:
                _curentSceneIndex = Source.G.MarsSceneIndex;
                break;
            default:
                _curentSceneIndex = Source.G.MoonSceneIndex;
                break;
        }

        SceneManager.LoadSceneAsync(_curentSceneIndex);
    }
}
