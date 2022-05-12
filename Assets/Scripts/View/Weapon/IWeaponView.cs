using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.Weapon;

namespace Asteroids.View.Weapon
{
    public interface IWeaponView
    {
        WeaponType WeaponType { get; }
        void Init(IWeapon weapon);
        void CustomUpdate();
    }
}