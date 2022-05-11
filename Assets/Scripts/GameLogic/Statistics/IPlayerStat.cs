using Asteroids.Common;
using Asteroids.Weapon;

namespace Asteroids.Statistics
{
    public interface IGamePoints
    {
        int Amount { get; }
        void TriggerStatEvent(StatType statType);
        void Clear();
    }
}