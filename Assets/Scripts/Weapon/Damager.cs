using Asteroids.Utility;
using UnityEngine;

namespace Asteroids.Weapon
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] private GroupType _groupType;
        private void OnTriggerEnter2D(Collider2D coll)
        {
            var destructible = coll.GetComponent<IDestructible>();
            if (destructible != null)
            {
                var hit = destructible.Hit(_groupType);
            }
        }

        public void Init(GroupType groupType)
        {
            _groupType = groupType;
        }
    }
}