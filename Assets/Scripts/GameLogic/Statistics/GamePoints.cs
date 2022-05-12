using System.Collections.Generic;
using Asteroids.GameLogic.Common;

namespace Asteroids.GameLogic.Statistics
{
    public class GamePoints : IGamePoints
    {
        public int Amount { get; private set; }
        private readonly Dictionary<StatType, int> _statTable = new Dictionary<StatType, int>()
        {
            {StatType.DestroyAsteroid, 10},
            {StatType.DestroyAsteroidFragment, 5},
            {StatType.DestroyUfo, 15}
        };

        public void TriggerStatEvent(StatType statType)
        {
            if (!_statTable.TryGetValue(statType, out var value)) return;
            Amount += value;
        }

        public void Clear()
        {
            Amount = 0;
        }
    }
}