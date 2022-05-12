using Asteroids.GameLogic.Common;
using UnityEngine;

namespace Asteroids.View.Effect
{
    public interface IEffectsManager
    {
        void Create(EffectType effectType, Vector2 position);
    }
}