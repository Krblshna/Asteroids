using UnityEngine;
namespace Asteroids.Movers
{
    public interface IMover
    {
        void Move(Vector2 direction, float velocity);
        void Rotate(float angularVelocity);
        void DoOnDestroy();
    }
}