using UnityEngine;

namespace Asteroids.Movers
{
    public interface IFollowMover
    {
        void StartFollow(float velocity);
        void Update();
    }
}