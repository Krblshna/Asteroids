using UnityEngine;

namespace Asteroids.GameLogic.PositionValidators
{
    public interface IPositionValidator
    {
        Vector3 GetPos();
    }
}