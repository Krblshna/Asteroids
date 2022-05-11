using Asteroids.Common;
using UnityEngine;

namespace Asteroids.Movers
{
    public interface IFollowMover
    {
        void StartFollow(IFollowable followable, float velocity);
        void Update();
    }
}