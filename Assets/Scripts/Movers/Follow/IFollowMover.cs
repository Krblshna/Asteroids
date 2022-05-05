using UnityEngine;

namespace Asteroids.Movers
{
    public interface IFollowMover
    {
        void StartFollow(Transform targetTransform, float velocity);
    }
}