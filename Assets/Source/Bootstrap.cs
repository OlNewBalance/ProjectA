using System;
using System.Collections;
using Source.StateMachine;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Source
{
    public class Bootstrap: MonoBehaviour
    {
        [SerializeField] private LoadingPlaceholder loadingPrefab;
        [SerializeField] private Main _mainPrefab;
        public LoadingPlaceholder Loading { get;  private set; }
        public StateMachine.StateMachine stateMachine;
        private void Start()
        {
            if (FindObjectsByType<Bootstrap>(FindObjectsSortMode.None).Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(this);
            InitLoading();
            
            stateMachine = new StateMachine.StateMachine(this, StateName.Menu);
            StartCoroutine(TestStateTransition());
        }

        private void InitLoading()
        {
            Loading = Instantiate(loadingPrefab, transform);
        }

        public bool LoadScene(string sceneName, Action callback)
        {
            StartCoroutine(Loading.LoadLevelAsync(sceneName, callback));
            return Loading.IsLoaded();
        }

        public IEnumerator TestStateTransition()
        {
            yield return new WaitForSeconds(2f);
            stateMachine.SwitchState(StateName.Game);
        }

        public void StartGame()
        {
            Instantiate(_mainPrefab, transform);
        }
    }
    
}