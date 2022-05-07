using UnityEngine;

namespace Asteroids.PositionValidators
{
    public interface IBorderValidator
    {
        Vector3 Validate(Vector3 pos);
    }
}