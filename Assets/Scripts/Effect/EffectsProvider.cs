using System;
using Asteroids.Common;
using UnityEngine;

namespace Asteroids.Effect
{
    public class EffectsProvider : IEffectsProvider
    {
        private Action<EffectType, Vector2> _createAction;

        public void Init(Action<EffectType, Vector2> create)
        {
            _createAction = create;
        }

        public void Create(EffectType effectType, Vector2 pos)
        {
            _createAction(effectType, pos);
        }
    }
}