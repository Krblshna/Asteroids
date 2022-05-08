using System;
using Asteroids.Common;
using Asteroids.Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Actions
{
    public class EnemiesCreationData
    {
        public EnemyType EnemyType { get; }
        public float CreationRadius { get; }
        public int AmountMin { get; }
        public int AmountMax { get; }

        public EnemiesCreationData(EnemyType enemyType, float creationRadius, int amountMin, int amountMax)
        {
            EnemyType = enemyType;
            CreationRadius = creationRadius;
            AmountMin = amountMin;
            AmountMax = amountMax;
        }
    }

    public class CreateEnemyAction : IAction
    {
        private readonly EnemiesCreationData _creationData;
        private readonly Transform _transform;
        private readonly IEnemyFactoryProvider _enemyFactoryProvider;

        public CreateEnemyAction(IEnemyFactoryProvider enemyFactoryProvider, Transform transform, EnemiesCreationData creationData)
        {
            _enemyFactoryProvider = enemyFactoryProvider;
            _transform = transform;
            _creationData = creationData;
        }

        public void Call()
        {
            var amount = Random.Range(_creationData.AmountMin, _creationData.AmountMax + 1);
            for (var i = 0; i < amount; i++)
            {
                var randX = RandVal();
                var randY = RandVal();
                var creationPos = (Vector2)_transform.position + new Vector2(randX, randY);
                _enemyFactoryProvider.Create(_creationData.EnemyType, creationPos);
            }
        }

        public float RandVal()
        {
            return Random.Range(-_creationData.CreationRadius, _creationData.CreationRadius);
        }
    }
}