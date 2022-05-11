using Asteroids.GameLogic;
using UnityEngine;

namespace Asteroids.Enemies.EnemyProviders
{
    public class ShardProvider : MonoBehaviour, IEnemyProvider
    {
        public IEnemy GetModel()
        {
            return Logic.ShardsFactory.Create(transform);
        }
    }
}