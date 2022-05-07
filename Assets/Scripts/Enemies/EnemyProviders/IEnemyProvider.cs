using Asteroids.GameLogic;

namespace Asteroids.Enemies.EnemyProviders
{
    public interface IEnemyProvider
    {
        IEnemy GetModel();
    }
}