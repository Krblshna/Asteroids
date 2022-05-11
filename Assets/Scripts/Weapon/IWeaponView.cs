using Asteroids.Common;

namespace Asteroids.Weapon
{
    public interface IWeaponView
    {
        WeaponType WeaponType { get; }
        void Init(IWeapon weapon);
        void CustomUpdate();
    }
}