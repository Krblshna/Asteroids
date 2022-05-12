using UnityEngine;

namespace Asteroids.GameLogic.Enemies
{
    public interface IFactory<T>
    {
        T Create(Transform transform);
    }
}