using System.Collections.Generic;
using System.Linq;
using Asteroids.Common;
using Asteroids.Utility;
using UnityEngine;

namespace Asteroids.Enemies
{
    public class EnemiesManager : Singleton<EnemiesManager>
    {
        [SerializeField] private EnemyPool[] _pools;
        private Dictionary<EnemyType, IEnemyPool> _poolsDict;

        public override void Awake()
        {
            base.Awake();
            foreach (var effectPool in _pools)
            {
                effectPool.Init();
            }
            _poolsDict = _pools.ToDictionary(pool => pool.Type, pool => (IEnemyPool)pool);
        }

        public void CreateEnemy(EnemyType enemyType, Vector2 pos)
        {
            if (_poolsDict.TryGetValue(enemyType, out var enemyPool))
            {
                var enemy = enemyPool.Get();
                enemy.SetPos(pos);
            }
        }
    }
}