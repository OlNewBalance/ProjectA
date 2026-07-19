using System;
using Source.Objects;
using Source.Objects.Enemies;
using System.Collections;
using Source.Health;
using Source;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private EnemyPool _pool;
    private Vector2 spawnPoint;
    private int _spawnCoolDown = 5;

    public Player Player { get; set; }
    public Camera MainCamera { get; set; }
    public Action<Enemy> OnEnemyDie;

    private void Awake()
    {
        Debug.Log("Spawner Awake");
        _pool = new EnemyPool();
        _pool.cleanupFunc += enemy =>
        {
            if (enemy.TryGetComponent<EnemyDie>(out var ed))
            {
                ed.OnDie += () =>
                {
                    _pool.PutEnemy(enemy);
                };
            }
        };
        _pool.cleanupFunc += enemy =>
        {
            if (enemy.TryGetComponent<EnemyDie>(out var ed))
            {
                ed.OnDie += () =>
                {
                    OnEnemyDie?.Invoke(enemy);
                };
            }
        };
        StartCoroutine(SpawnCoroutine(spawnPoint));
    }

    private IEnumerator SpawnCoroutine(Vector2 spawnPoint)
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnCoolDown);

            spawnPoint = new Vector2(Player.PlayerPosition().x + Random.Range(-50, 50), Player.PlayerPosition().y + Random.Range(-50, 50));

            Enemy newEnemy = _pool.GetEnemy(_enemyPrefab);
            newEnemy.transform.position = spawnPoint;
            newEnemy.transform.rotation = new Quaternion(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1), 0);

            if (newEnemy.TryGetComponent<IHealth>(out var hp))
            {
                hp.SetMaxHealth(G.EnemyHp);
                hp.SetHealth(G.EnemyHp);
            }
            
            spawnPoint = Vector2.zero;
        }
    }
}
