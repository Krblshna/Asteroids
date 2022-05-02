using UnityEngine;

namespace Asteroids.Weapon.FireDirection
{
    public class TargetFireDirection : MonoBehaviour, IFireDirection
    {
        [SerializeField] private Transform _targetTransform;
        public Vector2 GetDirection()
        {
            var deltaPos = _targetTransform.position - transform.position;
            return deltaPos.normalized;
        }
    }
}