using Source.Objects;
using Unity.Mathematics.Geometry;
using UnityEngine;

namespace Source.CameraUtil
{
    [RequireComponent(typeof(Camera))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class FollowPlayer: MonoBehaviour
    {
        [SerializeField] private float recenterSpeed;
        [SerializeField] private float enterRadius;
        private BoxCollider2D _collider;
        private float _cameraSemiHeight;
        private float _cameraSemiWidth;
        private Camera _camera;
        private bool _exited = false;
        private Transform moveTo;
        private void Awake()
        {
            _camera = gameObject.GetComponent<Camera>();
            _collider = gameObject.GetComponent<BoxCollider2D>();
            
            _cameraSemiHeight = _camera.orthographicSize;
            _cameraSemiWidth = _cameraSemiHeight * _camera.aspect;
            
            _collider.size = new Vector2(_cameraSemiWidth, _cameraSemiHeight);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<Player>(out var _))
            {
                _exited = true;
                moveTo = other.gameObject.transform;
            }
            
        }

        private void FixedUpdate()
        {
            HandleCameraExited();
        }

        private void HandleCameraExited()
        {
            if (_exited)
            {
                var to = Vector2.Lerp(transform.position, moveTo.position, Time.deltaTime *  recenterSpeed);
                transform.position = to;

                if ((new Vector2(moveTo.position.x, moveTo.position.y) - new Vector2(transform.position.x, transform.position.y)).magnitude <= enterRadius)
                {
                    _exited = false;
                }
            }
            
        }
    }
}