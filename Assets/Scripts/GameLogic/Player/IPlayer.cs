using Asteroids.Common;

namespace Asteroids.Player
{
    public interface IPlayer
    {
        GroupType GroupType { get; }
        IWeaponController WeaponController { get; }
        IMovementController MovementController { get; }
        void OnDestroy();
        void Update();
    }
}