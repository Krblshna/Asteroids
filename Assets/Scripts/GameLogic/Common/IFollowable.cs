using UnityEngine;

namespace Asteroids.GameLogic.Common
{
    public interface IFollowable
    {
        Vector3 GetPos();
        bool Active { get; }
    }
}