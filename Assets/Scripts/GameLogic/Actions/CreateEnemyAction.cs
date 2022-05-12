using Asteroids.GameLogic.Providers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.GameLogic.Actions
{
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