using UnityEngine;

namespace Asteroids.Player
{
    public interface IMovementController
    {
        void Init(IInput input, Rigidbody2D body);
        void CustomFixedUpdate();
    }
}