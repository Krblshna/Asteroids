using UnityEngine;

namespace Asteroids.Player
{
    public interface IMovementController
    {
        void Init(IInput input, Transform transform);
        void CustomUpdate();
    }
}