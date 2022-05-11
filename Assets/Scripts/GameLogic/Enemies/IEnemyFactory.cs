
using UnityEngine;

namespace Asteroids.GameLogic
{
    public interface IFactory<T>
    {
        T Create(Transform transform);
    }
}