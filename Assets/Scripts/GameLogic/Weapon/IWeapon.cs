using Asteroids.GameLogic.Common;

namespace Asteroids.GameLogic.Weapon
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