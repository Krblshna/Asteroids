using UnityEngine;

namespace Asteroids.Effect
{
    public interface IEffectsManager
    {
        void Create(EffectType effectType, Vector2 position);
    }
}