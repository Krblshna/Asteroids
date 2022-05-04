using System;
using Asteroids.Input;
using UnityEngine;

namespace Asteroids.Player
{
    public class PlayerInput : MonoBehaviour, IInput
    {
        
        public bool Left { get; private set; }
        public bool Right { get; private set; }
        public bool Up { get; private set; }
        public bool Fire { get; private set; }
        public bool AltFire { get; private set; }
        private float _minSensitivity = 0.3f;
        private PlayerControls _playerControls;
        private float _tolerance = 0.01f;

        private void Awake()
        {
            _playerControls = new PlayerControls();
        }

        private void OnEnable()
        {
            _playerControls.Enable();
        }

        private void OnDisable()
        {
            _playerControls.Disable();
        }

        public void CustomUpdate()
        {
            Up = Math.Abs(_playerControls.Main.Move.ReadValue<float>() - 1) < _tolerance;
            Left = Math.Abs(_playerControls.Main.RotateLeft.ReadValue<float>() - 1) < _tolerance;
            Right = Math.Abs(_playerControls.Main.RotateRight.ReadValue<float>() - 1) < _tolerance;
            Fire = Math.Abs(_playerControls.Main.Fire.ReadValue<float>() - 1) < _tolerance;
            AltFire = Math.Abs(_playerControls.Main.AltFire.ReadValue<float>() - 1) < _tolerance;
        }
    }
}