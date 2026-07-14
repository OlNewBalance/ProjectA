using System;
using Source.Objects;
using UnityEngine;

namespace Source.Move
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Move: MonoBehaviour, IMove
    {
        [SerializeField] private float speed;
        [SerializeField] private float maxSpeed;
        private Rigidbody2D _rb;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void MoveTo(Vector2 value)
        {
            _rb.AddForce(value * speed, ForceMode2D.Force);
            _rb.linearVelocity = Vector2.ClampMagnitude(_rb.linearVelocity, maxSpeed);
        }

        public void RotateTo(Vector2 target)
        {
            Vector2 direction = target - new Vector2(transform.position.x,  transform.position.y);

            var q = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, q - 90);        
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        } 
        public void SetMaxSpeed(float value)
        {
            maxSpeed = value;
        }
    }
}