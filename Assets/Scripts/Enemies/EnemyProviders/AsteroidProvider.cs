using Asteroids.GameLogic;
using UnityEngine;

namespace Asteroids.Enemies.EnemyProviders
{
    public class AsteroidProvider : MonoBehaviour, IEnemyProvider
    {
        public IEnemy GetModel()
        {
            return GameLogic.Logic.AsteroidFactory.Create(transform);
        }
    }
}