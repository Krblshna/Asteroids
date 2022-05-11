using UnityEngine;

namespace Asteroids.Player
{
    public class VelocityRotator : IVelocityRotator
    {
        private Transform _transform;

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