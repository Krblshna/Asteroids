using Asteroids.Common;

namespace Asteroids.Weapon
{
    public interface IWeapon
    {
        void Fire();
        void Init(GroupType groupType);
    }
}