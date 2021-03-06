using UnityEngine;

namespace Asteroids.GameLogic.Player
{
    public interface IMoverData
    {
        Vector3 Position { get; }
        Vector3 Velocity { get; }
        int Rotation { get; }
    }
}