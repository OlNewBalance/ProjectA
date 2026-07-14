using Source.Move;
using Source.Objects;
using UnityEngine;

namespace Source
{
    [RequireComponent(typeof(InputService))]
    public class Main: MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private AlterHole[] alterHoles;
        private InputService _is;
        private void Awake()
        {
            _is = GetComponent<InputService>();

            G.CurrentExp = 0;
            G.CurrentLevel = 1;
            
            G.OnExpChanged += i => Debug.Log(i);
            G.CurrentCoinExpValue = 10;
            G.FastTravelLVL = 5; // УСЛОВНО, ПРЯ НАДОБНОСТИ - ПОМЕНЯТЬ
            G.GloryHoles = new System.Collections.Generic.Dictionary<int, AlterHole>
            {
                {0, alterHoles[0]},
                {1, alterHoles[1]},
                {2, alterHoles[2]}
            };
            G.AttractionForce = 40f;
            G.CurrentLevel = 5;
        }
        
        private void Start()
        {
            _is.Init(player);
        }
    }  
}
