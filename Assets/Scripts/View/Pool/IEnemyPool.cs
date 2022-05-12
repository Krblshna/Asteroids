using Asteroids.View.Enemies;

namespace Asteroids.View.Pool
{
    public interface IEnemyPool
    {
        IEnemyView Get();
    }
}