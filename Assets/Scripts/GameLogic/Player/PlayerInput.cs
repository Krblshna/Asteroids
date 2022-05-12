using System;
using Asteroids.GameLogic.Common;
using Asteroids.Input;

namespace Asteroids.GameLogic.Player
{
    public class PlayerInput : IInput
    {
        private readonly PlayerControls _playerControls;

        public bool Left { get; private set; }
        public bool Right { get; private set; }
        public bool Up { get; private set; }
        private bool _fire;
        private bool _altFire;
        private float _tolerance = 0.01f;

        public PlayerInput()
        {
            _playerControls = new PlayerControls();
            _playerControls.Enable();
        }

        public bool IsFire(FireType fireType)
        {
            switch (fireType)
            {
                case FireType.MainFire:
                {
                    return _fire;
                }
                case FireType.AltFire:
                {
                    return _altFire;
                }
            }
            return false;
        }

        public void CustomUpdate()
        {
            Up = Math.Abs(_playerControls.Main.Move.ReadValue<float>() - 1) < _tolerance;
            Left = Math.Abs(_playerControls.Main.RotateLeft.ReadValue<float>() - 1) < _tolerance;
            Right = Math.Abs(_playerControls.Main.RotateRight.ReadValue<float>() - 1) < _tolerance;
            _fire = Math.Abs(_playerControls.Main.Fire.ReadValue<float>() - 1) < _tolerance;
            _altFire = Math.Abs(_playerControls.Main.AltFire.ReadValue<float>() - 1) < _tolerance;
        }

        public void OnDestroy()
        {
            _playerControls.Disable();
        }
    }
}