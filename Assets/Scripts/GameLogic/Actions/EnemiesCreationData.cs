using Asteroids.GameLogic.Common;

namespace Asteroids.GameLogic.Actions
{
    public class EnemiesCreationData
    {
        public EnemyType EnemyType { get; }
        public float CreationRadius { get; }
        public int AmountMin { get; }
        public int AmountMax { get; }

        public EnemiesCreationData(EnemyType enemyType, float creationRadius, int amountMin, int amountMax)
        {
            EnemyType = enemyType;
            CreationRadius = creationRadius;
            AmountMin = amountMin;
            AmountMax = amountMax;
        }
    }
}