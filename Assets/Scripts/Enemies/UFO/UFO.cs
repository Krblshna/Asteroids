using System;
using Asteroids.Common;
using Asteroids.Effect;
using Asteroids.Statistics;
using Asteroids.Weapon;
using UnityEngine;

namespace Asteroids.Enemies
{
    public class UFO3214 : MonoBehaviour, IEnemyView, IDestructible
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float startFireDelay = 2f;
        private float spawnTime;
        private GroupType _groupType = GroupType.Enemy;
        private IWeapon _weapon;
        private Action<IEnemyView> _onDestroyAction;
        private Vector2 lastMoveDirection;
        private bool _destroyed;

        void Awake()
        {
            _weapon = GetComponentInChildren<IWeapon>();
            _weapon.Init(_groupType);
        }

        void Update()
        {
            if (playerTransform == null) return;
            if (playerTransform.gameObject.activeSelf)
            {
                transform.position =
                    Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
                lastMoveDirection = playerTransform.position - transform.position;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + lastMoveDirection, speed * Time.deltaTime);
            }

            //if (Time.time - spawnTime > startFireDelay)
            //{
            //    _weapon.Fire();
            //}
        }

        public bool Hit(GroupType hitGroup)
        {
            if (_groupType == hitGroup || _destroyed) return false;
            _destroyed = true;
            //EffectsManager.Instance.Create(EffectType.DeathMiddle, transform.position);
            //GamePoints.TriggerStatEvent(StatType.DestroyUfo);
            _onDestroyAction?.Invoke(this);
            return true;
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void Init(Action<IEnemyView> destroyCallback)
        {
            _onDestroyAction = destroyCallback;
        }

        public GameObject GetObj => gameObject;
        public void OnCreate()
        {
            _destroyed = false;
            spawnTime = Time.time;
            var player = FindObjectOfType<Player.Player>();
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }

        public void SetPos(Vector2 pos)
        {
            transform.position = pos;
        }

        public void Hit()
        {
            throw new NotImplementedException();
        }
    }
}