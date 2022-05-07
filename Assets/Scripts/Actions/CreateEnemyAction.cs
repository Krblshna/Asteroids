using System;
using Asteroids.Common;
using Asteroids.Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Actions
{
    public class CreateEnemyAction : IAction
    {
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private float _creationRadius;
        [SerializeField] private int _amountMin, _amountMax;
        private readonly Transform _transform;
        private readonly IEnemyFactoryProvider _enemyFactoryProvider;

        public CreateEnemyAction(IEnemyFactoryProvider enemyFactoryProvider, Transform transform, EnemyType enemyType)
        {
            _enemyFactoryProvider = enemyFactoryProvider;
            _transform = transform;
            _enemyType = enemyType;
        }

        public void Call()
        {
            var amount = Random.Range(_amountMin, _amountMax + 1);
            for (var i = 0; i < amount; i++)
            {
                var randX = RandVal();
                var randY = RandVal();
                var creationPos = (Vector2)_transform.position + new Vector2(randX, randY);
                _enemyFactoryProvider.Create(_enemyType, creationPos);
            }
        }

        public float RandVal()
        {
            return Random.Range(-_creationRadius, _creationRadius);
        }
    }
}