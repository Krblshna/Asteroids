using System.Collections.Generic;
using System.Linq;
using Asteroids.Common;
using Asteroids.Utility;
using UnityEngine;

namespace Asteroids.Enemies
{
    public class EnemiesManager : MonoBehaviour, IEnemyCreator
    {
        [SerializeField] private EnemyPool[] _pools;
        private Dictionary<EnemyType, IEnemyPool> _poolsDict = new Dictionary<EnemyType, IEnemyPool>();
        private IEnemyFactoryProvider _enemyFactoryProvider;

        public void Awake()
        {
            _enemyFactoryProvider = GameLogic.Logic.EnemyFactoryProvider;
            _enemyFactoryProvider.Init(Create);
            foreach (var effectPool in _pools)
            {
                effectPool.Init();
            }
            _poolsDict = _pools.ToDictionary(pool => pool.Type, pool => (IEnemyPool)pool);
        }

        public void Create(EnemyType enemyType, Vector2 pos)
        {
            if (_poolsDict.TryGetValue(enemyType, out var enemyPool))
            {
                var enemy = enemyPool.Get();
                enemy.SetPos(pos);
            }
        }
    }
}