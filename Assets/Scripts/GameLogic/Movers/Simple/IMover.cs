using UnityEngine;
namespace Asteroids.Movers
{
    public interface IMover
    {
        void Update();
        void Move(Vector2 direction, float velocity);
        void DoOnDestroy();
    }
}