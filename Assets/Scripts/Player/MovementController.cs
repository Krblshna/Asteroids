using UnityEngine;

namespace Asteroids.Player
{
    public class MovementController : IMovementController, IMoverData
    {
        private readonly IVelocityMover _mover;
        private readonly IVelocityRotator _rotator;
        private readonly IInput _input;
        private readonly Transform _transform;

        private float _moveSpeed = 3;
        private float _rotationSpeed = 120f;
        private float _maxSpeed = 5f;
        private float _maxAngularVelocity = 120f;
        
        private Vector2 _velocityVector;
        private float _angularVelocity;
        public Vector3 Position => _transform.position;
        public Vector3 Velocity => _velocityVector;
        public int Rotation => (int)_transform.eulerAngles.z;

        public MovementController(IInput input, IVelocityMover mover, IVelocityRotator rotator, Transform transform)
        {
            _input = input;
            _transform = transform;
            _mover = mover;
            _rotator = rotator;
        }

        public void CustomUpdate()
        {
            UpdateControls();
            _mover.Update(_velocityVector);
            _rotator.Update(_angularVelocity);
        }

        public void UpdateControls()
        {
            if (_input.Up)
            {
                var accelerationVector = _transform.rotation * Vector2.up * _moveSpeed * Time.deltaTime;
                _velocityVector += (Vector2)accelerationVector;
                _velocityVector = Vector2.ClampMagnitude(_velocityVector, _maxSpeed);
            }

            if (_input.Right || _input.Left)
            {
                var sign = _input.Right ? -1 : 1;
                var angularAcceleration = sign * _rotationSpeed * Time.deltaTime;
                _angularVelocity += angularAcceleration;
                _angularVelocity = Mathf.Clamp(_angularVelocity, -_maxAngularVelocity, _maxAngularVelocity);
            }
        }
    }
}