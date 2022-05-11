using Asteroids.Actions;
using Asteroids.Common;
using Asteroids.Effect;
using Asteroids.Enemies;
using Asteroids.Statistics;
using Asteroids.Movers;
using Asteroids.PositionValidators;
using UnityEngine;

namespace Asteroids.GameLogic
{
    public class ShardsFactory : IFactory<IEnemy>
    {
        private readonly IEffectsProvider _effectsProvider;
        private readonly IEnemyFactoryProvider _enemyFactoryProvider;
        private readonly IGamePoints _gamePoints;
        private readonly SimpleMoveData _moveData;
        private readonly float _bodySize;

        public ShardsFactory(
            IEffectsProvider effectsProvider, 
            IGamePoints gamePoints, 
            SimpleMoveData moveData,
            float bodySize
            )
        {
            _effectsProvider = effectsProvider;
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
            var creationData = new EnemiesCreationData(EnemyType.asteroidShard, 0.5f, 1, 3);
            var destroyActions = new IAction[]
            {
                new ParticleAction(_effectsProvider, transform,  EffectType.DeathMiddle),
                new StatAction(_gamePoints, StatType.DestroyAsteroidFragment)
            };
            return new Asteroid(moveController, destroyActions);
        }
    }
}