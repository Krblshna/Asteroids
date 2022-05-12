using Asteroids.GameLogic.Enemies;

namespace Asteroids.View.Enemies
{
    public interface IEnemyProvider
    {
        IEnemy GetModel();
    }
}