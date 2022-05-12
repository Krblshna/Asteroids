using System;
using Asteroids.GameLogic.Common;
using UnityEngine;

namespace Asteroids.GameLogic.Providers
{
    public class EnemiesManagerProvider : IEnemyFactoryProvider
    {
        private Action<EnemyType, Vector2> _createAction;

        public void Init(Action<EnemyType, Vector2> create)
        {
            _createAction = create;
        }

        public void Create(EnemyType enemyType, Vector2 pos)
        {
            _createAction(enemyType, pos);
        }
    }
}