using System;
using Asteroids.GameLogic.Common;
using Asteroids.GameLogic.Enemies;
using Asteroids.View.HitDetectors;
using UnityEngine;

namespace Asteroids.View.Enemies
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        private bool _destroyed;
        private Action<IEnemyView> _destroyCallback;
        private IHitDetector _hitDetector;
        private IEnemy _enemyModel;
        private ICouldSplit _splitable;

        public virtual void Awake()
        {
            _enemyModel = GetComponent<IEnemyProvider>().GetModel();
            if (_enemyModel is ICouldSplit split)
            {
                _splitable = split;
            }
            _hitDetector = GetComponentInChildren<IHitDetector>();
            _hitDetector.Init(_enemyModel.GroupType, Hit);
        }

        public void Update()
        {
            _enemyModel.Update();
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

        public void Hit(DamageType damageType)
        {
            if (_destroyed) return;
            Death(damageType);
        }

        private void Death(DamageType damageType)
        {
            _destroyed = true;
            _enemyModel.OnDestroy();
            if (damageType != DamageType.Destroy)
            {
                _splitable?.OnSplit();
            }
            _destroyCallback?.Invoke(this);
        }
    }
}