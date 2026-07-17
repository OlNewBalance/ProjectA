using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.StateMachine
{
    public class LoadingPlaceholder: MonoBehaviour
    {
        [SerializeField] private GameObject loadingCover;
        private float _loadingProgress;
        private bool _isLoading;
        
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
        public IEnumerator LoadLevelAsync(int sceneIndex, Action callback)
        {
            _isLoading = true;
            loadingCover.SetActive(true);
            AsyncOperation loading = SceneManager.LoadSceneAsync(sceneIndex);
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
}