using Asteroids.GameLogic.Actions;
using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.Enemies;
using Asteroids.GameLogic.PositionValidators;
using Asteroids.GameLogic.Providers;
using Asteroids.GameLogic.Movers;
using Asteroids.GameLogic.Statistics;
using UnityEngine;

namespace Asteroids.GameLogic.Factories
{
    public class UfoFactory : IFactory<IEnemy>
    {
        private readonly IEffectsProvider _effectsProvider;
        private readonly IGamePoints _gamePoints;
        private readonly IPosProvider _posProvider;
        private readonly float _bodySize, _velocity;
        public UfoFactory(IEffectsProvider effectsProvider,
            IPosProvider posProvider,
            IGamePoints gamePoints,
            float velocity,
            float bodySize)
        {
            _effectsProvider = effectsProvider;
            _posProvider = posProvider;
            _gamePoints = gamePoints;
            _bodySize = bodySize;
            _velocity = velocity;
        }

        public IEnemy Create(Transform transform)
        {
            var borderValidator = new BorderValidator(_bodySize);
            var mover = new FollowMover(transform, _posProvider, _velocity, borderValidator);
            var moveController = new FollowMoveController(mover);
            var destroyActions = new IAction[]
            {
                new ParticleAction(_effectsProvider, transform,  EffectType.DeathBig),
                new StatAction(_gamePoints, StatType.DestroyAsteroid)
            };
            return new UFO(moveController, destroyActions);
        }
    }
}