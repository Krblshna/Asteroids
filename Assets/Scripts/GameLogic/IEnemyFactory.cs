
using UnityEngine;

namespace Asteroids.GameLogic
{
    public interface IEnemyFactory<T>
    {
        T Create(Transform transform);
    }
}