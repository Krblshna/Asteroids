using UnityEngine;

namespace Asteroids.GameLogic.PositionValidators
{
    public interface IBorderValidator
    {
        Vector3 Validate(Vector3 pos);
    }
}