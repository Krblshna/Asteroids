using Asteroids.Common;
using Asteroids.Weapon;

namespace Asteroids.Player
{
    public interface IWeaponController
    {
        IWeapon GetWeapon(WeaponType weaponType);
        void CustomUpdate();
    }
}