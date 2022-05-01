using UnityEngine;

namespace Asteroids.Player
{
    public class MovementController : MonoBehaviour, IMovementController
    {
        [SerializeField] private float _moveSpeed = 5;
        [SerializeField] private float _rotationSpeed = 5;
        private Rigidbody2D _body;
        private IInput _input;

        public void Init(IInput input, Rigidbody2D body)
        {
            _input = input;
            _body = body;
        }
        public void CustomFixedUpdate()
        {
            if (_input.Up)
            {
                _body.AddRelativeForce(Vector2.up * _moveSpeed);
            }

            if (_input.Right || _input.Left)
            {
                var torqueSign = -Mathf.Sign(_input.Horizontal);
                _body.AddTorque(torqueSign * _rotationSpeed);
            }
        }
    }
}