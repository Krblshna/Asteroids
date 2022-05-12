using Asteroids.GameLogic.Weapon;

namespace Asteroids.GameLogic.Player
{
    public interface IPlayerStat
    {
        IMoverData MoveData { get; }
        ILaserData LaserData { get; }
        void BindData(IMovementController moveController, ILaserData laserModel);
    }
}