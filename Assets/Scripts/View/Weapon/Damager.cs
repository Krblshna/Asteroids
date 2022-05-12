using Asteroids.GameLogic.Common;
using Asteroids.View.HitDetectors;
using Unity.Plastic.Antlr3.Runtime.Misc;
using UnityEngine;

namespace Asteroids.View.Weapon
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] private GroupType _groupType;
        [SerializeField] private DamageType _damageType = DamageType.Common;
        private Action _onHit;

        private void OnTriggerEnter2D(Collider2D coll)
        {
            var hitDetector = coll.GetComponent<IHitDetector>();
            if (hitDetector == null) return;
            if (hitDetector.Hit(_groupType, _damageType))
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