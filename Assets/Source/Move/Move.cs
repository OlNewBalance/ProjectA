using System;
using Source.Objects;
using UnityEngine;

namespace Source.Move
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Move: MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody2D _rb;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void MoveTo(Vector2 value)
        {
            _rb.AddForce(value * speed, ForceMode2D.Force);
        }

        public void RotateTo(Vector2 target)
        {
            Vector2 direction = target - new Vector2(transform.position.x,  transform.position.y);

            var q = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, q - 90);        }
    }
}