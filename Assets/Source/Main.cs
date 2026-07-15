using Source.Move;
using Source.Objects;
using UnityEngine;

namespace Source
{
    [RequireComponent(typeof(InputService))]
    [RequireComponent(typeof(AvailableArea))]
    public class Main: MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private PlanetOrbite _planetOrbite;

        //[SerializeField] private AlterHole[] alterHoles;
        private InputService _is;
        private AvailableArea _availableArea;
        private Transform _playerPosition;
        private Transform _spaceObjectPosition;

        private void Awake()
        {
            _is = GetComponent<InputService>();
            _availableArea = GetComponent<AvailableArea>();
            _playerPosition = _player.GetComponent<Transform>();
            _spaceObjectPosition = _planetOrbite.GetComponent<Transform>();

            G.CurrentExp = 0;
            G.CurrentLevel = 1;
            
            G.OnExpChanged += i => Debug.Log(i);
            G.CurrentCoinExpValue = 10;
            G.FastTravelLVL = 5; // УСЛОВНО, ПРЯ НАДОБНОСТИ - ПОМЕНЯТЬ
            //G.GloryHoles = new System.Collections.Generic.Dictionary<int, AlterHole>
            //{
            //    {0, alterHoles[0]},
            //    {1, alterHoles[1]},
            //    {2, alterHoles[2]}
            //};
            G.AttractionForce = 150;
            G.CurrentLevel = 5;
            G.EarthSceneIndex = 1;
            G.MoonSceneIndex = 2;
            G.MarsSceneIndex = 3;
        }
        
        private void Start()
        {
            _is.Init(_player);
            _availableArea.Init(ref _playerPosition, ref _spaceObjectPosition);
        }
    }  
}
