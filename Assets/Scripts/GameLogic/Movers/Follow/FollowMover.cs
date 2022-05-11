﻿using Asteroids.Common;
using Asteroids.PositionValidators;
using UnityEngine;

namespace Asteroids.Movers
{
    public class FollowMover : IFollowMover
    {
        private readonly IBorderValidator _borderValidator;
        private readonly Transform _transform;
        private IFollowable _followable;

        private float _velocity;
        private Vector2 _lastMoveDirection;

        public FollowMover(Transform transform, IBorderValidator borderValidator)
        {
            _transform = transform;
            _borderValidator = borderValidator;
        }

        public void Update()
        {
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
                Vector2.MoveTowards(_transform.position, _followable.GetPos(), _velocity * Time.deltaTime);
            var validPos = _borderValidator.Validate(nextPos);
            _transform.position = validPos;
            _lastMoveDirection = _followable.GetPos() - validPos;
        }

        private void MoveLastDirection()
        {
            var pos = Vector2.MoveTowards(_transform.position, (Vector2)_transform.position + _lastMoveDirection, _velocity * Time.deltaTime);
            _transform.position = _borderValidator.Validate(pos);
        }

        public void StartFollow(IFollowable followable, float velocity)
        {
            _followable = followable;
            _velocity = velocity;
        }
    }
}