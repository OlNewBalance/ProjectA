using Source.Move;
using Source.Objects;
using Sourceг;
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
            G.InitG(G.DefaultInit);
            _is = GetComponent<InputService>();
        }
        
        private void Start()
        {
            _is.Init(player);
        }
    }  
}
