using UnityEngine;

namespace Asteroids.View.Weapon
{
    public class StraightFireDirection : MonoBehaviour, IFireDirection
    {
        public Vector2 GetDirection()
        {
            return transform.rotation * Vector2.up;
        }
    }
}