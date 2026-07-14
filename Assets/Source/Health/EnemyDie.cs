using System;
using JetBrains.Annotations;
using Source.Objects.Enemies;
using Unity.VisualScripting;
using UnityEngine;

namespace Source.Health
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyDie: MonoBehaviour, IDie
    {
        public Action OnDie;
        
        public void Die()
        {
            if (!OnDie.IsUnityNull())
            {
                OnDie.Invoke();
                return;
            }
            Destroy(gameObject);
        }
    }
}