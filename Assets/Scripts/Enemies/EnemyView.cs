using System;
using Asteroids.Actions;
using Asteroids.Enemies.EnemyProviders;
using Asteroids.GameLogic;
using Asteroids.HitDetectors;
using Asteroids.Movers;
using UnityEngine;

namespace Asteroids.Enemies
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        private bool _destroyed;
        private Action<IEnemyView> _destroyCallback;
        private IHitDetector _hitDetector;
        private IEnemy _enemyModel;

        public virtual void Awake()
        {
            _enemyModel = GetComponent<IEnemyProvider>().GetModel();
            _hitDetector = GetComponentInChildren<IHitDetector>();
            _hitDetector.Init(_enemyModel.GroupType, Hit);
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void SetPos(Vector2 pos)
        {
            transform.position = pos;
        }

        public void Init(Action<IEnemyView> destroyCallback)
        {
            _destroyCallback = destroyCallback;
        }

        public void OnCreate()
        {
            _destroyed = false;
            _enemyModel.OnCreate();
        }

        public void Hit()
        {
            if (_destroyed) return;
            Death();
        }

        private void Death()
        {
            _destroyed = true;
            _enemyModel.OnDestroy();
            _destroyCallback?.Invoke(this);
        }
    }
}