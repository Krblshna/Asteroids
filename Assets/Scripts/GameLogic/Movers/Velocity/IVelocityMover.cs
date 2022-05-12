using UnityEngine;

namespace Asteroids.GameLogic.Movers
{
    public interface IVelocityMover
    {
        void Update(Vector2 velocityVector);
    }
}