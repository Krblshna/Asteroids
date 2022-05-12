using UnityEngine;

namespace Asteroids.GameLogic.Player
{
    public class MoverData
    {
        public Vector3 Position { get; }
        public Vector3 Velocity { get; }
        public int Rotation { get; }
        private IMovementController _moveController;

        public MoverData(IMovementController moveController)
        {
            _moveController = moveController;
        }
    }
}