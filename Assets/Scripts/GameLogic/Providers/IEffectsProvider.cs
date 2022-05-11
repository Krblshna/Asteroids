using System;
using UnityEngine;

namespace Asteroids.Effect
{
    public interface IEffectsProvider
    {
        void Create(EffectType effectType, Vector2 position);
        void Init(Action<EffectType, Vector2> create);
    }
}