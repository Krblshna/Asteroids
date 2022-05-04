using Asteroids.Common;
using Asteroids.HitDetectors;
using UnityEngine;

namespace Asteroids.Weapon
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] private GroupType _groupType;
        private void OnTriggerEnter2D(Collider2D coll)
        {
            var hitDetector = coll.GetComponent<IHitDetector>();
            hitDetector?.Hit(_groupType);
        }

        public void Init(GroupType groupType)
        {
            _groupType = groupType;
        }
    }
}