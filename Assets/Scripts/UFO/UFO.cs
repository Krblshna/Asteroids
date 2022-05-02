using Asteroids.Effect;
using Asteroids.Utility;
using Asteroids.Weapon;
using UnityEngine;

namespace Asteroids.UFO
{
    public class UFO : MonoBehaviour, IDestructible
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float speed = 5f;
        private GroupType _groupType = GroupType.Enemy;
        private IWeapon _weapon;

        void Awake()
        {
            _weapon = GetComponentInChildren<IWeapon>();
            _weapon.Init(_groupType);
        }

        void Update()
        {
            float step = speed * Time.deltaTime;

            // move sprite towards the target location
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, step);
            _weapon.Fire();
        }

        public bool Hit(GroupType hitGroup)
        {
            if (_groupType == hitGroup) return false;
            EffectsManager.Instance.CreateEffect(EffectType.DeathMiddle, transform.position);
            Destroy(gameObject);
            return true;
        }
    }
}