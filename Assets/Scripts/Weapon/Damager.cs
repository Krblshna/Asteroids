using Asteroids.Common;
using Asteroids.HitDetectors;
using Unity.Plastic.Antlr3.Runtime.Misc;
using UnityEngine;

namespace Asteroids.Weapon
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] private GroupType _groupType;
        private Action _onHit;

        private void OnTriggerEnter2D(Collider2D coll)
        {
            var hitDetector = coll.GetComponent<IHitDetector>();
            if (hitDetector == null) return;
            if (hitDetector.Hit(_groupType))
            {
                _onHit?.Invoke();
            }
        }

        public void Init(GroupType groupType, Action onHit = null)
        {
            _groupType = groupType;
            _onHit = onHit;
        }
    }
}