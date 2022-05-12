using UnityEngine;

namespace Asteroids.GameLogic.Movers
{
    public class VelocityRotator : IVelocityRotator
    {
        private readonly Transform _transform;

        public VelocityRotator(Transform transform)
        {
            _transform = transform;
        }
        public void Update(float angularVelocity)
        {
            _transform.Rotate(0, 0, angularVelocity * Time.deltaTime);
        }
    }
}