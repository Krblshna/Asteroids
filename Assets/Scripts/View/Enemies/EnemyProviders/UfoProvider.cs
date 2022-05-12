using Asteroids.GameLogic;
using Asteroids.GameLogic.Enemies;
using UnityEngine;

namespace Asteroids.View.Enemies
{
    public class UfoProvider : MonoBehaviour, IEnemyProvider
    {
        public IEnemy GetModel()
        {
            return Logic.UfoFactory.Create(transform);
        }
    }
}