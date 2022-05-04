using UnityEngine;

namespace Asteroids.Player
{
    public class MovementController : MonoBehaviour, IMovementController
    {
        [SerializeField] private float _moveSpeed = 5;
        [SerializeField] private float _rotationSpeed = 0.01f;
        [SerializeField] private float _maxSpeed = 1f;
        [SerializeField] private float _maxAngularVelocity = 1f;
        private IInput _input;
        private Transform _transform;
        private Vector2 _velocityVector;
        private float _angularVelocity;

        public void Init(IInput input, Transform transform_)
        {
            _input = input;
            _transform = transform_;
        }

        private void UpdateMovement()
        {
            _transform.Translate(_velocityVector * Time.deltaTime, Space.World);

        }

        private void UpdateRotation()
        {
            _transform.Rotate(0, 0, _angularVelocity * Time.deltaTime);
        }

        public void CustomUpdate()
        {
            UpdateControls();
            UpdateMovement();
            UpdateRotation();
        }

        public void UpdateControls()
        {
            if (_input.Up)
            {
                var accelerationVector = transform.rotation * Vector2.up * _moveSpeed * Time.deltaTime;
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