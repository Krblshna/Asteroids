using Asteroids.GameLogic;
using Asteroids.GameLogic.Enemies;
using UnityEngine;

namespace Asteroids.View.Enemies
{
    public class ShardProvider : MonoBehaviour, IEnemyProvider
    {
        public IEnemy GetModel()
        {
            return Logic.ShardsFactory.Create(transform);
        }
    }
}