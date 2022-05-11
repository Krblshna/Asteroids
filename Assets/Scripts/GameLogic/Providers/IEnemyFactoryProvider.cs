using System;
using Asteroids.Common;
using UnityEngine;

namespace Asteroids.Enemies
{
    public interface IEnemyFactoryProvider
    {
        void Create(EnemyType enemyType, Vector2 creationPos);
        void Init(Action<EnemyType, Vector2> create);
    }
}