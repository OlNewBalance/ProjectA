using Source.Shoot;
using System.Collections;
using UnityEngine;

namespace Source.Objects.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyCorvette : MonoBehaviour, IEnemy
    {
        [SerializeField] private LookRadius _lookRadius;
        [SerializeField] private float _radius = 50;

        private Rigidbody2D _rigidbody;
        private EnemyShoot _enemyShoot;
        private Vector2 _direction;
        private float _time = 3;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            Vector2 _enemyPosition = this.gameObject.transform.position;
        }

        private void FixedUpdate()
        {

        }

        public void Init(Vector2 pos)
        {
            //
        }

        private void Move() // ¬ “≈Œ–»» Œ“ƒ≈À‹Õ€… ≈ƒ»Õ€…  À¿—— MOVE
        {
            // «¿“≈—“»“‹
            //if (_lookRadius.Player() != null)
            //{
            //    Attack();
            //    return;
            //}

            StartCoroutine(ChangeDirection());
            _rigidbody.AddForce(_direction.normalized * Source.G.EnemyMoveSpeed, ForceMode2D.Force);
            _rigidbody.linearVelocity = Vector2.ClampMagnitude(_rigidbody.linearVelocity, Source.G.EnemyMoveMaxSpeed);
        }

        private void Attack()
        {
            Vector2 direction = _lookRadius.Player().transform.position;
            _rigidbody.AddForce(direction.normalized * Source.G.EnemyMoveSpeed, ForceMode2D.Force);
            _rigidbody.linearVelocity = Vector2.ClampMagnitude(_rigidbody.linearVelocity, Source.G.EnemyMoveMaxSpeed);
            _enemyShoot.Shoot(direction);
        }

        private IEnumerator ChangeDirection()
        {
            yield return new WaitForSeconds(_time);
            _direction = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
        }

    }
}