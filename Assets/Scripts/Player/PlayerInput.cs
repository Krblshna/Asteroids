using UnityEngine;

namespace Asteroids.Player
{
    public class PlayerInput : MonoBehaviour, IInput
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public bool Left { get; private set; }
        public bool Right { get; private set; }
        public bool Up { get; private set; }
        public bool Down { get; private set; }
        public bool Fire { get; private set; }
        public bool AltFire { get; private set; }
        private float _minSensitivity = 0.3f;
        public void CustomUpdate()
        {
            Clear();
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
            Fire = Input.GetButton("Fire1");
            AltFire = Input.GetButton("Fire2");
            if (Mathf.Abs(Horizontal) > _minSensitivity)
            {
                Left = Horizontal < 0;
                Right = Horizontal > 0;
            }
            if (Mathf.Abs(Vertical) > _minSensitivity)
            {
                Down = Vertical < 0;
                Up = Vertical > 0;
            }
        }

        private void Clear()
        {
            Left = false;
            Right = false;
            Up = false;
            Down = false;
            Fire = false;
            AltFire = false;
            Vertical = 0;
            Horizontal = 0;
        }
    }
}