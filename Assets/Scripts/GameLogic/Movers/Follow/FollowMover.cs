using Asteroids.GameLogic.PositionValidators;
using Asteroids.GameLogic.Providers;
using UnityEngine;

namespace Asteroids.GameLogic.Movers
{
    public class FollowMover : IFollowMover
    {
        private readonly IBorderValidator _borderValidator;
        private readonly Transform _transform;
        private IPosProvider _followable;

        private float _velocity;
        private Vector2 _lastMoveDirection;
        private bool _active;

        public FollowMover(Transform transform, IPosProvider followable, float velocity, IBorderValidator borderValidator)
        {
            _transform = transform;
            _followable = followable;
            _velocity = velocity;
            _borderValidator = borderValidator;
        }

        public void Update()
        {
            if (!_active) return;
            if (_followable != null && _followable.Active)
            {
                FollowMove();
            }
            else
            {
                MoveLastDirection();
            }
        }

        private void FollowMove()
        {
            var nextPos =
                Vector2.MoveTowards(_transform.position, _followable.GetPos, _velocity * Time.deltaTime);
            var validPos = _borderValidator.Validate(nextPos);
            _transform.position = validPos;
            _lastMoveDirection = _followable.GetPos - validPos;
        }

        private void MoveLastDirection()
        {
            var pos = Vector2.MoveTowards(_transform.position, (Vector2)_transform.position + _lastMoveDirection, _velocity * Time.deltaTime);
            _transform.position = _borderValidator.Validate(pos);
        }

        public void Move()
        {
            _active = true;
        }
    }
}