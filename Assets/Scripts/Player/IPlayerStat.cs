using Asteroids.Weapon;

namespace Asteroids.Player
{
    public interface IPlayerStat
    {
        IMoverData MoveData { get; }
        ILaserData LaserData { get; }
        void BindData(IMovementController moveController, ILaserData laserModel);
    }
}