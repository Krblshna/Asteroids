using UnityEngine;

namespace Asteroids.GameLogic.Providers
{
    public interface IPosProvider
    {
        Vector3 GetPos { get; }
        bool Active { get; }
        void Init(Transform transform);
    }
}