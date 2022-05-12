using UnityEngine;

namespace Asteroids.GameLogic.Providers
{
    public class PositionProvider : IPosProvider
    {
        private Transform _transform;
        public void Init(Transform transform)
        {
            _transform = transform;
        }

        public Vector3 GetPos => _transform.position;
        public bool Active => _transform.gameObject.activeSelf;
    }
}