using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.Providers;
using UnityEngine;

namespace Asteroids.GameLogic.Actions
{
    public class ParticleAction : IAction
    {
        private readonly EffectType _destroyEffect;
        private readonly IEffectsProvider _effectsProvider;
        private readonly Transform _transform;

        public ParticleAction(IEffectsProvider effectsProvider, Transform transform, EffectType destroyEffect)
        {
            _effectsProvider = effectsProvider;
            _transform = transform;
            _destroyEffect = destroyEffect;
        }

        public void Call()
        {
            _effectsProvider.Create(_destroyEffect, _transform.position);
        }
    }
}