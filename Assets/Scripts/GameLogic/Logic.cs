using Asteroids.GameLogic.Enemies;
using Asteroids.GameLogic.Factories;
using Asteroids.GameLogic.Providers;
using Asteroids.GameLogic.Statistics;
using Asteroids.GameLogic.Movers;
using Asteroids.GameLogic.Player;

namespace Asteroids.GameLogic
{
    public static class Logic
    {
        public static IFactory<IEnemy> AsteroidFactory { get; }
        public static IFactory<IEnemy> ShardsFactory { get; }
        public static IFactory<IEnemy> UfoFactory { get; }
        public static IFactory<IPlayer> PlayerFactory { get; }
        public static readonly IEffectsProvider EffectsProvider;
        public static readonly IEnemyFactoryProvider EnemyFactoryProvider;
        public static readonly IPosProvider PlayerPosProvider;
        public static readonly IGamePoints GamePoints;
        public static readonly IPlayerStat PlayerStat;

        static Logic()
        {
            EffectsProvider = new EffectsProvider();
            EnemyFactoryProvider = new EnemiesManagerProvider();
            PlayerPosProvider = new PositionProvider();
            GamePoints = new GamePoints();
            PlayerStat = new PlayerStat();

            PlayerFactory = new PlayerFactory(EffectsProvider, PlayerPosProvider, PlayerStat);

            UfoFactory = new UfoFactory(EffectsProvider, PlayerPosProvider, GamePoints, 1, 0.5f);

            var asteroidMoveData = new SimpleMoveData(0.5f, 0.9f, 15f, 30f);
            AsteroidFactory = new AsteroidFactory(EffectsProvider, EnemyFactoryProvider, GamePoints, asteroidMoveData, 1f);

            var shardMoveData = new SimpleMoveData(0.9f, 1.2f, 30f, 50f);
            ShardsFactory = new ShardsFactory(EffectsProvider,  GamePoints, shardMoveData, 0.5f);
        }
    }
}