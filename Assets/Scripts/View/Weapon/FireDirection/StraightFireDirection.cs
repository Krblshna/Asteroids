using UnityEngine;

namespace Asteroids.Weapon.FireDirection
{
    public class StraightFireDirection : MonoBehaviour, IFireDirection
    {
        public Vector2 GetDirection()
        {
            return transform.rotation * Vector2.up;
        }
    }
}