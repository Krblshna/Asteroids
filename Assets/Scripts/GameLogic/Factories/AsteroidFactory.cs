using Asteroids.GameLogic.Actions;
using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.Enemies;
using Asteroids.GameLogic.Movers;
using Asteroids.GameLogic.PositionValidators;
using Asteroids.GameLogic.Providers;
using Asteroids.GameLogic.Statistics;
using UnityEngine;

namespace Asteroids.GameLogic.Factories
{
    public class AsteroidFactory : IFactory<IEnemy>
    {
        private readonly IEffectsProvider _effectsProvider;
        private readonly IEnemyFactoryProvider _enemyFactoryProvider;
        private readonly IGamePoints _gamePoints;
        private readonly SimpleMoveData _moveData;
        private readonly float _bodySize;

        public AsteroidFactory(
            IEffectsProvider effectsProvider, 
            IEnemyFactoryProvider enemyFactoryProvider, 
            IGamePoints gamePoints, 
            SimpleMoveData moveData,
            float bodySize
            )
        {
            _effectsProvider = effectsProvider;
            _enemyFactoryProvider = enemyFactoryProvider;
            _gamePoints = gamePoints;
            _moveData = moveData;
            _bodySize = bodySize;
        }

        public IEnemy Create(Transform transform)
        {
            var borderValidator = new BorderValidator(_bodySize);
            var mover = new SimpleMover(transform, borderValidator);
            var rotator = new SimpleRotator(transform);
            var moveController = new SimpleMoveController(mover, rotator, _moveData);
            var creationData = new EnemiesCreationData(EnemyType.asteroidShard, 0.2f, 1, 3);
            var destroyActions = new IAction[]
            {
                new ParticleAction(_effectsProvider, transform,  EffectType.DeathBig),
                new StatAction(_gamePoints, StatType.DestroyAsteroid)
            };
            var splitActions = new IAction[]
            {
                new CreateEnemyAction(_enemyFactoryProvider, transform, creationData),
            };
            return new Asteroid(moveController, destroyActions, splitActions);
        }
    }
}