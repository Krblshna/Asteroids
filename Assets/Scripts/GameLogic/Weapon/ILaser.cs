using System;

namespace Asteroids.Weapon
{
    public interface ILaser : IWeapon
    {
        void BindActions(Action onActivate, Action onDeactivate);
    }
}