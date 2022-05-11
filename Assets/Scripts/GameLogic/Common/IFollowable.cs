using UnityEngine;

namespace Asteroids.Common
{
    public interface IFollowable
    {
        Vector3 GetPos();
        bool Active { get; }
    }
}