using System;
using Asteroids.Utils;
using Asteroids.Weapon;
using UnityEngine;

namespace Asteroids.Player
{
    public class Player : MonoBehaviour
    {
        private IMovementController _movementController;
        private IInput _input;
        private IWeapon _weapon;
        private float ship_size = 0.46f;

        void Awake()
        {
            var body = GetComponent<Rigidbody2D>();
            _input = GetComponent<IInput>();
            _movementController = GetComponent<IMovementController>();
            _movementController.Init(_input, body);
            _weapon = GetComponentInChildren<IWeapon>();
        }
        void Update()
        {
            _input.CustomUpdate();
            transform.position = ScreenPortal.ValidatePos(transform.position, ship_size);
        }

        void FixedUpdate()
        {
            _movementController.CustomFixedUpdate();

            if (_input.Fire)
            {
                _weapon.Fire();
            }
        }
    }
}