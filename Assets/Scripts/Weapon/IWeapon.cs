using Asteroids.Common;

namespace Asteroids.Weapon
{
    public interface IWeapon
    {
        GroupType GroupType { get; }
        WeaponType WeaponType { get; }
        FireType FireType { get; }
        void Fire();
        void Update();
    }
}