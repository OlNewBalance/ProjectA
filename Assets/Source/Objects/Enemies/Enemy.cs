using Source.Shoot;
using Source.Move;
using Source;
using UnityEngine;
using Random = UnityEngine.Random;
using Source.Health;

namespace Source.Objects.Enemies
{
    [RequireComponent(typeof(EnemyHealthUI))]
    [RequireComponent(typeof(Health.Health))]
    [RequireComponent(typeof(EnemyDie))]
    [RequireComponent(typeof(Source.Move.Move))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(IMove))]
    [RequireComponent(typeof(IShoot))]
    public class Enemy : MonoBehaviour, IEnemy, IInitiator
    {
        [SerializeField] private LookRadius lookRadius;
        [SerializeField] private float radius = 50;

        private IShoot _enemyShoot;
        private IMove _move;
        
        private Vector2 _direction;
        private Vector2 _lookAt;
        private float _changeDirectionCooldown = 3;
        private float _changeDirection_cur = 0.0f;

        private float _shootCooldown = 2f;
        private float _shootCooldown_cur = 0.0f;
        private int _damage;

        private void Awake()
        {
            _enemyShoot = gameObject.GetComponent<IShoot>();
            _move = gameObject.GetComponent<IMove>();
        }

        private void Start()
        {
            _damage = G.EnemyCorvetteDamage;
            
            _move.SetMaxSpeed(G.EnemyMoveMaxSpeed);
            _move.SetSpeed(G.EnemyMoveSpeed);
        }

        private void FixedUpdate()
        {
            HandlePlayer();   
            Move(_direction, _lookAt);
            DecideToShoot();
        }

        public void Init(Vector2 pos)
        {
        }

        private void HandlePlayer()
        {
            if (lookRadius.Player())
            {
                _direction = lookRadius.Player().transform.position - transform.position;
                _lookAt = lookRadius.Player().transform.position;
                return;
            }
            _changeDirection_cur += Time.deltaTime;
            if (_changeDirection_cur >= _changeDirectionCooldown)
            {
                _direction = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
                _changeDirection_cur = 0;
            }
        }

        private void DecideToShoot()
        {
            _shootCooldown_cur  += Time.deltaTime;
            if (lookRadius.Player() && _shootCooldown_cur >= _shootCooldown)
            {
                _enemyShoot.Shoot(_damage);
                _shootCooldown_cur = 0.0f;
            }
        }
        
        private void Move(Vector2 direction, Vector2 lookAt)
        {
            _move.MoveTo(direction);
            _move.RotateTo(_lookAt);
        }

        public InitiatorType GetInitiatorType()
        {
            return InitiatorType.EnemyCorvette;
        }
    }
}