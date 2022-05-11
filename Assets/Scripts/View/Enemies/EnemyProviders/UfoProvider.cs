using Asteroids.GameLogic;
using UnityEngine;

namespace Asteroids.Enemies.EnemyProviders
{
    public class UfoProvider : MonoBehaviour, IEnemyProvider
    {
        public IEnemy GetModel()
        {
            return Logic.UfoFactory.Create(transform);
        }
    }
}