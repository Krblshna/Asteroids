using UnityEngine;

namespace Asteroids.Weapon.FireDirection
{
    public class TargetFireDirection : MonoBehaviour, IFireDirection
    {
        [SerializeField] private Transform _targetTransform;

        public void Start()
        {
            _targetTransform = GameObject.FindObjectOfType<Player.Player>().transform;
        }
        public Vector2 GetDirection()
        {
            var deltaPos = _targetTransform.position - transform.position;
            return deltaPos.normalized;
        }
    }
}