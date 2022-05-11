using Asteroids.GameLogic;
using UnityEngine;

namespace Asteroids.Enemies.EnemyProviders
{
    public class ShardProvider : MonoBehaviour, IEnemyProvider
    {
        public IEnemy GetModel()
        {
            return GameLogic.Logic.ShardsFactory.Create(transform);
        }
    }
}