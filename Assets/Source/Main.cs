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
        }
        
        private void Start()
        {
            _is.Init(player);
        }
    }  
}
