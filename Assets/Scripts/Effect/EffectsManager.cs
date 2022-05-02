﻿using System.Collections.Generic;
using System.Linq;
using Asteroids.Utility;
using UnityEngine;

namespace Asteroids.Effect
{
    public enum EffectType { DeathBig, DeathMiddle, DeathMini}
    public class EffectsManager : Singleton<EffectsManager>
    {
        [SerializeField] private EffectPool[] _effects;
        private Dictionary<EffectType, EffectPool> _effectsPools;

        public override void Awake()
        {
            base.Awake();
            foreach (var effectPool in _effects)
            {
                effectPool.Init();
            }
            _effectsPools = _effects.ToDictionary(effect => effect.Type, effect => effect);
        }

        public void CreateEffect(EffectType effectType, Vector2 pos)
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