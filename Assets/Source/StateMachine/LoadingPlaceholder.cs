using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.StateMachine
{
    public class LoadingPlaceholder: MonoBehaviour
    {
        public static Dictionary<GameScene, string> ScenesByName = new Dictionary<GameScene, string>()
        {
            {GameScene.Earth, "Game"},
            {GameScene.Moon, "Moon"},
            {GameScene.Mars, "Mars"}
        };
        
        [SerializeField] private GameObject loadingCover;
        private float _loadingProgress;
        private bool _isLoading;

        public IEnumerator LoadLevelAsync(GameScene sceneName, Action callback)
        {
            return LoadLevelAsync(ScenesByName[sceneName], callback);
        }
        
        public IEnumerator LoadLevelAsync(string sceneName, Action callback)
        {
            _isLoading = true;
            loadingCover.SetActive(true);
            AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName);
            if (loading == null)
            {
                yield break;
            }
            while (!loading.isDone)
            {
                _loadingProgress = loading.progress;
                yield return new WaitForEndOfFrame();
            }
            callback();
            _isLoading = false;
            loadingCover.SetActive(false);
        }


        public bool IsLoaded()
        {
            return !_isLoading;
        }
    }

    public enum GameScene
    {
        Earth,
        Moon,
        Mars
    }
}