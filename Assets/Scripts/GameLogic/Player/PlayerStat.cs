using Asteroids.GameLogic.Weapon;

namespace Asteroids.GameLogic.Player
{
    public class PlayerStat : IPlayerStat
    {
        public IMoverData MoveData { get; private set; }
        public ILaserData LaserData { get; private set; }
        public void BindData(IMovementController moveController, ILaserData laserModel)
        {
            if (moveController is IMoverData moverData)
            {
                MoveData = moverData;
            }

            LaserData = laserModel;
        }
    }
}