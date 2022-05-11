using Asteroids.Actions;
using Asteroids.Common;
using Asteroids.Effect;
using Asteroids.Movers;
using Asteroids.PositionValidators;
using Asteroids.Statistics;
using UnityEngine;

namespace Asteroids.GameLogic
{
    public class UfoFactory : IFactory<IEnemy>
    {
        private readonly IEffectsProvider _effectsProvider;
        private readonly IGamePoints _gamePoints;
        private readonly float _bodySize, _velocity;
        public UfoFactory(IEffectsProvider effectsProvider, 
            IGamePoints gamePoints,
            float velocity,
            float bodySize)
        {
            _effectsProvider = effectsProvider;
            _gamePoints = gamePoints;
            _bodySize = bodySize;
            _velocity = velocity;
        }

        public IEnemy Create(Transform transform)
        {
            var borderValidator = new BorderValidator(_bodySize);
            var mover = new FollowMover(transform, borderValidator);
            var moveController = new FollowMoveController(mover, _velocity);
            var destroyActions = new IAction[]
            {
                new ParticleAction(_effectsProvider, transform,  EffectType.DeathBig),
                new StatAction(_gamePoints, StatType.DestroyAsteroid)
            };
            return new UFO(moveController, destroyActions);
        }
    }
}