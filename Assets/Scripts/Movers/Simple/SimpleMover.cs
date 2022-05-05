using UnityEngine;

namespace Asteroids.Movers
{
    public class SimpleMover : MonoBehaviour, IMover
    {
        private Vector2 _moveDirection;
        private float _velocity;
        private float _angularVelocity;
        private bool _move, _rotate;
        public void Move(Vector2 direction, float velocity)
        {
            _moveDirection = direction;
            _velocity = velocity;
            _move = true;
        }

        public void Rotate(float angularVelocity)
        {
            _rotate = true;
            _angularVelocity = angularVelocity;
        }

        public void DoOnDestroy()
        {
            _moveDirection = Vector2.zero;
            _velocity = 0;
            _angularVelocity = 0;
            _move = false;
            _rotate = false;
        }

        private void UpdateMovement()
        {
            if (!_move) return;
            transform.Translate(_moveDirection * Time.deltaTime * _velocity, Space.World);

        }

        private void UpdateRotation()
        {
            if (!_rotate) return;
            transform.Rotate(0, 0, _angularVelocity * Time.deltaTime);
        }

        void Update()
        {
            UpdateMovement();
            UpdateRotation();
        }
    }
}