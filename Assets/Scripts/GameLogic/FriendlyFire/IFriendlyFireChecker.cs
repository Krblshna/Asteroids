using Asteroids.GameLogic.Common;

namespace Asteroids.GameLogic.FriendlyFire
{
    public interface IFriendlyFireChecker
    {
        bool IsFriendly(GroupType groupType);
    }
}