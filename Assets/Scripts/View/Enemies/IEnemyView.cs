using System;
using UnityEngine;

namespace Asteroids.View.Enemies
{
    public interface IEnemyView
    {
        void SetActive(bool active);
        void Init(Action<IEnemyView> destroyCallback);
        void OnCreate();
        void SetPos(Vector2 pos);
    }
}