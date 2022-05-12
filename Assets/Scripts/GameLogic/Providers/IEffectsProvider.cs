using System;
using Asteroids.GameLogic.Common;
using UnityEngine;

namespace Asteroids.GameLogic.Providers
{
    public interface IEffectsProvider
    {
        void Create(EffectType effectType, Vector2 position);
        void Init(Action<EffectType, Vector2> create);
    }
}