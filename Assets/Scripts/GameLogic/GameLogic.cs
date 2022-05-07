using Asteroids.Effect;
using Asteroids.Enemies;
using Asteroids.Movers;
using Asteroids.Statistics;
using Asteroids.Test2;

namespace Asteroids.GameLogic
{
    public static class GameLogic
    {
        public static readonly IEnemyFactory<IEnemy> AsteroidFactory;
        public static readonly IEnemyFactory<IEnemy> ShardsFactory;
        public static readonly IEnemyFactory<IEnemy> UfoFactory;
        public static readonly IEffectsProvider EffectsProvider;
        public static readonly IEnemyFactoryProvider EnemyFactoryProvider;
        public static readonly IPlayerStat PlayerStat;

        static GameLogic()
        {
            EffectsProvider = new EffectsProvider();
            EnemyFactoryProvider = new EnemiesManagerProvider();
            PlayerStat = new GamePoints();

            UfoFactory = new UfoFactory(EffectsProvider, PlayerStat, 1, 0.5f);

            var asteroidMoveData = new SimpleMoveData(0.5f, 0.9f, 15f, 30f);
            AsteroidFactory = new AsteroidFactory(EffectsProvider, EnemyFactoryProvider, PlayerStat, asteroidMoveData, 1f);

            var shardMoveData = new SimpleMoveData(1.1f, 1.4f, 30f, 50f);
            ShardsFactory = new AsteroidFactory(EffectsProvider, EnemyFactoryProvider, PlayerStat, shardMoveData, 0.5f);
        }
    }
}