using Asteroids.GameLogic.Common;

namespace Asteroids.GameLogic.FriendlyFire
{
    public class FriendlyFireChecker : IFriendlyFireChecker
    {
        private readonly GroupType _groupType;

        public FriendlyFireChecker(GroupType groupType)
        {
            _groupType = groupType;
        }

        public bool IsFriendly(GroupType groupType)
        {
            return groupType == _groupType;
        }
    }
}