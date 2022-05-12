using System;

namespace Asteroids.GameLogic.Weapon
{
    public interface ILaser : IWeapon
    {
        void BindActions(Action onActivate, Action onDeactivate);
    }
}