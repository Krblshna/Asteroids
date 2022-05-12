using Asteroids.GameLogic.Common;
using UnityEngine;

namespace Asteroids.View.Enemies
{
    public interface IEnemyCreator
    {
        void Create(EnemyType enemyType, Vector2 pos);
    }
}