using UnityEngine;

namespace Asteroids.Player
{
    public interface IVelocityMover
    {
        void Update(Vector2 velocityVector);
    }
}