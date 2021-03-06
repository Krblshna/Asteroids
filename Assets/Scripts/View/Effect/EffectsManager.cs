using System.Collections.Generic;
using System.Linq;
using Asteroids.GameLogic;
using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.Providers;
using Asteroids.View.Pool;
using UnityEngine;

namespace Asteroids.View.Effect
{
    public class EffectsManager : MonoBehaviour, IEffectsManager
    {
        [SerializeField] private EffectPool[] _effects;
        private Dictionary<EffectType, EffectPool> _effectsPools;
        private IEffectsProvider _effectProvider;

        public void Awake()
        {
            _effectProvider = Logic.EffectsProvider;
            _effectProvider.Init(Create);
            foreach (var effectPool in _effects)
            {
                effectPool.Init();
            }
            _effectsPools = _effects.ToDictionary(effect => effect.Type, effect => effect);
        }

        public void Create(EffectType effectType, Vector2 pos)
        {
            if (_effectsPools.TryGetValue(effectType, out var effectPool))
            {
                var effect = effectPool.GetEffect();
                var effectObj = effect.GetObj;
                effectObj.transform.position = pos;
                effect.ShowEffect();
            }
        }
    }
}