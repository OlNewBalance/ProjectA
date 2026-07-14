using System;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

namespace Source.Move
{
    public class InputService : MonoBehaviour
    {
        public Action OnShoot;

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
            OnShoot?.Invoke();
        }

        public Vector2 KeyBoardValue()
        {
            return _move;
        }

        public Vector2 MouseValue()
        {
            return _mouse;
        }
    }
}
