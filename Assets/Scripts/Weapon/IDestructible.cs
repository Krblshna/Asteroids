using Asteroids.Utility;

namespace Asteroids.Weapon
{
    public interface IDestructible
    {
        bool Hit(GroupType hitGroup);
    }
}