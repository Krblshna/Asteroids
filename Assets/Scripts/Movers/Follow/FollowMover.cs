using UnityEngine;

namespace Asteroids.Movers
{
    public class FollowMover : MonoBehaviour, IFollowMover
    {
        private Transform _followTransform;
        private float _velocity;
        private Vector2 _lastMoveDirection;

        private bool CouldFollow => _followTransform.gameObject.activeSelf;

        void Update()
        {
            if (_followTransform == null) return;
            if (CouldFollow)
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
            transform.position =
                Vector2.MoveTowards(transform.position, _followTransform.position, _velocity * Time.deltaTime);
            _lastMoveDirection = _followTransform.position - transform.position;
        }

        private void MoveLastDirection()
        {
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + _lastMoveDirection, _velocity * Time.deltaTime);
        }

        public void StartFollow(Transform followTransform, float velocity)
        {
            _followTransform = followTransform;
            _velocity = velocity;
        }
    }
}