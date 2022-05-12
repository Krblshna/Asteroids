using Asteroids.GameLogic.Common;

namespace Asteroids.GameLogic.Statistics
{
    public interface IGamePoints
    {
        int Amount { get; }
        void TriggerStatEvent(StatType statType);
        void Clear();
    }
}