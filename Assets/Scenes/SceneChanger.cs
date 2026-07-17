using Unity.VisualScripting;
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
        DontDestroyOnLoad(gameObject);
        SceneManager.UnloadSceneAsync(_curentSceneIndex);

        if (Source.G.UnlokedLocations[holeRank] == false)
        {
            return;
        }

        _curentSceneIndex = holeRank;
        SceneManager.LoadSceneAsync(_curentSceneIndex);
    }
}
