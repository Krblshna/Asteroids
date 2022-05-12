using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.Weapon;

namespace Asteroids.GameLogic.Player
{
    public interface IWeaponController
    {
        IWeapon GetWeapon(WeaponType weaponType);
        void CustomUpdate();
    }
}