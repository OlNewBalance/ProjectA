using Source.Objects.Enemies;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool
{
    private int _maxEnemies = 25;
    private List<Enemy> _enemies = new List<Enemy>();

    public Enemy GetEnemy(Enemy enemyPrefab)
    {
        if (_enemies.Count == 0)
        {
            SetEnemy(enemyPrefab);
        }

        Enemy enemy = _enemies.FirstOrDefault();
        _enemies.Remove(enemy);
        enemy.gameObject.SetActive(true);
        return enemy;
    }

    public IEnumerator ReturnBulletCallback(Enemy enemy, float timeout)
    {
        yield return new WaitForSeconds(timeout);
        this.PutEnemy(enemy);
    }

    public void PutEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        _enemies.Add(enemy);
    }

    private void SetEnemy(Enemy enemyPrefab)
    {
        if (_enemies.Count >= _maxEnemies)
        {
            return;
        }

        for (int i = 0; i < _maxEnemies; i++)
        {
            Enemy enemy = UnityEngine.MonoBehaviour.Instantiate(enemyPrefab);
            enemy.gameObject.SetActive(false);
            _enemies.Add(enemy);
        }
    }
}