using System;

namespace Asteroids.GameLogic.Weapon
{
    public interface IGun : IWeapon
    {
        void BindActions(Action onFire);
    }
}