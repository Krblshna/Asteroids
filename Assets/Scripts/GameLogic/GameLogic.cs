using Asteroids.Effect;
using Asteroids.Enemies;
using Asteroids.Movers;
using Asteroids.Player;
using Asteroids.Statistics;

namespace Asteroids.GameLogic
{
    public static class GameLogic
    {
        public static IFactory<IEnemy> AsteroidFactory { get; }
        public static IFactory<IEnemy> ShardsFactory { get; }
        public static IFactory<IEnemy> UfoFactory { get; }
        public static IFactory<IPlayer> PlayerFactory { get; }
        public static readonly IEffectsProvider EffectsProvider;
        public static readonly IEnemyFactoryProvider EnemyFactoryProvider;
        public static readonly IGamePoints GamePoints;
        public static readonly IPlayerStat PlayerStat;

        static GameLogic()
        {
            EffectsProvider = new EffectsProvider();
            EnemyFactoryProvider = new EnemiesManagerProvider();
            GamePoints = new GamePoints();
            PlayerStat = new PlayerStat();

            PlayerFactory = new PlayerFactory(EffectsProvider, PlayerStat);

            UfoFactory = new UfoFactory(EffectsProvider, GamePoints, 1, 0.5f);

            var asteroidMoveData = new SimpleMoveData(0.5f, 0.9f, 15f, 30f);
            AsteroidFactory = new AsteroidFactory(EffectsProvider, EnemyFactoryProvider, GamePoints, asteroidMoveData, 1f);

            var shardMoveData = new SimpleMoveData(0.9f, 1.2f, 30f, 50f);
            ShardsFactory = new ShardsFactory(EffectsProvider,  GamePoints, shardMoveData, 0.5f);
        }
    }
}