using System;
using UnityEngine;

namespace Asteroids.Asteroid
{
    public interface IAsteroid
    {
        void SetActive(bool active);
        void Init(Action<IAsteroid> OnDestroyAction);
        GameObject GetObj { get; }
        void OnGet();
    }
}