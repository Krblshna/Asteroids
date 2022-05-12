using Asteroids.GameLogic.PositionValidators;
using UnityEngine;

namespace Asteroids.GameLogic.Movers
{
    public class SimpleMover : IMover
    {
        private readonly Transform _transform;
        private readonly IBorderValidator _borderValidator;
        private Vector2 _moveDirection;
        private float _velocity;

        public SimpleMover(Transform transform, IBorderValidator borderValidator)
        {
            _transform = transform;
            _borderValidator = borderValidator;
        }

        public void Move(Vector2 direction, float velocity)
        {
            _moveDirection = direction;
            _velocity = velocity;
        }

        public void DoOnDestroy()
        {
            _moveDirection = Vector2.zero;
            _velocity = 0;
        }

        public void Update()
        {
            _transform.Translate(_moveDirection * Time.deltaTime * _velocity, Space.World);
            _transform.position = _borderValidator.Validate(_transform.position);
        }
    }
}