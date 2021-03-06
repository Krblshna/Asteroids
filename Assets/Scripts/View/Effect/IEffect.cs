using System;
using UnityEngine;

namespace Asteroids.View.Effect
{
    public interface IEffect
    {
        void SetActive(bool active);
        void ShowEffect();
        GameObject GetObj { get;}
        void Init(Action<IEffect> onDestroyAction);
    }
}