using Asteroids.Common;

namespace Asteroids.Statistics
{
    public interface IPlayerStat
    {
        void TriggerStatEvent(StatType statType);
        void Clear();
    }
}