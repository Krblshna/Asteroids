using UnityEngine;

namespace Asteroids.Weapon.FireDirection
{
    public class TargetFireDirection : MonoBehaviour, IFireDirection
    {
        [SerializeField] private Transform _targetTransform;

        public void Start()
        {
            var player = GameObject.FindObjectOfType<Player.Player>();
            if (player != null)
            {
                _targetTransform = player.transform;
            }
        }
        public Vector2 GetDirection()
        {
            if (_targetTransform == null) return Vector2.zero;
            var deltaPos = _targetTransform.position - transform.position;
            return deltaPos.normalized;
        }
    }
}