using Asteroids.Common;

namespace Asteroids.FriendlyFire
{
    public interface IFriendlyFireChecker
    {
        bool IsFriendly(GroupType groupType);
    }
}