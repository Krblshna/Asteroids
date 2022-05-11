using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.Common;
using Asteroids.Utility;
using UnityEngine;

namespace Asteroids.Enemies
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