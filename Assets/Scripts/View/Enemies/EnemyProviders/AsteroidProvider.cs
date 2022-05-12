using Asteroids.GameLogic;
using Asteroids.GameLogic.Enemies;
using UnityEngine;

namespace Asteroids.View.Enemies
{
    public class AsteroidProvider : MonoBehaviour, IEnemyProvider
    {
        public IEnemy GetModel()
        {
            return Logic.AsteroidFactory.Create(transform);
        }
    }
}