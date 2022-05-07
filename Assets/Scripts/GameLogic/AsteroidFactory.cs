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
    public class AsteroidFactory : IEnemyFactory<IEnemy>
    {
        private readonly IEffectsProvider _effectsProvider;
        private readonly IEnemyFactoryProvider _enemyFactoryProvider;
        private readonly IPlayerStat _playerStat;
        private readonly SimpleMoveData _moveData;
        private readonly float _bodySize;

        public AsteroidFactory(
            IEffectsProvider effectsProvider, 
            IEnemyFactoryProvider enemyFactoryProvider, 
            IPlayerStat playerStat, 
            SimpleMoveData moveData,
            float bodySize
            )
        {
            _effectsProvider = effectsProvider;
            _enemyFactoryProvider = enemyFactoryProvider;
            _playerStat = playerStat;
            _moveData = moveData;
            _bodySize = bodySize;
        }

        public IEnemy Create(Transform transform)
        {
            var borderValidator = new BorderValidator(_bodySize);
            var mover = new SimpleMover(transform, borderValidator);
            var rotator = new SimpleRotator(transform);
            var moveController = new SimpleMoveController(mover, rotator, _moveData);
            var destroyActions = new IAction[]
            {
                new CreateEnemyAction(_enemyFactoryProvider, transform, EnemyType.asteroidShard),
                new ParticleAction(_effectsProvider, transform,  EffectType.DeathBig),
                new StatAction(_playerStat, StatType.DestroyAsteroid)
            };
            return new Asteroid(moveController, destroyActions);
        }
    }
}