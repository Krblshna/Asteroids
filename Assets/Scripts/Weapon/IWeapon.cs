using Asteroids.Utility;

namespace Asteroids.Weapon
{
    public interface IWeapon
    {
        void Fire();
        void Init(GroupType groupType);
    }
}