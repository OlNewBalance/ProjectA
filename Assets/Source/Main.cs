using Source.Move;
using Source.Objects;
using UnityEngine;

namespace Source
{
    [RequireComponent(typeof(InputService))]
    public class Main: MonoBehaviour
    {
        [SerializeField] private Player player;
        
        private InputService _is;
        private void Awake()
        {
            _is = GetComponent<InputService>();

            G.CurrentExp = 0;
            G.CurrentLevel = 1;
            
            G.OnExpChanged += i => Debug.Log(i);
            G.CurrentCoinExpValue = 10;
        }
        
        private void Start()
        {
            _is.Init(player);
        }
    }  
}
