using System;
using Asteroids.Actions;
using Asteroids.Common;
using Asteroids.HitDetectors;
using Asteroids.Movers;
using UnityEngine;

namespace Asteroids.Enemies
{
    public class Ufo2 : MonoBehaviour, IEnemy
    {
        private bool _destroyed;
        private GroupType _groupType = GroupType.Enemy;
        private Action<IEnemy> _destroyCallback;
        private IMoveController _moveController;
        private IAction[] _onDestroyActions;
        private IHitDetector _hitDetector;

        private void Awake()
        {
            _moveController = GetComponentInChildren<IMoveController>();
            _onDestroyActions = GetComponentsInChildren<IAction>();
            _hitDetector = GetComponentInChildren<IHitDetector>();
            _hitDetector.Init(_groupType, Hit);
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void SetPos(Vector2 pos)
        {
            transform.position = pos;
        }

        public void Init(Action<IEnemy> destroyCallback)
        {
            _destroyCallback = destroyCallback;
        }

        public void OnCreate()
        {
            _destroyed = false;
            _moveController.Move();
        }

        public void Hit()
        {
            if (_destroyed) return;
            Death();
        }

        private void Death()
        {
            _destroyed = true;
            _moveController.DoOnDestroy();
            _destroyCallback?.Invoke(this);
            foreach (var destroyEvent in _onDestroyActions)
            {
                destroyEvent.Call();
            }
        }
    }
}