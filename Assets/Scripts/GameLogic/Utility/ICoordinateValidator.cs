using UnityEngine;

namespace Asteroids.GameLogic.Utility
{
    public interface ICoordinateValidator
    {
        Vector3 ValidatePos(Vector3 pos, float size);
    }
}