using System;
using Asteroids.GameLogic.Common;
using UnityEngine;

namespace Asteroids.View.Enemies
{
    [System.Serializable]
    public class SpawnParams
    {
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private float _minSpawnDelay;
        [SerializeField] private float _maxSpawnDelay;
        private float _lastSpawnTime;
        private float _waitTime;
        private Action<EnemyType> _spawnAction;

        public void Init(Action<EnemyType> spawn)
        {
            _spawnAction = spawn;
            _waitTime = UnityEngine.Random.Range(_minSpawnDelay, _maxSpawnDelay);
        }

        public void TrySpawn()
        {
            if (Time.timeSinceLevelLoad - _lastSpawnTime > _waitTime)
            {
                _waitTime = UnityEngine.Random.Range(_minSpawnDelay, _maxSpawnDelay);
                _lastSpawnTime = Time.timeSinceLevelLoad;
                _spawnAction?.Invoke(_enemyType);
            }
        }
    }
}