using System;
using UnityEngine;

namespace Asteroids.Enemies
{
    public interface IEnemy
    {
        void SetActive(bool active);
        void Init(Action<IEnemy> destroyCallback);
        void OnCreate();
        void SetPos(Vector2 pos);
    }
}