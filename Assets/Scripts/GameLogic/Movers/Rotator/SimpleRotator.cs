using UnityEngine;

namespace Asteroids.GameLogic.Movers
{
    public class SimpleRotator : IRotator
    {
        private readonly Transform _transform;
        private float _angularVelocity;

        public SimpleRotator(Transform transform)
        {
            _transform = transform;
        }

        public void Rotate(float angularVelocity)
        {
            _angularVelocity = angularVelocity;
        }

        public void DoOnDestroy()
        {
            _angularVelocity = 0;
        }

        public void Update()
        {
            _transform.Rotate(0, 0, _angularVelocity * Time.deltaTime);
        }
    }
}