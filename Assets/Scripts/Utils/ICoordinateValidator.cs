using UnityEngine;

namespace Asteroids.Utils
{
    public interface ICoordinateValidator
    {
        Vector3 ValidatePos(Vector3 pos, float size);
    }
}