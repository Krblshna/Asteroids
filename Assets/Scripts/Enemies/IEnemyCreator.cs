using Asteroids.Common;
using UnityEngine;

namespace Asteroids.Enemies
{
    public interface IEnemyCreator
    {
        void Create(EnemyType enemyType, Vector2 pos);
    }
}