using UnityEditor.Build;
using UnityEngine;

namespace Source.Move
{
    public class InputService : MonoBehaviour
    {
        private InputActions _inputActions;
        private Source.Objects.Player _player;

        private Vector2 _move;
        private Vector2 _mouse;

        private void Awake()
        {
            _inputActions = new InputActions();
            _inputActions.Enable();
        }

        private void FixedUpdate()
        {
            _move = _inputActions.Keyboard.WASD.ReadValue<Vector2>();
            Debug.Log("Suka8");
            _mouse = _inputActions.Mouse.MousePosition.ReadValue<Vector2>();
            _inputActions.Mouse.LeftMouseButton.performed += OnLeftMouseBotton;
        }

        private void OnDestroy()
        {
            _inputActions.Disable();
        }

        public void Init(Source.Objects.Player player)
        {
            _player = player;
        }

        private void OnLeftMouseBotton(UnityEngine.InputSystem.InputAction.CallbackContext callback)
        {
            _player.Shoot();
        }

        public Vector2 KeyBoardValue()
        {
            Debug.Log("Suka6");
            return _move;
            Debug.Log("Suka7");
        }

        public Vector2 MouseValue()
        {
            Debug.Log("Suka9");
            return _mouse;
            Debug.Log("Suka10");
        }
    }
}
