using Asteroids.Actions;
using Asteroids.Common;
using Asteroids.Effect;
using Asteroids.Enemies;
using Asteroids.HitDetectors;
using Asteroids.Movers;
using Asteroids.PositionValidators;
using Asteroids.Statistics;
using Asteroids.Test2;
using UnityEngine;

namespace Asteroids.GameLogic
{
    public class UfoFactory : IEnemyFactory<IEnemy>
    {
        private readonly IEffectsProvider _effectsProvider;
        private readonly IPlayerStat _playerStat;
        private readonly float _bodySize, _velocity;
        public UfoFactory(IEffectsProvider effectsProvider, 
            IPlayerStat playerStat,
            float velocity,
            float bodySize)
        {
            _effectsProvider = effectsProvider;
            _playerStat = playerStat;
            _bodySize = bodySize;
            _velocity = velocity;
        }

        public IEnemy Create(Transform transform)
        {
            var borderValidator = new BorderValidator(_bodySize);
            var dumbPlayer = new DumbPlayer();
            var mover = new FollowMover(transform, dumbPlayer, borderValidator);
            var moveController = new FollowMoveController(mover, _velocity);
            var destroyActions = new IAction[]
            {
                new ParticleAction(_effectsProvider, transform,  EffectType.DeathBig),
                new StatAction(_playerStat, StatType.DestroyAsteroid)
            };
            return new UFO(moveController, destroyActions);
        }
    }
}