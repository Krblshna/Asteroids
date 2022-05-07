using Asteroids.GameLogic;
using UnityEngine;

namespace Asteroids.Enemies.EnemyProviders
{
    public class UfoProvider : MonoBehaviour, IEnemyProvider
    {
        public IEnemy GetModel()
        {
            return GameLogic.GameLogic.UfoFactory.Create(transform);
        }
    }
}