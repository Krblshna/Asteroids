using Asteroids.GameLogic.PositionValidators;
using UnityEngine;

namespace Asteroids.GameLogic.Movers
{
    public class VelocityMover : IVelocityMover
    {
        private readonly Transform _transform;
        private readonly IBorderValidator _borderValidator;

        public VelocityMover(Transform transform, IBorderValidator borderValidator)
        {
            _transform = transform;
            _borderValidator = borderValidator;
        }

        public void Update(Vector2 velocityVector)
        {
            _transform.Translate(velocityVector * Time.deltaTime, Space.World);
            _transform.position = _borderValidator.Validate(_transform.position);
        }
    }
}