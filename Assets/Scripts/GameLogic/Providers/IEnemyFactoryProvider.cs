using System;
using Asteroids.GameLogic.Common;
using UnityEngine;

namespace Asteroids.GameLogic.Providers
{
    public interface IEnemyFactoryProvider
    {
        void Create(EnemyType enemyType, Vector2 creationPos);
        void Init(Action<EnemyType, Vector2> create);
    }
}