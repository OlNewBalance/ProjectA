using Source.Shoot;
using System.Collections;
using UnityEngine;

namespace Source.Objects.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyCorvette : MonoBehaviour, IEnemy
    {
        [SerializeField] private LookRadius _lookRadius;
        [SerializeField] private float _time = 3;
        [SerializeField] private float _speed = 15;
        [SerializeField] private float _radius = 50;

        private Rigidbody2D _rigidbody;
        private EnemyShoot _enemyShoot;
        private Vector2 _direction;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            Vector2 _enemyPosition = this.gameObject.transform.position;
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void Init(Vector2 pos)
        {
            //
        }

        private void Move()
        {
            // ЗАТЕСТИТЬ
            //if (_lookRadius.Player() != null)
            //{
            //    Attack();
            //    return;
            //}

            StartCoroutine(ChangeDirection());
            _rigidbody.AddForce(_direction.normalized * _speed, ForceMode2D.Force);
        }

        private void Attack()
        {
            Vector2 direction = _lookRadius.Player().transform.position;
            _rigidbody.AddForce(direction.normalized * _speed, ForceMode2D.Force);
            //_rigidbody.linearVelocity 
            // Добавить ограничение скорости (Velocity)
            // Добавить поворот врага в сторону игрока
            _enemyShoot.Shoot(direction);
        }

        private IEnumerator ChangeDirection()
        {
            yield return new WaitForSeconds(_time);
            _direction = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
        }
    }
}